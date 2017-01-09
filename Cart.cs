using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_System
{
    public partial class GUI    
    {
        public void checkCart(int resume)
        {
            cartResume = resume;
            btnCheckout.Enabled = true;
            if (cartItems.Count == 0)
            {
                btnCheckout.Enabled = false;

            }
            switch (resume)
            {
                case 4:
                    pnlNaming.Visible = false;
                    pnlCart.Visible = true;
                    break;
                case 1:
                    pnlCheckingBooking.Visible = false;
                    pnlCart.Visible = true;
                    break;
                case 3:
                    pnlAvailableFlights.Visible = false;
                    pnlCart.Visible = true;
                    break;
                case 5:
                    pnlNaming.Visible = false;
                    pnlCart.Visible = true;
                    break;
                case 6:
                    pnlNaming.Visible = false;
                    pnlCart.Visible = true;
                    break;
                case 2:
                    pnlNaming.Visible = false;
                    pnlCart.Visible = true;
                    break;
            }
        }
        //Cart Button's function

        public void cartBackButton()
        {
            switch (cartResume)
            {
                case 4:
                    pnlNaming.Visible = true;
                    pnlCart.Visible = false;
                    break;
                case 1:
                    pnlCheckingBooking.Visible = true;
                    pnlCart.Visible = false;
                    break;
                case 3:
                    pnlAvailableFlights.Visible = true;
                    pnlCart.Visible = false;
                    break;
                case 5:
                    pnlPayment.Visible = true;
                    pnlCart.Visible = false;
                    break;
                case 6:
                    pnlConfirmation.Visible = true;
                    pnlCart.Visible = false;
                    break;
                case 2:
                    pnlTicketDetails.Visible = true;
                    pnlCart.Visible = false;
                    break;
                default:
                    pnlCart.Visible = false;
                    pnlCheckingBooking.Visible = true;
                    break;
            }
        }
        //Cart Page's Back Button's function

        public void clearButton()
        {
            cartItems.Clear();
            txtCartItems.Clear();
        }
        //Cart Page's Clear Cart Button's function

        public void ticketDataRecorder(int people)
        {
            List<string> cartItemContent = new List<string>();
            string[] ticketID = ticketIDGenerator(people);
            string flightDetailsPath = (FolderDirFlights + cmbFlightOfChoice.Text + ".txt");
            string gateNumber = ((System.IO.File.ReadAllLines(flightDetailsPath))[6]);
            string boardingTime = ((System.IO.File.ReadAllLines(flightDetailsPath))[5]);
            string dateOfDeparture = ((System.IO.File.ReadAllLines(flightDetailsPath))[4]);
            string[] seatNumber = this.seatNumGenerator(people, cmbFlightOfChoice.Text,
                                                        lblClassOfFlightDetails.Text);
           
            List<string> cartItemsContent = new List<string>();
            for (int i = 0; i < people; i++)
            {
                string first = "";
                string last = "";
                if (i == 0)
                {
                    first = txtNameFirst01.Text;
                    last = txtNameLast01.Text;
                }
                else if (i == 1)
                {
                    first = txtNameFirst02.Text;
                    last = txtNameLast02.Text;
                }
                else if (i == 2)
                {
                    first = txtNameFirst03.Text;
                    last = txtNameLast03.Text;
                }
                else if (i == 3)
                {
                    first = txtNameFirst04.Text;
                    last = txtNameLast04.Text;
                }
                else if (i == 4)
                {
                    first = txtNameFirst05.Text;
                    last = txtNameLast05.Text;
                }
                cartItemContent.Clear();
                cartItemContent.Add(lblFromDetails.Text);          //0
                cartItemContent.Add(lblToDetails.Text);            //1
                cartItemContent.Add(txtEmailLogin.Text);           //2
                cartItemContent.Add(seatNumber[i]);                //3
                cartItemContent.Add(dateOfDeparture);              //4
                cartItemContent.Add(boardingTime);                 //5
                cartItemContent.Add(gateNumber);                   //6
                cartItemContent.Add(lblClassOfFlightDetails.Text); //7
                cartItemContent.Add(cmbFlightOfChoice.Text);       //8
                cartItemContent.Add(first);                        //9
                cartItemContent.Add(last);                         //10
                cartItemContent.Add(ticketID[i]);                  //11
                cartItems.Add(cartItemContent);
                txtCartItems.Text += 
                                     "Name : " + first + "   " + last + "\r\n" +
                                     "Ticket ID : " + ticketID[i] + "\r\n" +
                                     "From : " + lblFromDetails.Text + "\r\n" +
                                     "To : " + lblToDetails.Text + "\r\n" +
                                     "Date Of Departure : " + dateOfDeparture + "\r\n" +
                                     "Boarding Time : " + boardingTime + "\r\n" +
                                     "Class Of Flight : " + lblClassOfFlightDetails.Text + "\r\n" +
                                     "Seat Number : " + seatNumber[i] + "\r\n" +
                                     "Flight Number : " + cmbFlightOfChoice.Text + "\r\n" +
                                     "Gate Number : " + gateNumber + "\r\n\r\n";
                pnlNaming.Visible = false;
                pnlCart.Visible = true;
            }
        }
        //Records each item's content in the cart down
        

    }
}
