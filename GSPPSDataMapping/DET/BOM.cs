using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections;

namespace GSPPSDataMapping.DET
{
    class BOM
    {
        #region MEMBERS
        //private string defaultValue;//Default
        //private string recordType;//PKGEXT-RECORD-TYPE
        private string packedServicePart;//PKGEXT-PACKED-SERVICE-PART
        private int specType;//PKGEXT-PACKAGING-TYPE
        private string version;//PKGEXT-VERSION
        private string servicePartNumber;//PKGEXT-SERVICE-PART-NUMBER.
        private string subPackFlag;//PKGEXT-SUB-PACK
        private string countryOfOrigin;//PKGEXT-CO-CD
        private int bomPartQuantity = 0;//PKGEXT-BOM-QTY
        private string bomPartPrefix;//PKGEXT-BOM-SVC-PRF (Right align)
        private string bomPartBase;//PKGEXT-BOM-SVC-BSE (Right align)
        private string bomPartSuffix;//PKGEXT-BOM-SVC-SUF (Left align)
        private string servicePN;//PKGEXT-SERVICE-PN.
        private string bomEngineeringPrefix;//PKGEXT-BOM-ENG-PRF (Right align)
        private string bomEngineeringBase;//PKGEXT-BOM-ENG-BSE (Right align)
        private string bomEngineeringSuffix;//PKGEXT-BOM-ENG-SUF (Left align)
        private string name;//PKGEXT-BOM-PART-NAME (ENG)
        private string engineeringPN;//PKGEXT-ENG-PN.
        private string firNo;//PKGEXT-BOM-TOX-NO
        private string countryCode;//PKGEXT-COUNTRY-CODE5
        private string companyCode;//PKGEXT-COMPANY-CODE5
        //FILLER
        #endregion

        #region ACCESSORS
        public string PackedServicePart
        {
            get { return packedServicePart; }
            set { packedServicePart = value; }
        }
        public int SpecType
        {
            get { return specType; }
            set { specType = value; }
        }
        public string Version
        {
            get { return version; }
            set { version = value; }
        }
        public string ServicePartNo
        {
            get { return servicePartNumber; }
            set { servicePartNumber = value; }
        }
        public string SubPackFlag
        {
            get { return subPackFlag; }
            set { subPackFlag = value; }
        }
        public string CO
        {
            get { return countryOfOrigin; }
            set { countryOfOrigin = value; }
        }
        public int Qty
        {
            get { return bomPartQuantity; }
            set { bomPartQuantity = value; }
        }
        public string BomPartPrefix
        {
            get { return bomPartPrefix; }
            set { bomPartPrefix = value; }
        }
        public string BomPartBase
        {
            get { return bomPartBase; }
            set { bomPartBase = value; }
        }
        public string BomPartSuffix
        {
            get { return bomPartSuffix; }
            set { bomPartSuffix = value; }
        }
        public string BomEngineeringPrefix
        {
            get { return bomEngineeringPrefix; }
            set { bomEngineeringPrefix = value; }
        }
        public string BomEngineeringBase
        {
            get { return bomEngineeringBase; }
            set { bomEngineeringBase = value; }
        }
        public string BomEngineeringSuffix
        {
            get { return bomEngineeringSuffix; }
            set { bomEngineeringSuffix = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string FirNo
        {
            get { return firNo; }
            set { firNo = value; }
        }
        public string CountryCode
        {
            get { return countryCode; }
            set { countryCode = value; }
        }
        public string CompanyCode
        {
            get { return companyCode; }
            set { companyCode = value; }
        }
        public string ServicePN
        {
            get { return servicePN; }
            set { servicePN = value; }
        }
        public string EngineeringPN
        {
            get { return engineeringPN; }
            set { engineeringPN = value; }
        }

        #endregion

        public BOM(string line, string sPNo)
        {
            //defaultValue = line.Substring(0, 3).Trim();
            //recordType = line.Substring(3, 1).Trim();
            packedServicePart = line.Substring(4, 18).Trim();
            specType = Int32.Parse(line.Substring(22, 2).Trim());
            version = line.Substring(24, 3).Trim();
            servicePartNumber = sPNo;

            subPackFlag = line.Substring(27, 1).Trim();
            countryOfOrigin = line.Substring(28, 2).Trim();
            bomPartQuantity = Int32.Parse(line.Substring(30, 3).Trim());

            bomPartPrefix = line.Substring(33, 5).Trim();
            bomPartBase = line.Substring(38, 8).Trim();
            bomPartSuffix = line.Substring(46, 5).Trim();
            servicePN = bomPartPrefix + bomPartBase + bomPartSuffix;

            bomEngineeringPrefix = line.Substring(51, 6).Trim();
            bomEngineeringBase = line.Substring(57, 8).Trim();
            bomEngineeringSuffix = line.Substring(65, 8).Trim();
            engineeringPN = bomEngineeringPrefix + bomEngineeringBase + bomEngineeringSuffix;

            name = line.Substring(73, 22).Trim();
            firNo = line.Substring(95, 6).Trim();
            countryCode = line.Substring(101, 2).Trim();
            companyCode = line.Substring(103, 2).Trim();
            //line.Substring(105, 243).Trim();
        }
    }
}