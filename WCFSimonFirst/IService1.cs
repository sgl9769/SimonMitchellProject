using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.IO;
using MySql.Data.MySqlClient;

namespace WCFSimonFirst
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    public class Create
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\users\Simon Lee\Desktop\Coding Challenge\create-claim.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/MitchellClaim");

            List<LossInfoType> loss_info_type_list = new List<LossInfoType>();
            List<MitchellClaimType> mitchell_claim_type_list = new List<MitchellClaimType>();
            List<VehicleInfoType> vehicle_info_type_list = new List<VehicleInfoType>();

            foreach (XmlNode node in nodes)
            {
                LossInfoType loss_info_type = new LossInfoType();

                loss_info_type.CauseOfLoss = node.SelectSingleNode("CauseOfLoss").InnerText;
                loss_info_type.ReportedDate = node.SelectSingleNode("ReportedDate").InnerText;
                loss_info_type.LossDescription = node.SelectSingleNode("LossDescription").InnerText;

                loss_info_type_list.Add(loss_info_type);

                MitchellClaimType mitchell_claim_type = new MitchellClaimType();

                mitchell_claim_type.ClaimNumber = node.SelectSingleNode("ClaimNumber").InnerText;
                mitchell_claim_type.ClaimantFirstName = node.SelectSingleNode("ClaimantFirstName").InnerText;
                mitchell_claim_type.ClaimantLastName = node.SelectSingleNode("ClaimLastName").InnerText;
                mitchell_claim_type.Status = node.SelectSingleNode("Status").InnerText;
                mitchell_claim_type.LossDate = node.SelectSingleNode("LossDate").InnerText;
                mitchell_claim_type.CauseOfLoss = node.SelectSingleNode("CauseOfLoss").InnerText;
                mitchell_claim_type.ReportedDate = node.SelectSingleNode("ReportedDate").InnerText;
                mitchell_claim_type.LossDescription = node.SelectSingleNode("LossDescription").InnerText;
                mitchell_claim_type.AssignedAdjusterID = node.SelectSingleNode("AssignedAdjusterID").InnerText;

                mitchell_claim_type_list.Add(mitchell_claim_type);

                VehicleInfoType vehicle_info_type = new VehicleInfoType();

                vehicle_info_type.ModelYear = node.SelectSingleNode("ModelYear").InnerText;
                vehicle_info_type.MakeDescription = node.SelectSingleNode("MakeDescription").InnerText;
                vehicle_info_type.ModelDescription = node.SelectSingleNode("ModelDescription").InnerText;
                vehicle_info_type.EngineDescription = node.SelectSingleNode("EngineDescription").InnerText;
                vehicle_info_type.ExteriorColor = node.SelectSingleNode("ExteriorColor").InnerText;
                vehicle_info_type.Vin = node.SelectSingleNode("Vin").InnerText;
                vehicle_info_type.LicPlate = node.SelectSingleNode("LicPlate").InnerText;
                vehicle_info_type.LicPlateState = node.SelectSingleNode("LicPlateState").InnerText;
                vehicle_info_type.LicPlateExpDate = node.SelectSingleNode("LicPlateExpDate").InnerText;
                vehicle_info_type.DamageDescription = node.SelectSingleNode("DamageDescription").InnerText;
                vehicle_info_type.Mileage = node.SelectSingleNode("Mileage").InnerText;

                vehicle_info_type_list.Add(vehicle_info_type);


                string MyConnection2 = "datasource=localhost;port=3307;username=root;password=root";
            }

            Console.ReadKey();
        }
    }

    public class LossInfoType
    {
        public string CauseOfLoss;
        public string ReportedDate;   //Need to convert this to type DateTime later
        public string LossDescription;
    }

    public class MitchellClaimType
    {
        public string ClaimNumber;
        public string ClaimantFirstName;
        public string ClaimantLastName;
        public string Status;
        public string LossDate;   //Need to convert this to type DateTime later
        public string CauseOfLoss;
        public string ReportedDate;
        public string LossDescription;
        public string AssignedAdjusterID; //Need to convert this to type DateTimeLater
        public VehicleInfoType[] Vehicles;
    }

    public class VehicleInfoType
    {
        public string ModelYear;   //Need to convert this to int later
        public string MakeDescription;
        public string ModelDescription;
        public string EngineDescription;
        public string ExteriorColor;
        public string Vin;
        public string LicPlate;
        public string LicPlateState;
        public string LicPlateExpDate;  //Need to convert this to DateTime later
        public string DamageDescription;
        public string Mileage;  //Need to convert this to int later
    }

}
