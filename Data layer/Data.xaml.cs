using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ParcelTrack
{
    public partial class Window1 : Window
    {
        //Reader & writer info: All variables in Parcel and Courier classes must be defined as <string> in order to work with the CsvHelper extension.
        //Some fields go through conversion to int and back to string in order to change their values
        //Any antivirus programs are blocking the access to creating files
        
        //Initialize the program and fill combo list
        public Window1()
        {
            InitializeComponent();
            combo_courierType.Items.Add("Van");
            combo_courierType.Items.Add("Cycle");
            combo_courierType.Items.Add("Walking");
        }

        //Define the lists
        private static List<Courier> couriers = new List<Courier>();
        private static List<Parcel> parcels = new List<Parcel>();

        //Code under this line is for anything related to the class Courier-------------------------------------------------------------------------------------------------------------------------------

        //Validate input for couriers using regular expressions
        public void CheckCourier()
        {
            string areas = string.Join(",", txtbox_courierAreas.Text);
            int typecheck = combo_courierType.SelectedIndex;
           
            //Validate fields structure
            if (!Regex.Match(txtbox_courierName.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                MessageBox.Show("First name cannot contain special characters.");
            }
            else if (!Regex.Match(txtbox_courierSurname.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                MessageBox.Show("Surname cannot contain special characters.");
            }

            //Validate areas and capacity
            else if (typecheck == 1 & areas.Split(',').Length > 1)
            {
                MessageBox.Show("This type of courier can deliver only to 1 area.");
            }
            else if (typecheck == 2 & areas.Split(',').Length > 1)
            {
                if (!areas.Contains("EH1") || !areas.Contains("EH2") || !areas.Contains("EH3") || !areas.Contains("EH4"))
                {
                    MessageBox.Show("This type of courier can deliver only to one area between postcodes EH1 and EH4.");
                }
            }
            else if (txtbox_courierAreas.Text != "")
            {
                string[] availableareas = { "EH1", "EH2", "EH3", "EH4", "EH5", "EH6", "EH7", "EH8", "EH9", "EH10", "EH11", "EH12", "EH13", "EH14", "EH15", "EH16", "EH17", "EH18", "EH19", "EH20", "EH21", "EH22" };
                string[] splitareas = txtbox_courierAreas.Text.Split(',');
                int errorvalue = 0;
                foreach(string v in splitareas)
                {
                    if(!v.Any(c => availableareas.Contains(v)))
                    {
                        MessageBox.Show("The system only accepts areas between EH1 and EH22.");
                        errorvalue = 1;
                    }
                }
                if(errorvalue == 0)
                {
                    AddNewCourier();
                }
            }
        }

        //Add a new courier after a successful check
        private void AddNewCourier()
        {
            //Assign a unique ID to a courier based on the last ID in list
            int maxID = couriers.Max(x => Convert.ToInt32(x.pub_courierID));
            int newID = maxID + 1;

            //Define an array of packageIDs for the courier
            int[] packages = { };

            //Create a new courier
            Courier newcourier = new();
            newcourier.pub_courierID = Convert.ToString(newID); //Example of necessary conversion for CsvHelper
            newcourier.pub_courierName = txtbox_courierName.Text + " " + txtbox_courierSurname.Text;
            newcourier.pub_courierAreas = txtbox_courierAreas.Text;
            newcourier.pub_courierType = Convert.ToString(combo_courierType.SelectedItem);
            newcourier.pub_courierCapacity = txtbox_courierCapacity.Text;
            newcourier.pub_courierPackages = string.Join(",", packages);
            couriers.Add(newcourier);

            //Clear the text boxes for next input
            txtbox_courierName.Text = "";
            txtbox_courierSurname.Text = "";
            txtbox_courierAreas.Text = "";

            //Set up configuration for CsvHelper extension
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false,
                Comment = '#',
                AllowComments = true,
                Delimiter = ";",
            };

            //Add entry using CsvHelper extension
            using var streamWrit = new StreamWriter("parceltrack_couriers.csv");
            using var csvWriter = new CsvWriter(streamWrit, csvConfig);
            csvWriter.NextRecord();
            csvWriter.WriteRecords(couriers);

            //Write an entry in the info file
            StreamWriter sw = File.AppendText(@"info.txt");
            sw.WriteLine("[ " + DateTime.Now + " ]" + " Successfully added a new courier with ID " + newcourier.pub_courierID);
            sw.Close();

        }

        //Load csv file into the couriers list
        public void CourierReader()
        {
            //Avoid 'empty' error through checking if the file has any data
            if (new FileInfo(@"parceltrack_couriers.csv").Length != 0)
            {
                //Set up configuration for CsvHelper extension
                var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    HasHeaderRecord = false,
                    Comment = '#',
                    AllowComments = true,
                    Delimiter = ";",
                };

                //Set up the CsvHelper extension reader
                using var streamReader = File.OpenText("parceltrack_couriers.csv");
                using var csvReader = new CsvReader(streamReader, csvConfig);

                //Load contents into the parcels list
                while (csvReader.Read())
                {
                    var pub_courierID = csvReader.GetField(0);
                    var pub_courierName = csvReader.GetField(1);
                    var pub_courierAreas = csvReader.GetField(2);
                    var pub_courierType = csvReader.GetField(3);
                    var pub_courierCapacity = csvReader.GetField(4);
                    var pub_courierPackages = csvReader.GetField(5);

                    Courier newcourier = new();
                    newcourier.pub_courierID = pub_courierID;
                    newcourier.pub_courierName = pub_courierName;
                    newcourier.pub_courierAreas = pub_courierAreas;
                    newcourier.pub_courierType = pub_courierType;
                    newcourier.pub_courierCapacity = pub_courierCapacity;
                    newcourier.pub_courierPackages = string.Join(",", pub_courierPackages);
                    couriers.Add(newcourier);
                }
            } else
            {
                MessageBox.Show("Parcels file has no contents. Initializing program with empty file.");
            }
        }

        //Display all couriers
        public void ShowCouriers()
        {
            List<string> showcouriers = new();
            foreach (var v in couriers)
            {
                string addcourierentry = "Name: " + v.pub_courierName + " Areas: " + v.pub_courierAreas + 
                    " Type: " + v.pub_courierType + " Capacity: " + v.pub_courierCapacity;
                showcouriers.Add(addcourierentry);
            }
            var message = string.Join(Environment.NewLine, showcouriers.ToArray());
            MessageBox.Show(message, "Showing all couriers");
        }

        //Code under this line is for anything related to the class Parcel-------------------------------------------------------------------------------------------------------------------------------

        //Parcel validation
        public void CheckParcel()
        {
            if (!Regex.Match(txtbox_receiverName.Text, "^[A-Z][a-zA-Z]*$").Success 
                || !Regex.Match(txtbox_receiverSurname.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                MessageBox.Show("Receiver first name and surname must start with a capital cannot contain special characters.");
            } 
            else if (!Regex.Match(txtbox_senderName.Text, "^[A-Z][a-zA-Z]*$").Success 
                || !Regex.Match(txtbox_senderSurname.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                MessageBox.Show("Sender first name and surname must start with a capital and cannot contain special characters.");
            } 
            else if (!txtbox_postcode.Text.Contains(" "))
            {
                MessageBox.Show("The postcode must be separated by space.");
            }
            else if (txtbox_postcode.Text != "")
            {
                string[] availableareas = { "EH1", "EH2", "EH3", "EH4", "EH5", "EH6", "EH7", "EH8", "EH9", 
                    "EH10", "EH11", "EH12", "EH13", "EH14", "EH15", "EH16", "EH17", "EH18", "EH19", "EH20", "EH21", "EH22" };
                var splitarea = txtbox_postcode.Text.Split(' ')[0];
                int errorvalue = 0;
                if (!splitarea.Any(c => availableareas.Contains(splitarea)))
                {
                    MessageBox.Show("The system only accepts areas between EH1 and EH22.");
                    errorvalue = 1;
                }
                else if (errorvalue == 0)
                {
                    AddNewParcel();
                }
            }
        }

        //Add parcel and assign it to a courier after a successful check
        public void AddNewParcel()
        {
            string availableCourier;

            //Find an available courier
            if (couriers.FirstOrDefault(x => x.pub_courierAreas.Contains(txtbox_postcode.Text.Split(' ')[0])) != null)
            {
                //Assign the courier to the package
                availableCourier = (from x in couriers where x.pub_courierCapacity != "0" 
                                    && x.pub_courierAreas.Contains(txtbox_postcode.Text.Split(' ')[0]) 
                                    select x.pub_courierID).First();
                
                //Assign a unique ID to package through checking last known parcelID in loaded list
                int maxID = parcels.Max(x => Convert.ToInt32(x.pub_packageID));
                int newID = maxID + 1;

                //Create a new parcel
                Parcel newparcel = new();
                newparcel.pub_packageID = Convert.ToString(newID);
                newparcel.pub_street = txtbox_street.Text;
                newparcel.pub_postcode = txtbox_postcode.Text;
                newparcel.pub_receiverName = txtbox_receiverName.Text + " " + txtbox_receiverSurname.Text;
                newparcel.pub_senderName = txtbox_senderName.Text + " " + txtbox_senderSurname.Text;
                parcels.Add(newparcel);

                //Cleaning up WPF textboxes for new input
                txtbox_street.Text = "";
                txtbox_postcode.Text = "";
                txtbox_receiverName.Text = "";
                txtbox_receiverSurname.Text = "";
                txtbox_senderName.Text = "";
                txtbox_senderSurname.Text = "";

                //Updating courier record both in couriers list and the csv file
                foreach(Courier c in couriers.Where(c => c.pub_courierID == availableCourier))
                {
                    c.pub_courierPackages = c.pub_courierPackages + "," + newID;
                    int changecapacity = Convert.ToInt32(c.pub_courierCapacity) - 1;
                    string newcapacity = Convert.ToString(changecapacity);
                    c.pub_courierCapacity = newcapacity;

                    //Write the changes live to the courier csv file
                    var csvConfig2 = new CsvConfiguration(CultureInfo.CurrentCulture)
                    {
                        HasHeaderRecord = false,
                        Comment = '#',
                        AllowComments = true,
                        Delimiter = ";",
                    };

                    using var streamWrit2 = new StreamWriter("parceltrack_couriers.csv");
                    using var csvWriter2 = new CsvWriter(streamWrit2, csvConfig2);
                    csvWriter2.NextRecord();
                    csvWriter2.WriteRecords(couriers);
                }

                //Write the changes live to the parcels csv file
                var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    HasHeaderRecord = false,
                    Comment = '#',
                    AllowComments = true,
                    Delimiter = ";",
                };

                using var streamWrit = new StreamWriter("parceltrack_parcels.csv");
                using var csvWriter = new CsvWriter(streamWrit, csvConfig);
                csvWriter.NextRecord();
                csvWriter.WriteRecords(parcels);

                //Write an entry in the info file
                StreamWriter sw = File.AppendText(@"info.txt");
                sw.WriteLine("[ " + DateTime.Now + " ]" + " Successfully added a new parcel with ID " 
                    + newparcel.pub_packageID + " and assigned to courier with ID " + availableCourier);
                sw.Close();
            }
            else
            {
                MessageBox.Show("No couriers available for your package at this time");
            }
        }

        //Read the parcel csv file and insert contents into the list
        public void ParcelReader()
        {
            if (new FileInfo(@"parceltrack_parcels.csv").Length != 0)
            {
                var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    HasHeaderRecord = false,
                    Comment = '#',
                    AllowComments = true,
                    Delimiter = ";",
                };

                using var streamReader = File.OpenText("parceltrack_parcels.csv");
                using var csvReader = new CsvReader(streamReader, csvConfig);

                while (csvReader.Read())
                {
                    var pub_packageID = csvReader.GetField(0);
                    var pub_street = csvReader.GetField(1);
                    var pub_postcode = csvReader.GetField(2);
                    var pub_receiverName = csvReader.GetField(3);
                    var pub_senderName = csvReader.GetField(4);

                    Parcel newparcel = new();
                    newparcel.pub_packageID = pub_packageID;
                    newparcel.pub_street = pub_street;
                    newparcel.pub_postcode = pub_postcode;
                    newparcel.pub_receiverName = pub_receiverName;
                    newparcel.pub_senderName = pub_senderName;
                    parcels.Add(newparcel);
                }
            }
        }

        //Code under this line is for constructing Deliveries, Transferring packages and defining buttons-------------------------------------------------------------------------------------------------------------------------------


        private void Button_Parcel_Click(object sender, RoutedEventArgs e)
        {
            CheckParcel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckCourier();
        }

        //Update courier capacity based on combo box selection
        private void combo_courierType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int typecheck = combo_courierType.SelectedIndex;
            if (typecheck == 0)
            {
                txtbox_courierCapacity.Text = "100";
            }
            else if (typecheck == 1)
            {
                txtbox_courierCapacity.Text = "10";
            }
            else if (typecheck == 2)
            {
                txtbox_courierCapacity.Text = "5";
            }
        }

        //Construct a delivery for a specified courierID
        public void ShowDelivery(string courierDetails)
        {
            //Check if the given courier exists
            Courier courierID = couriers.FirstOrDefault(c => c.pub_courierID == courierDetails);

            if (courierID != null)
            {
                //Obtain courier packages
                string[] packageID = (from x in couriers where x.pub_courierID == courierDetails 
                                      && x.pub_courierPackages != null select x.pub_courierPackages).ToArray();

                //Successful match to ID, construct a delivery list for a courier
                if (packageID.Length != 0)
                {
                    //Selecting an array value requires making a string and splitting it
                    string[] packages = packageID.ToArray();
                    string bridge = packages[0];
                    List<string> result = new();

                    foreach (string s in bridge.Split(','))
                    {
                        foreach (Parcel p in parcels.Where(p => p.pub_packageID == s))
                        {
                            string targetParcel = "Street: " + p.pub_street + " postcode: " + p.pub_postcode 
                                + " sender: " + p.pub_senderName + " receiver: " + p.pub_receiverName;
                            result.Add(targetParcel);
                        }
                    }

                    //Display the results
                    var message = string.Join(Environment.NewLine, result.ToArray());
                    MessageBox.Show(message, "Showing deliveries for courier with ID: " + courierDetails);

                    //Clear for next input
                    result.Clear();
                    message = string.Empty;
                }
                else
                {
                    MessageBox.Show("This courier does not have any packages assigned.");
                }
            }
            else
            {
                MessageBox.Show("A courier with such ID does not exist, please try again.");
            }
        }
        
        public void TransferParcel(string target, string destination, string parcelToTransfer)
        {
            //Validation
            if (couriers.FirstOrDefault(c => c.pub_courierID == target) != null 
                && couriers.FirstOrDefault(c => c.pub_courierID == destination) != null 
                && couriers.FirstOrDefault(c => c.pub_courierPackages.Contains(parcelToTransfer)) != null
                && couriers.FirstOrDefault(c => c.pub_courierCapacity != "0") != null)
            {
                string[] targetCourier = (from x in couriers where x.pub_courierID == target select x.pub_courierID).ToArray();
                string[] destinationCourier = (from x in couriers where x.pub_courierID == destination select x.pub_courierID).ToArray();

                //Transfer package from specified courier
                foreach (Courier c in couriers.Where(c => c.pub_courierID == targetCourier[0]))
                {
                    c.pub_courierPackages = c.pub_courierPackages.Replace("," + parcelToTransfer, "");
                    int newcapacity = Convert.ToInt32(c.pub_courierCapacity) + 1;
                    c.pub_courierCapacity = Convert.ToString(newcapacity);
                }

                //Transfer package to the specified courier
                foreach (Courier c in couriers.Where(c => c.pub_courierID == destinationCourier[0]))
                {
                    if (c.pub_courierCapacity != "0")
                    {
                        c.pub_courierPackages = String.Concat(c.pub_courierPackages, "," + parcelToTransfer);
                        int newcapacity = Convert.ToInt32(c.pub_courierCapacity) - 1;
                        c.pub_courierCapacity = Convert.ToString(newcapacity);
                    } else
                    {
                        MessageBox.Show("This courier is full.");
                    }
                }

                //Update the CSV file with the transfer data
                var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    HasHeaderRecord = false,
                    Comment = '#',
                    AllowComments = true,
                    Delimiter = ";",
                };

                //Add entry using CsvHelper extension
                using var streamWrit = new StreamWriter("parceltrack_couriers.csv");
                using var csvWriter = new CsvWriter(streamWrit, csvConfig);
                csvWriter.NextRecord();
                csvWriter.WriteRecords(couriers);

                //Write an entry in the info file
                StreamWriter sw = File.AppendText(@"info.txt");
                sw.WriteLine("[ " + DateTime.Now + " ]" + " Successfully transferred parcel " + parcelToTransfer + " from courier: " + target + "to courier: " + destination);
                sw.Close();

            } else
            {
                MessageBox.Show("Specified courier or package does not exist.");
            }
        }
    }
}


