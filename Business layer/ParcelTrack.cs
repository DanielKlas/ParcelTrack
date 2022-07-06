using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ParcelTrack
{

    public class Parcel
    {
        private string packageID;
        private string street;
        private string postcode;
        private string receiverName;
        private string senderName;

        public string pub_packageID
        { get { return packageID; } set { packageID = value; } }
        public string pub_street
        { get { return street; } set { street = value; } }
        public string pub_postcode
        { get { return postcode; } set { postcode = value; } }
        public string pub_receiverName
        { get { return receiverName; } set { receiverName = value; } }
        public string pub_senderName
        { get { return senderName; } set { senderName = value; } }
    }

    public class Courier : Parcel
    {
        private string courierID;
        private string courierName;
        private string courierAreas;
        private string courierType;
        private string courierCapacity;
        private string courierPackages;

        public string pub_courierID
        { get { return courierID; } set { courierID = value; } }
        public string pub_courierName
        { get { return courierName; } set { courierName = value; } }
        public string pub_courierAreas
        { get { return courierAreas; } set { courierAreas = value; } }
        public string pub_courierType
        { get { return courierType; } set { courierType = value; } }
        public string pub_courierCapacity
        { get { return courierCapacity; } set { courierCapacity = value; } }
        public string pub_courierPackages
        { get { return courierPackages; } set { courierPackages = value; } }
    }
}
