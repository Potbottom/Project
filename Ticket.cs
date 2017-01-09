using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_System
{
    public partial class GUI
    {
        public void checkDetails()
        {
            lblCheckTicketExpire.Visible = false;
            lblValidifyTicket01.Visible = false;
            lblValidifyTicket02.Visible = false;
            if (string.IsNullOrEmpty(txtCheckTicketNumber01.Text))
            {
                lblValidifyTicket01.Visible = true;
            }
            else
            {
                string checkExistance = FolderDirTickets + txtCheckTicketNumber01.Text + ".txt";
                if (System.IO.File.Exists(checkExistance))
                {
                    string[] ticketContent = System.IO.File.ReadAllLines(FolderDirTickets +
                                                                         txtCheckTicketNumber01.Text +
                                                                         ".txt");
                    if (ticketContent[2] == txtEmailLogin.Text)
                    {
                        string ticketID = (txtCheckTicketNumber01.Text).ToUpper();
                        lblValidifyTicket01.Visible = false;
                        lblCheckTicketExpire.Visible = false;
                        this.TicketChecker(ticketID, 1);
                    }
                    else
                    {
                        lblValidifyTicket01.Visible = true;
                    }
                }
                else
                {
                    lblValidifyTicket01.Visible = true;
                }
            }
        }

        public void checkDetails2()
        {
            lblCheckTicketExpire.Visible = false;
            lblValidifyTicket02.Visible = false;
            if (string.IsNullOrEmpty(txtCheckTicketNumber02.Text))
            {
                lblValidifyTicket02.Visible = true;
            }
            else
            {
                string checkExistance = FolderDirTickets + txtCheckTicketNumber02.Text + ".txt";
                if (System.IO.File.Exists(checkExistance))
                {
                    string[] ticketContent = System.IO.File.ReadAllLines(FolderDirTickets +
                                                                         txtCheckTicketNumber01.Text +
                                                                         ".txt");
                    if (ticketContent[2] == txtEmailLogin.Text)
                    {
                        string ticketID = (txtCheckTicketNumber02.Text).ToUpper();
                        lblCheckTicketExpire.Visible = false;
                        lblValidifyTicket02.Visible = false;
                        this.TicketChecker(ticketID, 2);
                    }
                    else
                    {
                        lblValidifyTicket01.Visible = true;
                    }
                }
                else
                {
                    lblValidifyTicket02.Visible = true;
                }
            }
        }

        public void TicketChecker(string ticketID, int number)
        {
            string[] ticketContent = System.IO.File.ReadAllLines(FolderDirTickets +
                                                     ticketID +
                                                     ".txt");
            DateTime ticketDate = DateTime.ParseExact((ticketContent[4]), "dd/MM/yyyy",
                                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime now = DateTime.Now;
            if (now > ticketDate)
            {
                lblCheckTicketExpire.Visible = true;
            }
            lblCheckFirstName.Text = ticketContent[9];
            lblCheckLastName.Text = ticketContent[10];
            lblCheckTicketID.Text = ticketID;
            lblCheckFrom.Text = ticketContent[0];
            lblCheckTo.Text = ticketContent[1];
            lblCheckDateOfDeparture.Text = ticketContent[4];
            lblCheckBoardingTime.Text = ticketContent[5];
            lblCheckClassOfFlight.Text = ticketContent[7];
            lblCheckSeatNumber.Text = ticketContent[3];
            lblCheckFlightNumber.Text = ticketContent[8];
            lblCheckGateNumber.Text = ticketContent[6];
            if (number == 1)
            {
                pnlCheckingBooking.Visible = false;
                pnlTicketDetails.Visible = true;
                txtCheckTicketNumber02.Text = ticketID;
            }
        }
        //Ticket Details Checking function

        public void ticketBack()
        {
            pnlCheckingBooking.Visible = true;
            pnlTicketDetails.Visible = false;
            txtCheckTicketNumber01.Clear();
            txtCheckTicketNumber02.Clear();
            lblCheckTicketExpire.Visible = false;
        }

        public void naming()
        {
            lblCheckNullNaming.Visible = false;
            //Reset visibility of all error messages

            if ((int.Parse(lblNumberOfPeople02.Text)) == 1)
            {
                if (string.IsNullOrEmpty(txtNameFirst01.Text) ||
                    string.IsNullOrEmpty(txtNameLast01.Text))
                {
                    lblCheckNullNaming.Visible = true;
                }
                else
                {
                    this.ticketDataRecorder(1);
                }
            }
            else if ((int.Parse(lblNumberOfPeople02.Text)) == 2)
            {
                if (string.IsNullOrEmpty(txtNameFirst01.Text) ||
                    string.IsNullOrEmpty(txtNameLast01.Text) ||
                    string.IsNullOrEmpty(txtNameFirst02.Text) ||
                    string.IsNullOrEmpty(txtNameLast02.Text))
                {
                    lblCheckNullNaming.Visible = true;
                }
                else
                {
                    this.ticketDataRecorder(2);
                }
            }
            else if ((int.Parse(lblNumberOfPeople02.Text)) == 3)
            {
                if (string.IsNullOrEmpty(txtNameFirst01.Text) ||
                    string.IsNullOrEmpty(txtNameLast01.Text) ||
                    string.IsNullOrEmpty(txtNameFirst02.Text) ||
                    string.IsNullOrEmpty(txtNameLast02.Text) ||
                    string.IsNullOrEmpty(txtNameFirst03.Text) ||
                    string.IsNullOrEmpty(txtNameLast03.Text))
                {
                    lblCheckNullNaming.Visible = true;
                }
                else
                {
                    this.ticketDataRecorder(3);
                }
            }
            else if ((int.Parse(lblNumberOfPeople02.Text)) == 4)
            {
                if (string.IsNullOrEmpty(txtNameFirst01.Text) ||
                    string.IsNullOrEmpty(txtNameLast01.Text) ||
                    string.IsNullOrEmpty(txtNameFirst02.Text) ||
                    string.IsNullOrEmpty(txtNameLast02.Text) ||
                    string.IsNullOrEmpty(txtNameFirst03.Text) ||
                    string.IsNullOrEmpty(txtNameLast03.Text) ||
                    string.IsNullOrEmpty(txtNameFirst04.Text) ||
                    string.IsNullOrEmpty(txtNameLast04.Text))
                {
                    lblCheckNullNaming.Visible = true;
                }
                else
                {
                    this.ticketDataRecorder(4);
                }
            }
            else if ((int.Parse(lblNumberOfPeople02.Text)) == 5)
            {
                if (string.IsNullOrEmpty(txtNameFirst01.Text) ||
                    string.IsNullOrEmpty(txtNameLast01.Text) ||
                    string.IsNullOrEmpty(txtNameFirst02.Text) ||
                    string.IsNullOrEmpty(txtNameLast02.Text) ||
                    string.IsNullOrEmpty(txtNameFirst03.Text) ||
                    string.IsNullOrEmpty(txtNameLast03.Text) ||
                    string.IsNullOrEmpty(txtNameFirst04.Text) ||
                    string.IsNullOrEmpty(txtNameLast04.Text) ||
                    string.IsNullOrEmpty(txtNameFirst01.Text) ||
                    string.IsNullOrEmpty(txtNameLast01.Text))
                {
                    lblCheckNullNaming.Visible = true;
                }
                else
                {
                    this.ticketDataRecorder(5);
                }
            }
        }
        //Getting first and last names of the owner for each ticket

    }
}
