using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_System
{
    public partial class GUI
    {
        public void CreateAccount()
        {
            lblConfirmEmail.Visible = false;
            lblConfirmPassword.Visible = false;
            lblCheckCreate.Visible = false;
            lblCheckNullCreate.Visible = false;
            //Reset visibility of all error messages

            int createAccount = 1;
            //Varabile to grant permission to create account

            if (string.IsNullOrEmpty(txtFirstCreate.Text) ||
                string.IsNullOrEmpty(txtLastCreate.Text) ||
                string.IsNullOrEmpty(txtEmailCreate.Text) ||
                string.IsNullOrEmpty(txtPasswordCreate.Text) ||
                string.IsNullOrEmpty(txtConfirmPasswordCreate.Text))
            {
                lblCheckNullCreate.Visible = true;
                createAccount = 0;
            }
            //Check for any null in the fields

            else
            {
                string emailUserEntered = (txtEmailCreate.Text).ToLower();
                /*Varaible of user input email processed to lower case
                  to prevent duplicate accounts from being created by
                  making emails case unsensitive*/

                string checkExistance = FolderDirAccounts + emailUserEntered + ".txt";
                if (System.IO.File.Exists(checkExistance))
                {
                    lblConfirmEmail.Visible = true;
                    createAccount = 0;
                }
                /*Checks if the email input by the user is already used
                  for an existing account in the system*/

                else if (((emailUserEntered.Contains(".com")) == false) ||
                         ((emailUserEntered.Contains("@"))) == false)
                {
                    lblConfirmEmail.Visible = true;
                    lblConfirmEmail.Text = "Invalid Email";
                    createAccount = 0;
                }
                /*Checks if an actual email address is entered into the
                  email address field*/

                else if (txtPasswordCreate.Text != txtConfirmPasswordCreate.Text)
                {
                    lblConfirmPassword.Visible = true;
                    createAccount = 0;
                }
                /*Check if the proposed password is the same as the 
                  confirmation password*/
            }
            if (createAccount == 1)
            {
                string emailUserEntered = (txtEmailCreate.Text).ToLower();
                string temp1 = (FolderDirAccounts + "\\" + emailUserEntered + ".txt");
                string temp2 = txtPasswordCreate.Text + "\r\n" +
                               txtFirstCreate.Text + "\r\n" +
                               txtLastCreate.Text;
                System.IO.File.Create(temp1).Close();
                using (System.IO.StreamWriter writeTxt =
                       new System.IO.StreamWriter(temp1, true))
                {
                    writeTxt.WriteLine(temp2);
                }
                lblCheckCreate.Visible = true;
                txtPasswordCreate.Clear();
                txtConfirmPasswordCreate.Clear();
            }
            /*Creates a new text file which will be named according
              to the user's email address and will store the account's
              password, along with the user's first and last name*/

            else if (createAccount == 0)
            {
                txtPasswordCreate.Clear();
                txtConfirmPasswordCreate.Clear();
            }
            /*Clears the password and confirm password fields if an error
              is encountered for security and privacy reasons*/
        }
        //Login Page's Create Account Button function

        public void NameAnnouncer(string first, string last)
        {
            lblFirstName01.Text = first;
            lblFirstName02.Text = first;
            lblFirstName03.Text = first;
            lblFirstName04.Text = first;
            lblFirstName05.Text = first;
            lblFirstName07.Text = first;
            lblFirstName08.Text = first;
            lblFirstName09.Text = first;
            lblLastName01.Text = last;
            lblLastName02.Text = last;
            lblLastName03.Text = last;
            lblLastName04.Text = last;
            lblLastName05.Text = last;
            lblLastName07.Text = last;
            lblLastName08.Text = last;
            lblLastName09.Text = last;
        }
        //Shows user's first and last name on all pages after they login


    }
}

