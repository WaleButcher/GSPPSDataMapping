using GSPPSDataMapping.DET;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Configuration;

namespace GSPPSDataMapping.Tables
{
    class ARINVT : IIQMSTable
    {
        private static StringBuilder ARINVTColumns = new StringBuilder("");
        private StringBuilder sbNewLine = new StringBuilder("");
        private string createTempTableQuery;
        private string stageIntoRealTableQuery;
        private string allItemsQuery;
        private StringBuilder insertIntoStageTableQuery = new StringBuilder("");
        private StringBuilder packagingStringLine = new StringBuilder("");
        private StringBuilder finishedGoodString = new StringBuilder("");
        private string SpecFolder = "";
        private string controlFilePath = @"SQLLoaderControl\tempARINVT_for_GSPPS.ctl";
        private string sqlLoaderTableName = "tempARINVT_for_GSPPS";

        string[] stringArray;

        private HashSet<string> newMaterials = new HashSet<string>();
        private HashSet<string> tableMaterials = new HashSet<string>();

        private StringBuilder dataLoaderString = new StringBuilder("");
        private long DataFileLineCount = 0;
        private bool dataCanBeAddedToTable = false;

        public long TotalItems()
        {
            return newMaterials.Count;
        }

        private bool CheckIfInTableOrMaterialList(string className, string material, string version)
        {
            return newMaterials.Contains(className + "|" + material + "|" + version)
                || tableMaterials.Contains(className + "|" + material + "|" + version);
        }

        public void AddToMaterialList(string className, string material, string version)
        {
            newMaterials.Add(className + "|" + material + "|" + version);
        }

        /// <summary>ARINVT class initializer:
        /// <list type="bullet">
        /// <item>
        /// <description>Sets the folder location for this class' table</description>
        /// </item>
        /// <item>
        /// <description>Clears the CSV file for the temporary table </description>
        /// </item>
        /// <item>
        /// <description>Recreates the temporary table </description>
        /// </item>
        /// </list>
        /// </summary>
        public ARINVT(string folder, bool allowInsertIntoLiveTable)
        {
            SpecFolder = folder;//set the folder location for individual spec CSVs

            dataCanBeAddedToTable = allowInsertIntoLiveTable;
            GetColumnNames();

            GetAllItemsFromTable();

            CreateTemporaryTable();
        }

        public void GetAllItemsFromTable()
        {
            tableMaterials.Clear();

            if (dataCanBeAddedToTable ==  true) //this is to make sure the table ARINVT may have more rows or not
            {
                Console.Write(" Getting ARINVT class FD, FG, PK items...");

                allItemsQuery = "SELECT CLASS, ITEMNO, REV FROM ARINVT WHERE CLASS IN ('FD', 'FG', 'PK')";
                using (OracleConnection db = OracleConnectionFactory.IQMSConnection)
                {
                    using (OracleCommand select = new OracleCommand(allItemsQuery, db))
                    {
                        select.CommandType = CommandType.Text;
                        select.CommandTimeout = 0;
                        using (OracleDataReader reader = select.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tableMaterials.Add(
                                    reader["CLASS"].ToString().Trim() + "|" +
                                    reader["ITEMNO"].ToString().Trim() + "|" +
                                    reader["REV"].ToString().Trim()
                                );

                                /*
                                Console.Write("\r " + (reader["CLASS"].ToString().Trim() + "|" +
                                    reader["ITEMNO"].ToString().Trim() + "|" +
                                    reader["REV"].ToString().Trim() + " = " + 
                                    tableMaterials.Count).PadRight(80));
                                */
                                ;
                            }
                        }
                    }
                }
                Console.WriteLine(" Done");
            }
        }

        /// <summary>
        /// This method is responsible for inserting values into ARINVT table from the staging table (tempARINVT_for_GSPPS)
        /// that do not already exist in ARINVT table. We are doi
        /// </summary>
        public void StageIntoRealTable()
        {
            if (dataCanBeAddedToTable == true) //this is to make sure the table ARINVT may have more rows or not
            {
                Console.WriteLine("\n Staging tempARINVT_for_GSPPS into ARINVT");
                using (OracleConnection db = OracleConnectionFactory.IQMSConnection)
                {
                    int intMaxRowsAtATime = 100;
                    OracleCommand insert = new OracleCommand("", db);

                    insert.CommandType = CommandType.Text;
                    insert.CommandTimeout = 0;
                    for (int countID = 1; countID <= newMaterials.Count; countID += intMaxRowsAtATime)
                    {
                        stageIntoRealTableQuery = "BEGIN ";
                        stageIntoRealTableQuery += " INSERT INTO ARINVT(ARINVT.ARCUSTO_ID, ARINVT.CLASS, ARINVT.ITEMNO, ARINVT.REV, ARINVT.DESCRIP, ARINVT.DESCRIP2, ARINVT.AVG_COST, ARINVT.VENDOR_ID, ARINVT.UNIT, ARINVT.BLEND, ARINVT.CUSER1, ARINVT.CUSER2, ARINVT.CUSER3, ARINVT.NUSER1, ARINVT.NUSER2, ARINVT.NUSER3, ARINVT.BOM_ACTIVE, ARINVT.ONHAND, ARINVT.RG_ONHAND, ARINVT.NON_SALABLE, ARINVT.NON_CONFORM_TOTAL, ARINVT.SERIALIZED, ARINVT.SAFETY_STOCK, ARINVT.MIN_ORDER_QTY, ARINVT.MAX_ORDER_QTY, ARINVT.MULTIPLE, ARINVT.YTDQTY, ARINVT.PTDQTY, ARINVT.CODE, ARINVT.LDATE, ARINVT.LBUY_DATE, ARINVT.TYPE, ARINVT.SERIES, ARINVT.LEAD_DAYS, ARINVT.LEAD_TIME, ARINVT.SPG, ARINVT.DRYTIME, ARINVT.DRYTEMP, ARINVT.RGPRCNT, ARINVT.AUTO_MJO, ARINVT.MFG_QUAN, ARINVT.AUX_AMT, ARINVT.STDQUAN, ARINVT.LOW_LEVEL_CODE, ARINVT.MPS_CODE, ARINVT.ARINVT_FAMILY_ID, ARINVT.BACKFLUSH, ARINVT.DRAWING, ARINVT.ECNO, ARINVT.STD_PRICE, ARINVT.STD_COST, ARINVT.STANDARD_ID, ARINVT.ACCT_ID_SALES, ARINVT.ACCT_ID_INV, ARINVT.MFG_SPLIT, ARINVT.PRICE_PER_1000, ARINVT.COMIS_PRCNT, ARINVT.UNQUE_DATE_IN, ARINVT.SHELF_LIFE, ARINVT.ECODE, ARINVT.EID, ARINVT.EDATE_TIME, ARINVT.ECOPY, ARINVT.ACCT_ID_PPV, ARINVT.ACCT_ID_OH_DISPO, ARINVT.ACCT_ID_LABOR_DISPO, ARINVT.ACCT_ID_HOLDING, ARINVT.ITEM_TYPE_ID, ARINVT.NMFC_ID, ARINVT.VOLUME, ARINVT.AUTO_MRP_REORD_POINT, ARINVT.AUTO_MRP_ORDER_QTY, ARINVT.AUTO_MRP_LEAD_DAYS, ARINVT.EPLANT_ID, ARINVT.COMMISSIONS_ID, ARINVT.STD_COST_CONTROL, ARINVT.PO_SCOPE, ARINVT.PO_SAFETY, ARINVT.PO_MOVE_RANGE, ARINVT.LM_IMAGE_FILENAME, ARINVT.CYCLE_COUNT_CODE, ARINVT.CUSER4, ARINVT.CUSER5, ARINVT.CUSER6, ARINVT.CUSER7, ARINVT.CUSER8, ARINVT.CUSER9, ARINVT.CUSER10, ARINVT.NUSER4, ARINVT.NUSER5, ARINVT.NUSER6, ARINVT.NUSER7, ARINVT.NUSER8, ARINVT.NUSER9, ARINVT.NUSER10, ARINVT.PROCESS_SAFETY_STOCK, ARINVT.MX_GROUP_ID, ARINVT.FR_GROUP_ID, ARINVT.SETUP_CHARGE, ARINVT.MOVE_TIME, ARINVT.CARTONS_PALLET, ARINVT.PIECES_CARTON, ARINVT.AUTO_MRP_FIRM_WO, ARINVT.FLOOR_BACKFLUSH, ARINVT.MPS, ARINVT.CUM_LEADTIME, ARINVT.PHANTOM, ARINVT.CRITICAL_FENCE, ARINVT.USER_NAME, ARINVT.PK_HIDE, ARINVT.ACCT_ID_PRODVAR, ARINVT.PHANTOM_ONHAND, ARINVT.LM_LABELS_ID, ARINVT.DRIVE_PHANTOM_NEGATIVE, ARINVT.NO_STDCOST_RECALC, ARINVT.ACCT_ID_INTPLANT_SALES, ARINVT.IMAGE_FILENAME, ARINVT.NON_ALLOCATE_TOTAL, ARINVT.INSP_RECEIPT_THRES, ARINVT.INSP_RECEIPT_COUNT, ARINVT.COST_STANDARD_ID_FUTURE, ARINVT.COST_STANDARD_ID, ARINVT.COST_DESCRIP_FUTURE, ARINVT.COST_DESCRIP, ARINVT.COST_CALC_DATE_FUTURE, ARINVT.COST_CALC_DATE, ARINVT.AUTO_MRP_INCLUDE_VMI, ARINVT.PROD_CODE_ID, ARINVT.DO_NOT_DISPO_FLOOR_PARTIAL, ARINVT.INFO_SO, ARINVT.INFO_PO, ARINVT.EXCL_RECEIPT_TIME_PPV, ARINVT.CYCLE_COUNT_ID, ARINVT.CYCLE_COUNT_DATE, ARINVT.NON_MATERIAL, ARINVT.MFG_MIN_QTY, ARINVT.MFG_MULTIPLE, ARINVT.BUYER_CODE_ID, ARINVT.COST_CALC_BATCH, ARINVT.INTRASTAT_CODE, ARINVT.FAB_START, ARINVT.MFG_SAFETY_QTY, ARINVT.PLANNER_CODE_ID, ARINVT.IS_LOT_MANDATORY, ARINVT.PK_WEIGHT, ARINVT.PK_PTSPER, ARINVT.DO_NOT_SCHED_FORECAST_WO, ARINVT.IS_PALLET, ARINVT.IS_AUTO_RT_LABELS, ARINVT.IS_LINKED_TO_SERIAL, ARINVT.FR_INCLUDE, ARINVT.MIN_CPK, ARINVT.LBL_ASSIST_LAST_PRINT, ARINVT.LBL_ASSIST_PRINT_INTERVAL, ARINVT.COC_EXCLUDE, ARINVT.ICT_REORD_POINT, ARINVT.ICT_REPLENISH_SCOPE_DAYS, ARINVT.ICT_LEAD_DAYS, ARINVT.ICT_SHIP_TO_ID, ARINVT.AUTO_MRP_KANBAN_LOT_SIZE, ARINVT.ICT_FIRE_TRIGGER, ARINVT.COLOR_GROUP_ID, ARINVT.FR_WO_TIME_FENCE, ARINVT.PK_LENGTH, ARINVT.PK_WIDTH, ARINVT.PK_HEIGHT, ARINVT.PALLET_LENGTH, ARINVT.PALLET_WIDTH, ARINVT.PALLET_HEIGHT, ARINVT.PALLET_VOLUME, ARINVT.PALLET_PTSPER, ARINVT.PALLET_WEIGHT, ARINVT.LENGTH, ARINVT.WIDTH, ARINVT.GAUGE, ARINVT.IS_BY_PRODUCT, ARINVT.EXCLUDE_FROM_COMMISSIONS, ARINVT.AUTO_RT_LABELS_PK_SEQ, ARINVT.PALLET_PATTERN_ID, ARINVT.WEB_SALABLE, ARINVT.PO_MULTIPLE, ARINVT.FIFO_THRESHOLD, ARINVT.COST_STANDARD_ID_FORECAST, ARINVT.COST_STANDARD_ID_BUDGET, ARINVT.COST_DESCRIP_FORECAST, ARINVT.COST_DESCRIP_BUDGET, ARINVT.COST_CALC_DATE_FORECAST, ARINVT.COST_CALC_DATE_BUDGET, ARINVT.KEEP_LABEL_BOM_INTERPLANT_TRAN, ARINVT.ECO_ORIG_CLASS, ARINVT.ACCT_ID_WIP, ARINVT.IRV32_NO_PLAN_WO, ARINVT.INFO_REC, ARINVT.IS_LOT_DATE_MANDATORY, ARINVT.USE_THIS_UOM_FOR_MRP, ARINVT.WAIT_TIME, ARINVT.BOL_CALC_OVERRIDE, ARINVT.RFQ_USE_STD_COST, ARINVT.ACCT_ID_PHYS_VAR, ARINVT.ACCT_ID_INV_COST_REV, ARINVT.EXCLUDE_BACKFLUSH, ARINVT.NONTAXABLE, ARINVT.ACCT_ID_SHIPMENT, ARINVT.AUTO_MRP_EXCLUDE_HARD_ALLOC, ARINVT.MIN_PPK, ARINVT.RUN_RULES, ARINVT.RTPM_TRG_RTLABEL, ARINVT.REBATE_PARAMS_ID, ARINVT.TARIFF_CODE_ID, ARINVT.WEBDIRECT_LEAD_DAYS, ARINVT.USE_COST_DEFAULT_STANDARD_ID, ARINVT.ARINVT_GROUP_ID, ARINVT.CLONED_FROM_ARINVT_ID, ARINVT.USE_LOT_CHARGE, ARINVT.LOT_CHARGE, ARINVT.UNIQUE_DISPO_LOC, ARINVT.HEIJUNKA_SINCE_SCHED_DEMAND, ARINVT.CONFIG_CODE, ARINVT.AUTO_MRP_INCLUDE_VMI_MFG_CALC, ARINVT.FR_WO_SCOPE, ARINVT.AUTO_MRP_APPLY_TO_SCHED_ALLOC, ARINVT.PHANTOM_COMPONENTS_ON_SO, ARINVT.SCHED_CASCADE_PARENT_MTO, ARINVT.AUTO_POP_SERV_CTR, ARINVT.EXCL_MARK_WO_MAT_XCPT, ARINVT.IS_ALC, ARINVT.MARK_ORD_DETAIL_MTO, ARINVT.MSDS_AUTHORABLE, ARINVT.IS_MSDS, ARINVT.MSDS_UPLOAD, ARINVT.NONTAXABLE_PO, ARINVT.OVERRIDE_REC_LOC, ARINVT.IS_DROP_SHIP, ARINVT.MAX_PALLET_STACK, ARINVT.LOOSE_INV_MOVE_CLASS_ID, ARINVT.PACK_INV_MOVE_CLASS_ID, ARINVT.PALLET_INV_MOVE_CLASS_ID, ARINVT.PK_UNIT_TYPE, ARINVT.LOOSE_MOVE_RANK_COUNT, ARINVT.PACK_MOVE_RANK_COUNT, ARINVT.PALLET_MOVE_RANK_COUNT, ARINVT.EXCL_WORKORDER_MAT, ARINVT.FIFO, ARINVT.COMPANY_ID, ARINVT.RECV_LOCATION_ID, ARINVT.SPC_INSPECTION_ID, ARINVT.AR_DISCOUNT_WATERFALL_ID, ARINVT.LBL_LAST_PRINT, ARINVT.EXCL_FROM_CTP_EXCEPTION, ARINVT.WMS_INV_GROUP_ID, ARINVT.CORE_SIZE, ARINVT.OD, ARINVT.PS_CONVERT_INFO, ARINVT.LOOSE_MOVE_RANK_LOCK, ARINVT.PACK_MOVE_RANK_LOCK, ARINVT.PALLET_MOVE_RANK_LOCK, ARINVT.CYCLE_COUNT_RANK_LOCK, ARINVT.MIN_SELL_QTY, ARINVT.INSP_LEAD_DAYS, ARINVT.LOOSE_WEIGHT, ARINVT.LOOSE_VOLUME, ARINVT.LOOSE_LENGTH, ARINVT.LOOSE_WIDTH, ARINVT.LOOSE_HEIGHT, ARINVT.IS_LOT_EXPIRY_DATE_MANDATORY, ARINVT.ICT_TRUCK_PTSPER, ARINVT.SAFETY_STOCK2, ARINVT.COST_CALC_USER_NAME, ARINVT.SHELF_LIFE2, ARINVT.ICT_AUTO_MRP_ORDER_QTY, ARINVT.ICT_SHIP_PULL_DEMAND, ARINVT.PLT_WRP_USE_QC, ARINVT.PLT_WRP_LOC_ID, ARINVT.HARD_ALLOC_ROUND_PRECISION, ARINVT.BACKFLUSH_BY_SERIAL, ARINVT.GROUP_CODE, ARINVT.PROPRIETARY_EFFECT_DATE, ARINVT.PROPRIETARY_DEACTIVE_DATE, ARINVT.DEMAND_CHANGE, ARINVT.TAX_CLASS_ID, ARINVT.DISCOUNT_GROUPS_ID, ARINVT.PHYS_CHAR_VOLUME, ARINVT.PHANTOM_KIT_USE_COMP_PRICE, ARINVT.ASSY1_EXCLUDE_FORECAST_WO, ARINVT.LAST_DEMAND_CHANGE, ARINVT.ARINVT_RECIPE_ID, ARINVT.GL_PLUG_VALUE, ARINVT.CAROUSEL_TARGET_ID, ARINVT.CAROUSEL_OPERATOR, ARINVT.CREATED, ARINVT.CREATEDBY, ARINVT.CHANGED, ARINVT.CHANGEDBY, ARINVT.ACCT_ID_INTRANSIT, ARINVT.ACCT_ID_IP_TRANS, ARINVT.ACCT_ID_IP_TRANS_VAR) ";
                        stageIntoRealTableQuery += " SELECT tempARINVT_for_GSPPS.ARCUSTO_ID,tempARINVT_for_GSPPS.CLASS,tempARINVT_for_GSPPS.ITEMNO,tempARINVT_for_GSPPS.REV,tempARINVT_for_GSPPS.DESCRIP,tempARINVT_for_GSPPS.DESCRIP2,tempARINVT_for_GSPPS.AVG_COST,tempARINVT_for_GSPPS.VENDOR_ID,tempARINVT_for_GSPPS.UNIT,tempARINVT_for_GSPPS.BLEND,tempARINVT_for_GSPPS.CUSER1,tempARINVT_for_GSPPS.CUSER2,tempARINVT_for_GSPPS.CUSER3,tempARINVT_for_GSPPS.NUSER1,tempARINVT_for_GSPPS.NUSER2,tempARINVT_for_GSPPS.NUSER3,tempARINVT_for_GSPPS.BOM_ACTIVE,tempARINVT_for_GSPPS.ONHAND,tempARINVT_for_GSPPS.RG_ONHAND,tempARINVT_for_GSPPS.NON_SALABLE,tempARINVT_for_GSPPS.NON_CONFORM_TOTAL,tempARINVT_for_GSPPS.SERIALIZED,tempARINVT_for_GSPPS.SAFETY_STOCK,tempARINVT_for_GSPPS.MIN_ORDER_QTY,tempARINVT_for_GSPPS.MAX_ORDER_QTY,tempARINVT_for_GSPPS.MULTIPLE,tempARINVT_for_GSPPS.YTDQTY,tempARINVT_for_GSPPS.PTDQTY,tempARINVT_for_GSPPS.CODE,tempARINVT_for_GSPPS.LDATE,tempARINVT_for_GSPPS.LBUY_DATE,tempARINVT_for_GSPPS.TYPE,tempARINVT_for_GSPPS.SERIES,tempARINVT_for_GSPPS.LEAD_DAYS,tempARINVT_for_GSPPS.LEAD_TIME,tempARINVT_for_GSPPS.SPG,tempARINVT_for_GSPPS.DRYTIME,tempARINVT_for_GSPPS.DRYTEMP,tempARINVT_for_GSPPS.RGPRCNT,tempARINVT_for_GSPPS.AUTO_MJO,tempARINVT_for_GSPPS.MFG_QUAN,tempARINVT_for_GSPPS.AUX_AMT,tempARINVT_for_GSPPS.STDQUAN,tempARINVT_for_GSPPS.LOW_LEVEL_CODE,tempARINVT_for_GSPPS.MPS_CODE,tempARINVT_for_GSPPS.ARINVT_FAMILY_ID,tempARINVT_for_GSPPS.BACKFLUSH,tempARINVT_for_GSPPS.DRAWING,tempARINVT_for_GSPPS.ECNO,tempARINVT_for_GSPPS.STD_PRICE,tempARINVT_for_GSPPS.STD_COST,tempARINVT_for_GSPPS.STANDARD_ID,tempARINVT_for_GSPPS.ACCT_ID_SALES,tempARINVT_for_GSPPS.ACCT_ID_INV,tempARINVT_for_GSPPS.MFG_SPLIT,tempARINVT_for_GSPPS.PRICE_PER_1000,tempARINVT_for_GSPPS.COMIS_PRCNT,tempARINVT_for_GSPPS.UNQUE_DATE_IN,tempARINVT_for_GSPPS.SHELF_LIFE,tempARINVT_for_GSPPS.ECODE,tempARINVT_for_GSPPS.EID,tempARINVT_for_GSPPS.EDATE_TIME,tempARINVT_for_GSPPS.ECOPY,tempARINVT_for_GSPPS.ACCT_ID_PPV,tempARINVT_for_GSPPS.ACCT_ID_OH_DISPO,tempARINVT_for_GSPPS.ACCT_ID_LABOR_DISPO,tempARINVT_for_GSPPS.ACCT_ID_HOLDING,tempARINVT_for_GSPPS.ITEM_TYPE_ID,tempARINVT_for_GSPPS.NMFC_ID,tempARINVT_for_GSPPS.VOLUME,tempARINVT_for_GSPPS.AUTO_MRP_REORD_POINT,tempARINVT_for_GSPPS.AUTO_MRP_ORDER_QTY,tempARINVT_for_GSPPS.AUTO_MRP_LEAD_DAYS,tempARINVT_for_GSPPS.EPLANT_ID,tempARINVT_for_GSPPS.COMMISSIONS_ID,tempARINVT_for_GSPPS.STD_COST_CONTROL,tempARINVT_for_GSPPS.PO_SCOPE,tempARINVT_for_GSPPS.PO_SAFETY,tempARINVT_for_GSPPS.PO_MOVE_RANGE,tempARINVT_for_GSPPS.LM_IMAGE_FILENAME,tempARINVT_for_GSPPS.CYCLE_COUNT_CODE,tempARINVT_for_GSPPS.CUSER4,tempARINVT_for_GSPPS.CUSER5,tempARINVT_for_GSPPS.CUSER6,tempARINVT_for_GSPPS.CUSER7,tempARINVT_for_GSPPS.CUSER8,tempARINVT_for_GSPPS.CUSER9,tempARINVT_for_GSPPS.CUSER10,tempARINVT_for_GSPPS.NUSER4,tempARINVT_for_GSPPS.NUSER5,tempARINVT_for_GSPPS.NUSER6,tempARINVT_for_GSPPS.NUSER7,tempARINVT_for_GSPPS.NUSER8,tempARINVT_for_GSPPS.NUSER9,tempARINVT_for_GSPPS.NUSER10,tempARINVT_for_GSPPS.PROCESS_SAFETY_STOCK,tempARINVT_for_GSPPS.MX_GROUP_ID,tempARINVT_for_GSPPS.FR_GROUP_ID,tempARINVT_for_GSPPS.SETUP_CHARGE,tempARINVT_for_GSPPS.MOVE_TIME,tempARINVT_for_GSPPS.CARTONS_PALLET,tempARINVT_for_GSPPS.PIECES_CARTON,tempARINVT_for_GSPPS.AUTO_MRP_FIRM_WO,tempARINVT_for_GSPPS.FLOOR_BACKFLUSH,tempARINVT_for_GSPPS.MPS,tempARINVT_for_GSPPS.CUM_LEADTIME,tempARINVT_for_GSPPS.PHANTOM,tempARINVT_for_GSPPS.CRITICAL_FENCE,tempARINVT_for_GSPPS.USER_NAME,tempARINVT_for_GSPPS.PK_HIDE,tempARINVT_for_GSPPS.ACCT_ID_PRODVAR,tempARINVT_for_GSPPS.PHANTOM_ONHAND,tempARINVT_for_GSPPS.LM_LABELS_ID,tempARINVT_for_GSPPS.DRIVE_PHANTOM_NEGATIVE,tempARINVT_for_GSPPS.NO_STDCOST_RECALC,tempARINVT_for_GSPPS.ACCT_ID_INTPLANT_SALES,tempARINVT_for_GSPPS.IMAGE_FILENAME,tempARINVT_for_GSPPS.NON_ALLOCATE_TOTAL,tempARINVT_for_GSPPS.INSP_RECEIPT_THRES,tempARINVT_for_GSPPS.INSP_RECEIPT_COUNT,tempARINVT_for_GSPPS.COST_STANDARD_ID_FUTURE,tempARINVT_for_GSPPS.COST_STANDARD_ID,tempARINVT_for_GSPPS.COST_DESCRIP_FUTURE,tempARINVT_for_GSPPS.COST_DESCRIP,tempARINVT_for_GSPPS.COST_CALC_DATE_FUTURE,tempARINVT_for_GSPPS.COST_CALC_DATE,tempARINVT_for_GSPPS.AUTO_MRP_INCLUDE_VMI,tempARINVT_for_GSPPS.PROD_CODE_ID,tempARINVT_for_GSPPS.DO_NOT_DISPO_FLOOR_PARTIAL,tempARINVT_for_GSPPS.INFO_SO,tempARINVT_for_GSPPS.INFO_PO,tempARINVT_for_GSPPS.EXCL_RECEIPT_TIME_PPV,tempARINVT_for_GSPPS.CYCLE_COUNT_ID,tempARINVT_for_GSPPS.CYCLE_COUNT_DATE,tempARINVT_for_GSPPS.NON_MATERIAL,tempARINVT_for_GSPPS.MFG_MIN_QTY,tempARINVT_for_GSPPS.MFG_MULTIPLE,tempARINVT_for_GSPPS.BUYER_CODE_ID,tempARINVT_for_GSPPS.COST_CALC_BATCH,tempARINVT_for_GSPPS.INTRASTAT_CODE,tempARINVT_for_GSPPS.FAB_START,tempARINVT_for_GSPPS.MFG_SAFETY_QTY,tempARINVT_for_GSPPS.PLANNER_CODE_ID,tempARINVT_for_GSPPS.IS_LOT_MANDATORY,tempARINVT_for_GSPPS.PK_WEIGHT,tempARINVT_for_GSPPS.PK_PTSPER,tempARINVT_for_GSPPS.DO_NOT_SCHED_FORECAST_WO,tempARINVT_for_GSPPS.IS_PALLET,tempARINVT_for_GSPPS.IS_AUTO_RT_LABELS,tempARINVT_for_GSPPS.IS_LINKED_TO_SERIAL,tempARINVT_for_GSPPS.FR_INCLUDE,tempARINVT_for_GSPPS.MIN_CPK,tempARINVT_for_GSPPS.LBL_ASSIST_LAST_PRINT,tempARINVT_for_GSPPS.LBL_ASSIST_PRINT_INTERVAL,tempARINVT_for_GSPPS.COC_EXCLUDE,tempARINVT_for_GSPPS.ICT_REORD_POINT,tempARINVT_for_GSPPS.ICT_REPLENISH_SCOPE_DAYS,tempARINVT_for_GSPPS.ICT_LEAD_DAYS,tempARINVT_for_GSPPS.ICT_SHIP_TO_ID,tempARINVT_for_GSPPS.AUTO_MRP_KANBAN_LOT_SIZE,tempARINVT_for_GSPPS.ICT_FIRE_TRIGGER,tempARINVT_for_GSPPS.COLOR_GROUP_ID,tempARINVT_for_GSPPS.FR_WO_TIME_FENCE,tempARINVT_for_GSPPS.PK_LENGTH,tempARINVT_for_GSPPS.PK_WIDTH,tempARINVT_for_GSPPS.PK_HEIGHT,tempARINVT_for_GSPPS.PALLET_LENGTH,tempARINVT_for_GSPPS.PALLET_WIDTH,tempARINVT_for_GSPPS.PALLET_HEIGHT,tempARINVT_for_GSPPS.PALLET_VOLUME,tempARINVT_for_GSPPS.PALLET_PTSPER,tempARINVT_for_GSPPS.PALLET_WEIGHT,tempARINVT_for_GSPPS.LENGTH,tempARINVT_for_GSPPS.WIDTH,tempARINVT_for_GSPPS.GAUGE,tempARINVT_for_GSPPS.IS_BY_PRODUCT,tempARINVT_for_GSPPS.EXCLUDE_FROM_COMMISSIONS,tempARINVT_for_GSPPS.AUTO_RT_LABELS_PK_SEQ,tempARINVT_for_GSPPS.PALLET_PATTERN_ID,tempARINVT_for_GSPPS.WEB_SALABLE,tempARINVT_for_GSPPS.PO_MULTIPLE,tempARINVT_for_GSPPS.FIFO_THRESHOLD,tempARINVT_for_GSPPS.COST_STANDARD_ID_FORECAST,tempARINVT_for_GSPPS.COST_STANDARD_ID_BUDGET,tempARINVT_for_GSPPS.COST_DESCRIP_FORECAST,tempARINVT_for_GSPPS.COST_DESCRIP_BUDGET,tempARINVT_for_GSPPS.COST_CALC_DATE_FORECAST,tempARINVT_for_GSPPS.COST_CALC_DATE_BUDGET,tempARINVT_for_GSPPS.KEEP_LABEL_BOM_INTERPLANT_TRAN,tempARINVT_for_GSPPS.ECO_ORIG_CLASS,tempARINVT_for_GSPPS.ACCT_ID_WIP,tempARINVT_for_GSPPS.IRV32_NO_PLAN_WO,tempARINVT_for_GSPPS.INFO_REC,tempARINVT_for_GSPPS.IS_LOT_DATE_MANDATORY,tempARINVT_for_GSPPS.USE_THIS_UOM_FOR_MRP,tempARINVT_for_GSPPS.WAIT_TIME,tempARINVT_for_GSPPS.BOL_CALC_OVERRIDE,tempARINVT_for_GSPPS.RFQ_USE_STD_COST,tempARINVT_for_GSPPS.ACCT_ID_PHYS_VAR,tempARINVT_for_GSPPS.ACCT_ID_INV_COST_REV,tempARINVT_for_GSPPS.EXCLUDE_BACKFLUSH,tempARINVT_for_GSPPS.NONTAXABLE,tempARINVT_for_GSPPS.ACCT_ID_SHIPMENT,tempARINVT_for_GSPPS.AUTO_MRP_EXCLUDE_HARD_ALLOC,tempARINVT_for_GSPPS.MIN_PPK,tempARINVT_for_GSPPS.RUN_RULES,tempARINVT_for_GSPPS.RTPM_TRG_RTLABEL,tempARINVT_for_GSPPS.REBATE_PARAMS_ID,tempARINVT_for_GSPPS.TARIFF_CODE_ID,tempARINVT_for_GSPPS.WEBDIRECT_LEAD_DAYS,tempARINVT_for_GSPPS.USE_COST_DEFAULT_STANDARD_ID,tempARINVT_for_GSPPS.ARINVT_GROUP_ID,tempARINVT_for_GSPPS.CLONED_FROM_ARINVT_ID,tempARINVT_for_GSPPS.USE_LOT_CHARGE,tempARINVT_for_GSPPS.LOT_CHARGE,tempARINVT_for_GSPPS.UNIQUE_DISPO_LOC,tempARINVT_for_GSPPS.HEIJUNKA_SINCE_SCHED_DEMAND,tempARINVT_for_GSPPS.CONFIG_CODE,tempARINVT_for_GSPPS.AUTO_MRP_INCLUDE_VMI_MFG_CALC,tempARINVT_for_GSPPS.FR_WO_SCOPE,tempARINVT_for_GSPPS.AUTO_MRP_APPLY_TO_SCHED_ALLOC,tempARINVT_for_GSPPS.PHANTOM_COMPONENTS_ON_SO,tempARINVT_for_GSPPS.SCHED_CASCADE_PARENT_MTO,tempARINVT_for_GSPPS.AUTO_POP_SERV_CTR,tempARINVT_for_GSPPS.EXCL_MARK_WO_MAT_XCPT,tempARINVT_for_GSPPS.IS_ALC,tempARINVT_for_GSPPS.MARK_ORD_DETAIL_MTO,tempARINVT_for_GSPPS.MSDS_AUTHORABLE,tempARINVT_for_GSPPS.IS_MSDS,tempARINVT_for_GSPPS.MSDS_UPLOAD,tempARINVT_for_GSPPS.NONTAXABLE_PO,tempARINVT_for_GSPPS.OVERRIDE_REC_LOC,tempARINVT_for_GSPPS.IS_DROP_SHIP,tempARINVT_for_GSPPS.MAX_PALLET_STACK,tempARINVT_for_GSPPS.LOOSE_INV_MOVE_CLASS_ID,tempARINVT_for_GSPPS.PACK_INV_MOVE_CLASS_ID,tempARINVT_for_GSPPS.PALLET_INV_MOVE_CLASS_ID,tempARINVT_for_GSPPS.PK_UNIT_TYPE,tempARINVT_for_GSPPS.LOOSE_MOVE_RANK_COUNT,tempARINVT_for_GSPPS.PACK_MOVE_RANK_COUNT,tempARINVT_for_GSPPS.PALLET_MOVE_RANK_COUNT,tempARINVT_for_GSPPS.EXCL_WORKORDER_MAT,tempARINVT_for_GSPPS.FIFO,tempARINVT_for_GSPPS.COMPANY_ID,tempARINVT_for_GSPPS.RECV_LOCATION_ID,tempARINVT_for_GSPPS.SPC_INSPECTION_ID,tempARINVT_for_GSPPS.AR_DISCOUNT_WATERFALL_ID,tempARINVT_for_GSPPS.LBL_LAST_PRINT,tempARINVT_for_GSPPS.EXCL_FROM_CTP_EXCEPTION,tempARINVT_for_GSPPS.WMS_INV_GROUP_ID,tempARINVT_for_GSPPS.CORE_SIZE,tempARINVT_for_GSPPS.OD,tempARINVT_for_GSPPS.PS_CONVERT_INFO,tempARINVT_for_GSPPS.LOOSE_MOVE_RANK_LOCK,tempARINVT_for_GSPPS.PACK_MOVE_RANK_LOCK,tempARINVT_for_GSPPS.PALLET_MOVE_RANK_LOCK,tempARINVT_for_GSPPS.CYCLE_COUNT_RANK_LOCK,tempARINVT_for_GSPPS.MIN_SELL_QTY,tempARINVT_for_GSPPS.INSP_LEAD_DAYS,tempARINVT_for_GSPPS.LOOSE_WEIGHT,tempARINVT_for_GSPPS.LOOSE_VOLUME,tempARINVT_for_GSPPS.LOOSE_LENGTH,tempARINVT_for_GSPPS.LOOSE_WIDTH,tempARINVT_for_GSPPS.LOOSE_HEIGHT,tempARINVT_for_GSPPS.IS_LOT_EXPIRY_DATE_MANDATORY,tempARINVT_for_GSPPS.ICT_TRUCK_PTSPER,tempARINVT_for_GSPPS.SAFETY_STOCK2,tempARINVT_for_GSPPS.COST_CALC_USER_NAME,tempARINVT_for_GSPPS.SHELF_LIFE2,tempARINVT_for_GSPPS.ICT_AUTO_MRP_ORDER_QTY,tempARINVT_for_GSPPS.ICT_SHIP_PULL_DEMAND,tempARINVT_for_GSPPS.PLT_WRP_USE_QC,tempARINVT_for_GSPPS.PLT_WRP_LOC_ID,tempARINVT_for_GSPPS.HARD_ALLOC_ROUND_PRECISION,tempARINVT_for_GSPPS.BACKFLUSH_BY_SERIAL,tempARINVT_for_GSPPS.GROUP_CODE,tempARINVT_for_GSPPS.PROPRIETARY_EFFECT_DATE,tempARINVT_for_GSPPS.PROPRIETARY_DEACTIVE_DATE,tempARINVT_for_GSPPS.DEMAND_CHANGE,tempARINVT_for_GSPPS.TAX_CLASS_ID,tempARINVT_for_GSPPS.DISCOUNT_GROUPS_ID,tempARINVT_for_GSPPS.PHYS_CHAR_VOLUME,tempARINVT_for_GSPPS.PHANTOM_KIT_USE_COMP_PRICE,tempARINVT_for_GSPPS.ASSY1_EXCLUDE_FORECAST_WO,tempARINVT_for_GSPPS.LAST_DEMAND_CHANGE,tempARINVT_for_GSPPS.ARINVT_RECIPE_ID,tempARINVT_for_GSPPS.GL_PLUG_VALUE,tempARINVT_for_GSPPS.CAROUSEL_TARGET_ID,tempARINVT_for_GSPPS.CAROUSEL_OPERATOR,tempARINVT_for_GSPPS.CREATED,tempARINVT_for_GSPPS.CREATEDBY,tempARINVT_for_GSPPS.CHANGED,tempARINVT_for_GSPPS.CHANGEDBY,tempARINVT_for_GSPPS.ACCT_ID_INTRANSIT,tempARINVT_for_GSPPS.ACCT_ID_IP_TRANS,tempARINVT_for_GSPPS.ACCT_ID_IP_TRANS_VAR ";
                        stageIntoRealTableQuery += " FROM tempARINVT_for_GSPPS WHERE " +
                            "tempARINVT_for_GSPPS.ID >= " + countID + " and " +
                            "tempARINVT_for_GSPPS.ID < " + (countID + intMaxRowsAtATime) + ";";
                        stageIntoRealTableQuery += " END; ";

                        insert.CommandText = stageIntoRealTableQuery;

                        insert.ExecuteNonQuery();

                        Console.Write("\r " + (countID
                                            + "/" + newMaterials.Count).PadRight(80));

                        Console.Write("\r " + (Math.Min(countID + intMaxRowsAtATime, newMaterials.Count)
                                            + "/" + newMaterials.Count).PadRight(80));
                    }
                    //Console.WriteLine("\n Done");
                }
            }
        }

        public string GetControlFilePath()
        {
            return controlFilePath;
        }

        public string GetSqlLoaderTableName()
        {
            return sqlLoaderTableName;
        }

        /// <summary>
        /// This table is reponsible for creating the temporary table tempARINVT_for_GSPPS 
        /// (recreate if it already exists)
        /// </summary>
        private void CreateTemporaryTable()
        {
            Console.Write(" Getting temporary Table ready...");

            Directory.CreateDirectory(SpecFolder + "ARINVT\\Loader\\");
            using (StreamWriter sw = new StreamWriter(SpecFolder
                + "ARINVT\\Loader\\tempARINVT_for_GSPPS.csv", false))
            {
                sw.Write("");
                sw.Close();
            }

            createTempTableQuery = "  ";
            createTempTableQuery += " BEGIN ";
            createTempTableQuery += "   execute immediate 'drop table tempARINVT_for_GSPPS'; ";
            createTempTableQuery += "   exception when others then null;  ";
            createTempTableQuery += " END; ";

            using (OracleConnection db = OracleConnectionFactory.IQMSConnection)
            {
                using (OracleCommand insert = new OracleCommand(createTempTableQuery, db))
                {
                    insert.CommandType = CommandType.Text;
                    insert.CommandTimeout = 0;

                    insert.ExecuteNonQuery();
                }
            }

            createTempTableQuery = " CREATE TABLE tempARINVT_for_GSPPS ";
            createTempTableQuery += " AS (SELECT * FROM ARINVT WHERE 1=2)";

            using (OracleConnection db = OracleConnectionFactory.IQMSConnection)
            {
                using (OracleCommand insert = new OracleCommand(createTempTableQuery, db))
                {
                    insert.CommandType = CommandType.Text;
                    insert.CommandTimeout = 0;

                    insert.ExecuteNonQuery();
                }
            }

            createTempTableQuery = " CREATE UNIQUE INDEX ARINVT_unique_index ON " +
                "tempARINVT_for_GSPPS (CLASS, ITEMNO, REV) ";

            using (OracleConnection db = OracleConnectionFactory.IQMSConnection)
            {
                using (OracleCommand insert = new OracleCommand(createTempTableQuery, db))
                {
                    insert.CommandType = CommandType.Text;
                    insert.CommandTimeout = 0;

                    insert.ExecuteNonQuery();
                }
            }

            createTempTableQuery = " CREATE UNIQUE INDEX ARINVT_unique_ID_index ON " +
                                    "tempARINVT_for_GSPPS (ID) ";

            using (OracleConnection db = OracleConnectionFactory.IQMSConnection)
            {
                using (OracleCommand insert = new OracleCommand(createTempTableQuery, db))
                {
                    insert.CommandType = CommandType.Text;
                    insert.CommandTimeout = 0;

                    insert.ExecuteNonQuery();
                }
            }
            Console.WriteLine(" Done");
        }

        /// <summary>
        /// this method is responsible for getting the actual columnnames or table in question: ARINVT
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private static void GetColumnNames()
        {
            ARINVTColumns.Clear();
            Console.Write(" Getting ARINVT columns...");
            using (OracleConnection dbO = OracleConnectionFactory.IQMSConnection)
            {
                using (OracleCommand select = new OracleCommand(
                    "SELECT * FROM ARINVT WHERE ROWNUM = 1 ", dbO))
                {
                    select.CommandType = CommandType.Text;
                    select.CommandTimeout = 0;
                    using (OracleDataReader reader = select.ExecuteReader())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            ARINVTColumns.Append(reader.GetName(i) + "|");
                        }
                    }
                }
            }

            ARINVTColumns.Length--; //remove last comma
            Console.WriteLine(" Done");
        }

        public void process(string specsFolder, SPECIFICATION pkgSpec,
                        List<DETAILS> currentDetails, List<BOM> currentBOM,
                        List<REMARKCODE> currentRemarkCode, REMARK rmk, string rawSpec)
        {
            sbNewLine.Clear();
            sbNewLine.Append(ARINVTColumns).AppendLine();
            sbNewLine.Append(SetUpFinishedGood("FG", pkgSpec, currentDetails)).AppendLine();
            sbNewLine.Append(SetUpFinishedGood("FD", pkgSpec, currentDetails)).AppendLine();

            foreach (DET.DETAILS details in currentDetails)
            {
                if (details.PartIsValid())
                {
                    sbNewLine.Append(SetUpPackaging("PK", pkgSpec, details)).AppendLine();
                }
            }

            // do not append =  a new part file

            //*
            Directory.CreateDirectory(specsFolder + "ARINVT\\");
            using (StreamWriter sw = new StreamWriter(specsFolder 
                + "ARINVT\\" + pkgSpec.PackedServicePart + ".csv", false))
            {
                sw.Write(sbNewLine.ToString());
                //sw.Close();
            }
            //*/
        }

        private StringBuilder SetUpPackaging(string mappingType,
            DET.SPECIFICATION pkgSpec, DET.DETAILS details)
        {
            packagingStringLine.Clear();

            #region BUILD MATERIALS
            packagingStringLine
                    .Append("|") //ID  NUMBER(15, 0)
                    .Append("|") //ARCUSTO_ID  NUMBER(15, 0)
                    .Append(mappingType + "|") //CLASS   VARCHAR2(2 BYTE)
                    .Append(details.ProcessOrMaterialCode + "|") //ITEMNO  VARCHAR2(50 BYTE)
                    .Append("0" + "|") //.Append(details.Version + "|") //REV VARCHAR2(15 BYTE)
                                       //make sure the comma is not part of this descriptiom
                    .Append(details.ProcessOrMaterialDescription + "|") //DESCRIP VARCHAR2(100 BYTE)
                    .Append("" + "|") //DESCRIP2    VARCHAR2(100 BYTE)
                    .Append("|") //AVG_COST    NUMBER(15, 6)
                    .Append("|") //VENDOR_ID   NUMBER(15, 0)
                    .Append("EACH" + "|") //UNIT    VARCHAR2(10 BYTE)
                    .Append("|") //BLEND   VARCHAR2(1 BYTE)
                    .Append("|") //.Append(pkgSpec.SalesPartNo + "|") //CUSER1  VARCHAR2(60 BYTE)
                    .Append("|") //CUSER2  VARCHAR2(60 BYTE)
                    .Append("|") //CUSER3  VARCHAR2(60 BYTE)
                    .Append("|") //NUSER1  NUMBER(15, 6)
                    .Append("|") //NUSER2  NUMBER(15, 6)
                    .Append("|") //NUSER3  NUMBER(15, 6)
                    .Append("|") //BOM_ACTIVE  VARCHAR2(1 BYTE)
                    .Append("|") //ONHAND  NUMBER(14, 4)
                    .Append("|") //RG_ONHAND   NUMBER(14, 4)
                    .Append("|") //NON_SALABLE VARCHAR2(1 BYTE)
                    .Append("|") //NON_CONFORM_TOTAL   NUMBER(14, 4)
                    .Append("|") //SERIALIZED  VARCHAR2(1 BYTE)
                    .Append("|") //SAFETY_STOCK    NUMBER(14, 4)
                    .Append("|") //MIN_ORDER_QTY   NUMBER(14, 4)
                    .Append("|") //MAX_ORDER_QTY   NUMBER(14, 4)
                    .Append("|") //MULTIPLE    NUMBER(14, 4)
                    .Append("|") //YTDQTY  NUMBER(12, 0)
                    .Append("|") //PTDQTY  NUMBER(12, 0)
                    .Append("|") //CODE    VARCHAR2(1 BYTE)
                    .Append("|") //LDATE   DATE
                    .Append("|") //LBUY_DATE   DATE
                    .Append("|") //TYPE    VARCHAR2(5 BYTE)
                    .Append("|") //SERIES  VARCHAR2(10 BYTE)
                    .Append("|") //LEAD_DAYS   NUMBER(3, 0)
                    .Append("|") //LEAD_TIME   VARCHAR2(10 BYTE)
                    .Append("|") //SPG NUMBER(15, 6)
                    .Append("|") //DRYTIME NUMBER(2, 0)
                    .Append("|") //DRYTEMP VARCHAR2(10 BYTE)
                    .Append("|") //RGPRCNT NUMBER(3, 0)
                    .Append("|") //AUTO_MJO    VARCHAR2(6 BYTE)
                    .Append("|") //MFG_QUAN    NUMBER(14, 4)
                    .Append("|") //AUX_AMT NUMBER(15, 6)
                    .Append("|") //STDQUAN NUMBER(10, 0)
                    .Append("|") //LOW_LEVEL_CODE  NUMBER(3, 0)
                    .Append("|") //MPS_CODE    VARCHAR2(1 BYTE)
                    .Append("|") //ARINVT_FAMILY_ID    NUMBER(15, 0)
                    .Append("Y" + "|") //BACKFLUSH   VARCHAR2(1 BYTE)
                    .Append("|") //DRAWING VARCHAR2(30 BYTE)
                    .Append("|") //ECNO    VARCHAR2(25 BYTE)
                    .Append("|") //STD_PRICE   NUMBER(15, 6)
                    .Append("|") //STD_COST    NUMBER(15, 6)
                    .Append("|") //STANDARD_ID NUMBER(15, 0)
                    .Append("|") //ACCT_ID_SALES   NUMBER(15, 0)
                    .Append("|") //ACCT_ID_INV NUMBER(15, 0)
                    .Append("|") //MFG_SPLIT   VARCHAR2(1 BYTE)
                    .Append("|") //PRICE_PER_1000  VARCHAR2(1 BYTE)
                    .Append("|") //COMIS_PRCNT NUMBER(15, 6)
                    .Append("|") //UNQUE_DATE_IN   VARCHAR2(1 BYTE)
                    .Append("|") //SHELF_LIFE  NUMBER(4, 0)
                    .Append("|") //ECODE   VARCHAR2(10 BYTE)
                    .Append("|") //EID NUMBER(15, 0)
                    .Append("|") //EDATE_TIME  DATE
                    .Append("|") //ECOPY   VARCHAR2(1 BYTE)
                    .Append("|") //ACCT_ID_PPV NUMBER(15, 0)
                    .Append("|") //ACCT_ID_OH_DISPO    NUMBER(15, 0)
                    .Append("|") //ACCT_ID_LABOR_DISPO NUMBER(15, 0)
                    .Append("|") //ACCT_ID_HOLDING NUMBER(15, 0)
                    .Append("|") //ITEM_TYPE_ID    NUMBER(15, 0)
                    .Append("|") //NMFC_ID NUMBER(15, 0)
                    .Append("|") //VOLUME  NUMBER(15, 6)
                    .Append("|") //AUTO_MRP_REORD_POINT    NUMBER(12, 2)
                    .Append("|") //AUTO_MRP_ORDER_QTY  NUMBER(12, 2)
                    .Append("|") //AUTO_MRP_LEAD_DAYS  NUMBER(5, 2)
                    .Append("5" + "|") //EPLANT_ID   NUMBER(15, 0)
                    .Append("|") //COMMISSIONS_ID  NUMBER(15, 0)
                    .Append("|") //STD_COST_CONTROL    VARCHAR2(60 BYTE)
                    .Append("0" + "|") //PO_SCOPE    NUMBER(3, 0)
                    .Append("0" + "|") //PO_SAFETY   NUMBER(3, 0)
                    .Append("0" + "|") //PO_MOVE_RANGE   NUMBER(3, 0)
                    .Append("|") //LM_IMAGE_FILENAME   VARCHAR2(50 BYTE)
                    .Append("|") //CYCLE_COUNT_CODE    VARCHAR2(15 BYTE)
                    .Append("|") //CUSER4  VARCHAR2(60 BYTE)
                    .Append("|") //CUSER5  VARCHAR2(60 BYTE)
                    .Append("|") //CUSER6  VARCHAR2(60 BYTE)
                    .Append("|") //CUSER7  VARCHAR2(60 BYTE)
                    .Append("|") //CUSER8  VARCHAR2(60 BYTE)
                    .Append("|") //CUSER9  VARCHAR2(60 BYTE)
                    .Append("|") //CUSER10 VARCHAR2(60 BYTE)
                    .Append("|") //NUSER4  NUMBER(15, 6)
                    .Append("|") //NUSER5  NUMBER(15, 6)
                    .Append("|") //NUSER6  NUMBER(15, 6)
                    .Append("|") //NUSER7  NUMBER(15, 6)
                    .Append("|") //NUSER8  NUMBER(15, 6)
                    .Append("|") //NUSER9  NUMBER(15, 6)
                    .Append("|") //details.UPCCode + "|") //NUSER10 NUMBER(15, 6)
                    .Append("|") //PROCESS_SAFETY_STOCK    VARCHAR2(1 BYTE)
                    .Append("|") //MX_GROUP_ID NUMBER(15, 0)
                    .Append("|") //FR_GROUP_ID NUMBER(15, 0)
                    .Append("|") //SETUP_CHARGE    NUMBER(15, 6)
                    .Append("|") //MOVE_TIME   NUMBER(7, 3)
                    .Append("|") //CARTONS_PALLET  NUMBER(15, 6)
                    .Append("|") //PIECES_CARTON   NUMBER(15, 6)
                    .Append("|") //AUTO_MRP_FIRM_WO    VARCHAR2(1 BYTE)
                    .Append("|") //FLOOR_BACKFLUSH VARCHAR2(1 BYTE)
                    .Append("|") //MPS VARCHAR2(1 BYTE)
                    .Append("|") //CUM_LEADTIME    NUMBER(8, 2)
                    .Append("|") //PHANTOM VARCHAR2(1 BYTE)
                    .Append("|") //CRITICAL_FENCE  NUMBER(3, 0)
                    .Append("|") //USER_NAME   VARCHAR2(35 BYTE)
                    .Append("|") //PK_HIDE VARCHAR2(1 BYTE)
                    .Append("|") //ACCT_ID_PRODVAR NUMBER(15, 0)
                    .Append("|") //PHANTOM_ONHAND  NUMBER(14, 4)
                    .Append("|") //LM_LABELS_ID    NUMBER(15, 0)
                    .Append("|") //DRIVE_PHANTOM_NEGATIVE  VARCHAR2(1 BYTE)
                    .Append("|") //NO_STDCOST_RECALC   VARCHAR2(1 BYTE)
                    .Append("|") //ACCT_ID_INTPLANT_SALES  NUMBER(15, 0)
                    .Append("|") //IMAGE_FILENAME  VARCHAR2(250 BYTE)
                    .Append("|") //NON_ALLOCATE_TOTAL  NUMBER(14, 4)
                    .Append("|") //INSP_RECEIPT_THRES  NUMBER(5, 0)
                    .Append("|") //INSP_RECEIPT_COUNT  NUMBER(5, 0)
                    .Append("|") //COST_STANDARD_ID_FUTURE NUMBER(15, 0)
                    .Append("|") //COST_STANDARD_ID    NUMBER(15, 0)
                    .Append("|") //COST_DESCRIP_FUTURE VARCHAR2(50 BYTE)
                    .Append("|") //COST_DESCRIP    VARCHAR2(50 BYTE)
                    .Append("|") //COST_CALC_DATE_FUTURE   DATE
                    .Append("|") //COST_CALC_DATE  DATE
                    .Append("|") //AUTO_MRP_INCLUDE_VMI    VARCHAR2(1 BYTE)
                    .Append("|") //PROD_CODE_ID    NUMBER(15, 0)
                    .Append("|") //DO_NOT_DISPO_FLOOR_PARTIAL  VARCHAR2(1 BYTE)
                    .Append("|") //INFO_SO VARCHAR2(2000 BYTE)
                    .Append("|") //INFO_PO VARCHAR2(2000 BYTE)
                    .Append("|") //EXCL_RECEIPT_TIME_PPV   VARCHAR2(1 BYTE)
                    .Append("|") //CYCLE_COUNT_ID  NUMBER(15, 0)
                    .Append("|") //CYCLE_COUNT_DATE    DATE
                    .Append(((details.Quantity > 0) ? "N" : "Y") + "|") //NON_MATERIAL    VARCHAR2(1 BYTE)
                    .Append("|") //MFG_MIN_QTY NUMBER(14, 4)
                    .Append("|") //MFG_MULTIPLE    NUMBER(14, 4)
                    .Append("|") //BUYER_CODE_ID   NUMBER(15, 0)
                    .Append("|") //COST_CALC_BATCH NUMBER(15, 0)
                    .Append("|") //INTRASTAT_CODE  VARCHAR2(25 BYTE)
                    .Append("|") //FAB_START   VARCHAR2(1 BYTE)
                    .Append("|") //MFG_SAFETY_QTY  NUMBER(14, 4)
                    .Append("|") //PLANNER_CODE_ID NUMBER(15, 0)
                    .Append("|") //IS_LOT_MANDATORY    VARCHAR2(1 BYTE)
                    .Append("0" + "|") //PK_WEIGHT   NUMBER(13, 6)
                    .Append("|") //PK_PTSPER   NUMBER(15, 6)
                    .Append("|") //DO_NOT_SCHED_FORECAST_WO    VARCHAR2(1 BYTE)
                    .Append("|") //IS_PALLET   VARCHAR2(1 BYTE)
                    .Append("|") //IS_AUTO_RT_LABELS   VARCHAR2(1 BYTE)
                    .Append("|") //IS_LINKED_TO_SERIAL VARCHAR2(1 BYTE)
                    .Append("|") //FR_INCLUDE  VARCHAR2(1 BYTE)
                    .Append("|") //MIN_CPK NUMBER(15, 6)
                    .Append("|") //LBL_ASSIST_LAST_PRINT   DATE
                    .Append("|") //LBL_ASSIST_PRINT_INTERVAL   NUMBER(5, 0)
                    .Append("|") //COC_EXCLUDE VARCHAR2(1 BYTE)
                    .Append("|") //ICT_REORD_POINT NUMBER(12, 2)
                    .Append("|") //ICT_REPLENISH_SCOPE_DAYS    NUMBER(3, 0)
                    .Append("|") //ICT_LEAD_DAYS   NUMBER(3, 0)
                    .Append("|") //ICT_SHIP_TO_ID  NUMBER(15, 0)
                    .Append("|") //AUTO_MRP_KANBAN_LOT_SIZE    NUMBER(15, 6)
                    .Append("|") //ICT_FIRE_TRIGGER    VARCHAR2(1 BYTE)
                    .Append("|") //COLOR_GROUP_ID  NUMBER(15, 0)
                    .Append("|") //FR_WO_TIME_FENCE    NUMBER(5, 2)
                    .Append(details.UnitizationPerLength + "|") //PK_LENGTH   NUMBER(15, 6)
                    .Append(details.UnitizationPerWidth + "|") //PK_WIDTH    NUMBER(15, 6)
                    .Append(details.UnitizationPerDepth + "|") //PK_HEIGHT   NUMBER(15, 6)
                    .Append(pkgSpec.UnitizationPerLength + "|") //PALLET_LENGTH   NUMBER(15, 6)
                    .Append(pkgSpec.UnitizationPerWidth + "|") //PALLET_WIDTH    NUMBER(15, 6)
                    .Append(pkgSpec.UnitizationPerDepth + "|") //PALLET_HEIGHT   NUMBER(15, 6)
                    .Append("|") //PALLET_VOLUME   NUMBER(15, 6)
                    .Append("|") //.Append(details.Quantity + "|") // pkgSpec.UnitPackageQuantity + "|") //PALLET_PTSPER   NUMBER(15, 6)
                    .Append("|") //PALLET_WEIGHT   NUMBER(15, 6)
                    .Append("|") //LENGTH  NUMBER(15, 6)
                    .Append("|") //WIDTH   NUMBER(15, 6)
                    .Append("|") //GAUGE   NUMBER(15, 6)
                    .Append("|") //IS_BY_PRODUCT   VARCHAR2(1 BYTE)
                    .Append("|") //EXCLUDE_FROM_COMMISSIONS    VARCHAR2(1 BYTE)
                    .Append("|") //AUTO_RT_LABELS_PK_SEQ   NUMBER(3, 0)
                    .Append("|") //PALLET_PATTERN_ID   NUMBER(15, 0)
                    .Append("|") //WEB_SALABLE VARCHAR2(1 BYTE)
                    .Append("|") //PO_MULTIPLE NUMBER(14, 4)
                    .Append("|") //FIFO_THRESHOLD  NUMBER(5, 2)
                    .Append("|") //COST_STANDARD_ID_FORECAST   NUMBER(15, 0)
                    .Append("|") //COST_STANDARD_ID_BUDGET NUMBER(15, 0)
                    .Append("|") //COST_DESCRIP_FORECAST   VARCHAR2(50 BYTE)
                    .Append("|") //COST_DESCRIP_BUDGET VARCHAR2(50 BYTE)
                    .Append("|") //COST_CALC_DATE_FORECAST DATE
                    .Append("|") //COST_CALC_DATE_BUDGET   DATE
                    .Append("|") //KEEP_LABEL_BOM_INTERPLANT_TRAN  VARCHAR2(1 BYTE)
                    .Append("|") //ECO_ORIG_CLASS  VARCHAR2(2 BYTE)
                    .Append("|") //ACCT_ID_WIP NUMBER(15, 0)
                    .Append("|") //IRV32_NO_PLAN_WO    VARCHAR2(1 BYTE)
                    .Append("|") //INFO_REC    VARCHAR2(2000 BYTE)
                    .Append("|") //IS_LOT_DATE_MANDATORY   VARCHAR2(1 BYTE)
                    .Append("|") //USE_THIS_UOM_FOR_MRP    VARCHAR2(1 BYTE)
                    .Append("|") //WAIT_TIME   NUMBER(7, 3)
                    .Append("|") //BOL_CALC_OVERRIDE   VARCHAR2(1 BYTE)
                    .Append("|") //RFQ_USE_STD_COST    VARCHAR2(1 BYTE)
                    .Append("|") //ACCT_ID_PHYS_VAR    NUMBER(15, 0)
                    .Append("|") //ACCT_ID_INV_COST_REV    NUMBER(15, 0)
                    .Append("|") //EXCLUDE_BACKFLUSH   VARCHAR2(1 BYTE)
                    .Append("|") //NONTAXABLE  VARCHAR2(1 BYTE)
                    .Append("|") //ACCT_ID_SHIPMENT    NUMBER(15, 0)
                    .Append("|") //AUTO_MRP_EXCLUDE_HARD_ALLOC VARCHAR2(1 BYTE)
                    .Append("|") //MIN_PPK NUMBER(15, 6)
                    .Append("|") //RUN_RULES   VARCHAR2(20 BYTE)
                    .Append("|") //RTPM_TRG_RTLABEL    VARCHAR2(1 BYTE)
                    .Append("|") //REBATE_PARAMS_ID    NUMBER(15, 0)
                    .Append("|") //TARIFF_CODE_ID  NUMBER(15, 0)
                    .Append("|") //WEBDIRECT_LEAD_DAYS NUMBER(5, 0)
                    .Append("|") //USE_COST_DEFAULT_STANDARD_ID    VARCHAR2(1 BYTE)
                    .Append("|") //ARINVT_GROUP_ID NUMBER(15, 0)
                    .Append("|") //CLONED_FROM_ARINVT_ID   NUMBER(15, 0)
                    .Append("|") //USE_LOT_CHARGE  VARCHAR2(1 BYTE)
                    .Append("|") //LOT_CHARGE  NUMBER(15, 6)
                    .Append("|") //UNIQUE_DISPO_LOC    VARCHAR2(1 BYTE)
                    .Append("|") //HEIJUNKA_SINCE_SCHED_DEMAND NUMBER(15, 6)
                    .Append("|") //CONFIG_CODE VARCHAR2(255 BYTE)
                    .Append("|") //AUTO_MRP_INCLUDE_VMI_MFG_CALC   VARCHAR2(1 BYTE)
                    .Append("|") //FR_WO_SCOPE NUMBER(5, 0)
                    .Append("|") //AUTO_MRP_APPLY_TO_SCHED_ALLOC   VARCHAR2(1 BYTE)
                    .Append("|") //PHANTOM_COMPONENTS_ON_SO    VARCHAR2(1 BYTE)
                    .Append("|") //SCHED_CASCADE_PARENT_MTO    VARCHAR2(1 BYTE)
                    .Append("|") //AUTO_POP_SERV_CTR   VARCHAR2(1 BYTE)
                    .Append("|") //EXCL_MARK_WO_MAT_XCPT   VARCHAR2(1 BYTE)
                    .Append("|") //IS_ALC  CHAR(1 BYTE)
                    .Append("|") //MARK_ORD_DETAIL_MTO VARCHAR2(1 BYTE)
                    .Append("|") //MSDS_AUTHORABLE VARCHAR2(1 BYTE)
                    .Append("|") //IS_MSDS VARCHAR2(1 BYTE)
                    .Append("|") //MSDS_UPLOAD VARCHAR2(1 BYTE)
                    .Append("|") //NONTAXABLE_PO   VARCHAR2(1 BYTE)
                    .Append("|") //OVERRIDE_REC_LOC    VARCHAR2(1 BYTE)
                    .Append("|") //IS_DROP_SHIP    VARCHAR2(1 BYTE)
                    .Append("|") //MAX_PALLET_STACK    NUMBER(2, 0)
                    .Append("|") //LOOSE_INV_MOVE_CLASS_ID NUMBER(15, 0)
                    .Append("|") //PACK_INV_MOVE_CLASS_ID  NUMBER(15, 0)
                    .Append("|") //PALLET_INV_MOVE_CLASS_ID    NUMBER(15, 0)
                    .Append("|") //PK_UNIT_TYPE    VARCHAR2(1 BYTE)
                    .Append("|") //LOOSE_MOVE_RANK_COUNT   NUMBER(15, 0)
                    .Append("|") //PACK_MOVE_RANK_COUNT    NUMBER(15, 0)
                    .Append("|") //PALLET_MOVE_RANK_COUNT  NUMBER(15, 0)
                    .Append("|") //EXCL_WORKORDER_MAT  VARCHAR2(1 BYTE)
                    .Append("|") //FIFO    VARCHAR2(1 BYTE)
                    .Append("|") //COMPANY_ID  NUMBER(15, 0)
                    .Append("|") //RECV_LOCATION_ID    NUMBER(15, 0)
                    .Append("|") //SPC_INSPECTION_ID   NUMBER(15, 0)
                    .Append("|") //AR_DISCOUNT_WATERFALL_ID    NUMBER(15, 0)
                    .Append("|") //LBL_LAST_PRINT  DATE
                    .Append("|") //EXCL_FROM_CTP_EXCEPTION VARCHAR2(1 BYTE)
                    .Append("|") //WMS_INV_GROUP_ID    NUMBER(15, 0)
                    .Append("|") //CORE_SIZE   NUMBER(15, 6)
                    .Append("|") //OD  NUMBER(15, 6)
                    .Append("|") //PS_CONVERT_INFO VARCHAR2(2000 BYTE)
                    .Append("|") //LOOSE_MOVE_RANK_LOCK    VARCHAR2(1 BYTE)
                    .Append("|") //PACK_MOVE_RANK_LOCK VARCHAR2(1 BYTE)
                    .Append("|") //PALLET_MOVE_RANK_LOCK   VARCHAR2(1 BYTE)
                    .Append("|") //CYCLE_COUNT_RANK_LOCK   VARCHAR2(1 BYTE)
                    .Append("|") //MIN_SELL_QTY    NUMBER(14, 4)
                    .Append("|") //INSP_LEAD_DAYS  NUMBER(3, 0)
                    .Append("|") //LOOSE_WEIGHT    NUMBER(15, 6)
                    .Append("|") //LOOSE_VOLUME    NUMBER(15, 6)
                    .Append(details.ContainerCLengthOutside + "|") //LOOSE_LENGTH    NUMBER(15, 6)
                    .Append(details.ContainerCWidthOutside + "|") //LOOSE_WIDTH NUMBER(15, 6)
                    .Append(details.ContainerCDepthOutside + "|") //LOOSE_HEIGHT    NUMBER(15, 6)
                    .Append("|") //IS_LOT_EXPIRY_DATE_MANDATORY    VARCHAR2(1 BYTE)
                    .Append("|") //ICT_TRUCK_PTSPER    NUMBER(15, 6)
                    .Append("|") //SAFETY_STOCK2   NUMBER(14, 4)
                    .Append("|") //COST_CALC_USER_NAME VARCHAR2(30 BYTE)
                    .Append("|") //SHELF_LIFE2 NUMBER(4, 0)
                    .Append("|") //ICT_AUTO_MRP_ORDER_QTY  NUMBER(12, 2)
                    .Append("|") //ICT_SHIP_PULL_DEMAND    VARCHAR2(1 BYTE)
                    .Append("|") //PLT_WRP_USE_QC  VARCHAR2(1 BYTE)
                    .Append("|") //PLT_WRP_LOC_ID  NUMBER(15, 0)
                    .Append("|") //HARD_ALLOC_ROUND_PRECISION  NUMBER(2, 0)
                    .Append("|") //BACKFLUSH_BY_SERIAL VARCHAR2(1 BYTE)
                    .Append("|") //GROUP_CODE  VARCHAR2(20 BYTE)
                    .Append("|") //PROPRIETARY_EFFECT_DATE DATE
                    .Append("|") //PROPRIETARY_DEACTIVE_DATE   DATE
                    .Append("|") //DEMAND_CHANGE   VARCHAR2(1 BYTE)
                    .Append("|") //TAX_CLASS_ID    NUMBER(15, 0)
                    .Append("|") //DISCOUNT_GROUPS_ID  NUMBER(15, 0)
                    .Append("|") //PHYS_CHAR_VOLUME    NUMBER(15, 6)
                    .Append("|") //PHANTOM_KIT_USE_COMP_PRICE  VARCHAR2(1 BYTE)
                    .Append("|") //ASSY1_EXCLUDE_FORECAST_WO   VARCHAR2(1 BYTE)
                    .Append("|") //LAST_DEMAND_CHANGE  DATE
                    .Append("|") //ARINVT_RECIPE_ID    NUMBER(15, 0)
                    .Append("|") //GL_PLUG_VALUE   VARCHAR2(50 BYTE)
                    .Append("|") //CAROUSEL_TARGET_ID  NUMBER(15, 0)
                    .Append("|") //CAROUSEL_OPERATOR   NUMBER(5, 2)
                    .Append("|") //CREATED DATE
                    .Append("|") //CREATEDBY   VARCHAR2(20 BYTE)
                    .Append("|") //CHANGED DATE
                    .Append("|") //CHANGEDBY   VARCHAR2(20 BYTE)
                    .Append("|") //ACCT_ID_INTRANSIT   NUMBER(15, 0)
                    .Append("|") //ACCT_ID_IP_TRANS    NUMBER(15, 0)
                    .Append("|"); //ACCT_ID_IP_TRANS_VAR    NUMBER(15, 0)
            #endregion

            PreloadData(packagingStringLine, pkgSpec);

            return packagingStringLine;
        }

        private StringBuilder SetUpFinishedGood(string mappingType,
            DET.SPECIFICATION pkgSpec, List<DET.DETAILS> currentDetails)
        {
            string partNumber = ((mappingType.Equals("FG")) ? pkgSpec.ServicePartNo : pkgSpec.PackedServicePart);
            string partName = ((pkgSpec.PartName.Equals("")) ? pkgSpec.ServicePartNo : pkgSpec.PartName);

            finishedGoodString.Clear();

            #region BUILD PARTNUMBER
            finishedGoodString
                .Append("|") //ID  NUMBER(15, 0)
                .Append("|") //ARCUSTO_ID  NUMBER(15, 0)
                .Append(mappingType + "|") //CLASS   VARCHAR2(2 BYTE)
                .Append(partNumber + "|") //ITEMNO  VARCHAR2(50 BYTE)
                .Append(pkgSpec.Version + "|") //REV VARCHAR2(15 BYTE)
                .Append(partName + "|") //DESCRIP VARCHAR2(100 BYTE)
                .Append("" + "|") //DESCRIP2    VARCHAR2(100 BYTE)
                .Append("|") //AVG_COST    NUMBER(15, 6)
                .Append("|") //VENDOR_ID   NUMBER(15, 0)
                .Append("EACH" + "|") //UNIT    VARCHAR2(10 BYTE)
                .Append("|") //BLEND   VARCHAR2(1 BYTE)
                .Append(pkgSpec.SalesPartNo + "|") //CUSER1  VARCHAR2(60 BYTE)
                .Append(pkgSpec.EngineeringPart1 + "|") //CUSER2  VARCHAR2(60 BYTE)
                .Append(pkgSpec.CountryOfOrigin + "|") //CUSER3  VARCHAR2(60 BYTE)
                .Append(pkgSpec.EndItemFinisNo + "|") //NUSER1  NUMBER(15, 6)
                .Append("|") //NUSER2  NUMBER(15, 6) pkgSpec.UpcCodeNumber + 
                .Append("|") //NUSER3  NUMBER(15, 6)
                .Append("|") //BOM_ACTIVE  VARCHAR2(1 BYTE)
                .Append("|") //ONHAND  NUMBER(14, 4)
                .Append("|") //RG_ONHAND   NUMBER(14, 4)
                .Append("|") //NON_SALABLE VARCHAR2(1 BYTE)
                .Append("|") //NON_CONFORM_TOTAL   NUMBER(14, 4)
                .Append("|") //SERIALIZED  VARCHAR2(1 BYTE)
                .Append("|") //SAFETY_STOCK    NUMBER(14, 4)
                .Append("|") //MIN_ORDER_QTY   NUMBER(14, 4)
                .Append("|") //MAX_ORDER_QTY   NUMBER(14, 4)
                .Append("|") //MULTIPLE    NUMBER(14, 4)
                .Append("|") //YTDQTY  NUMBER(12, 0)
                .Append("|") //PTDQTY  NUMBER(12, 0)
                .Append("|") //CODE    VARCHAR2(1 BYTE)
                .Append("|") //LDATE   DATE
                .Append("|") //LBUY_DATE   DATE
                .Append("|") //TYPE    VARCHAR2(5 BYTE)
                .Append("|") //SERIES  VARCHAR2(10 BYTE)
                .Append("|") //LEAD_DAYS   NUMBER(3, 0)
                .Append("|") //LEAD_TIME   VARCHAR2(10 BYTE)
                .Append("|") //SPG NUMBER(15, 6)
                .Append("|") //DRYTIME NUMBER(2, 0)
                .Append("|") //DRYTEMP VARCHAR2(10 BYTE)
                .Append("|") //RGPRCNT NUMBER(3, 0)
                .Append("|") //AUTO_MJO    VARCHAR2(6 BYTE)
                .Append("|") //MFG_QUAN    NUMBER(14, 4)
                .Append("|") //AUX_AMT NUMBER(15, 6)
                .Append("|") //STDQUAN NUMBER(10, 0)
                .Append("|") //LOW_LEVEL_CODE  NUMBER(3, 0)
                .Append("|") //MPS_CODE    VARCHAR2(1 BYTE)
                .Append("|") //ARINVT_FAMILY_ID    NUMBER(15, 0)
                .Append("Y" + "|") //BACKFLUSH   VARCHAR2(1 BYTE)
                .Append("|") //DRAWING VARCHAR2(30 BYTE)
                .Append("|") //ECNO    VARCHAR2(25 BYTE)
                .Append("|") //STD_PRICE   NUMBER(15, 6)
                .Append("|") //STD_COST    NUMBER(15, 6)
                .Append("|") //STANDARD_ID NUMBER(15, 0)
                .Append("|") //ACCT_ID_SALES   NUMBER(15, 0)
                .Append("|") //ACCT_ID_INV NUMBER(15, 0)
                .Append("|") //MFG_SPLIT   VARCHAR2(1 BYTE)
                .Append("|") //PRICE_PER_1000  VARCHAR2(1 BYTE)
                .Append("|") //COMIS_PRCNT NUMBER(15, 6)
                .Append("|") //UNQUE_DATE_IN   VARCHAR2(1 BYTE)
                .Append("|") //SHELF_LIFE  NUMBER(4, 0)
                .Append("|") //ECODE   VARCHAR2(10 BYTE)
                .Append("|") //EID NUMBER(15, 0)
                .Append("|") //EDATE_TIME  DATE
                .Append("|") //ECOPY   VARCHAR2(1 BYTE)
                .Append("|") //ACCT_ID_PPV NUMBER(15, 0)
                .Append("|") //ACCT_ID_OH_DISPO    NUMBER(15, 0)
                .Append("|") //ACCT_ID_LABOR_DISPO NUMBER(15, 0)
                .Append("|") //ACCT_ID_HOLDING NUMBER(15, 0)
                .Append("|") //ITEM_TYPE_ID    NUMBER(15, 0)
                .Append("|") //NMFC_ID NUMBER(15, 0)
                .Append("|") //VOLUME  NUMBER(15, 6)
                .Append("|") //AUTO_MRP_REORD_POINT    NUMBER(12, 2)
                .Append("|") //AUTO_MRP_ORDER_QTY  NUMBER(12, 2)
                .Append("|") //AUTO_MRP_LEAD_DAYS  NUMBER(5, 2)
                .Append("5" + "|") //EPLANT_ID   NUMBER(15, 0)
                .Append("|") //COMMISSIONS_ID  NUMBER(15, 0)
                .Append("|") //STD_COST_CONTROL    VARCHAR2(60 BYTE)
                .Append("0" + "|") //PO_SCOPE    NUMBER(3, 0)
                .Append("0" + "|") //PO_SAFETY   NUMBER(3, 0)
                .Append("0" + "|") //PO_MOVE_RANGE   NUMBER(3, 0)
                .Append("|") //LM_IMAGE_FILENAME   VARCHAR2(50 BYTE)
                .Append("|") //CYCLE_COUNT_CODE    VARCHAR2(15 BYTE)
                .Append(pkgSpec.PrimarySupplier + "|") //CUSER4  VARCHAR2(60 BYTE)
                .Append(pkgSpec.SecondarySupplier + "|") //CUSER5  VARCHAR2(60 BYTE)
                .Append(pkgSpec.ExpirationDate.ToString("ddMMMyyyy").ToUpper() + "|") //CUSER6  VARCHAR2(60 BYTE)
                .Append("|") //CUSER7  VARCHAR2(60 BYTE)
                .Append("|") //CUSER8  VARCHAR2(60 BYTE)
                .Append("|") //CUSER9  VARCHAR2(60 BYTE)
                .Append(pkgSpec.UpcCode + "|") //CUSER10 VARCHAR2(60 BYTE)
                .Append("|") //NUSER4  NUMBER(15, 6)
                .Append("|") //NUSER5  NUMBER(15, 6)
                .Append("|") //NUSER6  NUMBER(15, 6)
                .Append("|") //NUSER7  NUMBER(15, 6)
                .Append("|") //NUSER8  NUMBER(15, 6)
                .Append("|") //NUSER9  NUMBER(15, 6)
                .Append("|") //NUSER10 NUMBER(15, 6)
                .Append("|") //PROCESS_SAFETY_STOCK    VARCHAR2(1 BYTE)
                .Append("|") //MX_GROUP_ID NUMBER(15, 0)
                .Append("|") //FR_GROUP_ID NUMBER(15, 0)
                .Append("|") //SETUP_CHARGE    NUMBER(15, 6)
                .Append("|") //MOVE_TIME   NUMBER(7, 3)
                .Append("|") //CARTONS_PALLET  NUMBER(15, 6)
                .Append("|") //PIECES_CARTON   NUMBER(15, 6)
                .Append("|") //AUTO_MRP_FIRM_WO    VARCHAR2(1 BYTE)
                .Append("|") //FLOOR_BACKFLUSH VARCHAR2(1 BYTE)
                .Append("|") //MPS VARCHAR2(1 BYTE)
                .Append("|") //CUM_LEADTIME    NUMBER(8, 2)
                .Append("|") //PHANTOM VARCHAR2(1 BYTE)
                .Append("|") //CRITICAL_FENCE  NUMBER(3, 0)
                .Append("|") //USER_NAME   VARCHAR2(35 BYTE)
                .Append("|") //PK_HIDE VARCHAR2(1 BYTE)
                .Append("|") //ACCT_ID_PRODVAR NUMBER(15, 0)
                .Append("|") //PHANTOM_ONHAND  NUMBER(14, 4)
                .Append("|") //LM_LABELS_ID    NUMBER(15, 0)
                .Append("|") //DRIVE_PHANTOM_NEGATIVE  VARCHAR2(1 BYTE)
                .Append("|") //NO_STDCOST_RECALC   VARCHAR2(1 BYTE)
                .Append("|") //ACCT_ID_INTPLANT_SALES  NUMBER(15, 0)
                .Append("|") //IMAGE_FILENAME  VARCHAR2(250 BYTE)
                .Append("|") //NON_ALLOCATE_TOTAL  NUMBER(14, 4)
                .Append("|") //INSP_RECEIPT_THRES  NUMBER(5, 0)
                .Append("|") //INSP_RECEIPT_COUNT  NUMBER(5, 0)
                .Append("|") //COST_STANDARD_ID_FUTURE NUMBER(15, 0)
                .Append("|") //COST_STANDARD_ID    NUMBER(15, 0)
                .Append("|") //COST_DESCRIP_FUTURE VARCHAR2(50 BYTE)
                .Append("|") //COST_DESCRIP    VARCHAR2(50 BYTE)
                .Append("|") //COST_CALC_DATE_FUTURE   DATE
                .Append("|") //COST_CALC_DATE  DATE
                .Append("|") //AUTO_MRP_INCLUDE_VMI    VARCHAR2(1 BYTE)
                .Append("|") //PROD_CODE_ID    NUMBER(15, 0)
                .Append("|") //DO_NOT_DISPO_FLOOR_PARTIAL  VARCHAR2(1 BYTE)
                .Append("|") //INFO_SO VARCHAR2(2000 BYTE)
                .Append("|") //INFO_PO VARCHAR2(2000 BYTE)
                .Append("|") //EXCL_RECEIPT_TIME_PPV   VARCHAR2(1 BYTE)
                .Append("|") //CYCLE_COUNT_ID  NUMBER(15, 0)
                .Append("|") //CYCLE_COUNT_DATE    DATE
                .Append(((pkgSpec.UnitPackageQuantity > 0) ? "N" : "Y") + "|") // currentDetails[0].CpmIndicator : "") +"|") //NON_MATERIAL    VARCHAR2(1 BYTE)
                .Append("|") //MFG_MIN_QTY NUMBER(14, 4)
                .Append("|") //MFG_MULTIPLE    NUMBER(14, 4)
                .Append("|") //BUYER_CODE_ID   NUMBER(15, 0)
                .Append("|") //COST_CALC_BATCH NUMBER(15, 0)
                .Append("|") //INTRASTAT_CODE  VARCHAR2(25 BYTE)
                .Append("|") //FAB_START   VARCHAR2(1 BYTE)
                .Append("|") //MFG_SAFETY_QTY  NUMBER(14, 4)
                .Append("|") //PLANNER_CODE_ID NUMBER(15, 0)
                .Append("|") //IS_LOT_MANDATORY    VARCHAR2(1 BYTE)
                .Append(pkgSpec.Weight + "|") //PK_WEIGHT   NUMBER(13, 6)
                .Append("|") //PK_PTSPER   NUMBER(15, 6)
                .Append("|") //DO_NOT_SCHED_FORECAST_WO    VARCHAR2(1 BYTE)
                .Append("|") //IS_PALLET   VARCHAR2(1 BYTE)
                .Append("|") //IS_AUTO_RT_LABELS   VARCHAR2(1 BYTE)
                .Append("|") //IS_LINKED_TO_SERIAL VARCHAR2(1 BYTE)
                .Append("|") //FR_INCLUDE  VARCHAR2(1 BYTE)
                .Append("|") //MIN_CPK NUMBER(15, 6)
                .Append("|") //LBL_ASSIST_LAST_PRINT   DATE
                .Append("|") //LBL_ASSIST_PRINT_INTERVAL   NUMBER(5, 0)
                .Append("|") //COC_EXCLUDE VARCHAR2(1 BYTE)
                .Append("|") //ICT_REORD_POINT NUMBER(12, 2)
                .Append("|") //ICT_REPLENISH_SCOPE_DAYS    NUMBER(3, 0)
                .Append("|") //ICT_LEAD_DAYS   NUMBER(3, 0)
                .Append("|") //ICT_SHIP_TO_ID  NUMBER(15, 0)
                .Append("|") //AUTO_MRP_KANBAN_LOT_SIZE    NUMBER(15, 6)
                .Append("|") //ICT_FIRE_TRIGGER    VARCHAR2(1 BYTE)
                .Append("|") //COLOR_GROUP_ID  NUMBER(15, 0)
                .Append("|") //FR_WO_TIME_FENCE    NUMBER(5, 2)
                .Append("|") //PK_LENGTH   NUMBER(15, 6)
                .Append("|") //PK_WIDTH    NUMBER(15, 6)
                .Append("|") //PK_HEIGHT   NUMBER(15, 6)
                .Append(pkgSpec.UnitizationPerLength + "|") //PALLET_LENGTH   NUMBER(15, 6)
                .Append(pkgSpec.UnitizationPerWidth + "|") //PALLET_WIDTH    NUMBER(15, 6)
                .Append(pkgSpec.UnitizationPerDepth + "|") //PALLET_HEIGHT   NUMBER(15, 6)
                .Append("|") //PALLET_VOLUME   NUMBER(15, 6)
                .Append(pkgSpec.UnitPackageQuantity + "|") //Append(((currentDetails.Count > 0) ? "" + currentDetails[0].Quantity : "") + "|") //PALLET_PTSPER   NUMBER(15, 6)
                .Append("|") //PALLET_WEIGHT   NUMBER(15, 6)
                .Append("|") //LENGTH  NUMBER(15, 6)
                .Append("|") //WIDTH   NUMBER(15, 6)
                .Append("|") //GAUGE   NUMBER(15, 6)
                .Append("|") //IS_BY_PRODUCT   VARCHAR2(1 BYTE)
                .Append("|") //EXCLUDE_FROM_COMMISSIONS    VARCHAR2(1 BYTE)
                .Append("|") //AUTO_RT_LABELS_PK_SEQ   NUMBER(3, 0)
                .Append("|") //PALLET_PATTERN_ID   NUMBER(15, 0)
                .Append("|") //WEB_SALABLE VARCHAR2(1 BYTE)
                .Append("|") //PO_MULTIPLE NUMBER(14, 4)
                .Append("|") //FIFO_THRESHOLD  NUMBER(5, 2)
                .Append("|") //COST_STANDARD_ID_FORECAST   NUMBER(15, 0)
                .Append("|") //COST_STANDARD_ID_BUDGET NUMBER(15, 0)
                .Append("|") //COST_DESCRIP_FORECAST   VARCHAR2(50 BYTE)
                .Append("|") //COST_DESCRIP_BUDGET VARCHAR2(50 BYTE)
                .Append("|") //COST_CALC_DATE_FORECAST DATE
                .Append("|") //COST_CALC_DATE_BUDGET   DATE
                .Append("|") //KEEP_LABEL_BOM_INTERPLANT_TRAN  VARCHAR2(1 BYTE)
                .Append("|") //ECO_ORIG_CLASS  VARCHAR2(2 BYTE)
                .Append("|") //ACCT_ID_WIP NUMBER(15, 0)
                .Append("|") //IRV32_NO_PLAN_WO    VARCHAR2(1 BYTE)
                .Append("|") //INFO_REC    VARCHAR2(2000 BYTE)
                .Append("|") //IS_LOT_DATE_MANDATORY   VARCHAR2(1 BYTE)
                .Append("|") //USE_THIS_UOM_FOR_MRP    VARCHAR2(1 BYTE)
                .Append("|") //WAIT_TIME   NUMBER(7, 3)
                .Append("|") //BOL_CALC_OVERRIDE   VARCHAR2(1 BYTE)
                .Append("|") //RFQ_USE_STD_COST    VARCHAR2(1 BYTE)
                .Append("|") //ACCT_ID_PHYS_VAR    NUMBER(15, 0)
                .Append("|") //ACCT_ID_INV_COST_REV    NUMBER(15, 0)
                .Append("|") //EXCLUDE_BACKFLUSH   VARCHAR2(1 BYTE)
                .Append("|") //NONTAXABLE  VARCHAR2(1 BYTE)
                .Append("|") //ACCT_ID_SHIPMENT    NUMBER(15, 0)
                .Append("|") //AUTO_MRP_EXCLUDE_HARD_ALLOC VARCHAR2(1 BYTE)
                .Append("|") //MIN_PPK NUMBER(15, 6)
                .Append("|") //RUN_RULES   VARCHAR2(20 BYTE)
                .Append("|") //RTPM_TRG_RTLABEL    VARCHAR2(1 BYTE)
                .Append("|") //REBATE_PARAMS_ID    NUMBER(15, 0)
                .Append("|") //TARIFF_CODE_ID  NUMBER(15, 0)
                .Append("|") //WEBDIRECT_LEAD_DAYS NUMBER(5, 0)
                .Append("|") //USE_COST_DEFAULT_STANDARD_ID    VARCHAR2(1 BYTE)
                .Append("|") //ARINVT_GROUP_ID NUMBER(15, 0)
                .Append("|") //CLONED_FROM_ARINVT_ID   NUMBER(15, 0)
                .Append("|") //USE_LOT_CHARGE  VARCHAR2(1 BYTE)
                .Append("|") //LOT_CHARGE  NUMBER(15, 6)
                .Append("|") //UNIQUE_DISPO_LOC    VARCHAR2(1 BYTE)
                .Append("|") //HEIJUNKA_SINCE_SCHED_DEMAND NUMBER(15, 6)
                .Append("|") //CONFIG_CODE VARCHAR2(255 BYTE)
                .Append("|") //AUTO_MRP_INCLUDE_VMI_MFG_CALC   VARCHAR2(1 BYTE)
                .Append("|") //FR_WO_SCOPE NUMBER(5, 0)
                .Append("|") //AUTO_MRP_APPLY_TO_SCHED_ALLOC   VARCHAR2(1 BYTE)
                .Append("|") //PHANTOM_COMPONENTS_ON_SO    VARCHAR2(1 BYTE)
                .Append("|") //SCHED_CASCADE_PARENT_MTO    VARCHAR2(1 BYTE)
                .Append("|") //AUTO_POP_SERV_CTR   VARCHAR2(1 BYTE)
                .Append("|") //EXCL_MARK_WO_MAT_XCPT   VARCHAR2(1 BYTE)
                .Append("|") //IS_ALC  CHAR(1 BYTE)
                .Append("|") //MARK_ORD_DETAIL_MTO VARCHAR2(1 BYTE)
                .Append("|") //MSDS_AUTHORABLE VARCHAR2(1 BYTE)
                .Append("|") //IS_MSDS VARCHAR2(1 BYTE)
                .Append("|") //MSDS_UPLOAD VARCHAR2(1 BYTE)
                .Append("|") //NONTAXABLE_PO   VARCHAR2(1 BYTE)
                .Append("|") //OVERRIDE_REC_LOC    VARCHAR2(1 BYTE)
                .Append("|") //IS_DROP_SHIP    VARCHAR2(1 BYTE)
                .Append("|") //MAX_PALLET_STACK    NUMBER(2, 0)
                .Append("|") //LOOSE_INV_MOVE_CLASS_ID NUMBER(15, 0)
                .Append("|") //PACK_INV_MOVE_CLASS_ID  NUMBER(15, 0)
                .Append("|") //PALLET_INV_MOVE_CLASS_ID    NUMBER(15, 0)
                .Append("|") //PK_UNIT_TYPE    VARCHAR2(1 BYTE)
                .Append("|") //LOOSE_MOVE_RANK_COUNT   NUMBER(15, 0)
                .Append("|") //PACK_MOVE_RANK_COUNT    NUMBER(15, 0)
                .Append("|") //PALLET_MOVE_RANK_COUNT  NUMBER(15, 0)
                .Append("|") //EXCL_WORKORDER_MAT  VARCHAR2(1 BYTE)
                .Append("|") //FIFO    VARCHAR2(1 BYTE)
                .Append("|") //COMPANY_ID  NUMBER(15, 0)
                .Append("|") //RECV_LOCATION_ID    NUMBER(15, 0)
                .Append("|") //SPC_INSPECTION_ID   NUMBER(15, 0)
                .Append("|") //AR_DISCOUNT_WATERFALL_ID    NUMBER(15, 0)
                .Append("|") //LBL_LAST_PRINT  DATE
                .Append("|") //EXCL_FROM_CTP_EXCEPTION VARCHAR2(1 BYTE)
                .Append("|") //WMS_INV_GROUP_ID    NUMBER(15, 0)
                .Append("|") //CORE_SIZE   NUMBER(15, 6)
                .Append("|") //OD  NUMBER(15, 6)
                .Append("|") //PS_CONVERT_INFO VARCHAR2(2000 BYTE)
                .Append("|") //LOOSE_MOVE_RANK_LOCK    VARCHAR2(1 BYTE)
                .Append("|") //PACK_MOVE_RANK_LOCK VARCHAR2(1 BYTE)
                .Append("|") //PALLET_MOVE_RANK_LOCK   VARCHAR2(1 BYTE)
                .Append("|") //CYCLE_COUNT_RANK_LOCK   VARCHAR2(1 BYTE)
                .Append("|") //MIN_SELL_QTY    NUMBER(14, 4)
                .Append("|") //INSP_LEAD_DAYS  NUMBER(3, 0)
                .Append("|") //LOOSE_WEIGHT    NUMBER(15, 6)
                .Append("|") //LOOSE_VOLUME    NUMBER(15, 6)
                .Append(((currentDetails.Count > 0) ? "" + currentDetails[0].UnitizationPerLength : "") + "|") //LOOSE_LENGTH    NUMBER(15, 6)
                .Append(((currentDetails.Count > 0) ? "" + currentDetails[0].UnitizationPerWidth : "") + "|") //LOOSE_WIDTH NUMBER(15, 6)
                .Append(((currentDetails.Count > 0) ? "" + currentDetails[0].UnitizationPerDepth : "") + "|") //LOOSE_HEIGHT    NUMBER(15, 6)
                .Append("|") //IS_LOT_EXPIRY_DATE_MANDATORY    VARCHAR2(1 BYTE)
                .Append("|") //ICT_TRUCK_PTSPER    NUMBER(15, 6)
                .Append("|") //SAFETY_STOCK2   NUMBER(14, 4)
                .Append("|") //COST_CALC_USER_NAME VARCHAR2(30 BYTE)
                .Append("|") //SHELF_LIFE2 NUMBER(4, 0)
                .Append("|") //ICT_AUTO_MRP_ORDER_QTY  NUMBER(12, 2)
                .Append("|") //ICT_SHIP_PULL_DEMAND    VARCHAR2(1 BYTE)
                .Append("|") //PLT_WRP_USE_QC  VARCHAR2(1 BYTE)
                .Append("|") //PLT_WRP_LOC_ID  NUMBER(15, 0)
                .Append("|") //HARD_ALLOC_ROUND_PRECISION  NUMBER(2, 0)
                .Append("|") //BACKFLUSH_BY_SERIAL VARCHAR2(1 BYTE)
                .Append("|") //GROUP_CODE  VARCHAR2(20 BYTE)
                .Append("|") //PROPRIETARY_EFFECT_DATE DATE
                .Append("|") //PROPRIETARY_DEACTIVE_DATE   DATE
                .Append("|") //DEMAND_CHANGE   VARCHAR2(1 BYTE)
                .Append("|") //TAX_CLASS_ID    NUMBER(15, 0)
                .Append("|") //DISCOUNT_GROUPS_ID  NUMBER(15, 0)
                .Append("|") //PHYS_CHAR_VOLUME    NUMBER(15, 6)
                .Append("|") //PHANTOM_KIT_USE_COMP_PRICE  VARCHAR2(1 BYTE)
                .Append("|") //ASSY1_EXCLUDE_FORECAST_WO   VARCHAR2(1 BYTE)
                .Append("|") //LAST_DEMAND_CHANGE  DATE
                .Append("|") //ARINVT_RECIPE_ID    NUMBER(15, 0)
                .Append("|") //GL_PLUG_VALUE   VARCHAR2(50 BYTE)
                .Append("|") //CAROUSEL_TARGET_ID  NUMBER(15, 0)
                .Append("|") //CAROUSEL_OPERATOR   NUMBER(5, 2)
                .Append("|") //CREATED DATE
                .Append("|") //CREATEDBY   VARCHAR2(20 BYTE)
                .Append("|") //CHANGED DATE
                .Append("|") //CHANGEDBY   VARCHAR2(20 BYTE)
                .Append("|") //ACCT_ID_INTRANSIT   NUMBER(15, 0)
                .Append("|") //ACCT_ID_IP_TRANS    NUMBER(15, 0)
                .Append("|"); //ACCT_ID_IP_TRANS_VAR    NUMBER(15, 0)
            #endregion

            PreloadData(finishedGoodString, pkgSpec);

            return finishedGoodString;
        }

        private void PreloadData(StringBuilder newLine, DET.SPECIFICATION pkgSpec)
        {
            stringArray = newLine.ToString().Split('|');

            if (CheckIfInTableOrMaterialList(stringArray[2], stringArray[3], stringArray[4]))
            {
                return;
            }

            Directory.CreateDirectory(SpecFolder + "ARINVT\\Loader\\");

            //Add to data string for sql loader
            dataLoaderString.AppendLine("" + (newMaterials.Count + 1) + newLine.ToString());
            DataFileLineCount++;

            AddToMaterialList(stringArray[2], stringArray[3], stringArray[4]);
        }

        public void InsertIntoDataFile(bool force)
        {
            if (force || DataFileLineCount >= 500)
            {
                using (StreamWriter sw = new StreamWriter(SpecFolder + "ARINVT\\Loader\\tempARINVT_for_GSPPS.csv", true))
                {
                    sw.Write(dataLoaderString);
                    sw.Close();
                }

                dataLoaderString.Clear();
                DataFileLineCount = 0;
            }
        }

        private static object GetString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "null";
            }
            return "'" + value.Replace("'", "''") + "'";
        }

        private static object GetDecimal(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "null";
            }
            return Decimal.Parse(value);
        }

        private static object GetDateTime(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "null";
            }
            return "to_date('" + DateTime.Parse(value).ToString("dd-MMM-yy") + "','DD-MON-RR')";
        }
    }
}
