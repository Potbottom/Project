using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight_Booking_System
{
    public partial class GUI : Form

    {
        public string FolderDir = (System.IO.Directory.GetCurrentDirectory()) +
                                  "\\..\\..\\Data\\";
        //Path to Flight_Booking_System\Data
        public string FolderDirAccounts = (System.IO.Directory.GetCurrentDirectory()) +
                                          "\\..\\..\\Data\\Accounts\\";
        //Path to Flight_Booking_System\Data\Accounts
        public string FolderDirFlights = (System.IO.Directory.GetCurrentDirectory()) +
                                          "\\..\\..\\Data\\Flights\\";
        //Path to Flight_Booking_System\Data\Flights
        public string FolderDirTickets = (System.IO.Directory.GetCurrentDirectory()) +
                                          "\\..\\..\\Data\\Tickets\\";
        //Path to Flight_Booking_System\Data\Tickets
        public int loggedOn = 0;
        //Variable to keep track if user is logged into an account
        public int resume = 0;
        //Variable keeping track of previous pages, creating the illusion function of resuming
        public List<List<string>> cartItems = new List<List<string>>();
        //2D list to keep the data of the items in the cart and the item's contents
        public int cartResume = 0;
        //Variable to keep track of Cart Page's Back button

        public GUI()
        {
            InitializeComponent();

            this.expiredFlightsCleaner();

            pnlCheckingBooking.Visible = false;
            pnlAvailableFlights.Visible = false;
            pnlTicketDetails.Visible = false;
            pnlLogin.Visible = false;
            pnlNaming.Visible = false;
            pnlAddFlights.Visible = false;
            pnlAdminFunction.Visible = false;
            pnlPayment.Visible = false;
            pnlConfirmation.Visible = false;
            pnlCart.Visible = false;
            grpbUserFunction.Size = new Size(192, 364);
            //Reset visibility of all pages except home page

            lblCheckNullNaming.Visible = false;
            lblConfirmEmail.Visible = false;
            lblConfirmPassword.Visible = false;
            lblCheckCreate.Visible = false;
            lblCheckNullCreate.Visible = false;
            lblCheckNullLogin.Visible = false;
            lblValidifyEmail.Visible = false;
            lblValidifyPassword.Visible = false;
            lblValidifyTicket01.Visible = false;
            lblValidifyDestination01.Visible = false;
            lblValidifyDestination02.Visible = false;
            lblCheckNullSearching01.Visible = false;
            lblCheckNullSearching02.Visible = false;
            lblNoFlightsFound.Visible = false;
            lblChooseAFlight.Visible = false;
            lblCheckNullPayment.Visible = false;
            lblErrorPayment.Visible = false;
            lblConfirmPayment.Visible = false;
            lblErrorAdding.Visible = false;
            lblConfirmAdding.Visible = false;
            //Reset visibility of all error messages

            btnCart08.Enabled = false;
            //This button is just for visual appeal

            string[] cmbFromBookingOptions = System.IO.File.ReadAllLines
                                             (FolderDir + "Countries_In_Service.txt");
            foreach (string option in cmbFromBookingOptions)
            {
                cmbFromBooking01.Items.Add(option);
                cmbFromBooking02.Items.Add(option);
                cmbToBooking01.Items.Add(option);
                cmbToBooking02.Items.Add(option);
                cmbFromAdding.Items.Add(option);
                cmbToAdding.Items.Add(option);
            }
            /*Adding options of countries that we are servicing to
              the selection of the user's To and From choices*/

            cmbNumberOfPeople01.Items.Add("1");
            cmbNumberOfPeople01.Items.Add("2");
            cmbNumberOfPeople01.Items.Add("3");
            cmbNumberOfPeople01.Items.Add("4");
            cmbNumberOfPeople01.Items.Add("5");
            cmbNumberOfPeople02.Items.Add("1");
            cmbNumberOfPeople02.Items.Add("2");
            cmbNumberOfPeople02.Items.Add("3");
            cmbNumberOfPeople02.Items.Add("4");
            cmbNumberOfPeople02.Items.Add("5");
            /*Adding options for number of people the user
              want to book for at a time*/

            for (int i = 0; i < 24; i++)
            {
                if (i == 0){
                    cmbBoardingAdding.Items.Add("0000");
                }
                else if (i > 0 && i < 10)
                {
                    cmbBoardingAdding.Items.Add("0" + i*100);
                }
                else
                {
                    cmbBoardingAdding.Items.Add(i * 100);
                }
            }
            for (int i = 1; i < 13; i++)
            {
                cmbMonthPayment.Items.Add(i);
            }
            for (int i = 20; i < 31; i++)
            {
                cmbYearPayment.Items.Add(i);
            }

            cmbClassBooking01.Items.Add("Business");
            cmbClassBooking01.Items.Add("Economy");
            cmbClassBooking02.Items.Add("Business");
            cmbClassBooking02.Items.Add("Economy");
            /*Adding options of classes of flights available to 
              the selection of the user's flight's class*/

            if (new System.IO.FileInfo(FolderDirAccounts + "Remembered.txt").Length != 0)
            {
                string[] temp = System.IO.File.ReadAllLines(FolderDirAccounts + "Remembered.txt");
                txtEmailLogin.Text = temp[0];
            }
            /*Fills in login's email's field if the previous runtime's login's
              Remember Me checkbox was checked*/
        }
        //Resets or actions to carry out when the GUI of the application launches

        

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAccount();
        }
        //Login Page's Create Account Button function

        private void btnLogin_Click(object sender, EventArgs e)
        {

            lblCheckNullLogin.Visible = false;
            lblValidifyEmail.Visible = false;
            lblValidifyPassword.Visible = false;
            //Reset visibility of all error messages

            if (string.IsNullOrEmpty(txtEmailLogin.Text) ||
                string.IsNullOrEmpty(txtPasswordLogin.Text))
            {
                lblCheckNullLogin.Visible = true;
            }
            //Check for any null in the fields

            else
            {
                string emailUserEntered = (txtEmailLogin.Text).ToLower();
                string checkExistance = FolderDirAccounts + emailUserEntered + ".txt";
                if (System.IO.File.Exists(checkExistance) == true)
                {
                    string correctPassword = (System.IO.File.ReadAllLines(checkExistance))[0];
                    /*If account is valid, the correct password will be retrived from the
                      account's data*/
                    if ((((txtEmailLogin.Text).ToLower()) == "admin@control.com") &&
                        (correctPassword == txtPasswordLogin.Text))
                    {
                        loggedOn = 2;
                        btnCart01.Enabled = false;
                        btnCart02.Enabled = false;
                        btnCart03.Enabled = false;
                        btnCart04.Enabled = false;
                        btnCart05.Enabled = false;
                        btnCart06.Enabled = false;
                        cmbFlightOfChoice.Enabled = false;
                        btnConfirm.Enabled = false;
                        pnlAdminFunction.Visible = true;
                        grpbUserFunction.Size = new Size(192, 276);
                    }
                    if (correctPassword == txtPasswordLogin.Text)
                    {
                        string temp = "";
                        if (resume == 1)
                        {
                            temp = (FolderDirAccounts + "Remembered.txt");
                            pnlLogin.Visible = false;
                            pnlAvailableFlights.Visible = true;
                            NameAnnouncer(((System.IO.File.ReadAllLines(checkExistance))[1]),
                                               ((System.IO.File.ReadAllLines(checkExistance))[2]));
                            loggedOn = 1;
                            resume = 0;
                        }
                        else if (resume == 2)
                        {
                            temp = (FolderDirAccounts + "Remembered.txt");
                            pnlLogin.Visible = false;
                            pnlCheckingBooking.Visible = true;
                            NameAnnouncer(((System.IO.File.ReadAllLines(checkExistance))[1]),
                                               ((System.IO.File.ReadAllLines(checkExistance))[2]));
                            cmbToBooking01.Text = cmbToBooking02.Text;
                            cmbFromBooking01.Text = cmbFromBooking02.Text;
                            dtpDateOfDeparture01.Text = dtpDateOfDeparture02.Text;
                            cmbClassBooking01.Text = cmbClassBooking02.Text;
                            cmbNumberOfPeople01.Text = cmbNumberOfPeople02.Text;
                            loggedOn = 1;
                            resume = 0;
                        }
                        else if (resume == 3)
                        {
                            temp = (FolderDirAccounts + "Remembered.txt");
                            pnlLogin.Visible = false;
                            pnlAvailableFlights.Visible = true;
                            NameAnnouncer(((System.IO.File.ReadAllLines(checkExistance))[1]),
                                          ((System.IO.File.ReadAllLines(checkExistance))[2]));
                            loggedOn = 1;
                            resume = 0;
                        }
                        else
                        {
                            temp = (FolderDirAccounts + "Remembered.txt");
                            pnlLogin.Visible = false;
                            pnlCheckingBooking.Visible = true;
                            this.NameAnnouncer(((System.IO.File.ReadAllLines(checkExistance))[1]),
                                               ((System.IO.File.ReadAllLines(checkExistance))[2]));
                            loggedOn = 1;
                        }
                        if (chbRememberMe.Checked == true)
                        {
                            System.IO.File.WriteAllText(temp, string.Empty);
                            using (System.IO.StreamWriter writeTxt =
                                   new System.IO.StreamWriter(temp, true))
                            {
                                writeTxt.WriteLine(txtEmailLogin.Text);
                            }
                        }
                        else
                        {
                            System.IO.File.WriteAllText(temp, string.Empty);
                        }
                        /*When the user checks the Remember Me checkbox, the system
                          will remember the email address and auto fills in the
                          email field on the next app startup*/
                    }
                    /*Login will be granted and the login page will be set to hide
                      while the next page, Checking and Booking will be brought to 
                      the front*/

                    else
                    {
                        lblValidifyPassword.Visible = true;
                        txtPasswordLogin.Clear();
                        txtPasswordLogin.Focus();
                    }
                    /*When an incorrect password is entered, the password field
                      will be cleared and an error message will be shown*/
                }

                else if (((emailUserEntered.Contains(".com")) == false) ||
                         ((emailUserEntered.Contains("@"))) == false)
                {
                    lblValidifyEmail.Visible = true;
                    txtPasswordLogin.Clear();
                    txtEmailLogin.Focus();
                }
                /*When an invalid email is entered the password field
                  will be cleared and an error message will be shown*/

                else
                {
                    lblValidifyEmail.Visible = true;
                    txtPasswordLogin.Clear();
                    txtEmailLogin.Focus();
                }
                /*When an invalid email is entered the password field
                  will be cleared and an error message will be shown*/
            }
            /*Checks if the email input by the user is already used
              for an existing account in the system*/
        }
        private void btnCheckAvailableFlight01_Click(object sender, EventArgs e)
        {
            checkFlights1();
        }
        //Search available flights function for booking when logged in
        private void btnCheckAvailableFlight02_Click_1(object sender, EventArgs e)
        {
            checkFlight2();
        }
            
        //Search available flights function for booking when not logged in
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelFlight();
        }
        //Cancel Button Of Available Flights Page's function

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            confirmflight();
        }
        //Confirm Button of Available Flights Page's function

        private void btnCheckDetails01_Click(object sender, EventArgs e)
        {
            checkDetails();
        }
        private void btnCheckDetails02_Click(object sender, EventArgs e)
        {
            checkDetails2();
        }
        

        private void btnBack_Click(object sender, EventArgs e)
        {
            ticketBack();
        }
        //Back Button of Ticket Details Page's function

        

        private void btnLogOut01_Click(object sender, EventArgs e)
        {
            this.LogOut();
        }
        private void btnLogOut02_Click(object sender, EventArgs e)
        {
            this.LogOut();
        }
        private void btnLogOut03_Click(object sender, EventArgs e)
        {
            this.LogOut();
        }
        private void btnLogOut04_Click(object sender, EventArgs e)
        {
            this.LogOut();
        }
        private void btnLogOut05_Click(object sender, EventArgs e)
        {
            this.LogOut();

            btnCancelPayment.Text = "Cancel";
            btnPaynowPayment.Enabled = true;
        }
        private void btnLogOut06_Click(object sender, EventArgs e)
        {
            this.LogOut();
        }
        private void btnLogOut07_Click(object sender, EventArgs e)
        {
            this.LogOut();
        }
        private void btnLogOut08_Click(object sender, EventArgs e)
        {
            this.LogOut();
        }
        private void LogOut()
        {
            pnlCheckingBooking.Visible = false;
            pnlAvailableFlights.Visible = false;
            pnlTicketDetails.Visible = false;
            pnlLogin.Visible = false;
            pnlNaming.Visible = false;
            pnlAddFlights.Visible = false;
            pnlAdminFunction.Visible = false;
            pnlPayment.Visible = false;
            pnlConfirmation.Visible = false;
            pnlCart.Visible = false;

            pnlHomePage.Visible = true;
            txtFirstCreate.Clear();
            txtLastCreate.Clear();
            txtEmailCreate.Clear();
            txtPasswordCreate.Clear();
            txtConfirmPasswordCreate.Clear();
            txtPasswordLogin.Clear();
            cmbFlightOfChoice.Items.Clear();
            cmbFlightOfChoice.Text = "";
            cmbClassBooking01.Text = "";
            cmbFromBooking01.Text = "";
            cmbToBooking01.Text = "";
            dtpDateOfDeparture01.Value = DateTime.Now;
            lstResultOptions.Items.Clear();
            cartItems.Clear();
            txtCartItems.Clear();
            txtConfirmOrder.Clear();
            pnlAdminFunction.Visible = false;
            grpbUserFunction.Size = new Size(192, 364);
            btnCart01.Enabled = true;
            btnCart02.Enabled = true;
                btnCart03.Enabled = true;
                btnCart04.Enabled = true;
                btnCart05.Enabled = true;
                btnCart06.Enabled = true;
           
                
                cmbFlightOfChoice.Enabled = true;
                btnConfirm.Enabled = true;
                
            
            loggedOn = 0;
        }
        //Logout function

        private void btnGoLogin01_Click(object sender, EventArgs e)
        {
            pnlAvailableFlights.Visible = false;
            pnlLogin.Visible = true;
            resume = 1;
        }
        private void btnGoLogin02_Click(object sender, EventArgs e)
        {
            pnlHomePage.Visible = false;
            pnlLogin.Visible = true;
            resume = 2;
        }
        //Logging in halfway through booking or searching

        private void btnNamingConfirm_Click(object sender, EventArgs e)
        {
            naming();
        }
        //Getting first and last names of the owner for each ticket


        private void btnCart04_Click(object sender, EventArgs e)
        {
            //pnlNaming
            this.checkCart(4);
        }
        private void btnCart01_Click(object sender, EventArgs e)
        {
            //pnlCheckingBooking
            this.checkCart(1);
        }
        private void btnCart03_Click(object sender, EventArgs e)
        {
            //pnlAvailableFlights
            this.checkCart(3);
        }
        private void btnCart05_Click(object sender, EventArgs e)
        {
            //pnlPayment
            this.checkCart(5);

            btnCancelPayment.Text = "Cancel";
            btnPaynowPayment.Enabled = true;
        }
        private void btnCart06_Click(object sender, EventArgs e)
        {
            //pnlConfirmation
            this.checkCart(6);
        }
        private void btnCart02_Click(object sender, EventArgs e)
        {
            //pnlTicketDetails
            this.checkCart(2);
        }
        

        private void btnCartBack_Click(object sender, EventArgs e)
        {
            cartBackButton();
        }
        //Cart Page's Back Button's function

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            clearButton();
        }
        //Cart Page's Clear Cart Button's function

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            checkOut();
        }
        

        private void btnPaynowPayment_Click(object sender, EventArgs e)
        {
            payConfirm();
        }
        //Payment Page's Confirm Button's fuction

        private void btnCancelPayment_Click(object sender, EventArgs e)
        {
            payCancel();
        }
        //Payment Page's Cancel Button's function

        
        
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addflight();
        }
        //Add Flights Page's Add Button's function

        private void btnCancelAdding_Click(object sender, EventArgs e)
        {
            cancel();
        }
        //Add Flights Page's Cancel Button's function
        private void btnProceedToPayment_Click(object sender, EventArgs e)
        {
            btnCheckout.Enabled = true;
            if (cartItems.Count == 0)
            {
                btnCheckout.Enabled = false;

            }
            pnlConfirmation.Visible = false;
            pnlPayment.Visible = true;
        }

        private void btnAddFlights_Click(object sender, EventArgs e)
        {
            pnlAddFlights.Visible = true;
            pnlCheckingBooking.Visible = false;
        }

        


        //Proceed to payment button function
    }
}

/*NOTES FOR MY SHORT-TERMED MEMORY SELF:
---ADMIN ACCOUNT---
admin@control.com
admin

---TEST ACCOUNT---
abc@gmail.com
abc

---TICKET DATA RECORD---
(TICKET ID WILL BE RECORDED AS NAME OF TXT FILE)
[0]FROM
[1]TO
[2]EMAIL OF TICKET'S OWNER
[3]SEAT NUMBER
[4]DATE OF DEPARTURE
[5]BOARDING TIME
[6]GATE NUMBER
[7]CLASS OF FLIGHT
[8]FLIGHT NUMBER
[9]FIRST NAME
[10]LAST NAME

---FLIGHT DATA RECORD---
(FLIGHT NUMBER WILL BE RECORDED AS NAME OF TXT FILE)
[0]FROM
[1]TO
[2]NUMBER OF AVAILABLE BUSINESS CLASS SEATS
[3]NUMBER OF AVAILABLE ECONOMY  CLASS SEATS
[4]DATE OF DEPARTURE
[5]BOARDING TIME
[6]GATE NUMBER

15 BUSINESS CLASS (ROWS A,B,C,D,E  3 SEATS PER ROW)
35 ECONOMY CLASS  (ROWS F,G,H,I,J,K,L  5 SEATS PER ROW)

---NAMING SEQUENCE RECORD---
[0]TICKET ID ALPHABETIC ORDER
[1]TICKET ID NUMERICAL ORDER
[2]FIGHT NUMBER ALPHABETIC ORDER
[3]FIGHT NUMBER ALPHABETIC ORDER

---AUTHORIZED CARD---
[0]CARD NUMBER
[1]EXPIRATION DATE MONTH
[2]EXPIRATION DATE YEAR
[3]SECURITY CODE
*/
