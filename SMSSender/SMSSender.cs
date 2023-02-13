using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using System.IO.Ports;



using GsmComm.GsmCommunication;
namespace SMSSender
{
    public partial class SMS : Form
    {
        public SMS()
        {
            InitializeComponent();
        }
       // string connstring = "Data Source=(Local);Database=SuperSoftv1;User ID=sa;Password=;Network Library=dbnmpntw";
       string connstring = "Data Source=.\\SQLEXPRESS;Initial Catalog=POSSOFT;Integrated Security =true";
        SerialPort Port;
        SqlConnection con;
        //GsmCommMain comm; 
        private void SMS_Load(object sender, EventArgs e)
        {
            Port = new SerialPort("COM4", 9600);

           Port.Open();
           DeleteOldSMS();
           Time.Start();
        }
        private void DeleteOldSMS()
        {
            con = new SqlConnection(connstring);
            con.Open();
            string sSQaL = "Delete From Smsengine where issend=1";
            SqlCommand Cmdaaa = new SqlCommand(sSQaL, con);
            Cmdaaa.ExecuteNonQuery();
            con.Close();
        }
        private void SENDSMSIRFAN()
        {
            

            con = new SqlConnection(connstring);
            con.Open();
            string sSQL = "SELECT TOP 1 SMSNumber,Message FROM smsengine WHERE issend=0";
            SqlCommand Cmd = new SqlCommand(sSQL, con);
            SqlDataReader reader;
            reader = Cmd.ExecuteReader();
            while (reader.Read())
            {


                string num = reader["SMSNumber"].ToString();
                string meassage = reader["Message"].ToString();


                //OutgoingSmsPdu[] pdus = CreateConcatMessage(num, meassage,chkSmartUnicode.Checked, false);
                //if (pdus != null)
                //    SendMultiple(pdus);
                SendSMS(num, meassage);
                txtOutput.Text += "\r\n";
                txtOutput.Text += num + "  Sms Send...";
                txtOutput.Text += "\r\n";
                ///

                con = new SqlConnection(connstring);
                con.Open();
                string sSQaL = "update smsengine set issend=1 where SMSNumber=@d1";
                SqlCommand Cmdaa = new SqlCommand(sSQaL, con);
                Cmdaa.Parameters.Add("@d1", SqlDbType.VarChar).Value = num;

                Cmdaa.ExecuteNonQuery();
                con.Close();
              
               
            }

        }
        //Old Mehthod to send SMS
        private void SendSMS(string txtNumber, string txtMessage)
        {
            

            if (Port.IsOpen == true)
            {
              
                // Send an 'AT' command to the phone
                Port.WriteLine("AT" + "\r");
                Thread.Sleep(100);
                Port.WriteLine("AT+CMGF=1" + "\r"); //This line can be removed if your modem will always be in Text Mode...
                Thread.Sleep(100);
                Port.Write("AT+CMGS=" + (char)34 + txtNumber + (char)34 + "\r"); //Replace this with your mobile Phone's No.
                Thread.Sleep(100);
                Port.Write(txtMessage + (char)26);
                Thread.Sleep(100);
                var Responce = Port.ReadExisting();
                if (Responce.EndsWith("\r\nOK\r\n"))
                {
                    txtOutput.Text += "\r\n";
                    txtOutput.Text +=  "  Sms Send Ok...";
                    txtOutput.Text += "\r\n";
                }
                else if (Responce.Contains("ERROR"))
                {
                    txtOutput.Text += "\r\n";
                    txtOutput.Text += " Sms Send failed...";
                    txtOutput.Text += "\r\n";
                }
               
            }
            

        }

        private void Time_Tick(object sender, EventArgs e)
        {
           
           SENDSMSIRFAN();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Port.Close();
            this.Close();
            MainForm maa = new MainForm();
            maa.Show();
        }

        private void btnSendConcatSMS_Click(object sender, EventArgs e)
        {

        }

      

       

       

       
    }
}
