using GSPPSDataMapping.DET;
using System.Collections.Generic;

namespace GSPPSDataMapping.Tables
{
    interface IIQMSTable
    {
        string GetControlFilePath();
        string GetSqlLoaderTableName();
        void InsertIntoDataFile(bool force);
        void process(string specsFolder, SPECIFICATION pkgSpec, List<DETAILS> currentDetails, List<BOM> currentBOM, List<REMARKCODE> currentRemarkCode, REMARK rmk, string rawSpec);
        void StageIntoRealTable();
        long TotalItems();
    }
}