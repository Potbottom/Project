using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_System
{
    public partial class GUI
    {
        public int fareCalculator(string temp01, string temp02)
        {
            string[] value = (System.IO.File.ReadAllLines(FolderDir + "Fare_Calculation.txt"));
            int fare = 0;
            string flightClass = lblClassOfFlightDetails.Text;

            for (int i = 0; i < value.Length; i += 2)
            {
                if (value[i].Contains(temp01) && value[i].Contains(temp02))
                {
                    fare = int.Parse(value[i + 1]);
                    i = value.Length + 1;
                }
            }
            if (flightClass == "Business")
            {
                fare *= 2;
            }
            return fare;
        }
        //Calculates the price of all the items in the cart

        public string arrivalTimeCalculator(string travel, int boardingTime)
        {
            string[] value = (System.IO.File.ReadAllLines(FolderDir + "Flight_Time.txt"));
            int arrivalTime = boardingTime;
            string timeOfArrival = "";
            string flightClass = lblClassOfFlightDetails.Text;

            for (int i = 0; i < value.Length; i += 2)
            {
                if (travel == value[i])
                {
                    arrivalTime += int.Parse(value[i + 1]);
                    i = value.Length + 1;
                }
            }
            if (arrivalTime / 2400 == 1)
            {
                arrivalTime -= 2400;
                if (arrivalTime < 10)
                {
                    timeOfArrival = "000" + arrivalTime;
                }
                else if (arrivalTime < 100)
                {
                    timeOfArrival = "00" + arrivalTime;
                }
                else if (arrivalTime < 1000)
                {
                    timeOfArrival = "0" + arrivalTime;
                }
            }
            else
            {
                timeOfArrival = arrivalTime + "";
            }
            return timeOfArrival;
        }
        //Calculates time of arrival of flights
    }
}
