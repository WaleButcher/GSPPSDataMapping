using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data;

namespace GSPPSDataMapping.DET
{
    class SPECIFICATION
    {
        #region MEMBERS
        //private string defaultValue;//Default
        //private string recordType;//PKGEXT-RECORD-TYPE
        private string packedServicePart = "";//PKGEXT-PACKED-SERVICE-PART
        private int specType = 1;//PKGEXT-PACKAGING-TYPE
        private string version = "";//PKGEXT-VERSION
        private string servicePartNumber = "";//PKGEXT-SERVICE-PART-NUMBER.
        private string servicePartBase = "";//PKGEXT-SERVICE-PART-BASE  (Right align)
        private string servicePartPrefix = "";//PKGEXT-SERVICE-PART-PREFIX (Left align)
        private string servicePartSuffix = "";//PKGEXT-SERVICE-PART-SUFFIX (Left Algin)
        private string salesPartNo = "";//PKGEXT-MOTORCRAFT-NUMBER
        private string engineeringPartNo = "";//PKGEXT-ENGINEER-NUMBER
        private string partName = "";//PKGEXT-PART-NAME
        private string responsibleEngineer = "";//PKGEXT-ENG-INITIALS
        private DateTime effectiveDate = Convert.ToDateTime("1/1/1900");//PKGEXT-EFFECTIVE-DATE
        private int unitPackageQuantity = 0;//PKGEXT-UNIT-PKS-QUANTITY
        private int unitizationPerLength = 0;//PKGEXT-CNTR-PER-LENGTH
        private int unitizationPerWidth = 0;//PKGEXT-CNTR-PER-WIDTH
        private int unitizationPerDepth = 0;//PKGEXT-CNTR-PER-DEPTH
        private double weight = 0.0;//PKGEXT-PKG-WGT-Q
        private string costPackaging = "";//PKGEXT-COST-PACKAGING
        private string countryCode = "";//PKGEXT-COUNTRY-CODE
        private string companyCode = "";//PKGEXT-COMPANY-CODE
        private DateTime issueDate = Convert.ToDateTime("1/1/1900");//PKGEXT-SPEC-UPDATE-DATE
        private DateTime priorDate = Convert.ToDateTime("1/1/1900");//PKGEXT-PREV-SPEC-DATE
        private DateTime expirationDate = Convert.ToDateTime("1/1/1900");//PKGEXT-EXPIRATION-DATE
        private string merchandiseBrand = "";//PKGEXT-MERCHANDISE-BRAND
        private string merchandiseBrandDescription = "";//PKGEXT-MRCH-BRND-DESC
        private string countryOfOrigin = "";//PKGEXT-COUNTRY-MADEIN
        private string issuingEngineer = "";//PKGEXT-ISSUE-BY-INITIALS
        private string pdcLocation = "";//PKGEXT-PDC-LOC
        private string warehouseLocation = "";//PKGEXT-WAREHOUSE-LOCATION
        private string partDirShipC = "";//PKGEXT-SPART-DIR-SHIP-C
        private string detailStatus = "";//PKGEXT-DETAIL-STATUS
        private DateTime partObsoleteEffectiveDate = Convert.ToDateTime("1/1/1900");//PKGEXT-SPART-OBS-EFF-Y
        private string kitPap = "";//PKGEXT-SPART-KIT-PAP-C
        private string primeSupplier = "";//PKGEXT-PRIME-SUPPLIER
        private string secSupplier = "";//PKGEXT-SEC-SUPPLIER
        private string vendorToAdvice = "";//PKGEXT-VENDOR-TO-ADVISE-IND
        private string engineeringPart1 = "";//PKGEXT-ENG-PART-1
        private string engineeringPart2 = "";//PKGEXT-ENG-PART-2 REDEFINES
        private string engineeringPartPrefix = "";//PKGEXT-ENG-PREFIX (Right align)
        private string engineeringPartBase = "";//PKGEXT-ENG-BASE (Right align)
        private string engineeringPartSuffix = "";//PKGEXT-ENG-SUFFIX (Left align)
        private string endItemFinisNo = "";//PKGEXT-ENGP-FINIS-NBR
        private ArrayList engineeringNumbers = new ArrayList();
        private ArrayList finisNumbers = new ArrayList();
        private string motorCraftPrefix = "";//PKGEXT-MOTORCRAFT-PREFIX
        private string motorCraftBase = "";//PKGEXT-MOTORCRAFT-BASE
        private string motorCraftSuffix = "";//PKGEXT-MOTORCRAFT-SUFFIX

        private string upcCode = "";
        private string upcCodeNumber = "";
        #endregion

        #region CHECK IF SPEC IS B969F
        public bool isB969F()
        {
            return string.Equals(this.PrimarySupplier, "B969F") || string.Equals(this.SecondarySupplier, "B969F");
        }
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
        public string ServicePartBase
        {
            get { return servicePartBase; }
            set { servicePartBase = value; }
        }
        public string ServicePartPrefix
        {
            get { return servicePartPrefix; }
            set { servicePartPrefix = value; }
        }
        public string ServicePartSuffix
        {
            get { return servicePartSuffix; }
            set { servicePartSuffix = value; }
        }
        public string SalesPartNo
        {
            get { return salesPartNo; }
            set { salesPartNo = value; }
        }
        public string EngineeringPartNo
        {
            get { return engineeringPartNo; }
            set { engineeringPartNo = value; }
        }
        public string PartName
        {
            get { return partName; }
            set { partName = value; }
        }
        public string ResponsibleEngineer
        {
            get { return responsibleEngineer; }
            set { responsibleEngineer = value; }
        }
        public DateTime EffectiveDate
        {
            get { return effectiveDate; }
            set { effectiveDate = value; }
        }
        public int UnitPackageQuantity
        {
            get { return unitPackageQuantity; }
            set { unitPackageQuantity = value; }
        }
        public int UnitOfIssue
        {
            get { return unitPackageQuantity; }
            set { unitPackageQuantity = value; }
        }
        public int UnitizationPerLength
        {
            get { return unitizationPerLength; }
            set { unitizationPerLength = value; }
        }
        public int UnitizationPerWidth
        {
            get { return unitizationPerWidth; }
            set { unitizationPerWidth = value; }
        }
        public int UnitizationPerDepth
        {
            get { return unitizationPerDepth; }
            set { unitizationPerDepth = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public string CostPackaging
        {
            get { return costPackaging; }
            set { costPackaging = value; }
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
        public DateTime IssueDate
        {
            get { return issueDate; }
            set { issueDate = value; }
        }
        public DateTime PriorDate
        {
            get { return priorDate; }
            set { priorDate = value; }
        }
        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }
        public string MerchandiseBrand
        {
            get { return merchandiseBrand; }
            set { merchandiseBrand = value; }
        }
        public string MerchandiseBrandDescription
        {
            get { return merchandiseBrandDescription; }
            set { merchandiseBrandDescription = value; }
        }
        public string CountryOfOrigin
        {
            get { return countryOfOrigin; }
            set { countryOfOrigin = value; }
        }
        public string IssuingEngineer
        {
            get { return issuingEngineer; }
            set { issuingEngineer = value; }
        }
        public string PdcLocation
        {
            get { return pdcLocation; }
            set { pdcLocation = value; }
        }
        public string WarehouseLocation
        {
            get { return warehouseLocation; }
            set { warehouseLocation = value; }
        }
        public string PartDirShipC
        {
            get { return partDirShipC; }
            set { partDirShipC = value; }
        }
        public string DetailStatus
        {
            get { return detailStatus; }
            set { detailStatus = value; }
        }
        public DateTime PartObsoleteEffectiveDate
        {
            get { return partObsoleteEffectiveDate; }
            set { partObsoleteEffectiveDate = value; }
        }
        public string KitPap
        {
            get { return kitPap; }
            set { kitPap = value; }
        }
        public string PrimarySupplier
        {
            get { return primeSupplier; }
            set { primeSupplier = value; }
        }
        public string SecondarySupplier
        {
            get { return secSupplier; }
            set { secSupplier = value; }
        }
        public string VendorToAdvice
        {
            get { return vendorToAdvice; }
            set { vendorToAdvice = value; }
        }
        public string EngineeringPart1
        {
            get { return engineeringPart1; }
            set { engineeringPart1 = value; }
        }
        public string EngineeringPart2
        {
            get { return engineeringPart2; }
            set { engineeringPart2 = value; }
        }
        public string EngineeringPartPrefix
        {
            get { return engineeringPartPrefix; }
            set { engineeringPartPrefix = value; }
        }
        public string EngineeringPartBase
        {
            get { return engineeringPartBase; }
            set { engineeringPartBase = value; }
        }
        public string EngineeringPartSuffix
        {
            get { return engineeringPartSuffix; }
            set { engineeringPartSuffix = value; }
        }
        public string EndItemFinisNo
        {
            get { return endItemFinisNo; }
            set { endItemFinisNo = value; }
        }
        public ArrayList FinisNumbers
        {
            get { return finisNumbers; }
            set { this.finisNumbers = value; }
        }
        public ArrayList EngineeringNumbers
        {
            get { return engineeringNumbers; }
            set { this.engineeringNumbers = value; }
        }
        public string UpcCode
        {
            get { return upcCode; }
            set { this.upcCode = value; }
        }
        public string UpcCodeNumber
        {
            get { return upcCodeNumber; }
            set { this.upcCodeNumber = value; }
        }
        #endregion

        public SPECIFICATION(string line)
        {
            //latest changes to layout does not give complete line for parsing
            if (line.Length < 368)
            {
                line = line.PadRight(368, ' ');
            }
            //defaultValue = line.Substring(0, 3).Trim();
            //recordType = line.Substring(3, 1).Trim();
            packedServicePart = line.Substring(4, 18).Trim();
            specType = Int32.Parse(line.Substring(22, 2).Trim());
            version = line.Substring(24, 3).Trim();

            servicePartBase = line.Substring(27, 8).Trim();
            servicePartPrefix = line.Substring(35, 5).Trim();
            servicePartSuffix = line.Substring(40, 5).Trim();
            servicePartNumber = servicePartPrefix + "-" + servicePartBase + "-" + servicePartSuffix;

            salesPartNo = line.Substring(45, 18).Trim();
            engineeringPartNo = line.Substring(63, 22).Trim();
            partName = line.Substring(85, 20).Trim();
            responsibleEngineer = line.Substring(105, 5).Trim();
            try { effectiveDate = DateTime.ParseExact(line.Substring(110, 8).Trim(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture); }
            catch (Exception) { effectiveDate = DateTime.Now; }
            unitPackageQuantity = Int32.Parse(line.Substring(118, 5).Trim());
            unitizationPerLength = Int32.Parse(line.Substring(123, 3).Trim());
            unitizationPerWidth = Int32.Parse(line.Substring(126, 3).Trim());
            unitizationPerDepth = Int32.Parse(line.Substring(129, 3).Trim());
            weight = Math.Round(Double.Parse(line.Substring(132, 8).Trim()), 2);
            costPackaging = line.Substring(140, 16).Trim();
            countryCode = line.Substring(156, 2).Trim();
            companyCode = line.Substring(158, 2).Trim();
            try { issueDate = DateTime.ParseExact(line.Substring(160, 8).Trim(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture); }
            catch (Exception) { issueDate = Convert.ToDateTime("1/1/1900"); }
            try { priorDate = DateTime.ParseExact(line.Substring(168, 8).Trim(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture); }
            catch (Exception) { priorDate = Convert.ToDateTime("1/1/1900"); }
            //try { expirationDate = DateTime.ParseExact(line.Substring(176, 8).Trim(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture); }
            //catch (Exception) { expirationDate = Convert.ToDateTime("12/31/9999"); }
            merchandiseBrand = line.Substring(184, 2).Trim();
            merchandiseBrandDescription = line.Substring(186, 40).Trim();
            countryOfOrigin = line.Substring(226, 2).Trim();
            issuingEngineer = line.Substring(228, 5).Trim();
            pdcLocation = line.Substring(233, 2).Trim();
            warehouseLocation = line.Substring(235, 9).Trim();
            partDirShipC = line.Substring(244, 1).Trim();
            detailStatus = line.Substring(245, 2).Trim();
            try { partObsoleteEffectiveDate = DateTime.ParseExact(line.Substring(247, 10).Trim(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture); }
            catch (Exception) { partObsoleteEffectiveDate = Convert.ToDateTime("12/31/9999"); }
            try { expirationDate = PartObsoleteEffectiveDate; expirationDate = expirationDate.AddYears(2); }
            catch (Exception) { expirationDate = Convert.ToDateTime("12/31/9999"); }
            kitPap = line.Substring(257, 1).Trim();
            primeSupplier = line.Substring(258, 5).Trim();
            secSupplier = line.Substring(263, 5).Trim();
            vendorToAdvice = line.Substring(268, 1).Trim();

            engineeringPartPrefix = line.Substring(269, 6).Trim();
            engineeringPartBase = line.Substring(275, 8).Trim();
            engineeringPartSuffix = line.Substring(283, 8).Trim();
            //if (engineeringPartPrefix != "" || engineeringPartBase != "" || engineeringPartSuffix != "")
            if (engineeringPartBase != "")
            {
                engineeringPart1 = engineeringPartPrefix + "-" + engineeringPartBase + "-" + engineeringPartSuffix;
                engineeringPart2 = engineeringPart1.Trim();
                engineeringPartNo = engineeringPart1.Replace("-", "").Replace(" ", "").Trim();
            }
            //line.Substring(291, 8).Trim();
            endItemFinisNo = line.Substring(299, 7).Trim();
            finisNumbers.Add(endItemFinisNo);
            //engineeringNumbers.Add(engineeringPart1.Replace("-", ""));
            engineeringNumbers.Add(engineeringPart1.Trim());
            motorCraftPrefix = line.Substring(348, 5).Trim();
            motorCraftBase = line.Substring(354, 8).Trim();
            motorCraftSuffix = line.Substring(363, 5).Trim();
            if (motorCraftBase != "")
            {
                salesPartNo = motorCraftPrefix + "-" + motorCraftBase + "-" + motorCraftSuffix;
            }
        }
    }
}