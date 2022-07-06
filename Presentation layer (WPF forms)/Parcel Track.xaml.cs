using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace ParcelTrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window1 refwindow = new Window1();
        public MainWindow()
        {
            CheckFiles(); //Check if databases exist and create them if not
            Window1 refwindow = new Window1();
            refwindow.InitializeComponent(); //Load the parcels
            refwindow.ParcelReader(); //from file into list
            refwindow.CourierReader();
            InitializeComponent();
        }

        public void CheckFiles()
        {
            if (!File.Exists(@"parceltrack_parcels.csv")){
                File.Create(@"parceltrack_parcels.csv");
            }

            if (!File.Exists(@"parceltrack_couriers.csv"))
            {
                File.Create(@"parceltrack_couriers.csv");
            }

            if (!File.Exists(@"info.txt"))
            {
                File.Create(@"info.txt");
            }
        }

        public void UpdateOutput()
        {
            string[] lines = File.ReadAllLines(@"info.txt");
        }

        private void btn_AddParcelOrCourier(object sender, RoutedEventArgs e)
        {
            Window1 refwindow = new();
            refwindow.Show();
        }

        private void btn_TransferParcel(object sender, RoutedEventArgs e)
        {
            string target = txtbox_targetID.Text;
            string destination = txtbox_destinationID.Text;
            string parcelToTransfer = txtbox_parcelTransferID.Text;
            refwindow.TransferParcel(target, destination, parcelToTransfer);
        }

        private void btn_ShowAllCouriers(object sender, RoutedEventArgs e)
        {
            refwindow.ShowCouriers();
        }

        private void btn_SaveExit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_DisplayDelivery(object sender, RoutedEventArgs e)
        {
            Window1 refwindow = new Window1();
            string courierDetails = txtbox_courierDetails.Text;
            refwindow.ShowDelivery(courierDetails);
        }
    }
}
