using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using GsmComm.PduConverter;
using GsmComm.PduConverter.SmartMessaging;
using GsmComm.GsmCommunication;

namespace SMSSender
{
    public partial class Manual_SMS : Form
    {
        public Manual_SMS()
        {
            InitializeComponent();
        }
  //  DataSet dataSet, dataSet1 = new DataSet();
        string SMSNumber;
     //string cons = "Data Source=(Local) ; Database=SuperSoftv1;User ID=sa;Password=;Network Library=dbnmpntw";
      string cons = "Data Source=.\\SQLEXPRESS;Initial Catalog=POSSOFT;Integrated Security =true";
      
        SqlConnection con;
        GsmCommMain comm; 
       

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.Rows.Clear();
              //  dataGridView1.Columns.Clear();
                
              //  dataGridView1.Columns.Add("A", "Numbers");
               // dataGridView1.Columns.Add("B", "Name");
                con = new SqlConnection(cons);
                String sql = "select mobile as Numbers,partyname as Name from parties where partytype='c' and mobile>''";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Numbers"], reader["Name"]);
                }
                con.Close();
                reader.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       



        private void SelectExcel_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog { };

            dialog.Filter = "SMS Sending File(*.xlsx;*.xls)|*.xlsx;*.xls";

            dialog.Title = "Select Excel File For SMS";

            DialogResult dlgresult = dialog.ShowDialog();

            if (dlgresult == DialogResult.Cancel)
            {
                MessageBox.Show("You Press Cancelled :-) !!!");
            }
            else
            {
                string sms_filename = dialog.FileName;

                if (System.IO.File.Exists(sms_filename))
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        OleDbConnection conn;
                        
                        string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", sms_filename);
                        conn = new OleDbConnection(connectionString);
                        string query = String.Format("select * from [{0}$]", "SMS");
                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        dataGridView1.Rows.Clear();
                        dataGridView1.Refresh();
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["Numbers"], reader["Name"]);
                        }
                        conn.Close();
                        reader.Close();

                        //OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);

                        //dataSet = new DataSet();

                        //dataAdapter.Fill(dataSet);

                        //dataGridView1.DataSource = dataSet.Tables[0];

                        //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void Manual_SMS_Load(object sender, EventArgs e)
        {
            comm = new GsmCommMain("COM5", 9600, 300);/// control port use hoti ha
           comm.Open();
            dataGridView1.Columns.Add("Numbers", "Numbers");
            dataGridView1.Columns.Add("Name", "Name");

        }

        private OutgoingSmsPdu[] CreateConcatMessage(string message, string number, bool unicode, bool showParts)
        {
            OutgoingSmsPdu[] pdus = null;
            try
            {
                if (!unicode)
                {
                    txtOutput.Text += "\r\n";
                    txtOutput.Text += "Creating concatenated message.";
                    txtOutput.Text += "\r\n";
                    pdus = SmartMessageFactory.CreateConcatTextMessage(message, number);
                }
                else
                {
                    txtOutput.Text += "\r\n";
                    txtOutput.Text += "Creating concatenated Unicode message.";
                    txtOutput.Text += "\r\n";
                    pdus = SmartMessageFactory.CreateConcatTextMessage(message, true, number);
                }
            }
            catch (Exception ex)
            {
                txtOutput.Text += "\r\n";
                txtOutput.Text += ex.ToString();
                txtOutput.Text += "\r\n";
                return null;
            }

            if (pdus.Length == 0)
            {
                txtOutput.Text += "\r\n";
                txtOutput.Text += "Error: No PDU parts have been created!";
                txtOutput.Text += "\r\n";
                return null;
            }
            else
            {
                if (showParts)
                {
                    for (int i = 0; i < pdus.Length; i++)
                    {
                        txtOutput.Text += "\r\n";
                        txtOutput.Text += "Part #" + (i + 1).ToString() + ": " + Environment.NewLine + pdus[i].ToString();
                        txtOutput.Text += "\r\n";
                    }
                }
                txtOutput.Text += "\r\n";
                txtOutput.Text += pdus.Length.ToString() + " message part(s) created.";
                txtOutput.Text += "\r\n";
            }

            return pdus;
        }
        private void SendMultiple(OutgoingSmsPdu[] pdus)
        {
            int num = pdus.Length;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                // Send the created messages
                int i = 0;
                foreach (OutgoingSmsPdu pdu in pdus)
                {
                    i++;
                    txtOutput.Text += "\r\n";
                    txtOutput.Text += "Sending message " + i.ToString() + " of " + num.ToString() + "...";
                    txtOutput.Text += "\r\n";
                    comm.SendMessage(pdu);
                }
                txtOutput.Text += "Done.";
                txtOutput.Text += "\r\n";
            }
            catch (Exception ex)
            {
                txtOutput.Text += "\r\n";
                txtOutput.Text += ex.ToString();
                txtOutput.Text += "\r\n";
                txtOutput.Text += "Message sending aborted because of an error.";
                txtOutput.Text += "\r\n";
            }

            Cursor.Current = Cursors.Default;
        }

     
        private void button3_Click(object sender, EventArgs e)
        {
            comm.Close();
            Application.Exit();
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
               
                con = new SqlConnection(cons);
                String sql = "Select SMSNumber As Numbers ,Message from SMSEngine where ISSend=0";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Numbers"], reader["Message"]);
                  //  dataGridView1.Rows.Add(reader["Numbers"]);
                }
                con.Close();
                reader.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           comm.Close();
            this.Close();
            MainForm ma = new MainForm();
            ma.Show();
        }

      
        private void SENDSMSIRFAN()
        {


            con = new SqlConnection(cons);
            con.Open();
            string sSQL = "SELECT TOP 1 SMSNumber,Message FROM smsengine WHERE issend=0";
            SqlCommand Cmd = new SqlCommand(sSQL, con);
            SqlDataReader reader;
            reader = Cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                  


                    string num = reader["SMSNumber"].ToString();
                    string meassage = reader["Message"].ToString();


                    OutgoingSmsPdu[] pdus = CreateConcatMessage(meassage,num, chkSmartUnicode.Checked, false);
                    if (pdus != null)
                        SendMultiple(pdus);
                    //  SendSMS(num, meassage);
                    txtOutput.Text += "\r\n";
                    txtOutput.Text += num + "  Sms Send...";
                    txtOutput.Text += "\r\n";
                    ///

                    con = new SqlConnection(cons);
                    con.Open();
                    string sSQaL = "update smsengine set issend=1 where SMSNumber=@d1";
                    SqlCommand Cmdaa = new SqlCommand(sSQaL, con);
                    Cmdaa.Parameters.Add("@d1", SqlDbType.VarChar).Value = num;

                    Cmdaa.ExecuteNonQuery();
                    con.Close();
                   

                }
        }
            else
    {
         Times.Stop();
         MessageBox.Show("Message Sending Complate","Message");
    }

                   
            
            

        }
        private void label12_Click(object sender, EventArgs e)
        {
            label2.Text= dataGridView1.RowCount.ToString();

            ////using (StreamWriter objWriter = new StreamWriter("SMSdata.txt"))
            ////{
            ////    objWriter.Write(txtOutput.Text);


            ////    MessageBox.Show("Details have been saved");
            ////}
        }

        private void Times_Tick(object sender, EventArgs e)
        {
            SENDSMSIRFAN();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DialogResult res = MessageBox.Show("Are you sure you want to Send", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //if (res == DialogResult.OK)
            //{
            //    if (String.IsNullOrEmpty(txtConcatMessage.Text) || dataGridView1.Rows.Count==0)
            //    {
            //        MessageBox.Show("Enter Material Please.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //    int i;
            //    for (i = 0; i < dataGridView1.RowCount - 1; i++)
            //    {
            //        SMSNumber = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //        con = new SqlConnection(cons);
            //        String sql = "INSERT INTO SMSEngine (SMSNumber,Message,Issend)VALUES('" + SMSNumber + "','" + txtConcatMessage.Text + "','0')";
            //        SqlCommand cmd = new SqlCommand(sql, con);
            //        cmd.CommandType = CommandType.Text;
            //        con.Open();
            //        cmd.ExecuteNonQuery();

            //        con.Close();


            //    }

               // MessageBox.Show("Total SMS" + i.ToString(), "SMS");
                Times.Start();
            //}
            //if (res == DialogResult.Cancel)
            //{
            //    MessageBox.Show("You have clicked Cancel Button");
                 
            //}   
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            OutgoingSmsPdu[] pdus = CreateConcatMessage(txtConcatMessage.Text, txtConcatNumber.Text,
             chkSmartUnicode.Checked, false);
            if (pdus != null)
                SendMultiple(pdus);
            txtOutput.Text += "\r\n";
            txtOutput.Text += txtConcatNumber.Text + "  Sms Send";
            txtOutput.Text += "\r\n";
            MessageBox.Show("SMS Send", "SMS");
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            comm = new GsmCommMain(BtnConnect.Text, 9600, 300);
            comm.Open();
        }
    }
}
