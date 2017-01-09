using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_System
{
    public partial class GUI
    {
        public void checkOut()
        {
            txtConfirmOrder.Text = txtCartItems.Text;
            int fare = 0;
            foreach (List<string> cartItemContent in cartItems)
            {
                
                int temp = fareCalculator(cartItemContent[0], cartItemContent[1]);
                fare = fare + temp;
               
            }
            lblTotalPrice.Text = "$" + fare + ".00";
            pnlCart.Visible = false;
            pnlConfirmation.Visible = true;
        }

        public void payConfirm()
        {
            lblCheckNullPayment.Visible = false;
            lblErrorPayment.Visible = false;
            lblConfirmPayment.Visible = false;
            string[] card = System.IO.File.ReadAllLines(FolderDir + "Authorized_Card.txt");
            if (string.IsNullOrEmpty(txtAddressLine1Payment.Text) ||
               string.IsNullOrEmpty(txtCityPayment.Text) ||
               string.IsNullOrEmpty(txtCountryPayment.Text) ||
               string.IsNullOrEmpty(txtCodePayment.Text) ||
               string.IsNullOrEmpty(cmbMonthPayment.Text) ||
               string.IsNullOrEmpty(cmbYearPayment.Text) ||
               string.IsNullOrEmpty(txtCardNumPayment.Text))
            {
                lblCheckNullPayment.Visible = true;
            }
            else if (card[0] != txtCardNumPayment.Text ||
                     card[1] != cmbMonthPayment.Text ||
                     card[2] != cmbYearPayment.Text ||
                     card[3] != txtCodePayment.Text)
            {
                lblErrorPayment.Visible = true;
            }
            else
            {
                
                

                lblConfirmPayment.Visible = true;
                txtAddressLine1Payment.Clear();
                txtAddressLine2Payment.Clear();
                txtCityPayment.Clear();
                txtCountryPayment.Clear();
                txtCodePayment.Clear();
                cmbMonthPayment.Text = "";
                cmbYearPayment.Text = "";
                txtCardNumPayment.Clear();
                btnPaynowPayment.Enabled = false;
                btnCancelPayment.Text = "Back";
                cartItems.Clear();
                txtConfirmOrder.Clear();
                txtCartItems.Clear();
            }
        }
        //Payment Page's Confirm Button's fuction

        public void payCancel()
        {
            btnCancelPayment.Text = "Cancel";
            btnPaynowPayment.Enabled = true;
            pnlCheckingBooking.Visible = true;
            pnlPayment.Visible = false;

            txtAddressLine1Payment.Clear();
            txtAddressLine2Payment.Clear();
            txtCityPayment.Clear();
            txtCountryPayment.Clear();
            txtCodePayment.Clear();
            cmbMonthPayment.Text = "";
            cmbYearPayment.Text = "";
            txtCardNumPayment.Clear();
        }

    }
}
