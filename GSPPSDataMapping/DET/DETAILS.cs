using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections;

namespace GSPPSDataMapping.DET
{
    class DETAILS
    {
        #region MEMBERS
        //private string defaultValue;//Default
        //private string recordType;//PKGEXT-RECORD-TYPE
        private string packedServicePart = ""; //PKGEXT-PACKED-SERVICE-PART
        private int specType = 1;//PKGEXT-PACKAGING-TYPE
        private string version = "";//PKGEXT-VERSION
        private string servicePartNo = "";//PKGEXT-SERVICE-PART-NUMBER.
        private string packageLevelNumber = "";//PKGEXT-PKS-LEVEL
        private string packageLevelDescription = "";//PKGEXT-PKS-LEVEL-DESC
        private int stepSequenceNumber = 0;//PKGEXT-STEP-SEQUENCE-NUMBER
        private string cpmIndicator = "";//PKGEXT-CPM-INDICATOR
        private string processOrMaterialCode = "";//PKGEXT-CPM-NUMBER
        private string processOrMaterialDescription = "";//PKGEXT-CPM-DESC
        private int quantity = 0;//PKGEXT-STEP-SPEC-QUANTITY
        private string quantityStr = "0";
        private double unitizationPerLength = 0.0;//PKGEXT-CONT-LENGTH-Outside
        private double unitizationPerWidth = 0.0;//PKGEXT-CONT-WIDTH-Outside
        private double unitizationPerDepth = 0.0;//PKGEXT-CONT-DEPTH-Outside
        private string containerGraphicsLevel = "";//PKGEXT-CNTR-GRAPHICS-LEVEL
        private string containerStyleCode = "";//PKGEXT-CNTR-STYLE
        private string containerStyleCodeDescription = "";//PKGEXT-CNTR-STYLE-DESC
        private string containerStyleClassCode = "";//PKGEXT-STYLE-CLASS
        private string containerTypeCode = "";//PKGEXT-CNTR-TYPE
        private string containerTypeCodeDescription = "";//PKGEXT-CNTR-TYPE-DESC
        private string uPCCode = "";//PKGEXT-UPC-NUMBER
        private string majorLogoSize = "";//PKGEXT-MAJOR-LOGO-SIZE
        private string majorLogoSizeDescription = "";//PKGEXT-MAJOR-LOGO-SIZE-DESC
        private string minorLogoSize = "";//PKGEXT-MINOR-LOGO-SIZE
        private string minorLogoSizeDescription = "";//PKGEXT-MINOR-LOGO-SIZE-DESC
        private string countryCode2 = "";//oPKGEXT-COUNTRY-CODE2
        private string companyCode2 = "";//PKGEXT-COMPANY-CODE2
        private string specSegment = "";
        private string comment = "";//
        //FILLER
        //*
        private double containerLengthInside = 0;//PKGEXT-CONT-LENGTH-Inside
        private double containerWidthInside = 0;//PKGEXT-CONT-WIDTH-Inside
        private double containerDepthInside = 0;//PKGEXT-CONT-DEPTH-Inside

        private string containerMLengthInside = "";//PKGEXT-CONTM-LENGTH-Inside
        private string containerMWidthInside = "";//PKGEXT-CONTM-WIDTH-Inside
        private string containerMDepthInside = "";//PKGEXT-CONTM-DEPTH-Inside
        private string containerMLengthOutside = "";//PKGEXT-CONTM-LENGTH-Outside
        private string containerMWidthOutside = "";//PKGEXT-CONTM-WIDTH-Outside
        private string containerMDepthOutside = "";//PKGEXT-CONTM-DEPTH-Outside
        private string containerCLengthInside = "";//PKGEXT-CONTC-LENGTH-Inside
        private string containerCWidthInside = "";//PKGEXT-CONTC-WIDTH-Inside
        private string containerCDepthInside = "";//PKGEXT-CONTC-DEPTH-Inside
        private string containerCLengthOutside = "";//PKGEXT-CONTC-LENGTH-Outside
        private string containerCWidthOutside = "";//PKGEXT-CONTC-WIDTH-Outside
        private string containerCDepthOutside = "";//PKGEXT-CONTC-DEPTH-Outside
        //*/
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
            get { return servicePartNo; }
            set { servicePartNo = value; }
        }
        public string PackageLevelNumber
        {
            get { return packageLevelNumber; }
            set { packageLevelNumber = value; }
        }
        public string PackageLevelDescription
        {
            get { return packageLevelDescription; }
            set { packageLevelDescription = value; }
        }
        public int StepSequenceNumber
        {
            get { return stepSequenceNumber; }
            set { stepSequenceNumber = value; }
        }
        public string CpmIndicator
        {
            get { return cpmIndicator; }
            set { cpmIndicator = value; }
        }
        public string ProcessOrMaterialCode
        {
            get { return processOrMaterialCode; }
            set { processOrMaterialCode = value; }
        }
        public string UnitPackageContainer
        {
            get { return processOrMaterialCode; }
            set { processOrMaterialCode = value; }
        }
        public string SubPacksContainer
        {
            get { return processOrMaterialCode; }
            set { processOrMaterialCode = value; }
        }
        public string ProcessOrMaterialDescription
        {
            get { return processOrMaterialDescription; }
            set { processOrMaterialDescription = value; }
        }
        public string SubPacksDescription
        {
            get { return processOrMaterialDescription; }
            set { processOrMaterialDescription = value; }
        }
        public string UnitPackageDescription
        {
            get { return processOrMaterialDescription; }
            set { processOrMaterialDescription = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public string  QuantityStr
        {
            get { return quantityStr; }
            set { quantityStr = value; }
        }
        public double UnitizationPerLength
        {
            get { return unitizationPerLength; }
            set { unitizationPerLength = value; }
        }
        public double UnitizationPerWidth
        {
            get { return unitizationPerWidth; }
            set { unitizationPerWidth = value; }
        }
        public double UnitizationPerDepth
        {
            get { return unitizationPerDepth; }
            set { unitizationPerDepth = value; }
        }
        public string ContainerGraphicsLevel
        {
            get { return containerGraphicsLevel; }
            set { containerGraphicsLevel = value; }
        }
        public string ContainerStyleCode
        {
            get { return containerStyleCode; }
            set { containerStyleCode = value; }
        }
        public string ContainerStyleCodeDescription
        {
            get { return containerStyleCodeDescription; }
            set { containerStyleCodeDescription = value; }
        }
        public string ContainerStyleClassCode
        {
            get { return containerStyleClassCode; }
            set { containerStyleClassCode = value; }
        }
        public string ContainerTypeCode
        {
            get { return containerTypeCode; }
            set { containerTypeCode = value; }
        }
        public string ContainerTypeCodeDescription
        {
            get { return containerTypeCodeDescription; }
            set { containerTypeCodeDescription = value; }
        }
        public string UPCCode
        {
            get { return uPCCode; }
            set { uPCCode = value; }
        }
        public string MajorLogoSize
        {
            get { return majorLogoSize; }
            set { majorLogoSize = value; }
        }
        public string MajorLogoSizeDescription
        {
            get { return majorLogoSizeDescription; }
            set { majorLogoSizeDescription = value; }
        }
        public string MinorLogoSize
        {
            get { return minorLogoSize; }
            set { minorLogoSize = value; }
        }
        public string MinorLogoSizeDescription
        {
            get { return minorLogoSizeDescription; }
            set { minorLogoSizeDescription = value; }
        }
        public string CountryCode2
        {
            get { return countryCode2; }
            set { countryCode2 = value; }
        }
        public string CompanyCode2
        {
            get { return companyCode2; }
            set { companyCode2 = value; }
        }
        public string SpecSegment
        {
            get { return specSegment; }
            set { specSegment = value; }
        }
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        public double SubSize1
        {
            get { return containerLengthInside; }
            set { containerLengthInside = value; }
        }

        public double SubSize2
        {
            get { return containerWidthInside; }
            set { containerWidthInside = value; }
        }
        public double SubSize3
        {
            get { return containerDepthInside; }
            set { containerDepthInside = value; }
        }

        public string ContainerCLengthOutside
        {
            get { return containerCLengthOutside; }
            set { containerCLengthOutside = value; }
        }
        public string ContainerCWidthOutside
        {
            get { return containerCWidthOutside; }
            set { containerCWidthOutside = value; }
        }
        public string ContainerCDepthOutside
        {
            get { return containerCDepthOutside; }
            set { containerCDepthOutside = value; }
        }
        #endregion

        public DETAILS(string line, string sPNo, SPECIFICATION pkgSpec)
        {
            //latest changes to layout does not give complete line for parsing
            line = line.PadRight(470, ' ');

            //defaultValue = line.Substring(0, 3).Trim();
            //recordType = line.Substring(3, 1).Trim();
            packedServicePart = line.Substring(4, 18).Trim();
            specType = Int32.Parse(line.Substring(22, 2).Trim());
            version = line.Substring(24, 3).Trim();
            servicePartNo = sPNo;

            packageLevelNumber = line.Substring(27, 2).Trim();
            packageLevelDescription = line.Substring(29, 40).Trim();
            switch (packageLevelDescription)
            {
                case "Preliminary":
                    specSegment = "PRELIM";
                    break;
                case "SubPackage":
                    specSegment = "SUBPACK";
                    break;
                case "Intermediate Package":
                    specSegment = "INTERMED";
                    break;
                case "Masterpack Container":
                    specSegment = "MASTER";
                    break;
                case "Unitization":
                    specSegment = "PALLET";
                    break;
                default:
                    specSegment = "EXTRA";
                    break; //remarks is DET3-4, //bom is DET5
            }
            stepSequenceNumber = Int32.Parse(line.Substring(69, 2).Trim());
            cpmIndicator = line.Substring(71, 1).Trim();
            processOrMaterialCode = line.Substring(72, 8).Trim();
            processOrMaterialDescription = line.Substring(80, 40).Trim();
            if (processOrMaterialCode == "PARTSIZE" || processOrMaterialCode == "PARTS1ZE")
            {
                processOrMaterialCode = "PARTSIZE";
                processOrMaterialDescription = "PART DIMENSIONS, ACTUAL OR APPROX. SEE SPEC PRELIM. AREA FOR PART I.D.";
            }

            //spec changes forces this part to fail
            quantityStr = line.Substring(120, 5).Trim();

            try { quantity = Int32.Parse(quantityStr); }
            catch {
                quantityStr = "0"; quantity = 1; }

            unitizationPerLength = Double.Parse(line.Substring(125, 8).Trim()); //unitizationPerLength;
            unitizationPerWidth = Double.Parse(line.Substring(133, 8).Trim()); //unitizationPerWidth;
            unitizationPerDepth = Double.Parse(line.Substring(141, 8).Trim()); //unitizationPerDepth;
            containerGraphicsLevel = line.Substring(149, 2).Trim();
            containerStyleCode = line.Substring(151, 2).Trim();
            containerStyleCodeDescription = line.Substring(153, 40).Trim();
            containerStyleClassCode = line.Substring(193, 2).Trim();
            containerTypeCode = line.Substring(195, 2).Trim();
            containerTypeCodeDescription = line.Substring(197, 40).Trim();
            uPCCode = line.Substring(237, 11).Trim();
            if (uPCCode != "")
            {
                uPCCode = uPCCode.PadLeft(11, '0');
                string upc1 = "0-" + uPCCode.Substring(0, 5);
                string upc2 = "-" + uPCCode.Substring(5, 5);
                string upc3 = "-" + uPCCode.Substring(10, 1);
                uPCCode = upc1 + upc2 + upc3;

                pkgSpec.UpcCode = uPCCode;
            }
            majorLogoSize = line.Substring(248, 2).Trim();
            majorLogoSizeDescription = line.Substring(250, 40).Trim();
            minorLogoSize = line.Substring(290, 2).Trim();
            minorLogoSizeDescription = line.Substring(292, 40).Trim();
            countryCode2 = line.Substring(332, 2).Trim();
            companyCode2 = line.Substring(334, 2).Trim();
            //line.Substring(336, 12).Trim();
            if (line.TrimEnd().Length > 336)
            {
                containerLengthInside = Convert.ToDouble(line.Substring(348, 8).Trim());
                containerWidthInside = Convert.ToDouble(line.Substring(356, 8).Trim());
                containerDepthInside = Convert.ToDouble(line.Substring(364, 8).Trim());
                containerMLengthInside = line.Substring(372, 8).Trim();
                containerMWidthInside = line.Substring(380, 8).Trim();
                containerMDepthInside = line.Substring(388, 8).Trim();
                containerMLengthOutside = line.Substring(396, 8).Trim();
                containerMWidthOutside = line.Substring(404, 8).Trim();
                containerMDepthOutside = line.Substring(412, 8).Trim();
                containerCLengthInside = line.Substring(420, 8).Trim();
                containerCWidthInside = line.Substring(428, 8).Trim();
                containerCDepthInside = line.Substring(436, 8).Trim();
                containerCLengthOutside = line.Substring(444, 8).Trim();
                containerCWidthOutside = line.Substring(452, 8).Trim();
                containerCDepthOutside = line.Substring(460, 8).Trim();
            }
        }

        internal bool isPartDimensions()
        {
            return (processOrMaterialCode.Equals("PARTSIZE") || processOrMaterialCode.Equals("PARTS1ZE"));
        }

        internal bool PartIsValid()
        {
            //return !(quantityStr.Equals("0") || quantityStr.Equals(""));
            return !(packageLevelNumber.Equals("10"));
        }
    }
}
