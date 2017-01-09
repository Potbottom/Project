using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_System
{
    public partial class GUI
    {
        public string[] seatNumGenerator(int people, string flightNum, string flightClass)
        {
            List<string> seats = new List<string>();
            string path = (FolderDirFlights + cmbFlightOfChoice.Text + ".txt");
            int economy = int.Parse((System.IO.File.ReadAllLines(path))[3]);
            int business = int.Parse((System.IO.File.ReadAllLines(path))[2]);
            for (int i = 0; i < people; i++)
            {
                int temp01 = business - i;
                int temp02 = economy - i;
                if (flightClass == "Business")
                {
                    int row = temp01 / 5;
                    string rowAlpha = "";
                    int col = temp01 % 5;
                    switch (row)
                    {
                        case 0:
                            rowAlpha = "E";
                            break;
                        case 1:
                            rowAlpha = "D";
                            break;
                        case 2:
                            rowAlpha = "C";
                            break;
                        case 3:
                            rowAlpha = "B";
                            break;
                        case 4:
                            rowAlpha = "A";
                            break;
                        case 5:
                            col = 0;
                            rowAlpha = "A";
                            break;
                    }
                    seats.Add(rowAlpha + col);
                }
                else
                {
                    int row = temp02 / 5;
                    string rowAlpha = "";
                    int col = temp02 % 5;
                    switch (row)
                    {
                        case 0:
                            rowAlpha = "L";
                            break;
                        case 1:
                            rowAlpha = "K";
                            break;
                        case 2:
                            rowAlpha = "J";
                            break;
                        case 3:
                            rowAlpha = "I";
                            break;
                        case 4:
                            rowAlpha = "H";
                            break;
                        case 5:
                            rowAlpha = "G";
                            break;
                        case 6:
                            rowAlpha = "F";
                            break;
                        case 7:
                            col = 0;
                            rowAlpha = "F";
                            break;
                    }
                    seats.Add(rowAlpha + col);
                }
            }
            string[] seatNumber = seats.ToArray();
            return seatNumber;
        }
        //Seat Number generator

        public string flightIDGenerator()
        {
            string[] naming = System.IO.File.ReadAllLines(FolderDir + "Naming_Sequence.txt");
            string flightAlpha = "";
            string flightNum = "";
            int flightLetter = int.Parse(naming[2]);
            int flightNumber = int.Parse(naming[3]);
            if (flightNumber < 10)
            {
                flightNum = ("000" + flightNumber);
            }
            else if (flightNumber < 100 && flightNumber > 10)
            {
                flightNum = ("00" + flightNumber);
            }
            else if (flightNumber < 1000 && flightNumber > 100)
            {
                flightNum = ("0" + flightNumber);
            }
            else if (flightNumber < 10000 && flightNumber > 1000)
            {
                flightNum = (flightNumber + "");
            }
            else if (flightNumber >= 10000)
            {
                flightLetter += (flightNumber / 10000);
                flightNum = (flightNumber % 10000 + "");
            }
            switch (flightLetter)
            {
                case 1:
                    flightAlpha = "A";
                    break;
                case 2:
                    flightAlpha = "B";
                    break;
                case 3:
                    flightAlpha = "C";
                    break;
                case 4:
                    flightAlpha = "D";
                    break;
                case 5:
                    flightAlpha = "E";
                    break;
                case 6:
                    flightAlpha = "F";
                    break;
            }
            string flightID = (flightAlpha + flightNum);
            return flightID;
        }
        //Flight Number generator

        public string[] ticketIDGenerator(int people)
        {
            string[] naming = System.IO.File.ReadAllLines(FolderDir + "Naming_Sequence.txt");
            string ticketAlpha = "";
            string ticketID;
            string ticketNum = "";
            List<string> ticketIDs = new List<string>();
            for (int i = 1; i < (people + 1); i++)
            {
                int ticketNumber = (int.Parse(naming[1])) + i;
                int ticketLetter = int.Parse(naming[0]);
                if (ticketNumber < 10)
                {
                    ticketNum = ("000" + ticketNumber);
                }
                else if (ticketNumber < 100 && ticketNumber > 10)
                {
                    ticketNum = ("00" + ticketNumber);
                }
                else if (ticketNumber < 1000 && ticketNumber > 100)
                {
                    ticketNum = ("0" + ticketNumber);
                }
                else if (ticketNumber < 10000 && ticketNumber > 1000)
                {
                    ticketNum = (ticketNumber + "");
                }
                else if (ticketNumber >= 10000)
                {
                    ticketLetter += (ticketNumber / 10000);
                    ticketNum = ((ticketNumber % 10000) + "");
                }
                switch (ticketLetter)
                {
                    case 1:
                        ticketAlpha = "A";
                        break;
                    case 2:
                        ticketAlpha = "B";
                        break;
                    case 3:
                        ticketAlpha = "C";
                        break;
                    case 4:
                        ticketAlpha = "D";
                        break;
                    case 5:
                        ticketAlpha = "E";
                        break;
                    case 6:
                        ticketAlpha = "F";
                        break;
                }
                ticketID = "T" + ticketAlpha + ticketNum;
                ticketIDs.Add(ticketID);
            }
            string[] arTicketIDs = ticketIDs.ToArray();
            return arTicketIDs;
        }
        //TicketID generator
    }
}
