using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Data;

namespace GSPPSDataMapping.DET
{
    class REMARKCODE
    {
        #region MEMBERS
        //private string defaultValue;//Default
        //private string recordType;//PKGEXT-RECORD-TYPE
        private string packedServicePart;//PKGEXT-PACKED-SERVICE-PART
        private int specType;//PKGEXT-PACKAGING-TYPE
        private string version;//PKGEXT-VERSION
        private string servicePartNumber;//PKGEXT-SERVICE-PART-NUMBER.
        private string remarkCode;//PKGEXT-REMARK-CODE
        private string remarkDescription;//PKGEXT-REMARK-DESCRIPTION
        private string remark;
        private string countryCode;//PKGEXT-COUNTRY-CODE3
        private string companyCode;//PKGEXT-COMPANY-CODE3
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
        public string RemarkCode
        {
            get { return remarkCode; }
            set { remarkCode = value; }
        }
        public string RemarkDescription
        {
            get { return remarkDescription; }
            set { remarkDescription = value; }
        }
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
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
        //FILLER
        #endregion

        public REMARKCODE(string line, string servicePartNo)
        {
            //defaultValue = line.Substring(0, 3).Trim();
            //recordType = line.Substring(3, 1).Trim();
            packedServicePart = line.Substring(4, 18).Trim();
            specType = Int32.Parse(line.Substring(22, 2).Trim());
            version = line.Substring(24, 3).Trim();
            servicePartNumber = servicePartNo;

            remarkCode = line.Substring(27, 2).Trim();
            remarkDescription = line.Substring(29, 120).Trim();
            remark = remarkDescription;
            countryCode = line.Substring(149, 2).Trim();
            companyCode = line.Substring(151, 2).Trim();
            //line.Substring(153, 195).Trim();
        }
    }
}