﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace Blood_Bank
{
    public partial class Director_Login_Form : Form
    {
        public Director_Login_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string queary = "select firstName from employee where UserID ='" + txtUserID.Text + "' and userPassword = '" + txtPassword.Text + "' and empMode = 'Director'";
            string testName;

            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(queary, con);

                con.Open();

                testName = Convert.ToString(cmd.ExecuteScalar());

                con.Close();

                if (testName.Length > 0)
                {

                    Clipboard.SetText(txtUserID.Text);

                    Thread edit = new Thread(openEditModeDirector);
                    edit.SetApartmentState(ApartmentState.STA);
                    edit.Start();
                    this.Close();
                }
                else if (testName.Length == 0)
                {
                    MessageBox.Show("Invalid Entered data\nCheck User ID or Password", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserID.Clear();
                    txtPassword.Clear();
                    txtUserID.Focus();
                }
                else
                {
                    MessageBox.Show("Try Again Later", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception loginViewClerck)
            {
                MessageBox.Show(loginViewClerck.Message);
            }
        }

        private void openEditModeDirector()
        {
            Application.Run(new DirectorEditForm());
        }

        private void Director_Login_Form_Load(object sender, EventArgs e)
        {
            txtPassword.Enabled = false;
            btnClear.Enabled = false;
            button1.Enabled = false;
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            if(txtUserID.TextLength > 0)
            {
                txtPassword.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                txtPassword.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtUserID.Clear();
            txtUserID.Focus();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.TextLength > 0)
            {
                btnClear.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                btnClear.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string queary = "select firstName from employee where UserID ='" + txtUserID.Text + "' and userPassword = '" + txtPassword.Text + "' and empMode = 'Director'";
            string testName;

            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-ILF4RKJ\\MSSQLSERVER01;Initial Catalog=bloodBank;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(queary, con);

                con.Open();

                testName = Convert.ToString(cmd.ExecuteScalar());

                con.Close();

                if (testName.Length > 0)
                {

                    Clipboard.SetText(txtUserID.Text);

                    Thread edit = new Thread(openEditModeDirector);
                    edit.SetApartmentState(ApartmentState.STA);
                    edit.Start();
                    this.Close();
                }
                else if (testName.Length == 0)
                {
                    MessageBox.Show("Invalid Entered data\nCheck User ID or Password", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserID.Text = "UserName";
                    txtPassword.Text = "Password";
                    txtUserID.Focus();
                    btnClear.Enabled = false;
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Try Again Later", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception loginViewClerck)
            {
                MessageBox.Show(loginViewClerck.Message);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtPassword.Text = "Password";
            txtUserID.Text = "UserName";
            btnClear.Enabled = false;
            txtUserID.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Thread td = new Thread(goBackDirectorForm);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
            this.Close();
        }

        private void goBackDirectorForm()
        {
            Application.Run(new Director_Form());
        }

        private void txtUserID_TextChanged_1(object sender, EventArgs e)
        {
            if (txtUserID.TextLength > 0)
            {
                txtPassword.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                txtPassword.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
            if (txtPassword.TextLength > 0)
            {
                btnClear.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                btnClear.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void txtUserID_Click(object sender, EventArgs e)
        {
            txtUserID.Clear();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
        }
    }
}
