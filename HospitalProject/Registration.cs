using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalProject
{
    public partial class Registration : Form
    {
        string emailpattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        string password = @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";

        public Registration()
        {
            InitializeComponent();
        }

        private void Btnregister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxReguser.Text) == true)
            {
                textBoxReguser.Focus();
                errorProvider1.SetError(this.textBoxReguser, "Please fill username");
            }
            else if (Regex.IsMatch(textBoxregemail.Text, emailpattern) == false)
            {
                textBoxregemail.Focus();
                errorProvider2.SetError(this.textBoxregemail, "Please enter valid email");

            }
            else if (Regex.IsMatch(textBoxregpass.Text, password) == false)
            {
                textBoxregpass.Focus();
                errorProvider3.SetError(this.textBoxregpass, "Enter strong password!");
            }
            else if (textBoxregcp.Text != textBoxregpass.Text)
            {
                textBoxregcp.Focus();
                errorProvider4.SetError(this.textBoxregcp, "Password Mismatched");
            }
         
            else {
                try
                {

                    String name = textBoxReguser.Text;
                    String email = textBoxregemail.Text;
                    String password = textBoxregpass.Text;
                    String cnfpass = textBoxregcp.Text;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=INBAWN170255\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = @"INSERT INTO [dbo].[Register]
                   
           ([User name]
           ,[Emailid]
           ,[Password]
           ,[Confirmpass])
     VALUES
          ('" + name + "', '" + email + "', '" + password + "', '" + cnfpass + "')";
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sd.Fill(ds);
                    MessageBox.Show("Registered");

                    Login l = new Login();
                    l.Show();
                    this.Hide();

                }


                catch (Exception)
                {
                    MessageBox.Show("Inavalid Format");
                }
               
            }

        }

        private void btnalreday_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.ShowDialog();
            this.Hide();
        }

        private void textBoxReguser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxReguser.Text) == true)
            {
                textBoxReguser.Focus();
                errorProvider1.SetError(this.textBoxReguser, "Please fill username");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBoxReguser_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;

            }
            else if (ch == 8)
            {
                e.Handled = false;
            }
            else if (ch == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;

            }
        }

        private void textBoxregemail_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxregemail.Text, emailpattern) == false)
            {
                textBoxregemail.Focus();
                errorProvider2.SetError(this.textBoxregemail, "Please enter valid email");

            }
            else
            {
                errorProvider2.Clear();
            }

        }

        private void textBoxregpass_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxregpass.Text, password) == false)
            {
                textBoxregpass.Focus();
                errorProvider3.SetError(this.textBoxregpass, "Enter strong password!");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBoxregcp_Leave(object sender, EventArgs e)
        {
            if (textBoxregcp.Text != textBoxregpass.Text)
            {
                textBoxregcp.Focus();
                errorProvider4.SetError(this.textBoxregcp, "Password Mismatched");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Welcome w = new Welcome();
            w.Show();
            this.Hide();

        }

        private void Registration_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

        }

        private void textBoxReguser_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxregemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxregpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxregcp_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
