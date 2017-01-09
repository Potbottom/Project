using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_System
{
    public partial class GUI
    {
        public void checkFlights1()
        {
            lstResultOptions.Items.Clear();
            lblFromDetails.Text = "";
            lblToDetails.Text = "";
            lblDateOfDepartureDetails.Text = "";
            lblNumberOfPeople01.Text = "";
            lblClassOfFlightDetails.Text = "";
            lblNoFlightsFound.Visible = false;
            cmbFlightOfChoice.Visible = true;
            lblChooseFlight.Visible = true;
            lblValidifyDestination01.Visible = false;
            lblCheckNullSearching01.Visible = false;
            //Reset visibility of all error messages

            int error = 0;
            if (string.IsNullOrEmpty(cmbFromBooking01.Text) ||
                string.IsNullOrEmpty(cmbToBooking01.Text) ||
                string.IsNullOrEmpty(cmbClassBooking01.Text) ||
                string.IsNullOrEmpty(cmbNumberOfPeople01.Text))
            {
                error = 1;
                lblCheckNullSearching01.Visible = true;
            }
            //If the user leaves a field empty
            else if (cmbFromBooking01.SelectedIndex == cmbToBooking01.SelectedIndex)
            {
                error = 1;
                lblValidifyDestination01.Visible = true;
            }
            //If the user picks the same option for the From and To fields

            if (error == 0)
            {
                //Checking and Booking Page's Check Available Flights Button Function
                string from = cmbFromBooking01.Text;
                string to = cmbToBooking01.Text;
                int people = int.Parse(cmbNumberOfPeople01.Text);
                string departureDate = dtpDateOfDeparture01.Value.ToString("dd/MM/yyyy");
                string flightClass = cmbClassBooking01.Text;
                List<string> searchResults = new List<string>();
                int resultCounter = 0;
                lblFromDetails.Text = from;
                lblToDetails.Text = to;
                lblDateOfDepartureDetails.Text = departureDate;
                lblNumberOfPeople01.Text = people + "";
                lblClassOfFlightDetails.Text = flightClass;
                foreach (var currentFile in System.IO.Directory.GetFiles(FolderDirFlights, "*.txt"))
                {
                    string[] fileContent = System.IO.File.ReadAllLines(currentFile);
                    if (departureDate == fileContent[4])
                    {
                        if (fileContent[0] == from &&
                            fileContent[1] == to)
                        {
                            if (flightClass == "Business")
                            {
                                if ((int.Parse(fileContent[2]) >= people) == true)
                                {
                                    string flightNumber = System.IO.Path.GetFileNameWithoutExtension(currentFile);
                                    searchResults.Add(flightNumber);
                                    cmbFlightOfChoice.Items.Add(flightNumber);
                                    resultCounter++;
                                    lblClassOfFlightDetails.Text = flightClass;
                                    lblFromDetails.Text = from;
                                    lblToDetails.Text = to;
                                    lblDateOfDepartureDetails.Text = departureDate;
                                    lblNumberOfPeople01.Text = cmbNumberOfPeople01.Text;
                                }
                                //When there is available Business Class Seats on flight
                            }
                            //Checks for available Business Class Seats

                            else if (flightClass == "Economy")
                            {
                                if ((int.Parse(fileContent[3]) >= people) == true)
                                {
                                    string flightNumber = System.IO.Path.GetFileNameWithoutExtension(currentFile);
                                    searchResults.Add(flightNumber);
                                    cmbFlightOfChoice.Items.Add(flightNumber);
                                    resultCounter++;
                                    lblClassOfFlightDetails.Text = flightClass;
                                    lblFromDetails.Text = from;
                                    lblToDetails.Text = to;
                                    lblDateOfDepartureDetails.Text = departureDate;
                                    lblNumberOfPeople01.Text = cmbNumberOfPeople01.Text;
                                }
                                //When there is available Economy Class Seats on flight
                            }
                            //Checks for available Economy Class Seats
                        }
                        /*Checks for flights with the matching To and From
                          requirements*/
                    }
                    /*Scans through all flights to find flights which meets
                      the search requiremens*/
                }
                pnlCheckingBooking.Visible = false;
                pnlAvailableFlights.Visible = true;
                pnlLogged01.Visible = true;
                pnlNotLogged01.Visible = false;
                if (resultCounter == 0)
                {
                    lstResultOptions.Text = "";
                    lblNoFlightsFound.Visible = true;
                    cmbFlightOfChoice.Visible = false;
                    lblChooseFlight.Visible = false;
                    btnConfirm.Enabled = false;
                }
                else
                {
                    string displayResult = "";
                    foreach (string result in searchResults)
                    {
                        string[] content = System.IO.File.ReadAllLines(FolderDirFlights + result + ".txt");
                        string arrivalTime = arrivalTimeCalculator((lblFromDetails.Text + " - " + lblToDetails.Text),
                                                                   int.Parse(content[5]));
                        displayResult = ((result.ToUpper()) + "                          " +
                                          content[5] + "                               " +
                                          arrivalTime);
                        lstResultOptions.Items.Add(displayResult);
                    }
                }
            }
            //Allows search of flights if no error is encountered
        }
        //Search available flights function for booking when logged in

        public void checkFlight2()
        {
            lstResultOptions.Items.Clear();
            lblFromDetails.Text = "";
            lblToDetails.Text = "";
            lblDateOfDepartureDetails.Text = "";
            lblNumberOfPeople01.Text = "";
            lblClassOfFlightDetails.Text = "";
            lblNoFlightsFound.Visible = false;
            cmbFlightOfChoice.Visible = true;
            lblChooseFlight.Visible = true;
            lblValidifyDestination02.Visible = false;
            lblCheckNullSearching02.Visible = false;
            //Reset visibility of all error messages

            int error = 0;
            if (string.IsNullOrEmpty(cmbFromBooking02.Text) ||
                string.IsNullOrEmpty(cmbToBooking02.Text) ||
                string.IsNullOrEmpty(cmbClassBooking02.Text) ||
                string.IsNullOrEmpty(cmbNumberOfPeople02.Text))
            {
                error = 1;
                lblCheckNullSearching02.Visible = true;
            }
            //If the user leaves a field empty
            else if (cmbFromBooking02.SelectedIndex == cmbToBooking02.SelectedIndex)
            {
                error = 1;
                lblValidifyDestination02.Visible = true;
            }
            //If the user picks the same option for the From and To fields

            if (error == 0)
            {
                //Checking and Booking Page's Check Available Flights Button Function
                string from = cmbFromBooking02.Text;
                string to = cmbToBooking02.Text;
                int people = int.Parse(cmbNumberOfPeople02.Text);
                string departureDate = dtpDateOfDeparture02.Value.ToString("dd/MM/yyyy");
                string flightClass = cmbClassBooking02.Text;
                lblFromDetails.Text = from;
                lblToDetails.Text = to;
                lblDateOfDepartureDetails.Text = departureDate;
                lblNumberOfPeople01.Text = people + "";
                lblClassOfFlightDetails.Text = flightClass;
                List<string> searchResults = new List<string>();
                int resultCounter = 0;
                foreach (var currentFile in System.IO.Directory.GetFiles(FolderDirFlights, "*.txt"))
                {
                    string[] fileContent = System.IO.File.ReadAllLines(currentFile);
                    if (departureDate == fileContent[4])
                    {
                        if (fileContent[0] == from &&
                            fileContent[1] == to)
                        {
                            if (flightClass == "Business")
                            {
                                if ((int.Parse(fileContent[2]) >= people) == true)
                                {
                                    string flightNumber = System.IO.Path.GetFileNameWithoutExtension(currentFile);
                                    searchResults.Add(flightNumber);
                                    cmbFlightOfChoice.Items.Add(flightNumber);
                                    resultCounter++;
                                    lblClassOfFlightDetails.Text = flightClass;
                                    lblFromDetails.Text = from;
                                    lblToDetails.Text = to;
                                    lblDateOfDepartureDetails.Text = departureDate;
                                    lblNumberOfPeople01.Text = cmbNumberOfPeople02.Text;
                                }
                                //When there is available Business Class Seats on flight
                            }
                            //Checks for available Business Class Seats

                            else if (flightClass == "Economy")
                            {
                                if ((int.Parse(fileContent[3]) >= people) == true)
                                {
                                    string flightNumber = System.IO.Path.GetFileNameWithoutExtension(currentFile);
                                    searchResults.Add(flightNumber);
                                    cmbFlightOfChoice.Items.Add(flightNumber);
                                    resultCounter++;
                                    lblClassOfFlightDetails.Text = flightClass;
                                    lblFromDetails.Text = from;
                                    lblToDetails.Text = to;
                                    lblDateOfDepartureDetails.Text = departureDate;
                                    lblNumberOfPeople01.Text = cmbNumberOfPeople02.Text;
                                }
                                //When there is available Economy Class Seats on flight
                            }
                            //Checks for available Economy Class Seats
                        }
                        /*Checks for flights with the matching To and From
                          requirements*/
                    }
                    /*Scans through all flights to find flights which meets
                      the search requiremens*/
                }
                pnlHomePage.Visible = false;
                pnlAvailableFlights.Visible = true;
                pnlLogged01.Visible = false;
                pnlNotLogged01.Visible = true;
                if (resultCounter == 0)
                {
                    lstResultOptions.Text = "";
                    lblNoFlightsFound.Visible = true;
                    cmbFlightOfChoice.Visible = false;
                    lblChooseFlight.Visible = false;
                    btnConfirm.Enabled = false;
                }
                else
                {
                    string displayResult = "";
                    foreach (string result in searchResults)
                    {
                        string[] content = System.IO.File.ReadAllLines(FolderDirFlights + result + ".txt");
                        string arrivalTime = arrivalTimeCalculator((lblFromDetails.Text + " - " + lblToDetails.Text),
                                                                   int.Parse(content[5]));
                        displayResult = ((result.ToUpper()) + "                          " +
                                          content[5] + "                               " +
                                          arrivalTime);
                        lstResultOptions.Items.Add(displayResult);
                    }
                }
            }
            //Allows search of flights if no error is encountered
        }
        //Search available flights function for booking when not logged in

        public void cancelFlight()
        {
            if (btnConfirm.Enabled == false)
            {
                btnConfirm.Enabled = true;
            }
            if (loggedOn == 0)
            {
                pnlHomePage.Visible = true;
                pnlAvailableFlights.Visible = false;
                cmbFlightOfChoice.Items.Clear();
                cmbFlightOfChoice.Text = "";
                lstResultOptions.Items.Clear();
            }
            else if (loggedOn == 1)
            {
                pnlCheckingBooking.Visible = true;
                pnlAvailableFlights.Visible = false;
                cmbFlightOfChoice.Items.Clear();
                cmbFlightOfChoice.Text = "";
                lstResultOptions.Items.Clear();
            }
        }
        //Cancel Button Of Available Flights Page's function

        public void confirmflight()
        {
            lblChooseAFlight.Visible = false;
            //Reset visibility of all error messages

            if (string.IsNullOrEmpty(cmbFlightOfChoice.Text))
            {
                lblChooseAFlight.Visible = true;
            }
            //When the flight of choice is left blank

            else if (loggedOn == 0)
            {
                pnlAvailableFlights.Visible = false;
                pnlLogin.Visible = true;
                resume = 3;
            }
            //When user tried to add to cart but not logged into an account

            else if (loggedOn == 1)
            {
                lblNumberOfPeople02.Text = lblNumberOfPeople01.Text;
                int people = int.Parse(lblNumberOfPeople01.Text);
                if (people == 1)
                {
                    txtNameFirst01.Enabled = true;
                    txtNameFirst02.Enabled = false;
                    txtNameFirst03.Enabled = false;
                    txtNameFirst04.Enabled = false;
                    txtNameFirst05.Enabled = false;
                    txtNameLast01.Enabled = true;
                    txtNameLast02.Enabled = false;
                    txtNameLast03.Enabled = false;
                    txtNameLast04.Enabled = false;
                    txtNameLast05.Enabled = false;
                }
                else if (people == 2)
                {
                    txtNameFirst01.Enabled = true;
                    txtNameFirst02.Enabled = true;
                    txtNameFirst03.Enabled = false;
                    txtNameFirst04.Enabled = false;
                    txtNameFirst05.Enabled = false;
                    txtNameLast01.Enabled = true;
                    txtNameLast02.Enabled = true;
                    txtNameLast03.Enabled = false;
                    txtNameLast04.Enabled = false;
                    txtNameLast05.Enabled = false;
                }
                else if (people == 3)
                {
                    txtNameFirst01.Enabled = true;
                    txtNameFirst02.Enabled = true;
                    txtNameFirst03.Enabled = true;
                    txtNameFirst04.Enabled = false;
                    txtNameFirst05.Enabled = false;
                    txtNameLast01.Enabled = true;
                    txtNameLast02.Enabled = true;
                    txtNameLast03.Enabled = true;
                    txtNameLast04.Enabled = false;
                    txtNameLast05.Enabled = false;
                }
                else if (people == 4)
                {
                    txtNameFirst01.Enabled = true;
                    txtNameFirst02.Enabled = true;
                    txtNameFirst03.Enabled = true;
                    txtNameFirst04.Enabled = true;
                    txtNameFirst05.Enabled = false;
                    txtNameLast01.Enabled = true;
                    txtNameLast02.Enabled = true;
                    txtNameLast03.Enabled = true;
                    txtNameLast04.Enabled = true;
                    txtNameLast05.Enabled = false;
                }
                else if (people == 5)
                {
                    txtNameFirst01.Enabled = true;
                    txtNameFirst02.Enabled = true;
                    txtNameFirst03.Enabled = true;
                    txtNameFirst04.Enabled = true;
                    txtNameFirst05.Enabled = true;
                    txtNameLast01.Enabled = true;
                    txtNameLast02.Enabled = true;
                    txtNameLast03.Enabled = true;
                    txtNameLast04.Enabled = true;
                    txtNameLast05.Enabled = true;
                }
                pnlAvailableFlights.Visible = false;
                pnlNaming.Visible = true;
            }
            //When user is logged in and tries to add to cart

        }
        //Confirm Button Of Available Flights Page's function

        public void addflight()
        {
            lblErrorAdding.Visible = false;
            lblConfirmAdding.Visible = false;
            if (string.IsNullOrEmpty(cmbToAdding.Text) ||
                string.IsNullOrEmpty(cmbFromAdding.Text) ||
                string.IsNullOrEmpty(cmbBoardingAdding.Text))
            {
                lblErrorAdding.Visible = true;
            }

            else
            {
                string proposedDate = dtpDateOfDepartureAdding.Value.ToString("dd/MM/yyyy");
                string proposedTo = cmbToAdding.Text;
                string proposedFrom = cmbFromAdding.Text;
                string proposedBoardingTime = cmbBoardingAdding.Text;
                string generatedBoardingGate = "A";
                List<string> potentialConflicts = new List<string>();
                List<int> availableGates = new List<int>();

                foreach (var currentFile in System.IO.Directory.GetFiles(FolderDirFlights, "*.txt"))
                {
                    string[] flightDetails = System.IO.File.ReadAllLines(currentFile);
                    if (flightDetails[0] == proposedFrom &&
                        flightDetails[1] == proposedTo &&
                        flightDetails[4] == proposedDate)
                    {
                        if (flightDetails[5] == proposedBoardingTime)
                        {
                            potentialConflicts.Add(flightDetails[6]);
                        }
                    }
                    for (int i = 1; i < 21; i++)
                    {
                        foreach (string takenGates in potentialConflicts)
                        {
                            if (takenGates != ("A" + i))
                            {
                                availableGates.Add(i);
                            }
                        }
                    }
                }
                if (availableGates.Count == 0)
                {
                    generatedBoardingGate = "A1";
                }
                else
                {
                    generatedBoardingGate += availableGates.Min();
                }
                string flightID = this.flightIDGenerator();
                string path = FolderDirFlights + flightID + ".txt";
                string flightData = (proposedFrom + "\r\n" +
                                        proposedTo + "\r\n" +
                                        "35" + "\r\n"+
                                        "15" + "\r\n"+
                                        proposedDate + "\r\n" +
                                        proposedBoardingTime + "\r\n" +
                                        generatedBoardingGate);
                System.IO.File.Create(path).Close();
                using (System.IO.StreamWriter writeTxt =
                       new System.IO.StreamWriter(path, true))
                {
                    writeTxt.WriteLine(flightData);
                }
                string[] namingSequence = System.IO.File.ReadAllLines(FolderDir + "Naming_Sequence.txt");
                System.IO.File.WriteAllText((FolderDir + "Naming_Sequence.txt"), string.Empty);
                string namingSequenceData = (namingSequence[0] + "\r\n" +
                                            namingSequence[1] + "\r\n" +
                                            namingSequence[2] + "\r\n" +
                                            ((int.Parse(namingSequence[3])) + 1));
                using (System.IO.StreamWriter writeTxt =
                       new System.IO.StreamWriter((FolderDir + "Naming_Sequence.txt"), true))
                {
                    writeTxt.WriteLine(namingSequenceData);
                }

                cmbFromAdding.Text = "";
                cmbToAdding.Text = "";
                cmbBoardingAdding.Text = "";
                lblConfirmAdding.Visible = true;
            }
        }
        //add flight function
        
        public void cancel()
        {
            cmbToAdding.Text = "";
            cmbFromAdding.Text = "";
            cmbBoardingAdding.Text = "";
            pnlAddFlights.Visible = false;
            pnlCheckingBooking.Visible = true;
        }
        //Add Flights Page's Cancel Button's function

        public void expiredFlightsCleaner()
        {
            foreach (var currentFile in System.IO.Directory.GetFiles(FolderDirFlights, "*.txt"))
            {
                string[] flightDetails = System.IO.File.ReadAllLines(currentFile);
                DateTime dateOfDeparture = DateTime.ParseExact((flightDetails[4]), "dd/MM/yyyy",
                                                       System.Globalization.CultureInfo.InvariantCulture);
                if (dateOfDeparture < DateTime.Now)
                {
                    string flightNumber = System.IO.Path.GetFileNameWithoutExtension(currentFile);
                    System.IO.File.Delete(FolderDirFlights + flightNumber + ".txt");
                }
            }
        }
        //Deletes expired flight records
    }
}

