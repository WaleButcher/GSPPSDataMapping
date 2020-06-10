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

namespace GSPPSDataMapping.Tables
{
    class ARINVT 
    {
        //Insert into IQMS.ARINVT(ID, ARCUSTO_ID, CLASS, ITEMNO, REV, DESCRIP, DESCRIP2, AVG_COST, VENDOR_ID, UNIT, BLEND, CUSER1, CUSER2, CUSER3, NUSER1, NUSER2, NUSER3, BOM_ACTIVE, ONHAND, RG_ONHAND, NON_SALABLE, NON_CONFORM_TOTAL, SERIALIZED, SAFETY_STOCK, MIN_ORDER_QTY, MAX_ORDER_QTY, MULTIPLE, YTDQTY, PTDQTY, CODE, LDATE, LBUY_DATE, TYPE, SERIES, LEAD_DAYS, LEAD_TIME, SPG, DRYTIME, DRYTEMP, RGPRCNT, AUTO_MJO, MFG_QUAN, AUX_AMT, STDQUAN, LOW_LEVEL_CODE, MPS_CODE, ARINVT_FAMILY_ID, BACKFLUSH, DRAWING, ECNO, STD_PRICE, STD_COST, STANDARD_ID, ACCT_ID_SALES, ACCT_ID_INV, MFG_SPLIT, PRICE_PER_1000, COMIS_PRCNT, UNQUE_DATE_IN, SHELF_LIFE, ECODE, EID, EDATE_TIME, ECOPY, ACCT_ID_PPV, ACCT_ID_OH_DISPO, ACCT_ID_LABOR_DISPO, ACCT_ID_HOLDING, ITEM_TYPE_ID, NMFC_ID, VOLUME, AUTO_MRP_REORD_POINT, AUTO_MRP_ORDER_QTY, AUTO_MRP_LEAD_DAYS, EPLANT_ID, COMMISSIONS_ID, STD_COST_CONTROL, PO_SCOPE, PO_SAFETY, PO_MOVE_RANGE, LM_IMAGE_FILENAME, CYCLE_COUNT_CODE, CUSER4, CUSER5, CUSER6, CUSER7, CUSER8, CUSER9, CUSER10, NUSER4, NUSER5, NUSER6, NUSER7, NUSER8, NUSER9, NUSER10, PROCESS_SAFETY_STOCK, MX_GROUP_ID, FR_GROUP_ID, SETUP_CHARGE, MOVE_TIME, CARTONS_PALLET, PIECES_CARTON, AUTO_MRP_FIRM_WO, FLOOR_BACKFLUSH, MPS, CUM_LEADTIME, PHANTOM, CRITICAL_FENCE, USER_NAME, PK_HIDE, ACCT_ID_PRODVAR, PHANTOM_ONHAND, LM_LABELS_ID, DRIVE_PHANTOM_NEGATIVE, NO_STDCOST_RECALC, ACCT_ID_INTPLANT_SALES, IMAGE_FILENAME, NON_ALLOCATE_TOTAL, INSP_RECEIPT_THRES, INSP_RECEIPT_COUNT, COST_STANDARD_ID_FUTURE, COST_STANDARD_ID, COST_DESCRIP_FUTURE, COST_DESCRIP, COST_CALC_DATE_FUTURE, COST_CALC_DATE, AUTO_MRP_INCLUDE_VMI, PROD_CODE_ID, DO_NOT_DISPO_FLOOR_PARTIAL, INFO_SO, INFO_PO, EXCL_RECEIPT_TIME_PPV, CYCLE_COUNT_ID, CYCLE_COUNT_DATE, NON_MATERIAL, MFG_MIN_QTY, MFG_MULTIPLE, BUYER_CODE_ID, COST_CALC_BATCH, INTRASTAT_CODE, FAB_START, MFG_SAFETY_QTY, PLANNER_CODE_ID, IS_LOT_MANDATORY, PK_WEIGHT, PK_PTSPER, DO_NOT_SCHED_FORECAST_WO, IS_PALLET, IS_AUTO_RT_LABELS, IS_LINKED_TO_SERIAL, FR_INCLUDE, MIN_CPK, LBL_ASSIST_LAST_PRINT, LBL_ASSIST_PRINT_INTERVAL, COC_EXCLUDE, ICT_REORD_POINT, ICT_REPLENISH_SCOPE_DAYS, ICT_LEAD_DAYS, ICT_SHIP_TO_ID, AUTO_MRP_KANBAN_LOT_SIZE, ICT_FIRE_TRIGGER, COLOR_GROUP_ID, FR_WO_TIME_FENCE, PK_LENGTH, PK_WIDTH, PK_HEIGHT, PALLET_LENGTH, PALLET_WIDTH, PALLET_HEIGHT, PALLET_VOLUME, PALLET_PTSPER, PALLET_WEIGHT, LENGTH, WIDTH, GAUGE, IS_BY_PRODUCT, EXCLUDE_FROM_COMMISSIONS, AUTO_RT_LABELS_PK_SEQ, PALLET_PATTERN_ID, WEB_SALABLE, PO_MULTIPLE, FIFO_THRESHOLD, COST_STANDARD_ID_FORECAST, COST_STANDARD_ID_BUDGET, COST_DESCRIP_FORECAST, COST_DESCRIP_BUDGET, COST_CALC_DATE_FORECAST, COST_CALC_DATE_BUDGET, KEEP_LABEL_BOM_INTERPLANT_TRAN, ECO_ORIG_CLASS, ACCT_ID_WIP, IRV32_NO_PLAN_WO, INFO_REC, IS_LOT_DATE_MANDATORY, USE_THIS_UOM_FOR_MRP, WAIT_TIME, BOL_CALC_OVERRIDE, RFQ_USE_STD_COST, ACCT_ID_PHYS_VAR, ACCT_ID_INV_COST_REV, EXCLUDE_BACKFLUSH, NONTAXABLE, ACCT_ID_SHIPMENT, AUTO_MRP_EXCLUDE_HARD_ALLOC, MIN_PPK, RUN_RULES, RTPM_TRG_RTLABEL, REBATE_PARAMS_ID, TARIFF_CODE_ID, WEBDIRECT_LEAD_DAYS, USE_COST_DEFAULT_STANDARD_ID, ARINVT_GROUP_ID, CLONED_FROM_ARINVT_ID, USE_LOT_CHARGE, LOT_CHARGE, UNIQUE_DISPO_LOC, HEIJUNKA_SINCE_SCHED_DEMAND, CONFIG_CODE, AUTO_MRP_INCLUDE_VMI_MFG_CALC, FR_WO_SCOPE, AUTO_MRP_APPLY_TO_SCHED_ALLOC, PHANTOM_COMPONENTS_ON_SO, SCHED_CASCADE_PARENT_MTO, AUTO_POP_SERV_CTR, EXCL_MARK_WO_MAT_XCPT, IS_ALC, MARK_ORD_DETAIL_MTO, MSDS_AUTHORABLE, IS_MSDS, MSDS_UPLOAD, NONTAXABLE_PO, OVERRIDE_REC_LOC, IS_DROP_SHIP, MAX_PALLET_STACK, LOOSE_INV_MOVE_CLASS_ID, PACK_INV_MOVE_CLASS_ID, PALLET_INV_MOVE_CLASS_ID, PK_UNIT_TYPE, LOOSE_MOVE_RANK_COUNT, PACK_MOVE_RANK_COUNT, PALLET_MOVE_RANK_COUNT, EXCL_WORKORDER_MAT, FIFO, COMPANY_ID, RECV_LOCATION_ID, SPC_INSPECTION_ID, AR_DISCOUNT_WATERFALL_ID, LBL_LAST_PRINT, EXCL_FROM_CTP_EXCEPTION, WMS_INV_GROUP_ID, CORE_SIZE, OD, PS_CONVERT_INFO, LOOSE_MOVE_RANK_LOCK, PACK_MOVE_RANK_LOCK, PALLET_MOVE_RANK_LOCK, CYCLE_COUNT_RANK_LOCK, MIN_SELL_QTY, INSP_LEAD_DAYS, LOOSE_WEIGHT, LOOSE_VOLUME, LOOSE_LENGTH, LOOSE_WIDTH, LOOSE_HEIGHT, IS_LOT_EXPIRY_DATE_MANDATORY, ICT_TRUCK_PTSPER, SAFETY_STOCK2, COST_CALC_USER_NAME, SHELF_LIFE2, ICT_AUTO_MRP_ORDER_QTY, ICT_SHIP_PULL_DEMAND, PLT_WRP_USE_QC, PLT_WRP_LOC_ID, HARD_ALLOC_ROUND_PRECISION, BACKFLUSH_BY_SERIAL, GROUP_CODE, PROPRIETARY_EFFECT_DATE, PROPRIETARY_DEACTIVE_DATE, DEMAND_CHANGE, TAX_CLASS_ID, DISCOUNT_GROUPS_ID, PHYS_CHAR_VOLUME, PHANTOM_KIT_USE_COMP_PRICE, ASSY1_EXCLUDE_FORECAST_WO, LAST_DEMAND_CHANGE, ARINVT_RECIPE_ID, GL_PLUG_VALUE, CAROUSEL_TARGET_ID, CAROUSEL_OPERATOR, CREATED, CREATEDBY, CHANGED, CHANGEDBY, ACCT_ID_INTRANSIT, ACCT_ID_IP_TRANS, ACCT_ID_IP_TRANS_VAR) 
        
        private static string folderName = "ARINVT";
        private static StringBuilder ARINVTColumns = GetColumnNames(folderName);

        private static StringBuilder GetColumnNames(string tableName)
        {
            StringBuilder newLine = new StringBuilder("");
            using (OracleConnection dbO = OracleConnectionFactory.IQMSConnection)
            {
                using (OracleCommand select = new OracleCommand(
                    "SELECT * FROM " + tableName + " WHERE ROWNUM = 1 ", dbO))
                {
                    select.CommandType = CommandType.Text;
                    select.CommandTimeout = 0;
                    using (OracleDataReader reader = select.ExecuteReader())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            newLine.Append(reader.GetName(i) + ",");
                        }
                    }
                }
            }

            newLine.Length--;
            return newLine;
        }
        private static long getNextSequenceID()
        {
            using (OracleConnection dbo = OracleConnectionFactory.IQMSConnection)
            {
                //*
                using (OracleCommand loCmd = dbo.CreateCommand())
                {
                    loCmd.CommandType = CommandType.Text;
                    loCmd.CommandText = "select s_arinvt.nextval from dual";
                    long lnNextVal = Convert.ToInt64(loCmd.ExecuteScalar());

                    return lnNextVal;
                }
                //*/
                
            }
        }
        
        public static void process(string specsFolder, SPECIFICATION pkgSpec, 
                        List<DETAILS> currentDetails, List<BOM> currentBOM, 
                        List<REMARKCODE> currentRemarkCode, REMARK rmk, string rawSpec)
        {
            StringBuilder sbNewLine = new StringBuilder("");
            if (ARINVTColumns.Length > 0)
            {
                sbNewLine.Append(ARINVTColumns).AppendLine();
            }

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
            Directory.CreateDirectory(specsFolder + folderName + "\\");
            using (StreamWriter sw = new StreamWriter(specsFolder + folderName + "\\" + pkgSpec.PackedServicePart + ".csv", false))
            {
                sw.Write(sbNewLine.ToString());
                sw.Close();
            }
        }

        private static bool CheckMaterialExists(string materialNo)
        {
            using (OracleConnection dbO = OracleConnectionFactory.IQMSConnection)
            {
                using (OracleCommand select = new OracleCommand("SELECT * FROM ARINVT where ITEMNO = '" + materialNo + "' and rownum = 1", dbO))
                {
                    select.CommandType = CommandType.Text;
                    select.CommandTimeout = 0;
                    using (OracleDataReader reader = select.ExecuteReader())
                    {
                        return (reader.HasRows);
                    }
                }
            }
        }

        private static bool CheckPartAndVersionExists(string part, string version)
        {
            using (OracleConnection dbO = OracleConnectionFactory.IQMSConnection)
            {
                using (OracleCommand select = new OracleCommand("SELECT * FROM ARINVT where ITEMNO = '" + part + "' AND REV= '" + version + "' and rownum = 1", dbO))
                {
                    select.CommandType = CommandType.Text;
                    select.CommandTimeout = 0;
                    using (OracleDataReader reader = select.ExecuteReader())
                    {
                        return (reader.HasRows);
                    }
                }
            }
        }
       
        private static StringBuilder SetUpPackaging(string mappingType, DET.SPECIFICATION pkgSpec, DET.DETAILS details)
        {
            StringBuilder newLine = new StringBuilder("");
            newLine
                    .Append(",") //ID  NUMBER(15, 0)
                    .Append(",") //ARCUSTO_ID  NUMBER(15, 0)
                    .Append(mappingType + ",") //CLASS   VARCHAR2(2 BYTE)
                    .Append(details.ProcessOrMaterialCode + ",") //ITEMNO  VARCHAR2(50 BYTE)
                    .Append("0,") //.Append(details.Version + ",") //REV VARCHAR2(15 BYTE)
                                                  //make sure the comma is not part of this descriptiom
                    .Append(details.ProcessOrMaterialDescription.Replace(',', '-') + ",") //DESCRIP VARCHAR2(100 BYTE)
                    .Append("" + ",") //DESCRIP2    VARCHAR2(100 BYTE)
                    .Append(",") //AVG_COST    NUMBER(15, 6)
                    .Append(",") //VENDOR_ID   NUMBER(15, 0)
                    .Append("EACH" + ",") //UNIT    VARCHAR2(10 BYTE)
                    .Append(",") //BLEND   VARCHAR2(1 BYTE)
                    .Append(",") //.Append(pkgSpec.SalesPartNo + ",") //CUSER1  VARCHAR2(60 BYTE)
                    .Append(",") //CUSER2  VARCHAR2(60 BYTE)
                    .Append(",") //CUSER3  VARCHAR2(60 BYTE)
                    .Append(",") //NUSER1  NUMBER(15, 6)
                    .Append(",") //NUSER2  NUMBER(15, 6)
                    .Append(",") //NUSER3  NUMBER(15, 6)
                    .Append(",") //BOM_ACTIVE  VARCHAR2(1 BYTE)
                    .Append(",") //ONHAND  NUMBER(14, 4)
                    .Append(",") //RG_ONHAND   NUMBER(14, 4)
                    .Append(",") //NON_SALABLE VARCHAR2(1 BYTE)
                    .Append(",") //NON_CONFORM_TOTAL   NUMBER(14, 4)
                    .Append(",") //SERIALIZED  VARCHAR2(1 BYTE)
                    .Append(",") //SAFETY_STOCK    NUMBER(14, 4)
                    .Append(",") //MIN_ORDER_QTY   NUMBER(14, 4)
                    .Append(",") //MAX_ORDER_QTY   NUMBER(14, 4)
                    .Append(",") //MULTIPLE    NUMBER(14, 4)
                    .Append(",") //YTDQTY  NUMBER(12, 0)
                    .Append(",") //PTDQTY  NUMBER(12, 0)
                    .Append(",") //CODE    VARCHAR2(1 BYTE)
                    .Append(",") //LDATE   DATE
                    .Append(",") //LBUY_DATE   DATE
                    .Append(",") //TYPE    VARCHAR2(5 BYTE)
                    .Append(",") //SERIES  VARCHAR2(10 BYTE)
                    .Append(",") //LEAD_DAYS   NUMBER(3, 0)
                    .Append(",") //LEAD_TIME   VARCHAR2(10 BYTE)
                    .Append(",") //SPG NUMBER(15, 6)
                    .Append(",") //DRYTIME NUMBER(2, 0)
                    .Append(",") //DRYTEMP VARCHAR2(10 BYTE)
                    .Append(",") //RGPRCNT NUMBER(3, 0)
                    .Append(",") //AUTO_MJO    VARCHAR2(6 BYTE)
                    .Append(",") //MFG_QUAN    NUMBER(14, 4)
                    .Append(",") //AUX_AMT NUMBER(15, 6)
                    .Append(",") //STDQUAN NUMBER(10, 0)
                    .Append(",") //LOW_LEVEL_CODE  NUMBER(3, 0)
                    .Append(",") //MPS_CODE    VARCHAR2(1 BYTE)
                    .Append(",") //ARINVT_FAMILY_ID    NUMBER(15, 0)
                    .Append("Y" + ",") //BACKFLUSH   VARCHAR2(1 BYTE)
                    .Append(",") //DRAWING VARCHAR2(30 BYTE)
                    .Append(",") //ECNO    VARCHAR2(25 BYTE)
                    .Append(",") //STD_PRICE   NUMBER(15, 6)
                    .Append(",") //STD_COST    NUMBER(15, 6)
                    .Append(",") //STANDARD_ID NUMBER(15, 0)
                    .Append(",") //ACCT_ID_SALES   NUMBER(15, 0)
                    .Append(",") //ACCT_ID_INV NUMBER(15, 0)
                    .Append(",") //MFG_SPLIT   VARCHAR2(1 BYTE)
                    .Append(",") //PRICE_PER_1000  VARCHAR2(1 BYTE)
                    .Append(",") //COMIS_PRCNT NUMBER(15, 6)
                    .Append(",") //UNQUE_DATE_IN   VARCHAR2(1 BYTE)
                    .Append(",") //SHELF_LIFE  NUMBER(4, 0)
                    .Append(",") //ECODE   VARCHAR2(10 BYTE)
                    .Append(",") //EID NUMBER(15, 0)
                    .Append(",") //EDATE_TIME  DATE
                    .Append(",") //ECOPY   VARCHAR2(1 BYTE)
                    .Append(",") //ACCT_ID_PPV NUMBER(15, 0)
                    .Append(",") //ACCT_ID_OH_DISPO    NUMBER(15, 0)
                    .Append(",") //ACCT_ID_LABOR_DISPO NUMBER(15, 0)
                    .Append(",") //ACCT_ID_HOLDING NUMBER(15, 0)
                    .Append(",") //ITEM_TYPE_ID    NUMBER(15, 0)
                    .Append(",") //NMFC_ID NUMBER(15, 0)
                    .Append(",") //VOLUME  NUMBER(15, 6)
                    .Append(",") //AUTO_MRP_REORD_POINT    NUMBER(12, 2)
                    .Append(",") //AUTO_MRP_ORDER_QTY  NUMBER(12, 2)
                    .Append(",") //AUTO_MRP_LEAD_DAYS  NUMBER(5, 2)
                    .Append("5" + ",") //EPLANT_ID   NUMBER(15, 0)
                    .Append(",") //COMMISSIONS_ID  NUMBER(15, 0)
                    .Append(",") //STD_COST_CONTROL    VARCHAR2(60 BYTE)
                    .Append("0" + ",") //PO_SCOPE    NUMBER(3, 0)
                    .Append("0" + ",") //PO_SAFETY   NUMBER(3, 0)
                    .Append("0" + ",") //PO_MOVE_RANGE   NUMBER(3, 0)
                    .Append(",") //LM_IMAGE_FILENAME   VARCHAR2(50 BYTE)
                    .Append(",") //CYCLE_COUNT_CODE    VARCHAR2(15 BYTE)
                    .Append(",") //CUSER4  VARCHAR2(60 BYTE)
                    .Append(",") //CUSER5  VARCHAR2(60 BYTE)
                    .Append(",") //CUSER6  VARCHAR2(60 BYTE)
                    .Append(",") //CUSER7  VARCHAR2(60 BYTE)
                    .Append(",") //CUSER8  VARCHAR2(60 BYTE)
                    .Append(",") //CUSER9  VARCHAR2(60 BYTE)
                    .Append(",") //CUSER10 VARCHAR2(60 BYTE)
                    .Append(",") //NUSER4  NUMBER(15, 6)
                    .Append(",") //NUSER5  NUMBER(15, 6)
                    .Append(",") //NUSER6  NUMBER(15, 6)
                    .Append(",") //NUSER7  NUMBER(15, 6)
                    .Append(",") //NUSER8  NUMBER(15, 6)
                    .Append(",") //NUSER9  NUMBER(15, 6)
                    .Append(",") //details.UPCCode + ",") //NUSER10 NUMBER(15, 6)
                    .Append(",") //PROCESS_SAFETY_STOCK    VARCHAR2(1 BYTE)
                    .Append(",") //MX_GROUP_ID NUMBER(15, 0)
                    .Append(",") //FR_GROUP_ID NUMBER(15, 0)
                    .Append(",") //SETUP_CHARGE    NUMBER(15, 6)
                    .Append(",") //MOVE_TIME   NUMBER(7, 3)
                    .Append(",") //CARTONS_PALLET  NUMBER(15, 6)
                    .Append(",") //PIECES_CARTON   NUMBER(15, 6)
                    .Append(",") //AUTO_MRP_FIRM_WO    VARCHAR2(1 BYTE)
                    .Append(",") //FLOOR_BACKFLUSH VARCHAR2(1 BYTE)
                    .Append(",") //MPS VARCHAR2(1 BYTE)
                    .Append(",") //CUM_LEADTIME    NUMBER(8, 2)
                    .Append(",") //PHANTOM VARCHAR2(1 BYTE)
                    .Append(",") //CRITICAL_FENCE  NUMBER(3, 0)
                    .Append(",") //USER_NAME   VARCHAR2(35 BYTE)
                    .Append(",") //PK_HIDE VARCHAR2(1 BYTE)
                    .Append(",") //ACCT_ID_PRODVAR NUMBER(15, 0)
                    .Append(",") //PHANTOM_ONHAND  NUMBER(14, 4)
                    .Append(",") //LM_LABELS_ID    NUMBER(15, 0)
                    .Append(",") //DRIVE_PHANTOM_NEGATIVE  VARCHAR2(1 BYTE)
                    .Append(",") //NO_STDCOST_RECALC   VARCHAR2(1 BYTE)
                    .Append(",") //ACCT_ID_INTPLANT_SALES  NUMBER(15, 0)
                    .Append(",") //IMAGE_FILENAME  VARCHAR2(250 BYTE)
                    .Append(",") //NON_ALLOCATE_TOTAL  NUMBER(14, 4)
                    .Append(",") //INSP_RECEIPT_THRES  NUMBER(5, 0)
                    .Append(",") //INSP_RECEIPT_COUNT  NUMBER(5, 0)
                    .Append(",") //COST_STANDARD_ID_FUTURE NUMBER(15, 0)
                    .Append(",") //COST_STANDARD_ID    NUMBER(15, 0)
                    .Append(",") //COST_DESCRIP_FUTURE VARCHAR2(50 BYTE)
                    .Append(",") //COST_DESCRIP    VARCHAR2(50 BYTE)
                    .Append(",") //COST_CALC_DATE_FUTURE   DATE
                    .Append(",") //COST_CALC_DATE  DATE
                    .Append(",") //AUTO_MRP_INCLUDE_VMI    VARCHAR2(1 BYTE)
                    .Append(",") //PROD_CODE_ID    NUMBER(15, 0)
                    .Append(",") //DO_NOT_DISPO_FLOOR_PARTIAL  VARCHAR2(1 BYTE)
                    .Append(",") //INFO_SO VARCHAR2(2000 BYTE)
                    .Append(",") //INFO_PO VARCHAR2(2000 BYTE)
                    .Append(",") //EXCL_RECEIPT_TIME_PPV   VARCHAR2(1 BYTE)
                    .Append(",") //CYCLE_COUNT_ID  NUMBER(15, 0)
                    .Append(",") //CYCLE_COUNT_DATE    DATE
                    .Append(((details.Quantity > 0)? "N": "Y") + ",") //NON_MATERIAL    VARCHAR2(1 BYTE)
                    .Append(",") //MFG_MIN_QTY NUMBER(14, 4)
                    .Append(",") //MFG_MULTIPLE    NUMBER(14, 4)
                    .Append(",") //BUYER_CODE_ID   NUMBER(15, 0)
                    .Append(",") //COST_CALC_BATCH NUMBER(15, 0)
                    .Append(",") //INTRASTAT_CODE  VARCHAR2(25 BYTE)
                    .Append(",") //FAB_START   VARCHAR2(1 BYTE)
                    .Append(",") //MFG_SAFETY_QTY  NUMBER(14, 4)
                    .Append(",") //PLANNER_CODE_ID NUMBER(15, 0)
                    .Append(",") //IS_LOT_MANDATORY    VARCHAR2(1 BYTE)
                    .Append("0" + ",") //PK_WEIGHT   NUMBER(13, 6)
                    .Append(",") //PK_PTSPER   NUMBER(15, 6)
                    .Append(",") //DO_NOT_SCHED_FORECAST_WO    VARCHAR2(1 BYTE)
                    .Append(",") //IS_PALLET   VARCHAR2(1 BYTE)
                    .Append(",") //IS_AUTO_RT_LABELS   VARCHAR2(1 BYTE)
                    .Append(",") //IS_LINKED_TO_SERIAL VARCHAR2(1 BYTE)
                    .Append(",") //FR_INCLUDE  VARCHAR2(1 BYTE)
                    .Append(",") //MIN_CPK NUMBER(15, 6)
                    .Append(",") //LBL_ASSIST_LAST_PRINT   DATE
                    .Append(",") //LBL_ASSIST_PRINT_INTERVAL   NUMBER(5, 0)
                    .Append(",") //COC_EXCLUDE VARCHAR2(1 BYTE)
                    .Append(",") //ICT_REORD_POINT NUMBER(12, 2)
                    .Append(",") //ICT_REPLENISH_SCOPE_DAYS    NUMBER(3, 0)
                    .Append(",") //ICT_LEAD_DAYS   NUMBER(3, 0)
                    .Append(",") //ICT_SHIP_TO_ID  NUMBER(15, 0)
                    .Append(",") //AUTO_MRP_KANBAN_LOT_SIZE    NUMBER(15, 6)
                    .Append(",") //ICT_FIRE_TRIGGER    VARCHAR2(1 BYTE)
                    .Append(",") //COLOR_GROUP_ID  NUMBER(15, 0)
                    .Append(",") //FR_WO_TIME_FENCE    NUMBER(5, 2)
                    .Append(details.UnitizationPerLength + ",") //PK_LENGTH   NUMBER(15, 6)
                    .Append(details.UnitizationPerWidth + ",") //PK_WIDTH    NUMBER(15, 6)
                    .Append(details.UnitizationPerDepth + ",") //PK_HEIGHT   NUMBER(15, 6)
                    .Append(pkgSpec.UnitizationPerLength + ",") //PALLET_LENGTH   NUMBER(15, 6)
                    .Append(pkgSpec.UnitizationPerWidth + ",") //PALLET_WIDTH    NUMBER(15, 6)
                    .Append(pkgSpec.UnitizationPerDepth + ",") //PALLET_HEIGHT   NUMBER(15, 6)
                    .Append(",") //PALLET_VOLUME   NUMBER(15, 6)
                    .Append(",") //.Append(details.Quantity + ",") // pkgSpec.UnitPackageQuantity + ",") //PALLET_PTSPER   NUMBER(15, 6)
                    .Append(",") //PALLET_WEIGHT   NUMBER(15, 6)
                    .Append(",") //LENGTH  NUMBER(15, 6)
                    .Append(",") //WIDTH   NUMBER(15, 6)
                    .Append(",") //GAUGE   NUMBER(15, 6)
                    .Append(",") //IS_BY_PRODUCT   VARCHAR2(1 BYTE)
                    .Append(",") //EXCLUDE_FROM_COMMISSIONS    VARCHAR2(1 BYTE)
                    .Append(",") //AUTO_RT_LABELS_PK_SEQ   NUMBER(3, 0)
                    .Append(",") //PALLET_PATTERN_ID   NUMBER(15, 0)
                    .Append(",") //WEB_SALABLE VARCHAR2(1 BYTE)
                    .Append(",") //PO_MULTIPLE NUMBER(14, 4)
                    .Append(",") //FIFO_THRESHOLD  NUMBER(5, 2)
                    .Append(",") //COST_STANDARD_ID_FORECAST   NUMBER(15, 0)
                    .Append(",") //COST_STANDARD_ID_BUDGET NUMBER(15, 0)
                    .Append(",") //COST_DESCRIP_FORECAST   VARCHAR2(50 BYTE)
                    .Append(",") //COST_DESCRIP_BUDGET VARCHAR2(50 BYTE)
                    .Append(",") //COST_CALC_DATE_FORECAST DATE
                    .Append(",") //COST_CALC_DATE_BUDGET   DATE
                    .Append(",") //KEEP_LABEL_BOM_INTERPLANT_TRAN  VARCHAR2(1 BYTE)
                    .Append(",") //ECO_ORIG_CLASS  VARCHAR2(2 BYTE)
                    .Append(",") //ACCT_ID_WIP NUMBER(15, 0)
                    .Append(",") //IRV32_NO_PLAN_WO    VARCHAR2(1 BYTE)
                    .Append(",") //INFO_REC    VARCHAR2(2000 BYTE)
                    .Append(",") //IS_LOT_DATE_MANDATORY   VARCHAR2(1 BYTE)
                    .Append(",") //USE_THIS_UOM_FOR_MRP    VARCHAR2(1 BYTE)
                    .Append(",") //WAIT_TIME   NUMBER(7, 3)
                    .Append(",") //BOL_CALC_OVERRIDE   VARCHAR2(1 BYTE)
                    .Append(",") //RFQ_USE_STD_COST    VARCHAR2(1 BYTE)
                    .Append(",") //ACCT_ID_PHYS_VAR    NUMBER(15, 0)
                    .Append(",") //ACCT_ID_INV_COST_REV    NUMBER(15, 0)
                    .Append(",") //EXCLUDE_BACKFLUSH   VARCHAR2(1 BYTE)
                    .Append(",") //NONTAXABLE  VARCHAR2(1 BYTE)
                    .Append(",") //ACCT_ID_SHIPMENT    NUMBER(15, 0)
                    .Append(",") //AUTO_MRP_EXCLUDE_HARD_ALLOC VARCHAR2(1 BYTE)
                    .Append(",") //MIN_PPK NUMBER(15, 6)
                    .Append(",") //RUN_RULES   VARCHAR2(20 BYTE)
                    .Append(",") //RTPM_TRG_RTLABEL    VARCHAR2(1 BYTE)
                    .Append(",") //REBATE_PARAMS_ID    NUMBER(15, 0)
                    .Append(",") //TARIFF_CODE_ID  NUMBER(15, 0)
                    .Append(",") //WEBDIRECT_LEAD_DAYS NUMBER(5, 0)
                    .Append(",") //USE_COST_DEFAULT_STANDARD_ID    VARCHAR2(1 BYTE)
                    .Append(",") //ARINVT_GROUP_ID NUMBER(15, 0)
                    .Append(",") //CLONED_FROM_ARINVT_ID   NUMBER(15, 0)
                    .Append(",") //USE_LOT_CHARGE  VARCHAR2(1 BYTE)
                    .Append(",") //LOT_CHARGE  NUMBER(15, 6)
                    .Append(",") //UNIQUE_DISPO_LOC    VARCHAR2(1 BYTE)
                    .Append(",") //HEIJUNKA_SINCE_SCHED_DEMAND NUMBER(15, 6)
                    .Append(",") //CONFIG_CODE VARCHAR2(255 BYTE)
                    .Append(",") //AUTO_MRP_INCLUDE_VMI_MFG_CALC   VARCHAR2(1 BYTE)
                    .Append(",") //FR_WO_SCOPE NUMBER(5, 0)
                    .Append(",") //AUTO_MRP_APPLY_TO_SCHED_ALLOC   VARCHAR2(1 BYTE)
                    .Append(",") //PHANTOM_COMPONENTS_ON_SO    VARCHAR2(1 BYTE)
                    .Append(",") //SCHED_CASCADE_PARENT_MTO    VARCHAR2(1 BYTE)
                    .Append(",") //AUTO_POP_SERV_CTR   VARCHAR2(1 BYTE)
                    .Append(",") //EXCL_MARK_WO_MAT_XCPT   VARCHAR2(1 BYTE)
                    .Append(",") //IS_ALC  CHAR(1 BYTE)
                    .Append(",") //MARK_ORD_DETAIL_MTO VARCHAR2(1 BYTE)
                    .Append(",") //MSDS_AUTHORABLE VARCHAR2(1 BYTE)
                    .Append(",") //IS_MSDS VARCHAR2(1 BYTE)
                    .Append(",") //MSDS_UPLOAD VARCHAR2(1 BYTE)
                    .Append(",") //NONTAXABLE_PO   VARCHAR2(1 BYTE)
                    .Append(",") //OVERRIDE_REC_LOC    VARCHAR2(1 BYTE)
                    .Append(",") //IS_DROP_SHIP    VARCHAR2(1 BYTE)
                    .Append(",") //MAX_PALLET_STACK    NUMBER(2, 0)
                    .Append(",") //LOOSE_INV_MOVE_CLASS_ID NUMBER(15, 0)
                    .Append(",") //PACK_INV_MOVE_CLASS_ID  NUMBER(15, 0)
                    .Append(",") //PALLET_INV_MOVE_CLASS_ID    NUMBER(15, 0)
                    .Append(",") //PK_UNIT_TYPE    VARCHAR2(1 BYTE)
                    .Append(",") //LOOSE_MOVE_RANK_COUNT   NUMBER(15, 0)
                    .Append(",") //PACK_MOVE_RANK_COUNT    NUMBER(15, 0)
                    .Append(",") //PALLET_MOVE_RANK_COUNT  NUMBER(15, 0)
                    .Append(",") //EXCL_WORKORDER_MAT  VARCHAR2(1 BYTE)
                    .Append(",") //FIFO    VARCHAR2(1 BYTE)
                    .Append(",") //COMPANY_ID  NUMBER(15, 0)
                    .Append(",") //RECV_LOCATION_ID    NUMBER(15, 0)
                    .Append(",") //SPC_INSPECTION_ID   NUMBER(15, 0)
                    .Append(",") //AR_DISCOUNT_WATERFALL_ID    NUMBER(15, 0)
                    .Append(",") //LBL_LAST_PRINT  DATE
                    .Append(",") //EXCL_FROM_CTP_EXCEPTION VARCHAR2(1 BYTE)
                    .Append(",") //WMS_INV_GROUP_ID    NUMBER(15, 0)
                    .Append(",") //CORE_SIZE   NUMBER(15, 6)
                    .Append(",") //OD  NUMBER(15, 6)
                    .Append(",") //PS_CONVERT_INFO VARCHAR2(2000 BYTE)
                    .Append(",") //LOOSE_MOVE_RANK_LOCK    VARCHAR2(1 BYTE)
                    .Append(",") //PACK_MOVE_RANK_LOCK VARCHAR2(1 BYTE)
                    .Append(",") //PALLET_MOVE_RANK_LOCK   VARCHAR2(1 BYTE)
                    .Append(",") //CYCLE_COUNT_RANK_LOCK   VARCHAR2(1 BYTE)
                    .Append(",") //MIN_SELL_QTY    NUMBER(14, 4)
                    .Append(",") //INSP_LEAD_DAYS  NUMBER(3, 0)
                    .Append(",") //LOOSE_WEIGHT    NUMBER(15, 6)
                    .Append(",") //LOOSE_VOLUME    NUMBER(15, 6)
                    .Append(details.ContainerCLengthOutside + ",") //LOOSE_LENGTH    NUMBER(15, 6)
                    .Append(details.ContainerCWidthOutside + ",") //LOOSE_WIDTH NUMBER(15, 6)
                    .Append(details.ContainerCDepthOutside + ",") //LOOSE_HEIGHT    NUMBER(15, 6)
                    .Append(",") //IS_LOT_EXPIRY_DATE_MANDATORY    VARCHAR2(1 BYTE)
                    .Append(",") //ICT_TRUCK_PTSPER    NUMBER(15, 6)
                    .Append(",") //SAFETY_STOCK2   NUMBER(14, 4)
                    .Append(",") //COST_CALC_USER_NAME VARCHAR2(30 BYTE)
                    .Append(",") //SHELF_LIFE2 NUMBER(4, 0)
                    .Append(",") //ICT_AUTO_MRP_ORDER_QTY  NUMBER(12, 2)
                    .Append(",") //ICT_SHIP_PULL_DEMAND    VARCHAR2(1 BYTE)
                    .Append(",") //PLT_WRP_USE_QC  VARCHAR2(1 BYTE)
                    .Append(",") //PLT_WRP_LOC_ID  NUMBER(15, 0)
                    .Append(",") //HARD_ALLOC_ROUND_PRECISION  NUMBER(2, 0)
                    .Append(",") //BACKFLUSH_BY_SERIAL VARCHAR2(1 BYTE)
                    .Append(",") //GROUP_CODE  VARCHAR2(20 BYTE)
                    .Append(",") //PROPRIETARY_EFFECT_DATE DATE
                    .Append(",") //PROPRIETARY_DEACTIVE_DATE   DATE
                    .Append(",") //DEMAND_CHANGE   VARCHAR2(1 BYTE)
                    .Append(",") //TAX_CLASS_ID    NUMBER(15, 0)
                    .Append(",") //DISCOUNT_GROUPS_ID  NUMBER(15, 0)
                    .Append(",") //PHYS_CHAR_VOLUME    NUMBER(15, 6)
                    .Append(",") //PHANTOM_KIT_USE_COMP_PRICE  VARCHAR2(1 BYTE)
                    .Append(",") //ASSY1_EXCLUDE_FORECAST_WO   VARCHAR2(1 BYTE)
                    .Append(",") //LAST_DEMAND_CHANGE  DATE
                    .Append(",") //ARINVT_RECIPE_ID    NUMBER(15, 0)
                    .Append(",") //GL_PLUG_VALUE   VARCHAR2(50 BYTE)
                    .Append(",") //CAROUSEL_TARGET_ID  NUMBER(15, 0)
                    .Append(",") //CAROUSEL_OPERATOR   NUMBER(5, 2)
                    .Append(",") //CREATED DATE
                    .Append(",") //CREATEDBY   VARCHAR2(20 BYTE)
                    .Append(",") //CHANGED DATE
                    .Append(",") //CHANGEDBY   VARCHAR2(20 BYTE)
                    .Append(",") //ACCT_ID_INTRANSIT   NUMBER(15, 0)
                    .Append(",") //ACCT_ID_IP_TRANS    NUMBER(15, 0)
                    .Append(","); //ACCT_ID_IP_TRANS_VAR    NUMBER(15, 0)

            if (!CheckMaterialExists(details.ProcessOrMaterialCode))
            {
                InsertIntoTable(newLine, pkgSpec);
                //InsertIntoTable(newLine);
            }

            return newLine;
        }

        private static StringBuilder SetUpFinishedGood(string mappingType, DET.SPECIFICATION pkgSpec, List<DET.DETAILS> currentDetails)
        {
            string partNumber = ((mappingType.Equals("FG")) ? pkgSpec.ServicePartNo : pkgSpec.PackedServicePart);
            StringBuilder newLine = new StringBuilder("");
            newLine
                .Append(",") //ID  NUMBER(15, 0)
                .Append(",") //ARCUSTO_ID  NUMBER(15, 0)
                .Append(mappingType + ",") //CLASS   VARCHAR2(2 BYTE)
                .Append(partNumber + ",") //ITEMNO  VARCHAR2(50 BYTE)
                .Append(pkgSpec.Version + ",") //REV VARCHAR2(15 BYTE)
                .Append(pkgSpec.PartName + ",") //DESCRIP VARCHAR2(100 BYTE)
                .Append("" + ",") //DESCRIP2    VARCHAR2(100 BYTE)
                .Append(",") //AVG_COST    NUMBER(15, 6)
                .Append(",") //VENDOR_ID   NUMBER(15, 0)
                .Append("EACH" + ",") //UNIT    VARCHAR2(10 BYTE)
                .Append(",") //BLEND   VARCHAR2(1 BYTE)
                .Append(pkgSpec.SalesPartNo + ",") //CUSER1  VARCHAR2(60 BYTE)
                .Append(",") //CUSER2  VARCHAR2(60 BYTE)
                .Append(",") //CUSER3  VARCHAR2(60 BYTE)
                .Append(",") //NUSER1  NUMBER(15, 6)
                .Append(",") //NUSER2  NUMBER(15, 6)
                .Append(",") //NUSER3  NUMBER(15, 6)
                .Append(",") //BOM_ACTIVE  VARCHAR2(1 BYTE)
                .Append(",") //ONHAND  NUMBER(14, 4)
                .Append(",") //RG_ONHAND   NUMBER(14, 4)
                .Append(",") //NON_SALABLE VARCHAR2(1 BYTE)
                .Append(",") //NON_CONFORM_TOTAL   NUMBER(14, 4)
                .Append(",") //SERIALIZED  VARCHAR2(1 BYTE)
                .Append(",") //SAFETY_STOCK    NUMBER(14, 4)
                .Append(",") //MIN_ORDER_QTY   NUMBER(14, 4)
                .Append(",") //MAX_ORDER_QTY   NUMBER(14, 4)
                .Append(",") //MULTIPLE    NUMBER(14, 4)
                .Append(",") //YTDQTY  NUMBER(12, 0)
                .Append(",") //PTDQTY  NUMBER(12, 0)
                .Append(",") //CODE    VARCHAR2(1 BYTE)
                .Append(",") //LDATE   DATE
                .Append(",") //LBUY_DATE   DATE
                .Append(",") //TYPE    VARCHAR2(5 BYTE)
                .Append(",") //SERIES  VARCHAR2(10 BYTE)
                .Append(",") //LEAD_DAYS   NUMBER(3, 0)
                .Append(",") //LEAD_TIME   VARCHAR2(10 BYTE)
                .Append(",") //SPG NUMBER(15, 6)
                .Append(",") //DRYTIME NUMBER(2, 0)
                .Append(",") //DRYTEMP VARCHAR2(10 BYTE)
                .Append(",") //RGPRCNT NUMBER(3, 0)
                .Append(",") //AUTO_MJO    VARCHAR2(6 BYTE)
                .Append(",") //MFG_QUAN    NUMBER(14, 4)
                .Append(",") //AUX_AMT NUMBER(15, 6)
                .Append(",") //STDQUAN NUMBER(10, 0)
                .Append(",") //LOW_LEVEL_CODE  NUMBER(3, 0)
                .Append(",") //MPS_CODE    VARCHAR2(1 BYTE)
                .Append(",") //ARINVT_FAMILY_ID    NUMBER(15, 0)
                .Append("Y" + ",") //BACKFLUSH   VARCHAR2(1 BYTE)
                .Append(",") //DRAWING VARCHAR2(30 BYTE)
                .Append(",") //ECNO    VARCHAR2(25 BYTE)
                .Append(",") //STD_PRICE   NUMBER(15, 6)
                .Append(",") //STD_COST    NUMBER(15, 6)
                .Append(",") //STANDARD_ID NUMBER(15, 0)
                .Append(",") //ACCT_ID_SALES   NUMBER(15, 0)
                .Append(",") //ACCT_ID_INV NUMBER(15, 0)
                .Append(",") //MFG_SPLIT   VARCHAR2(1 BYTE)
                .Append(",") //PRICE_PER_1000  VARCHAR2(1 BYTE)
                .Append(",") //COMIS_PRCNT NUMBER(15, 6)
                .Append(",") //UNQUE_DATE_IN   VARCHAR2(1 BYTE)
                .Append(",") //SHELF_LIFE  NUMBER(4, 0)
                .Append(",") //ECODE   VARCHAR2(10 BYTE)
                .Append(",") //EID NUMBER(15, 0)
                .Append(",") //EDATE_TIME  DATE
                .Append(",") //ECOPY   VARCHAR2(1 BYTE)
                .Append(",") //ACCT_ID_PPV NUMBER(15, 0)
                .Append(",") //ACCT_ID_OH_DISPO    NUMBER(15, 0)
                .Append(",") //ACCT_ID_LABOR_DISPO NUMBER(15, 0)
                .Append(",") //ACCT_ID_HOLDING NUMBER(15, 0)
                .Append(",") //ITEM_TYPE_ID    NUMBER(15, 0)
                .Append(",") //NMFC_ID NUMBER(15, 0)
                .Append(",") //VOLUME  NUMBER(15, 6)
                .Append(",") //AUTO_MRP_REORD_POINT    NUMBER(12, 2)
                .Append(",") //AUTO_MRP_ORDER_QTY  NUMBER(12, 2)
                .Append(",") //AUTO_MRP_LEAD_DAYS  NUMBER(5, 2)
                .Append("5" + ",") //EPLANT_ID   NUMBER(15, 0)
                .Append(",") //COMMISSIONS_ID  NUMBER(15, 0)
                .Append(",") //STD_COST_CONTROL    VARCHAR2(60 BYTE)
                .Append("0" + ",") //PO_SCOPE    NUMBER(3, 0)
                .Append("0" + ",") //PO_SAFETY   NUMBER(3, 0)
                .Append("0" + ",") //PO_MOVE_RANGE   NUMBER(3, 0)
                .Append(",") //LM_IMAGE_FILENAME   VARCHAR2(50 BYTE)
                .Append(",") //CYCLE_COUNT_CODE    VARCHAR2(15 BYTE)
                .Append(",") //CUSER4  VARCHAR2(60 BYTE)
                .Append(",") //CUSER5  VARCHAR2(60 BYTE)
                .Append(",") //CUSER6  VARCHAR2(60 BYTE)
                .Append(",") //CUSER7  VARCHAR2(60 BYTE)
                .Append(",") //CUSER8  VARCHAR2(60 BYTE)
                .Append(",") //CUSER9  VARCHAR2(60 BYTE)
                .Append(pkgSpec.UpcCode + ",") //CUSER10 VARCHAR2(60 BYTE)
                .Append(",") //NUSER4  NUMBER(15, 6)
                .Append(",") //NUSER5  NUMBER(15, 6)
                .Append(",") //NUSER6  NUMBER(15, 6)
                .Append(",") //NUSER7  NUMBER(15, 6)
                .Append(",") //NUSER8  NUMBER(15, 6)
                .Append(",") //NUSER9  NUMBER(15, 6)
                .Append(",") //NUSER10 NUMBER(15, 6)
                .Append(",") //PROCESS_SAFETY_STOCK    VARCHAR2(1 BYTE)
                .Append(",") //MX_GROUP_ID NUMBER(15, 0)
                .Append(",") //FR_GROUP_ID NUMBER(15, 0)
                .Append(",") //SETUP_CHARGE    NUMBER(15, 6)
                .Append(",") //MOVE_TIME   NUMBER(7, 3)
                .Append(",") //CARTONS_PALLET  NUMBER(15, 6)
                .Append(",") //PIECES_CARTON   NUMBER(15, 6)
                .Append(",") //AUTO_MRP_FIRM_WO    VARCHAR2(1 BYTE)
                .Append(",") //FLOOR_BACKFLUSH VARCHAR2(1 BYTE)
                .Append(",") //MPS VARCHAR2(1 BYTE)
                .Append(",") //CUM_LEADTIME    NUMBER(8, 2)
                .Append(",") //PHANTOM VARCHAR2(1 BYTE)
                .Append(",") //CRITICAL_FENCE  NUMBER(3, 0)
                .Append(",") //USER_NAME   VARCHAR2(35 BYTE)
                .Append(",") //PK_HIDE VARCHAR2(1 BYTE)
                .Append(",") //ACCT_ID_PRODVAR NUMBER(15, 0)
                .Append(",") //PHANTOM_ONHAND  NUMBER(14, 4)
                .Append(",") //LM_LABELS_ID    NUMBER(15, 0)
                .Append(",") //DRIVE_PHANTOM_NEGATIVE  VARCHAR2(1 BYTE)
                .Append(",") //NO_STDCOST_RECALC   VARCHAR2(1 BYTE)
                .Append(",") //ACCT_ID_INTPLANT_SALES  NUMBER(15, 0)
                .Append(",") //IMAGE_FILENAME  VARCHAR2(250 BYTE)
                .Append(",") //NON_ALLOCATE_TOTAL  NUMBER(14, 4)
                .Append(",") //INSP_RECEIPT_THRES  NUMBER(5, 0)
                .Append(",") //INSP_RECEIPT_COUNT  NUMBER(5, 0)
                .Append(",") //COST_STANDARD_ID_FUTURE NUMBER(15, 0)
                .Append(",") //COST_STANDARD_ID    NUMBER(15, 0)
                .Append(",") //COST_DESCRIP_FUTURE VARCHAR2(50 BYTE)
                .Append(",") //COST_DESCRIP    VARCHAR2(50 BYTE)
                .Append(",") //COST_CALC_DATE_FUTURE   DATE
                .Append(",") //COST_CALC_DATE  DATE
                .Append(",") //AUTO_MRP_INCLUDE_VMI    VARCHAR2(1 BYTE)
                .Append(",") //PROD_CODE_ID    NUMBER(15, 0)
                .Append(",") //DO_NOT_DISPO_FLOOR_PARTIAL  VARCHAR2(1 BYTE)
                .Append(",") //INFO_SO VARCHAR2(2000 BYTE)
                .Append(",") //INFO_PO VARCHAR2(2000 BYTE)
                .Append(",") //EXCL_RECEIPT_TIME_PPV   VARCHAR2(1 BYTE)
                .Append(",") //CYCLE_COUNT_ID  NUMBER(15, 0)
                .Append(",") //CYCLE_COUNT_DATE    DATE
                .Append(((pkgSpec.UnitPackageQuantity > 0) ? "N" : "Y") + ",") // currentDetails[0].CpmIndicator : "") +",") //NON_MATERIAL    VARCHAR2(1 BYTE)
                .Append(",") //MFG_MIN_QTY NUMBER(14, 4)
                .Append(",") //MFG_MULTIPLE    NUMBER(14, 4)
                .Append(",") //BUYER_CODE_ID   NUMBER(15, 0)
                .Append(",") //COST_CALC_BATCH NUMBER(15, 0)
                .Append(",") //INTRASTAT_CODE  VARCHAR2(25 BYTE)
                .Append(",") //FAB_START   VARCHAR2(1 BYTE)
                .Append(",") //MFG_SAFETY_QTY  NUMBER(14, 4)
                .Append(",") //PLANNER_CODE_ID NUMBER(15, 0)
                .Append(",") //IS_LOT_MANDATORY    VARCHAR2(1 BYTE)
                .Append(pkgSpec.Weight + ",") //PK_WEIGHT   NUMBER(13, 6)
                .Append(",") //PK_PTSPER   NUMBER(15, 6)
                .Append(",") //DO_NOT_SCHED_FORECAST_WO    VARCHAR2(1 BYTE)
                .Append(",") //IS_PALLET   VARCHAR2(1 BYTE)
                .Append(",") //IS_AUTO_RT_LABELS   VARCHAR2(1 BYTE)
                .Append(",") //IS_LINKED_TO_SERIAL VARCHAR2(1 BYTE)
                .Append(",") //FR_INCLUDE  VARCHAR2(1 BYTE)
                .Append(",") //MIN_CPK NUMBER(15, 6)
                .Append(",") //LBL_ASSIST_LAST_PRINT   DATE
                .Append(",") //LBL_ASSIST_PRINT_INTERVAL   NUMBER(5, 0)
                .Append(",") //COC_EXCLUDE VARCHAR2(1 BYTE)
                .Append(",") //ICT_REORD_POINT NUMBER(12, 2)
                .Append(",") //ICT_REPLENISH_SCOPE_DAYS    NUMBER(3, 0)
                .Append(",") //ICT_LEAD_DAYS   NUMBER(3, 0)
                .Append(",") //ICT_SHIP_TO_ID  NUMBER(15, 0)
                .Append(",") //AUTO_MRP_KANBAN_LOT_SIZE    NUMBER(15, 6)
                .Append(",") //ICT_FIRE_TRIGGER    VARCHAR2(1 BYTE)
                .Append(",") //COLOR_GROUP_ID  NUMBER(15, 0)
                .Append(",") //FR_WO_TIME_FENCE    NUMBER(5, 2)
                .Append(",") //PK_LENGTH   NUMBER(15, 6)
                .Append(",") //PK_WIDTH    NUMBER(15, 6)
                .Append(",") //PK_HEIGHT   NUMBER(15, 6)
                .Append(pkgSpec.UnitizationPerLength + ",") //PALLET_LENGTH   NUMBER(15, 6)
                .Append(pkgSpec.UnitizationPerWidth + ",") //PALLET_WIDTH    NUMBER(15, 6)
                .Append(pkgSpec.UnitizationPerDepth + ",") //PALLET_HEIGHT   NUMBER(15, 6)
                .Append(",") //PALLET_VOLUME   NUMBER(15, 6)
                .Append(pkgSpec.UnitPackageQuantity + ",") //Append(((currentDetails.Count > 0) ? "" + currentDetails[0].Quantity : "") + ",") //PALLET_PTSPER   NUMBER(15, 6)
                .Append(",") //PALLET_WEIGHT   NUMBER(15, 6)
                .Append(",") //LENGTH  NUMBER(15, 6)
                .Append(",") //WIDTH   NUMBER(15, 6)
                .Append(",") //GAUGE   NUMBER(15, 6)
                .Append(",") //IS_BY_PRODUCT   VARCHAR2(1 BYTE)
                .Append(",") //EXCLUDE_FROM_COMMISSIONS    VARCHAR2(1 BYTE)
                .Append(",") //AUTO_RT_LABELS_PK_SEQ   NUMBER(3, 0)
                .Append(",") //PALLET_PATTERN_ID   NUMBER(15, 0)
                .Append(",") //WEB_SALABLE VARCHAR2(1 BYTE)
                .Append(",") //PO_MULTIPLE NUMBER(14, 4)
                .Append(",") //FIFO_THRESHOLD  NUMBER(5, 2)
                .Append(",") //COST_STANDARD_ID_FORECAST   NUMBER(15, 0)
                .Append(",") //COST_STANDARD_ID_BUDGET NUMBER(15, 0)
                .Append(",") //COST_DESCRIP_FORECAST   VARCHAR2(50 BYTE)
                .Append(",") //COST_DESCRIP_BUDGET VARCHAR2(50 BYTE)
                .Append(",") //COST_CALC_DATE_FORECAST DATE
                .Append(",") //COST_CALC_DATE_BUDGET   DATE
                .Append(",") //KEEP_LABEL_BOM_INTERPLANT_TRAN  VARCHAR2(1 BYTE)
                .Append(",") //ECO_ORIG_CLASS  VARCHAR2(2 BYTE)
                .Append(",") //ACCT_ID_WIP NUMBER(15, 0)
                .Append(",") //IRV32_NO_PLAN_WO    VARCHAR2(1 BYTE)
                .Append(",") //INFO_REC    VARCHAR2(2000 BYTE)
                .Append(",") //IS_LOT_DATE_MANDATORY   VARCHAR2(1 BYTE)
                .Append(",") //USE_THIS_UOM_FOR_MRP    VARCHAR2(1 BYTE)
                .Append(",") //WAIT_TIME   NUMBER(7, 3)
                .Append(",") //BOL_CALC_OVERRIDE   VARCHAR2(1 BYTE)
                .Append(",") //RFQ_USE_STD_COST    VARCHAR2(1 BYTE)
                .Append(",") //ACCT_ID_PHYS_VAR    NUMBER(15, 0)
                .Append(",") //ACCT_ID_INV_COST_REV    NUMBER(15, 0)
                .Append(",") //EXCLUDE_BACKFLUSH   VARCHAR2(1 BYTE)
                .Append(",") //NONTAXABLE  VARCHAR2(1 BYTE)
                .Append(",") //ACCT_ID_SHIPMENT    NUMBER(15, 0)
                .Append(",") //AUTO_MRP_EXCLUDE_HARD_ALLOC VARCHAR2(1 BYTE)
                .Append(",") //MIN_PPK NUMBER(15, 6)
                .Append(",") //RUN_RULES   VARCHAR2(20 BYTE)
                .Append(",") //RTPM_TRG_RTLABEL    VARCHAR2(1 BYTE)
                .Append(",") //REBATE_PARAMS_ID    NUMBER(15, 0)
                .Append(",") //TARIFF_CODE_ID  NUMBER(15, 0)
                .Append(",") //WEBDIRECT_LEAD_DAYS NUMBER(5, 0)
                .Append(",") //USE_COST_DEFAULT_STANDARD_ID    VARCHAR2(1 BYTE)
                .Append(",") //ARINVT_GROUP_ID NUMBER(15, 0)
                .Append(",") //CLONED_FROM_ARINVT_ID   NUMBER(15, 0)
                .Append(",") //USE_LOT_CHARGE  VARCHAR2(1 BYTE)
                .Append(",") //LOT_CHARGE  NUMBER(15, 6)
                .Append(",") //UNIQUE_DISPO_LOC    VARCHAR2(1 BYTE)
                .Append(",") //HEIJUNKA_SINCE_SCHED_DEMAND NUMBER(15, 6)
                .Append(",") //CONFIG_CODE VARCHAR2(255 BYTE)
                .Append(",") //AUTO_MRP_INCLUDE_VMI_MFG_CALC   VARCHAR2(1 BYTE)
                .Append(",") //FR_WO_SCOPE NUMBER(5, 0)
                .Append(",") //AUTO_MRP_APPLY_TO_SCHED_ALLOC   VARCHAR2(1 BYTE)
                .Append(",") //PHANTOM_COMPONENTS_ON_SO    VARCHAR2(1 BYTE)
                .Append(",") //SCHED_CASCADE_PARENT_MTO    VARCHAR2(1 BYTE)
                .Append(",") //AUTO_POP_SERV_CTR   VARCHAR2(1 BYTE)
                .Append(",") //EXCL_MARK_WO_MAT_XCPT   VARCHAR2(1 BYTE)
                .Append(",") //IS_ALC  CHAR(1 BYTE)
                .Append(",") //MARK_ORD_DETAIL_MTO VARCHAR2(1 BYTE)
                .Append(",") //MSDS_AUTHORABLE VARCHAR2(1 BYTE)
                .Append(",") //IS_MSDS VARCHAR2(1 BYTE)
                .Append(",") //MSDS_UPLOAD VARCHAR2(1 BYTE)
                .Append(",") //NONTAXABLE_PO   VARCHAR2(1 BYTE)
                .Append(",") //OVERRIDE_REC_LOC    VARCHAR2(1 BYTE)
                .Append(",") //IS_DROP_SHIP    VARCHAR2(1 BYTE)
                .Append(",") //MAX_PALLET_STACK    NUMBER(2, 0)
                .Append(",") //LOOSE_INV_MOVE_CLASS_ID NUMBER(15, 0)
                .Append(",") //PACK_INV_MOVE_CLASS_ID  NUMBER(15, 0)
                .Append(",") //PALLET_INV_MOVE_CLASS_ID    NUMBER(15, 0)
                .Append(",") //PK_UNIT_TYPE    VARCHAR2(1 BYTE)
                .Append(",") //LOOSE_MOVE_RANK_COUNT   NUMBER(15, 0)
                .Append(",") //PACK_MOVE_RANK_COUNT    NUMBER(15, 0)
                .Append(",") //PALLET_MOVE_RANK_COUNT  NUMBER(15, 0)
                .Append(",") //EXCL_WORKORDER_MAT  VARCHAR2(1 BYTE)
                .Append(",") //FIFO    VARCHAR2(1 BYTE)
                .Append(",") //COMPANY_ID  NUMBER(15, 0)
                .Append(",") //RECV_LOCATION_ID    NUMBER(15, 0)
                .Append(",") //SPC_INSPECTION_ID   NUMBER(15, 0)
                .Append(",") //AR_DISCOUNT_WATERFALL_ID    NUMBER(15, 0)
                .Append(",") //LBL_LAST_PRINT  DATE
                .Append(",") //EXCL_FROM_CTP_EXCEPTION VARCHAR2(1 BYTE)
                .Append(",") //WMS_INV_GROUP_ID    NUMBER(15, 0)
                .Append(",") //CORE_SIZE   NUMBER(15, 6)
                .Append(",") //OD  NUMBER(15, 6)
                .Append(",") //PS_CONVERT_INFO VARCHAR2(2000 BYTE)
                .Append(",") //LOOSE_MOVE_RANK_LOCK    VARCHAR2(1 BYTE)
                .Append(",") //PACK_MOVE_RANK_LOCK VARCHAR2(1 BYTE)
                .Append(",") //PALLET_MOVE_RANK_LOCK   VARCHAR2(1 BYTE)
                .Append(",") //CYCLE_COUNT_RANK_LOCK   VARCHAR2(1 BYTE)
                .Append(",") //MIN_SELL_QTY    NUMBER(14, 4)
                .Append(",") //INSP_LEAD_DAYS  NUMBER(3, 0)
                .Append(",") //LOOSE_WEIGHT    NUMBER(15, 6)
                .Append(",") //LOOSE_VOLUME    NUMBER(15, 6)
                .Append(((currentDetails.Count > 0) ? "" + currentDetails[0].UnitizationPerLength : "") + ",") //LOOSE_LENGTH    NUMBER(15, 6)
                .Append(((currentDetails.Count > 0) ? "" + currentDetails[0].UnitizationPerWidth : "") + ",") //LOOSE_WIDTH NUMBER(15, 6)
                .Append(((currentDetails.Count > 0) ? "" + currentDetails[0].UnitizationPerDepth : "") + ",") //LOOSE_HEIGHT    NUMBER(15, 6)
                .Append(",") //IS_LOT_EXPIRY_DATE_MANDATORY    VARCHAR2(1 BYTE)
                .Append(",") //ICT_TRUCK_PTSPER    NUMBER(15, 6)
                .Append(",") //SAFETY_STOCK2   NUMBER(14, 4)
                .Append(",") //COST_CALC_USER_NAME VARCHAR2(30 BYTE)
                .Append(",") //SHELF_LIFE2 NUMBER(4, 0)
                .Append(",") //ICT_AUTO_MRP_ORDER_QTY  NUMBER(12, 2)
                .Append(",") //ICT_SHIP_PULL_DEMAND    VARCHAR2(1 BYTE)
                .Append(",") //PLT_WRP_USE_QC  VARCHAR2(1 BYTE)
                .Append(",") //PLT_WRP_LOC_ID  NUMBER(15, 0)
                .Append(",") //HARD_ALLOC_ROUND_PRECISION  NUMBER(2, 0)
                .Append(",") //BACKFLUSH_BY_SERIAL VARCHAR2(1 BYTE)
                .Append(",") //GROUP_CODE  VARCHAR2(20 BYTE)
                .Append(",") //PROPRIETARY_EFFECT_DATE DATE
                .Append(",") //PROPRIETARY_DEACTIVE_DATE   DATE
                .Append(",") //DEMAND_CHANGE   VARCHAR2(1 BYTE)
                .Append(",") //TAX_CLASS_ID    NUMBER(15, 0)
                .Append(",") //DISCOUNT_GROUPS_ID  NUMBER(15, 0)
                .Append(",") //PHYS_CHAR_VOLUME    NUMBER(15, 6)
                .Append(",") //PHANTOM_KIT_USE_COMP_PRICE  VARCHAR2(1 BYTE)
                .Append(",") //ASSY1_EXCLUDE_FORECAST_WO   VARCHAR2(1 BYTE)
                .Append(",") //LAST_DEMAND_CHANGE  DATE
                .Append(",") //ARINVT_RECIPE_ID    NUMBER(15, 0)
                .Append(",") //GL_PLUG_VALUE   VARCHAR2(50 BYTE)
                .Append(",") //CAROUSEL_TARGET_ID  NUMBER(15, 0)
                .Append(",") //CAROUSEL_OPERATOR   NUMBER(5, 2)
                .Append(",") //CREATED DATE
                .Append(",") //CREATEDBY   VARCHAR2(20 BYTE)
                .Append(",") //CHANGED DATE
                .Append(",") //CHANGEDBY   VARCHAR2(20 BYTE)
                .Append(",") //ACCT_ID_INTRANSIT   NUMBER(15, 0)
                .Append(",") //ACCT_ID_IP_TRANS    NUMBER(15, 0)
                .Append(","); //ACCT_ID_IP_TRANS_VAR    NUMBER(15, 0)

            if (!CheckPartAndVersionExists(partNumber, pkgSpec.Version))
            {
                InsertIntoTable(newLine, pkgSpec);
                //InsertIntoTable(newLine);
            }

            return newLine;
        }

        private static void InsertIntoTable(StringBuilder newLine, DET.SPECIFICATION pkgSpec)
        {
            string[] stringArray = newLine.ToString().Split(',');
            //Console.Write("\r " + (stringArray[2] + " : " + pkgSpec.ServicePartNo).PadRight(30));

            string insertQuery = "INSERT INTO arinvt("
                                    + "id,"
                                    + "arcusto_id,"
                                    + "class,"
                                    + "itemno,"
                                    + "rev,"
                                    + "descrip,"
                                    + "descrip2,"
                                    + "avg_cost,"
                                    + "vendor_id,"
                                    + "unit,"
                                    + "blend,"
                                    + "cuser1,"
                                    + "cuser2,"
                                    + "cuser3,"
                                    + "nuser1,"
                                    + "nuser2,"
                                    + "nuser3,"
                                    + "bom_active,"
                                    + "onhand,"
                                    + "rg_onhand,"
                                    + "non_salable,"
                                    + "non_conform_total,"
                                    + "serialized,"
                                    + "safety_stock,"
                                    + "min_order_qty,"
                                    + "max_order_qty,"
                                    + "multiple,"
                                    + "ytdqty,"
                                    + "ptdqty,"
                                    + "code,"
                                    + "ldate,"
                                    + "lbuy_date,"
                                    + "type,"
                                    + "series,"
                                    + "lead_days,"
                                    + "lead_time,"
                                    + "spg,"
                                    + "drytime,"
                                    + "drytemp,"
                                    + "rgprcnt,"
                                    + "auto_mjo,"
                                    + "mfg_quan,"
                                    + "aux_amt,"
                                    + "stdquan,"
                                    + "low_level_code,"
                                    + "mps_code,"
                                    + "arinvt_family_id,"
                                    + "backflush,"
                                    + "drawing,"
                                    + "ecno,"
                                    + "std_price,"
                                    + "std_cost,"
                                    + "standard_id,"
                                    + "acct_id_sales,"
                                    + "acct_id_inv,"
                                    + "mfg_split,"
                                    + "price_per_1000,"
                                    + "comis_prcnt,"
                                    + "unque_date_in,"
                                    + "shelf_life,"
                                    + "ecode,"
                                    + "eid,"
                                    + "edate_time,"
                                    + "ecopy,"
                                    + "acct_id_ppv,"
                                    + "acct_id_oh_dispo,"
                                    + "acct_id_labor_dispo,"
                                    + "acct_id_holding,"
                                    + "item_type_id,"
                                    + "nmfc_id,"
                                    + "volume,"
                                    + "auto_mrp_reord_point,"
                                    + "auto_mrp_order_qty,"
                                    + "auto_mrp_lead_days,"
                                    + "eplant_id,"
                                    + "commissions_id,"
                                    + "std_cost_control,"
                                    + "po_scope,"
                                    + "po_safety,"
                                    + "po_move_range,"
                                    + "lm_image_filename,"
                                    + "cycle_count_code,"
                                    + "cuser4,"
                                    + "cuser5,"
                                    + "cuser6,"
                                    + "cuser7,"
                                    + "cuser8,"
                                    + "cuser9,"
                                    + "cuser10,"
                                    + "nuser4,"
                                    + "nuser5,"
                                    + "nuser6,"
                                    + "nuser7,"
                                    + "nuser8,"
                                    + "nuser9,"
                                    + "nuser10,"
                                    + "process_safety_stock,"
                                    + "mx_group_id,"
                                    + "fr_group_id,"
                                    + "setup_charge,"
                                    + "move_time,"
                                    + "cartons_pallet,"
                                    + "pieces_carton,"
                                    + "auto_mrp_firm_wo,"
                                    + "floor_backflush,"
                                    + "mps,"
                                    + "cum_leadtime,"
                                    + "phantom,"
                                    + "critical_fence,"
                                    + "user_name,"
                                    + "pk_hide,"
                                    + "acct_id_prodvar,"
                                    + "phantom_onhand,"
                                    + "lm_labels_id,"
                                    + "drive_phantom_negative,"
                                    + "no_stdcost_recalc,"
                                    + "acct_id_intplant_sales,"
                                    + "image_filename,"
                                    + "non_allocate_total,"
                                    + "insp_receipt_thres,"
                                    + "insp_receipt_count,"
                                    + "cost_standard_id_future,"
                                    + "cost_standard_id,"
                                    + "cost_descrip_future,"
                                    + "cost_descrip,"
                                    + "cost_calc_date_future,"
                                    + "cost_calc_date,"
                                    + "auto_mrp_include_vmi,"
                                    + "prod_code_id,"
                                    + "do_not_dispo_floor_partial,"
                                    + "info_so,"
                                    + "info_po,"
                                    + "excl_receipt_time_ppv,"
                                    + "cycle_count_id,"
                                    + "cycle_count_date,"
                                    + "non_material,"
                                    + "mfg_min_qty,"
                                    + "mfg_multiple,"
                                    + "buyer_code_id,"
                                    + "cost_calc_batch,"
                                    + "intrastat_code,"
                                    + "fab_start,"
                                    + "mfg_safety_qty,"
                                    + "planner_code_id,"
                                    + "is_lot_mandatory,"
                                    + "pk_weight,"
                                    + "pk_ptsper,"
                                    + "do_not_sched_forecast_wo,"
                                    + "is_pallet,"
                                    + "is_auto_rt_labels,"
                                    + "is_linked_to_serial,"
                                    + "fr_include,"
                                    + "min_cpk,"
                                    + "lbl_assist_last_print,"
                                    + "lbl_assist_print_interval,"
                                    + "coc_exclude,"
                                    + "ict_reord_point,"
                                    + "ict_replenish_scope_days,"
                                    + "ict_lead_days,"
                                    + "ict_ship_to_id,"
                                    + "auto_mrp_kanban_lot_size,"
                                    + "ict_fire_trigger,"
                                    + "color_group_id,"
                                    + "fr_wo_time_fence,"
                                    + "pk_length,"
                                    + "pk_width,"
                                    + "pk_height,"
                                    + "pallet_length,"
                                    + "pallet_width,"
                                    + "pallet_height,"
                                    + "pallet_volume,"
                                    + "pallet_ptsper,"
                                    + "pallet_weight,"
                                    + "length,"
                                    + "width,"
                                    + "gauge,"
                                    + "is_by_product,"
                                    + "exclude_from_commissions,"
                                    + "auto_rt_labels_pk_seq,"
                                    + "pallet_pattern_id,"
                                    + "web_salable,"
                                    + "po_multiple,"
                                    + "fifo_threshold,"
                                    + "cost_standard_id_forecast,"
                                    + "cost_standard_id_budget,"
                                    + "cost_descrip_forecast,"
                                    + "cost_descrip_budget,"
                                    + "cost_calc_date_forecast,"
                                    + "cost_calc_date_budget,"
                                    + "keep_label_bom_interplant_tran,"
                                    + "eco_orig_class,"
                                    + "acct_id_wip,"
                                    + "irv32_no_plan_wo,"
                                    + "info_rec,"
                                    + "is_lot_date_mandatory,"
                                    + "use_this_uom_for_mrp,"
                                    + "wait_time,"
                                    + "bol_calc_override,"
                                    + "rfq_use_std_cost,"
                                    + "acct_id_phys_var,"
                                    + "acct_id_inv_cost_rev,"
                                    + "exclude_backflush,"
                                    + "nontaxable,"
                                    + "acct_id_shipment,"
                                    + "auto_mrp_exclude_hard_alloc,"
                                    + "min_ppk,"
                                    + "run_rules,"
                                    + "rtpm_trg_rtlabel,"
                                    + "rebate_params_id,"
                                    + "tariff_code_id,"
                                    + "webdirect_lead_days,"
                                    + "use_cost_default_standard_id,"
                                    + "arinvt_group_id,"
                                    + "cloned_from_arinvt_id,"
                                    + "use_lot_charge,"
                                    + "lot_charge,"
                                    + "unique_dispo_loc,"
                                    + "heijunka_since_sched_demand,"
                                    + "config_code,"
                                    + "auto_mrp_include_vmi_mfg_calc,"
                                    + "fr_wo_scope,"
                                    + "auto_mrp_apply_to_sched_alloc,"
                                    + "phantom_components_on_so,"
                                    + "sched_cascade_parent_mto,"
                                    + "auto_pop_serv_ctr,"
                                    + "excl_mark_wo_mat_xcpt,"
                                    + "is_alc,"
                                    + "mark_ord_detail_mto,"
                                    + "msds_authorable,"
                                    + "is_msds,"
                                    + "msds_upload,"
                                    + "nontaxable_po,"
                                    + "override_rec_loc,"
                                    + "is_drop_ship,"
                                    + "max_pallet_stack,"
                                    + "loose_inv_move_class_id,"
                                    + "pack_inv_move_class_id,"
                                    + "pallet_inv_move_class_id,"
                                    + "pk_unit_type,"
                                    + "loose_move_rank_count,"
                                    + "pack_move_rank_count,"
                                    + "pallet_move_rank_count,"
                                    + "excl_workorder_mat,"
                                    + "fifo,"
                                    + "company_id,"
                                    + "recv_location_id,"
                                    + "spc_inspection_id,"
                                    + "ar_discount_waterfall_id,"
                                    + "lbl_last_print,"
                                    + "excl_from_ctp_exception,"
                                    + "wms_inv_group_id,"
                                    + "core_size,"
                                    + "od,"
                                    + "ps_convert_info,"
                                    + "loose_move_rank_lock,"
                                    + "pack_move_rank_lock,"
                                    + "pallet_move_rank_lock,"
                                    + "cycle_count_rank_lock,"
                                    + "min_sell_qty,"
                                    + "insp_lead_days,"
                                    + "loose_weight,"
                                    + "loose_volume,"
                                    + "loose_length,"
                                    + "loose_width,"
                                    + "loose_height,"
                                    + "is_lot_expiry_date_mandatory,"
                                    + "ict_truck_ptsper,"
                                    + "safety_stock2,"
                                    + "cost_calc_user_name,"
                                    + "shelf_life2,"
                                    + "ict_auto_mrp_order_qty,"
                                    + "ict_ship_pull_demand,"
                                    + "plt_wrp_use_qc,"
                                    + "plt_wrp_loc_id,"
                                    + "hard_alloc_round_precision,"
                                    + "backflush_by_serial,"
                                    + "group_code,"
                                    + "proprietary_effect_date,"
                                    + "proprietary_deactive_date,"
                                    + "demand_change,"
                                    + "tax_class_id,"
                                    + "discount_groups_id,"
                                    + "phys_char_volume,"
                                    + "phantom_kit_use_comp_price,"
                                    + "assy1_exclude_forecast_wo,"
                                    + "last_demand_change,"
                                    + "arinvt_recipe_id,"
                                    + "gl_plug_value,"
                                    + "carousel_target_id,"
                                    + "carousel_operator,"
                                    + "created,"
                                    + "createdby,"
                                    + "changed,"
                                    + "changedby,"
                                    + "acct_id_intransit,"
                                    + "acct_id_ip_trans,"
                                    + "acct_id_ip_trans_var"
                                    + ") VALUES("
                                    + ":ID, "
                                    + ":ARCUSTO_ID, "
                                    + ":CLASS, "
                                    + ":ITEMNO, "
                                    + ":REV, "
                                    + ":DESCRIP, "
                                    + ":DESCRIP2, "
                                    + ":AVG_COST, "
                                    + ":VENDOR_ID, "
                                    + ":UNIT, "
                                    + ":BLEND, "
                                    + ":CUSER1, "
                                    + ":CUSER2, "
                                    + ":CUSER3, "
                                    + ":NUSER1, "
                                    + ":NUSER2, "
                                    + ":NUSER3, "
                                    + ":BOM_ACTIVE, "
                                    + ":ONHAND, "
                                    + ":RG_ONHAND, "
                                    + ":NON_SALABLE, "
                                    + ":NON_CONFORM_TOTAL, "
                                    + ":SERIALIZED, "
                                    + ":SAFETY_STOCK, "
                                    + ":MIN_ORDER_QTY, "
                                    + ":MAX_ORDER_QTY, "
                                    + ":MULTIPLE, "
                                    + ":YTDQTY, "
                                    + ":PTDQTY, "
                                    + ":CODE, "
                                    + ":LDATE, "
                                    + ":LBUY_DATE, "
                                    + ":TYPE, "
                                    + ":SERIES, "
                                    + ":LEAD_DAYS, "
                                    + ":LEAD_TIME, "
                                    + ":SPG, "
                                    + ":DRYTIME, "
                                    + ":DRYTEMP, "
                                    + ":RGPRCNT, "
                                    + ":AUTO_MJO, "
                                    + ":MFG_QUAN, "
                                    + ":AUX_AMT, "
                                    + ":STDQUAN, "
                                    + ":LOW_LEVEL_CODE, "
                                    + ":MPS_CODE, "
                                    + ":ARINVT_FAMILY_ID, "
                                    + ":BACKFLUSH, "
                                    + ":DRAWING, "
                                    + ":ECNO, "
                                    + ":STD_PRICE, "
                                    + ":STD_COST, "
                                    + ":STANDARD_ID, "
                                    + ":ACCT_ID_SALES, "
                                    + ":ACCT_ID_INV, "
                                    + ":MFG_SPLIT, "
                                    + ":PRICE_PER_1000, "
                                    + ":COMIS_PRCNT, "
                                    + ":UNQUE_DATE_IN, "
                                    + ":SHELF_LIFE, "
                                    + ":ECODE, "
                                    + ":EID, "
                                    + ":EDATE_TIME, "
                                    + ":ECOPY, "
                                    + ":ACCT_ID_PPV, "
                                    + ":ACCT_ID_OH_DISPO, "
                                    + ":ACCT_ID_LABOR_DISPO, "
                                    + ":ACCT_ID_HOLDING, "
                                    + ":ITEM_TYPE_ID, "
                                    + ":NMFC_ID, "
                                    + ":VOLUME, "
                                    + ":AUTO_MRP_REORD_POINT, "
                                    + ":AUTO_MRP_ORDER_QTY, "
                                    + ":AUTO_MRP_LEAD_DAYS, "
                                    + ":EPLANT_ID, "
                                    + ":COMMISSIONS_ID, "
                                    + ":STD_COST_CONTROL, "
                                    + ":PO_SCOPE, "
                                    + ":PO_SAFETY, "
                                    + ":PO_MOVE_RANGE, "
                                    + ":LM_IMAGE_FILENAME, "
                                    + ":CYCLE_COUNT_CODE, "
                                    + ":CUSER4, "
                                    + ":CUSER5, "
                                    + ":CUSER6, "
                                    + ":CUSER7, "
                                    + ":CUSER8, "
                                    + ":CUSER9, "
                                    + ":CUSER10, "
                                    + ":NUSER4, "
                                    + ":NUSER5, "
                                    + ":NUSER6, "
                                    + ":NUSER7, "
                                    + ":NUSER8, "
                                    + ":NUSER9, "
                                    + ":NUSER10, "
                                    + ":PROCESS_SAFETY_STOCK, "
                                    + ":MX_GROUP_ID, "
                                    + ":FR_GROUP_ID, "
                                    + ":SETUP_CHARGE, "
                                    + ":MOVE_TIME, "
                                    + ":CARTONS_PALLET, "
                                    + ":PIECES_CARTON, "
                                    + ":AUTO_MRP_FIRM_WO, "
                                    + ":FLOOR_BACKFLUSH, "
                                    + ":MPS, "
                                    + ":CUM_LEADTIME, "
                                    + ":PHANTOM, "
                                    + ":CRITICAL_FENCE, "
                                    + ":USER_NAME, "
                                    + ":PK_HIDE, "
                                    + ":ACCT_ID_PRODVAR, "
                                    + ":PHANTOM_ONHAND, "
                                    + ":LM_LABELS_ID, "
                                    + ":DRIVE_PHANTOM_NEGATIVE, "
                                    + ":NO_STDCOST_RECALC, "
                                    + ":ACCT_ID_INTPLANT_SALES, "
                                    + ":IMAGE_FILENAME, "
                                    + ":NON_ALLOCATE_TOTAL, "
                                    + ":INSP_RECEIPT_THRES, "
                                    + ":INSP_RECEIPT_COUNT, "
                                    + ":COST_STANDARD_ID_FUTURE, "
                                    + ":COST_STANDARD_ID, "
                                    + ":COST_DESCRIP_FUTURE, "
                                    + ":COST_DESCRIP, "
                                    + ":COST_CALC_DATE_FUTURE, "
                                    + ":COST_CALC_DATE, "
                                    + ":AUTO_MRP_INCLUDE_VMI, "
                                    + ":PROD_CODE_ID, "
                                    + ":DO_NOT_DISPO_FLOOR_PARTIAL, "
                                    + ":INFO_SO, "
                                    + ":INFO_PO, "
                                    + ":EXCL_RECEIPT_TIME_PPV, "
                                    + ":CYCLE_COUNT_ID, "
                                    + ":CYCLE_COUNT_DATE, "
                                    + ":NON_MATERIAL, "
                                    + ":MFG_MIN_QTY, "
                                    + ":MFG_MULTIPLE, "
                                    + ":BUYER_CODE_ID, "
                                    + ":COST_CALC_BATCH, "
                                    + ":INTRASTAT_CODE, "
                                    + ":FAB_START, "
                                    + ":MFG_SAFETY_QTY, "
                                    + ":PLANNER_CODE_ID, "
                                    + ":IS_LOT_MANDATORY, "
                                    + ":PK_WEIGHT, "
                                    + ":PK_PTSPER, "
                                    + ":DO_NOT_SCHED_FORECAST_WO, "
                                    + ":IS_PALLET, "
                                    + ":IS_AUTO_RT_LABELS, "
                                    + ":IS_LINKED_TO_SERIAL, "
                                    + ":FR_INCLUDE, "
                                    + ":MIN_CPK, "
                                    + ":LBL_ASSIST_LAST_PRINT, "
                                    + ":LBL_ASSIST_PRINT_INTERVAL, "
                                    + ":COC_EXCLUDE, "
                                    + ":ICT_REORD_POINT, "
                                    + ":ICT_REPLENISH_SCOPE_DAYS, "
                                    + ":ICT_LEAD_DAYS, "
                                    + ":ICT_SHIP_TO_ID, "
                                    + ":AUTO_MRP_KANBAN_LOT_SIZE, "
                                    + ":ICT_FIRE_TRIGGER, "
                                    + ":COLOR_GROUP_ID, "
                                    + ":FR_WO_TIME_FENCE, "
                                    + ":PK_LENGTH, "
                                    + ":PK_WIDTH, "
                                    + ":PK_HEIGHT, "
                                    + ":PALLET_LENGTH, "
                                    + ":PALLET_WIDTH, "
                                    + ":PALLET_HEIGHT, "
                                    + ":PALLET_VOLUME, "
                                    + ":PALLET_PTSPER, "
                                    + ":PALLET_WEIGHT, "
                                    + ":LENGTH, "
                                    + ":WIDTH, "
                                    + ":GAUGE, "
                                    + ":IS_BY_PRODUCT, "
                                    + ":EXCLUDE_FROM_COMMISSIONS, "
                                    + ":AUTO_RT_LABELS_PK_SEQ, "
                                    + ":PALLET_PATTERN_ID, "
                                    + ":WEB_SALABLE, "
                                    + ":PO_MULTIPLE, "
                                    + ":FIFO_THRESHOLD, "
                                    + ":COST_STANDARD_ID_FORECAST, "
                                    + ":COST_STANDARD_ID_BUDGET, "
                                    + ":COST_DESCRIP_FORECAST, "
                                    + ":COST_DESCRIP_BUDGET, "
                                    + ":COST_CALC_DATE_FORECAST, "
                                    + ":COST_CALC_DATE_BUDGET, "
                                    + ":KEEP_LABEL_BOM_INTERPLANT_TRAN, "
                                    + ":ECO_ORIG_CLASS, "
                                    + ":ACCT_ID_WIP, "
                                    + ":IRV32_NO_PLAN_WO, "
                                    + ":INFO_REC, "
                                    + ":IS_LOT_DATE_MANDATORY, "
                                    + ":USE_THIS_UOM_FOR_MRP, "
                                    + ":WAIT_TIME, "
                                    + ":BOL_CALC_OVERRIDE, "
                                    + ":RFQ_USE_STD_COST, "
                                    + ":ACCT_ID_PHYS_VAR, "
                                    + ":ACCT_ID_INV_COST_REV, "
                                    + ":EXCLUDE_BACKFLUSH, "
                                    + ":NONTAXABLE, "
                                    + ":ACCT_ID_SHIPMENT, "
                                    + ":AUTO_MRP_EXCLUDE_HARD_ALLOC, "
                                    + ":MIN_PPK, "
                                    + ":RUN_RULES, "
                                    + ":RTPM_TRG_RTLABEL, "
                                    + ":REBATE_PARAMS_ID, "
                                    + ":TARIFF_CODE_ID, "
                                    + ":WEBDIRECT_LEAD_DAYS, "
                                    + ":USE_COST_DEFAULT_STANDARD_ID, "
                                    + ":ARINVT_GROUP_ID, "
                                    + ":CLONED_FROM_ARINVT_ID, "
                                    + ":USE_LOT_CHARGE, "
                                    + ":LOT_CHARGE, "
                                    + ":UNIQUE_DISPO_LOC, "
                                    + ":HEIJUNKA_SINCE_SCHED_DEMAND, "
                                    + ":CONFIG_CODE, "
                                    + ":AUTO_MRP_INCLUDE_VMI_MFG_CALC, "
                                    + ":FR_WO_SCOPE, "
                                    + ":AUTO_MRP_APPLY_TO_SCHED_ALLOC, "
                                    + ":PHANTOM_COMPONENTS_ON_SO, "
                                    + ":SCHED_CASCADE_PARENT_MTO, "
                                    + ":AUTO_POP_SERV_CTR, "
                                    + ":EXCL_MARK_WO_MAT_XCPT, "
                                    + ":IS_ALC, "
                                    + ":MARK_ORD_DETAIL_MTO, "
                                    + ":MSDS_AUTHORABLE, "
                                    + ":IS_MSDS, "
                                    + ":MSDS_UPLOAD, "
                                    + ":NONTAXABLE_PO, "
                                    + ":OVERRIDE_REC_LOC, "
                                    + ":IS_DROP_SHIP, "
                                    + ":MAX_PALLET_STACK, "
                                    + ":LOOSE_INV_MOVE_CLASS_ID, "
                                    + ":PACK_INV_MOVE_CLASS_ID, "
                                    + ":PALLET_INV_MOVE_CLASS_ID, "
                                    + ":PK_UNIT_TYPE, "
                                    + ":LOOSE_MOVE_RANK_COUNT, "
                                    + ":PACK_MOVE_RANK_COUNT, "
                                    + ":PALLET_MOVE_RANK_COUNT, "
                                    + ":EXCL_WORKORDER_MAT, "
                                    + ":FIFO, "
                                    + ":COMPANY_ID, "
                                    + ":RECV_LOCATION_ID, "
                                    + ":SPC_INSPECTION_ID, "
                                    + ":AR_DISCOUNT_WATERFALL_ID, "
                                    + ":LBL_LAST_PRINT, "
                                    + ":EXCL_FROM_CTP_EXCEPTION, "
                                    + ":WMS_INV_GROUP_ID, "
                                    + ":CORE_SIZE, "
                                    + ":OD, "
                                    + ":PS_CONVERT_INFO, "
                                    + ":LOOSE_MOVE_RANK_LOCK, "
                                    + ":PACK_MOVE_RANK_LOCK, "
                                    + ":PALLET_MOVE_RANK_LOCK, "
                                    + ":CYCLE_COUNT_RANK_LOCK, "
                                    + ":MIN_SELL_QTY, "
                                    + ":INSP_LEAD_DAYS, "
                                    + ":LOOSE_WEIGHT, "
                                    + ":LOOSE_VOLUME, "
                                    + ":LOOSE_LENGTH, "
                                    + ":LOOSE_WIDTH, "
                                    + ":LOOSE_HEIGHT, "
                                    + ":IS_LOT_EXPIRY_DATE_MANDATORY, "
                                    + ":ICT_TRUCK_PTSPER, "
                                    + ":SAFETY_STOCK2, "
                                    + ":COST_CALC_USER_NAME, "
                                    + ":SHELF_LIFE2, "
                                    + ":ICT_AUTO_MRP_ORDER_QTY, "
                                    + ":ICT_SHIP_PULL_DEMAND, "
                                    + ":PLT_WRP_USE_QC, "
                                    + ":PLT_WRP_LOC_ID, "
                                    + ":HARD_ALLOC_ROUND_PRECISION, "
                                    + ":BACKFLUSH_BY_SERIAL, "
                                    + ":GROUP_CODE, "
                                    + ":PROPRIETARY_EFFECT_DATE, "
                                    + ":PROPRIETARY_DEACTIVE_DATE, "
                                    + ":DEMAND_CHANGE, "
                                    + ":TAX_CLASS_ID, "
                                    + ":DISCOUNT_GROUPS_ID, "
                                    + ":PHYS_CHAR_VOLUME, "
                                    + ":PHANTOM_KIT_USE_COMP_PRICE, "
                                    + ":ASSY1_EXCLUDE_FORECAST_WO, "
                                    + ":LAST_DEMAND_CHANGE, "
                                    + ":ARINVT_RECIPE_ID, "
                                    + ":GL_PLUG_VALUE, "
                                    + ":CAROUSEL_TARGET_ID, "
                                    + ":CAROUSEL_OPERATOR, "
                                    + ":CREATED, "
                                    + ":CREATEDBY, "
                                    + ":CHANGED, "
                                    + ":CHANGEDBY, "
                                    + ":ACCT_ID_INTRANSIT, "
                                    + ":ACCT_ID_IP_TRANS, "
                                    + ":ACCT_ID_IP_TRANS_VAR"
                                    + ")";
            long sequenceID = 0;

            //*
            try
            {
                using (OracleConnection db = OracleConnectionFactory.IQMSConnection)
                {
                    //insertQuery
                    using (OracleCommand insert = new OracleCommand(insertQuery, db))
                    {
                        insert.CommandType = CommandType.Text;
                        insert.CommandTimeout = 0;

                        sequenceID = getNextSequenceID();
                        insert.Parameters.Add("ID", OracleDbType.Decimal, sequenceID, ParameterDirection.Input);
                        insert.Parameters.Add("ARCUSTO_ID", OracleDbType.Decimal, GetDecimal(stringArray[1]), ParameterDirection.Input);
                        insert.Parameters.Add("CLASS", OracleDbType.Varchar2, GetString(stringArray[2]), ParameterDirection.Input);
                        insert.Parameters.Add("ITEMNO", OracleDbType.Varchar2, GetString(stringArray[3]), ParameterDirection.Input);
                        insert.Parameters.Add("REV", OracleDbType.Varchar2, GetString(stringArray[4]), ParameterDirection.Input);
                        insert.Parameters.Add("DESCRIP", OracleDbType.Varchar2, GetString(stringArray[5]), ParameterDirection.Input);
                        insert.Parameters.Add("DESCRIP2", OracleDbType.Varchar2, GetString(stringArray[6]), ParameterDirection.Input);
                        insert.Parameters.Add("AVG_COST", OracleDbType.Decimal, GetDecimal(stringArray[7]), ParameterDirection.Input);
                        insert.Parameters.Add("VENDOR_ID", OracleDbType.Decimal, GetDecimal(stringArray[8]), ParameterDirection.Input);
                        insert.Parameters.Add("UNIT", OracleDbType.Varchar2, GetString(stringArray[9]), ParameterDirection.Input);
                        insert.Parameters.Add("BLEND", OracleDbType.Varchar2, GetString(stringArray[10]), ParameterDirection.Input);
                        insert.Parameters.Add("CUSER1", OracleDbType.Varchar2, GetString(stringArray[11]), ParameterDirection.Input);
                        insert.Parameters.Add("CUSER2", OracleDbType.Varchar2, GetString(stringArray[12]), ParameterDirection.Input);
                        insert.Parameters.Add("CUSER3", OracleDbType.Varchar2, GetString(stringArray[13]), ParameterDirection.Input);
                        insert.Parameters.Add("NUSER1", OracleDbType.Decimal, GetDecimal(stringArray[14]), ParameterDirection.Input);
                        insert.Parameters.Add("NUSER2", OracleDbType.Decimal, GetDecimal(stringArray[15]), ParameterDirection.Input);
                        insert.Parameters.Add("NUSER3", OracleDbType.Decimal, GetDecimal(stringArray[16]), ParameterDirection.Input);
                        insert.Parameters.Add("BOM_ACTIVE", OracleDbType.Varchar2, GetString(stringArray[17]), ParameterDirection.Input);
                        insert.Parameters.Add("ONHAND", OracleDbType.Decimal, GetDecimal(stringArray[18]), ParameterDirection.Input);
                        insert.Parameters.Add("RG_ONHAND", OracleDbType.Decimal, GetDecimal(stringArray[19]), ParameterDirection.Input);
                        insert.Parameters.Add("NON_SALABLE", OracleDbType.Varchar2, GetString(stringArray[20]), ParameterDirection.Input);
                        insert.Parameters.Add("NON_CONFORM_TOTAL", OracleDbType.Decimal, GetDecimal(stringArray[21]), ParameterDirection.Input);
                        insert.Parameters.Add("SERIALIZED", OracleDbType.Varchar2, GetString(stringArray[22]), ParameterDirection.Input);
                        insert.Parameters.Add("SAFETY_STOCK", OracleDbType.Decimal, GetDecimal(stringArray[23]), ParameterDirection.Input);
                        insert.Parameters.Add("MIN_ORDER_QTY", OracleDbType.Decimal, GetDecimal(stringArray[24]), ParameterDirection.Input);
                        insert.Parameters.Add("MAX_ORDER_QTY", OracleDbType.Decimal, GetDecimal(stringArray[25]), ParameterDirection.Input);
                        insert.Parameters.Add("MULTIPLE", OracleDbType.Decimal, GetDecimal(stringArray[26]), ParameterDirection.Input);
                        insert.Parameters.Add("YTDQTY", OracleDbType.Decimal, GetDecimal(stringArray[27]), ParameterDirection.Input);
                        insert.Parameters.Add("PTDQTY", OracleDbType.Decimal, GetDecimal(stringArray[28]), ParameterDirection.Input);
                        insert.Parameters.Add("CODE", OracleDbType.Varchar2, GetString(stringArray[29]), ParameterDirection.Input);
                        insert.Parameters.Add("LDATE", OracleDbType.Date, GetDateTime(stringArray[30]), ParameterDirection.Input);
                        insert.Parameters.Add("LBUY_DATE", OracleDbType.Date, GetDateTime(stringArray[31]), ParameterDirection.Input);
                        insert.Parameters.Add("TYPE", OracleDbType.Varchar2, GetString(stringArray[32]), ParameterDirection.Input);
                        insert.Parameters.Add("SERIES", OracleDbType.Varchar2, GetString(stringArray[33]), ParameterDirection.Input);
                        insert.Parameters.Add("LEAD_DAYS", OracleDbType.Decimal, GetDecimal(stringArray[34]), ParameterDirection.Input);
                        insert.Parameters.Add("LEAD_TIME", OracleDbType.Varchar2, GetString(stringArray[35]), ParameterDirection.Input);
                        insert.Parameters.Add("SPG", OracleDbType.Decimal, GetDecimal(stringArray[36]), ParameterDirection.Input);
                        insert.Parameters.Add("DRYTIME", OracleDbType.Decimal, GetDecimal(stringArray[37]), ParameterDirection.Input);
                        insert.Parameters.Add("DRYTEMP", OracleDbType.Varchar2, GetString(stringArray[38]), ParameterDirection.Input);
                        insert.Parameters.Add("RGPRCNT", OracleDbType.Decimal, GetDecimal(stringArray[39]), ParameterDirection.Input);
                        insert.Parameters.Add("AUTO_MJO", OracleDbType.Varchar2, GetString(stringArray[40]), ParameterDirection.Input);
                        insert.Parameters.Add("MFG_QUAN", OracleDbType.Decimal, GetDecimal(stringArray[41]), ParameterDirection.Input);
                        insert.Parameters.Add("AUX_AMT", OracleDbType.Decimal, GetDecimal(stringArray[42]), ParameterDirection.Input);
                        insert.Parameters.Add("STDQUAN", OracleDbType.Decimal, GetDecimal(stringArray[43]), ParameterDirection.Input);
                        insert.Parameters.Add("LOW_LEVEL_CODE", OracleDbType.Decimal, GetDecimal(stringArray[44]), ParameterDirection.Input);
                        insert.Parameters.Add("MPS_CODE", OracleDbType.Varchar2, GetString(stringArray[45]), ParameterDirection.Input);
                        insert.Parameters.Add("ARINVT_FAMILY_ID", OracleDbType.Decimal, GetDecimal(stringArray[46]), ParameterDirection.Input);
                        insert.Parameters.Add("BACKFLUSH", OracleDbType.Varchar2, GetString(stringArray[47]), ParameterDirection.Input);
                        insert.Parameters.Add("DRAWING", OracleDbType.Varchar2, GetString(stringArray[48]), ParameterDirection.Input);
                        insert.Parameters.Add("ECNO", OracleDbType.Varchar2, GetString(stringArray[49]), ParameterDirection.Input);
                        insert.Parameters.Add("STD_PRICE", OracleDbType.Decimal, GetDecimal(stringArray[50]), ParameterDirection.Input);
                        insert.Parameters.Add("STD_COST", OracleDbType.Decimal, GetDecimal(stringArray[51]), ParameterDirection.Input);
                        insert.Parameters.Add("STANDARD_ID", OracleDbType.Decimal, GetDecimal(stringArray[52]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_SALES", OracleDbType.Decimal, GetDecimal(stringArray[53]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_INV", OracleDbType.Decimal, GetDecimal(stringArray[54]), ParameterDirection.Input);
                        insert.Parameters.Add("MFG_SPLIT", OracleDbType.Varchar2, GetString(stringArray[55]), ParameterDirection.Input);
                        insert.Parameters.Add("PRICE_PER_1000", OracleDbType.Varchar2, GetString(stringArray[56]), ParameterDirection.Input);
                        insert.Parameters.Add("COMIS_PRCNT", OracleDbType.Decimal, GetDecimal(stringArray[57]), ParameterDirection.Input);
                        insert.Parameters.Add("UNQUE_DATE_IN", OracleDbType.Varchar2, GetString(stringArray[58]), ParameterDirection.Input);
                        insert.Parameters.Add("SHELF_LIFE", OracleDbType.Decimal, GetDecimal(stringArray[59]), ParameterDirection.Input);
                        insert.Parameters.Add("ECODE", OracleDbType.Varchar2, GetString(stringArray[60]), ParameterDirection.Input);
                        insert.Parameters.Add("EID", OracleDbType.Decimal, GetDecimal(stringArray[61]), ParameterDirection.Input);
                        insert.Parameters.Add("EDATE_TIME", OracleDbType.Date, GetDateTime(stringArray[62]), ParameterDirection.Input);
                        insert.Parameters.Add("ECOPY", OracleDbType.Varchar2, GetString(stringArray[63]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_PPV", OracleDbType.Decimal, GetDecimal(stringArray[64]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_OH_DISPO", OracleDbType.Decimal, GetDecimal(stringArray[65]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_LABOR_DISPO", OracleDbType.Decimal, GetDecimal(stringArray[66]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_HOLDING", OracleDbType.Decimal, GetDecimal(stringArray[67]), ParameterDirection.Input);
                        insert.Parameters.Add("ITEM_TYPE_ID", OracleDbType.Decimal, GetDecimal(stringArray[68]), ParameterDirection.Input);
                        insert.Parameters.Add("NMFC_ID", OracleDbType.Decimal, GetDecimal(stringArray[69]), ParameterDirection.Input);
                        insert.Parameters.Add("VOLUME", OracleDbType.Decimal, GetDecimal(stringArray[70]), ParameterDirection.Input);
                        insert.Parameters.Add("AUTO_MRP_REORD_POINT", OracleDbType.Decimal, GetDecimal(stringArray[71]), ParameterDirection.Input);
                        insert.Parameters.Add("AUTO_MRP_ORDER_QTY", OracleDbType.Decimal, GetDecimal(stringArray[72]), ParameterDirection.Input);
                        insert.Parameters.Add("AUTO_MRP_LEAD_DAYS", OracleDbType.Decimal, GetDecimal(stringArray[73]), ParameterDirection.Input);
                        insert.Parameters.Add("EPLANT_ID", OracleDbType.Decimal, GetDecimal(stringArray[74]), ParameterDirection.Input);
                        insert.Parameters.Add("COMMISSIONS_ID", OracleDbType.Decimal, GetDecimal(stringArray[75]), ParameterDirection.Input);
                        insert.Parameters.Add("STD_COST_CONTROL", OracleDbType.Varchar2, GetString(stringArray[76]), ParameterDirection.Input);
                        insert.Parameters.Add("PO_SCOPE", OracleDbType.Decimal, GetDecimal(stringArray[77]), ParameterDirection.Input);
                        insert.Parameters.Add("PO_SAFETY", OracleDbType.Decimal, GetDecimal(stringArray[78]), ParameterDirection.Input);
                        insert.Parameters.Add("PO_MOVE_RANGE", OracleDbType.Decimal, GetDecimal(stringArray[79]), ParameterDirection.Input);
                        insert.Parameters.Add("LM_IMAGE_FILENAME", OracleDbType.Varchar2, GetString(stringArray[80]), ParameterDirection.Input);
                        insert.Parameters.Add("CYCLE_COUNT_CODE", OracleDbType.Varchar2, GetString(stringArray[81]), ParameterDirection.Input);
                        insert.Parameters.Add("CUSER4", OracleDbType.Varchar2, GetString(stringArray[82]), ParameterDirection.Input);
                        insert.Parameters.Add("CUSER5", OracleDbType.Varchar2, GetString(stringArray[83]), ParameterDirection.Input);
                        insert.Parameters.Add("CUSER6", OracleDbType.Varchar2, GetString(stringArray[84]), ParameterDirection.Input);
                        insert.Parameters.Add("CUSER7", OracleDbType.Varchar2, GetString(stringArray[85]), ParameterDirection.Input);
                        insert.Parameters.Add("CUSER8", OracleDbType.Varchar2, GetString(stringArray[86]), ParameterDirection.Input);
                        insert.Parameters.Add("CUSER9", OracleDbType.Varchar2, GetString(stringArray[87]), ParameterDirection.Input);
                        insert.Parameters.Add("CUSER10", OracleDbType.Varchar2, GetString(stringArray[88]), ParameterDirection.Input);
                        insert.Parameters.Add("NUSER4", OracleDbType.Decimal, GetDecimal(stringArray[89]), ParameterDirection.Input);
                        insert.Parameters.Add("NUSER5", OracleDbType.Decimal, GetDecimal(stringArray[90]), ParameterDirection.Input);
                        insert.Parameters.Add("NUSER6", OracleDbType.Decimal, GetDecimal(stringArray[91]), ParameterDirection.Input);
                        insert.Parameters.Add("NUSER7", OracleDbType.Decimal, GetDecimal(stringArray[92]), ParameterDirection.Input);
                        insert.Parameters.Add("NUSER8", OracleDbType.Decimal, GetDecimal(stringArray[93]), ParameterDirection.Input);
                        insert.Parameters.Add("NUSER9", OracleDbType.Decimal, GetDecimal(stringArray[94]), ParameterDirection.Input);
                        insert.Parameters.Add("NUSER10", OracleDbType.Decimal, GetDecimal(stringArray[95]), ParameterDirection.Input);
                        insert.Parameters.Add("PROCESS_SAFETY_STOCK", OracleDbType.Varchar2, GetString(stringArray[96]), ParameterDirection.Input);
                        insert.Parameters.Add("MX_GROUP_ID", OracleDbType.Decimal, GetDecimal(stringArray[97]), ParameterDirection.Input);
                        insert.Parameters.Add("FR_GROUP_ID", OracleDbType.Decimal, GetDecimal(stringArray[98]), ParameterDirection.Input);
                        insert.Parameters.Add("SETUP_CHARGE", OracleDbType.Decimal, GetDecimal(stringArray[99]), ParameterDirection.Input);
                        insert.Parameters.Add("MOVE_TIME", OracleDbType.Decimal, GetDecimal(stringArray[100]), ParameterDirection.Input);
                        insert.Parameters.Add("CARTONS_PALLET", OracleDbType.Decimal, GetDecimal(stringArray[101]), ParameterDirection.Input);
                        insert.Parameters.Add("PIECES_CARTON", OracleDbType.Decimal, GetDecimal(stringArray[102]), ParameterDirection.Input);
                        insert.Parameters.Add("AUTO_MRP_FIRM_WO", OracleDbType.Varchar2, GetString(stringArray[103]), ParameterDirection.Input);
                        insert.Parameters.Add("FLOOR_BACKFLUSH", OracleDbType.Varchar2, GetString(stringArray[104]), ParameterDirection.Input);
                        insert.Parameters.Add("MPS", OracleDbType.Varchar2, GetString(stringArray[105]), ParameterDirection.Input);
                        insert.Parameters.Add("CUM_LEADTIME", OracleDbType.Decimal, GetDecimal(stringArray[106]), ParameterDirection.Input);
                        insert.Parameters.Add("PHANTOM", OracleDbType.Varchar2, GetString(stringArray[107]), ParameterDirection.Input);
                        insert.Parameters.Add("CRITICAL_FENCE", OracleDbType.Decimal, GetDecimal(stringArray[108]), ParameterDirection.Input);
                        insert.Parameters.Add("USER_NAME", OracleDbType.Varchar2, GetString(stringArray[109]), ParameterDirection.Input);
                        insert.Parameters.Add("PK_HIDE", OracleDbType.Varchar2, GetString(stringArray[110]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_PRODVAR", OracleDbType.Decimal, GetDecimal(stringArray[111]), ParameterDirection.Input);
                        insert.Parameters.Add("PHANTOM_ONHAND", OracleDbType.Decimal, GetDecimal(stringArray[112]), ParameterDirection.Input);
                        insert.Parameters.Add("LM_LABELS_ID", OracleDbType.Decimal, GetDecimal(stringArray[113]), ParameterDirection.Input);
                        insert.Parameters.Add("DRIVE_PHANTOM_NEGATIVE", OracleDbType.Varchar2, GetString(stringArray[114]), ParameterDirection.Input);
                        insert.Parameters.Add("NO_STDCOST_RECALC", OracleDbType.Varchar2, GetString(stringArray[115]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_INTPLANT_SALES", OracleDbType.Decimal, GetDecimal(stringArray[116]), ParameterDirection.Input);
                        insert.Parameters.Add("IMAGE_FILENAME", OracleDbType.Varchar2, GetString(stringArray[117]), ParameterDirection.Input);
                        insert.Parameters.Add("NON_ALLOCATE_TOTAL", OracleDbType.Decimal, GetDecimal(stringArray[118]), ParameterDirection.Input);
                        insert.Parameters.Add("INSP_RECEIPT_THRES", OracleDbType.Decimal, GetDecimal(stringArray[119]), ParameterDirection.Input);
                        insert.Parameters.Add("INSP_RECEIPT_COUNT", OracleDbType.Decimal, GetDecimal(stringArray[120]), ParameterDirection.Input);
                        insert.Parameters.Add("COST_STANDARD_ID_FUTURE", OracleDbType.Decimal, GetDecimal(stringArray[121]), ParameterDirection.Input);
                        insert.Parameters.Add("COST_STANDARD_ID", OracleDbType.Decimal, GetDecimal(stringArray[122]), ParameterDirection.Input);
                        insert.Parameters.Add("COST_DESCRIP_FUTURE", OracleDbType.Varchar2, GetString(stringArray[123]), ParameterDirection.Input);
                        insert.Parameters.Add("COST_DESCRIP", OracleDbType.Varchar2, GetString(stringArray[124]), ParameterDirection.Input);
                        insert.Parameters.Add("COST_CALC_DATE_FUTURE", OracleDbType.Date, GetDateTime(stringArray[125]), ParameterDirection.Input);
                        insert.Parameters.Add("COST_CALC_DATE", OracleDbType.Date, GetDateTime(stringArray[126]), ParameterDirection.Input);
                        insert.Parameters.Add("AUTO_MRP_INCLUDE_VMI", OracleDbType.Varchar2, GetString(stringArray[127]), ParameterDirection.Input);
                        insert.Parameters.Add("PROD_CODE_ID", OracleDbType.Decimal, GetDecimal(stringArray[128]), ParameterDirection.Input);
                        insert.Parameters.Add("DO_NOT_DISPO_FLOOR_PARTIAL", OracleDbType.Varchar2, GetString(stringArray[129]), ParameterDirection.Input);
                        insert.Parameters.Add("INFO_SO", OracleDbType.Varchar2, GetString(stringArray[130]), ParameterDirection.Input);
                        insert.Parameters.Add("INFO_PO", OracleDbType.Varchar2, GetString(stringArray[131]), ParameterDirection.Input);
                        insert.Parameters.Add("EXCL_RECEIPT_TIME_PPV", OracleDbType.Varchar2, GetString(stringArray[132]), ParameterDirection.Input);
                        insert.Parameters.Add("CYCLE_COUNT_ID", OracleDbType.Decimal, GetDecimal(stringArray[133]), ParameterDirection.Input);
                        insert.Parameters.Add("CYCLE_COUNT_DATE", OracleDbType.Date, GetDateTime(stringArray[134]), ParameterDirection.Input);
                        insert.Parameters.Add("NON_MATERIAL", OracleDbType.Varchar2, GetString(stringArray[135]), ParameterDirection.Input);
                        insert.Parameters.Add("MFG_MIN_QTY", OracleDbType.Decimal, GetDecimal(stringArray[136]), ParameterDirection.Input);
                        insert.Parameters.Add("MFG_MULTIPLE", OracleDbType.Decimal, GetDecimal(stringArray[137]), ParameterDirection.Input);
                        insert.Parameters.Add("BUYER_CODE_ID", OracleDbType.Decimal, GetDecimal(stringArray[138]), ParameterDirection.Input);
                        insert.Parameters.Add("COST_CALC_BATCH", OracleDbType.Decimal, GetDecimal(stringArray[139]), ParameterDirection.Input);
                        insert.Parameters.Add("INTRASTAT_CODE", OracleDbType.Varchar2, GetString(stringArray[140]), ParameterDirection.Input);
                        insert.Parameters.Add("FAB_START", OracleDbType.Varchar2, GetString(stringArray[141]), ParameterDirection.Input);
                        insert.Parameters.Add("MFG_SAFETY_QTY", OracleDbType.Decimal, GetDecimal(stringArray[142]), ParameterDirection.Input);
                        insert.Parameters.Add("PLANNER_CODE_ID", OracleDbType.Decimal, GetDecimal(stringArray[143]), ParameterDirection.Input);
                        insert.Parameters.Add("IS_LOT_MANDATORY", OracleDbType.Varchar2, GetString(stringArray[144]), ParameterDirection.Input);
                        insert.Parameters.Add("PK_WEIGHT", OracleDbType.Decimal, GetDecimal(stringArray[145]), ParameterDirection.Input);
                        insert.Parameters.Add("PK_PTSPER", OracleDbType.Decimal, GetDecimal(stringArray[146]), ParameterDirection.Input);
                        insert.Parameters.Add("DO_NOT_SCHED_FORECAST_WO", OracleDbType.Varchar2, GetString(stringArray[147]), ParameterDirection.Input);
                        insert.Parameters.Add("IS_PALLET", OracleDbType.Varchar2, GetString(stringArray[148]), ParameterDirection.Input);
                        insert.Parameters.Add("IS_AUTO_RT_LABELS", OracleDbType.Varchar2, GetString(stringArray[149]), ParameterDirection.Input);
                        insert.Parameters.Add("IS_LINKED_TO_SERIAL", OracleDbType.Varchar2, GetString(stringArray[150]), ParameterDirection.Input);
                        insert.Parameters.Add("FR_INCLUDE", OracleDbType.Varchar2, GetString(stringArray[151]), ParameterDirection.Input);
                        insert.Parameters.Add("MIN_CPK", OracleDbType.Decimal, GetDecimal(stringArray[152]), ParameterDirection.Input);
                        insert.Parameters.Add("LBL_ASSIST_LAST_PRINT", OracleDbType.Date, GetDateTime(stringArray[153]), ParameterDirection.Input);
                        insert.Parameters.Add("LBL_ASSIST_PRINT_INTERVAL", OracleDbType.Decimal, GetDecimal(stringArray[154]), ParameterDirection.Input);
                        insert.Parameters.Add("COC_EXCLUDE", OracleDbType.Varchar2, GetString(stringArray[155]), ParameterDirection.Input);
                        insert.Parameters.Add("ICT_REORD_POINT", OracleDbType.Decimal, GetDecimal(stringArray[156]), ParameterDirection.Input);
                        insert.Parameters.Add("ICT_REPLENISH_SCOPE_DAYS", OracleDbType.Decimal, GetDecimal(stringArray[157]), ParameterDirection.Input);
                        insert.Parameters.Add("ICT_LEAD_DAYS", OracleDbType.Decimal, GetDecimal(stringArray[158]), ParameterDirection.Input);
                        insert.Parameters.Add("ICT_SHIP_TO_ID", OracleDbType.Decimal, GetDecimal(stringArray[159]), ParameterDirection.Input);
                        insert.Parameters.Add("AUTO_MRP_KANBAN_LOT_SIZE", OracleDbType.Decimal, GetDecimal(stringArray[160]), ParameterDirection.Input);
                        insert.Parameters.Add("ICT_FIRE_TRIGGER", OracleDbType.Varchar2, GetString(stringArray[161]), ParameterDirection.Input);
                        insert.Parameters.Add("COLOR_GROUP_ID", OracleDbType.Decimal, GetDecimal(stringArray[162]), ParameterDirection.Input);
                        insert.Parameters.Add("FR_WO_TIME_FENCE", OracleDbType.Decimal, GetDecimal(stringArray[163]), ParameterDirection.Input);
                        insert.Parameters.Add("PK_LENGTH", OracleDbType.Decimal, GetDecimal(stringArray[164]), ParameterDirection.Input);
                        insert.Parameters.Add("PK_WIDTH", OracleDbType.Decimal, GetDecimal(stringArray[165]), ParameterDirection.Input);
                        insert.Parameters.Add("PK_HEIGHT", OracleDbType.Decimal, GetDecimal(stringArray[166]), ParameterDirection.Input);
                        insert.Parameters.Add("PALLET_LENGTH", OracleDbType.Decimal, GetDecimal(stringArray[167]), ParameterDirection.Input);
                        insert.Parameters.Add("PALLET_WIDTH", OracleDbType.Decimal, GetDecimal(stringArray[168]), ParameterDirection.Input);
                        insert.Parameters.Add("PALLET_HEIGHT", OracleDbType.Decimal, GetDecimal(stringArray[169]), ParameterDirection.Input);
                        insert.Parameters.Add("PALLET_VOLUME", OracleDbType.Decimal, GetDecimal(stringArray[170]), ParameterDirection.Input);
                        insert.Parameters.Add("PALLET_PTSPER", OracleDbType.Decimal, GetDecimal(stringArray[171]), ParameterDirection.Input);
                        insert.Parameters.Add("PALLET_WEIGHT", OracleDbType.Decimal, GetDecimal(stringArray[172]), ParameterDirection.Input);
                        insert.Parameters.Add("LENGTH", OracleDbType.Decimal, GetDecimal(stringArray[173]), ParameterDirection.Input);
                        insert.Parameters.Add("WIDTH", OracleDbType.Decimal, GetDecimal(stringArray[174]), ParameterDirection.Input);
                        insert.Parameters.Add("GAUGE", OracleDbType.Decimal, GetDecimal(stringArray[175]), ParameterDirection.Input);
                        insert.Parameters.Add("IS_BY_PRODUCT", OracleDbType.Varchar2, GetString(stringArray[176]), ParameterDirection.Input);
                        insert.Parameters.Add("EXCLUDE_FROM_COMMISSIONS", OracleDbType.Varchar2, GetString(stringArray[177]), ParameterDirection.Input);
                        insert.Parameters.Add("AUTO_RT_LABELS_PK_SEQ", OracleDbType.Decimal, GetDecimal(stringArray[178]), ParameterDirection.Input);
                        insert.Parameters.Add("PALLET_PATTERN_ID", OracleDbType.Decimal, GetDecimal(stringArray[179]), ParameterDirection.Input);
                        insert.Parameters.Add("WEB_SALABLE", OracleDbType.Varchar2, GetString(stringArray[180]), ParameterDirection.Input);
                        insert.Parameters.Add("PO_MULTIPLE", OracleDbType.Decimal, GetDecimal(stringArray[181]), ParameterDirection.Input);
                        insert.Parameters.Add("FIFO_THRESHOLD", OracleDbType.Decimal, GetDecimal(stringArray[182]), ParameterDirection.Input);
                        insert.Parameters.Add("COST_STANDARD_ID_FORECAST", OracleDbType.Decimal, GetDecimal(stringArray[183]), ParameterDirection.Input);
                        insert.Parameters.Add("COST_STANDARD_ID_BUDGET", OracleDbType.Decimal, GetDecimal(stringArray[184]), ParameterDirection.Input);
                        insert.Parameters.Add("COST_DESCRIP_FORECAST", OracleDbType.Varchar2, GetString(stringArray[185]), ParameterDirection.Input);
                        insert.Parameters.Add("COST_DESCRIP_BUDGET", OracleDbType.Varchar2, GetString(stringArray[186]), ParameterDirection.Input);
                        insert.Parameters.Add("COST_CALC_DATE_FORECAST", OracleDbType.Date, GetDateTime(stringArray[187]), ParameterDirection.Input);
                        insert.Parameters.Add("COST_CALC_DATE_BUDGET", OracleDbType.Date, GetDateTime(stringArray[188]), ParameterDirection.Input);
                        insert.Parameters.Add("KEEP_LABEL_BOM_INTERPLANT_TRAN", OracleDbType.Varchar2, GetString(stringArray[189]), ParameterDirection.Input);
                        insert.Parameters.Add("ECO_ORIG_CLASS", OracleDbType.Varchar2, GetString(stringArray[190]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_WIP", OracleDbType.Decimal, GetDecimal(stringArray[191]), ParameterDirection.Input);
                        insert.Parameters.Add("IRV32_NO_PLAN_WO", OracleDbType.Varchar2, GetString(stringArray[192]), ParameterDirection.Input);
                        insert.Parameters.Add("INFO_REC", OracleDbType.Varchar2, GetString(stringArray[193]), ParameterDirection.Input);
                        insert.Parameters.Add("IS_LOT_DATE_MANDATORY", OracleDbType.Varchar2, GetString(stringArray[194]), ParameterDirection.Input);
                        insert.Parameters.Add("USE_THIS_UOM_FOR_MRP", OracleDbType.Varchar2, GetString(stringArray[195]), ParameterDirection.Input);
                        insert.Parameters.Add("WAIT_TIME", OracleDbType.Decimal, GetDecimal(stringArray[196]), ParameterDirection.Input);
                        insert.Parameters.Add("BOL_CALC_OVERRIDE", OracleDbType.Varchar2, GetString(stringArray[197]), ParameterDirection.Input);
                        insert.Parameters.Add("RFQ_USE_STD_COST", OracleDbType.Varchar2, GetString(stringArray[198]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_PHYS_VAR", OracleDbType.Decimal, GetDecimal(stringArray[199]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_INV_COST_REV", OracleDbType.Decimal, GetDecimal(stringArray[200]), ParameterDirection.Input);
                        insert.Parameters.Add("EXCLUDE_BACKFLUSH", OracleDbType.Varchar2, GetString(stringArray[201]), ParameterDirection.Input);
                        insert.Parameters.Add("NONTAXABLE", OracleDbType.Varchar2, GetString(stringArray[202]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_SHIPMENT", OracleDbType.Decimal, GetDecimal(stringArray[203]), ParameterDirection.Input);
                        insert.Parameters.Add("AUTO_MRP_EXCLUDE_HARD_ALLOC", OracleDbType.Varchar2, GetString(stringArray[204]), ParameterDirection.Input);
                        insert.Parameters.Add("MIN_PPK", OracleDbType.Decimal, GetDecimal(stringArray[205]), ParameterDirection.Input);
                        insert.Parameters.Add("RUN_RULES", OracleDbType.Varchar2, GetString(stringArray[206]), ParameterDirection.Input);
                        insert.Parameters.Add("RTPM_TRG_RTLABEL", OracleDbType.Varchar2, GetString(stringArray[207]), ParameterDirection.Input);
                        insert.Parameters.Add("REBATE_PARAMS_ID", OracleDbType.Decimal, GetDecimal(stringArray[208]), ParameterDirection.Input);
                        insert.Parameters.Add("TARIFF_CODE_ID", OracleDbType.Decimal, GetDecimal(stringArray[209]), ParameterDirection.Input);
                        insert.Parameters.Add("WEBDIRECT_LEAD_DAYS", OracleDbType.Decimal, GetDecimal(stringArray[210]), ParameterDirection.Input);
                        insert.Parameters.Add("USE_COST_DEFAULT_STANDARD_ID", OracleDbType.Varchar2, GetString(stringArray[211]), ParameterDirection.Input);
                        insert.Parameters.Add("ARINVT_GROUP_ID", OracleDbType.Decimal, GetDecimal(stringArray[212]), ParameterDirection.Input);
                        insert.Parameters.Add("CLONED_FROM_ARINVT_ID", OracleDbType.Decimal, GetDecimal(stringArray[213]), ParameterDirection.Input);
                        insert.Parameters.Add("USE_LOT_CHARGE", OracleDbType.Varchar2, GetString(stringArray[214]), ParameterDirection.Input);
                        insert.Parameters.Add("LOT_CHARGE", OracleDbType.Decimal, GetDecimal(stringArray[215]), ParameterDirection.Input);
                        insert.Parameters.Add("UNIQUE_DISPO_LOC", OracleDbType.Varchar2, GetString(stringArray[216]), ParameterDirection.Input);
                        insert.Parameters.Add("HEIJUNKA_SINCE_SCHED_DEMAND", OracleDbType.Decimal, GetDecimal(stringArray[217]), ParameterDirection.Input);
                        insert.Parameters.Add("CONFIG_CODE", OracleDbType.Varchar2, GetString(stringArray[218]), ParameterDirection.Input);
                        insert.Parameters.Add("AUTO_MRP_INCLUDE_VMI_MFG_CALC", OracleDbType.Varchar2, GetString(stringArray[219]), ParameterDirection.Input);
                        insert.Parameters.Add("FR_WO_SCOPE", OracleDbType.Decimal, GetDecimal(stringArray[220]), ParameterDirection.Input);
                        insert.Parameters.Add("AUTO_MRP_APPLY_TO_SCHED_ALLOC", OracleDbType.Varchar2, GetString(stringArray[221]), ParameterDirection.Input);
                        insert.Parameters.Add("PHANTOM_COMPONENTS_ON_SO", OracleDbType.Varchar2, GetString(stringArray[222]), ParameterDirection.Input);
                        insert.Parameters.Add("SCHED_CASCADE_PARENT_MTO", OracleDbType.Varchar2, GetString(stringArray[223]), ParameterDirection.Input);
                        insert.Parameters.Add("AUTO_POP_SERV_CTR", OracleDbType.Varchar2, GetString(stringArray[224]), ParameterDirection.Input);
                        insert.Parameters.Add("EXCL_MARK_WO_MAT_XCPT", OracleDbType.Varchar2, GetString(stringArray[225]), ParameterDirection.Input);
                        insert.Parameters.Add("IS_ALC", OracleDbType.Varchar2, GetString(stringArray[226]), ParameterDirection.Input);
                        insert.Parameters.Add("MARK_ORD_DETAIL_MTO", OracleDbType.Varchar2, GetString(stringArray[227]), ParameterDirection.Input);
                        insert.Parameters.Add("MSDS_AUTHORABLE", OracleDbType.Varchar2, GetString(stringArray[228]), ParameterDirection.Input);
                        insert.Parameters.Add("IS_MSDS", OracleDbType.Varchar2, GetString(stringArray[229]), ParameterDirection.Input);
                        insert.Parameters.Add("MSDS_UPLOAD", OracleDbType.Varchar2, GetString(stringArray[230]), ParameterDirection.Input);
                        insert.Parameters.Add("NONTAXABLE_PO", OracleDbType.Varchar2, GetString(stringArray[231]), ParameterDirection.Input);
                        insert.Parameters.Add("OVERRIDE_REC_LOC", OracleDbType.Varchar2, GetString(stringArray[232]), ParameterDirection.Input);
                        insert.Parameters.Add("IS_DROP_SHIP", OracleDbType.Varchar2, GetString(stringArray[233]), ParameterDirection.Input);
                        insert.Parameters.Add("MAX_PALLET_STACK", OracleDbType.Decimal, GetDecimal(stringArray[234]), ParameterDirection.Input);
                        insert.Parameters.Add("LOOSE_INV_MOVE_CLASS_ID", OracleDbType.Decimal, GetDecimal(stringArray[235]), ParameterDirection.Input);
                        insert.Parameters.Add("PACK_INV_MOVE_CLASS_ID", OracleDbType.Decimal, GetDecimal(stringArray[236]), ParameterDirection.Input);
                        insert.Parameters.Add("PALLET_INV_MOVE_CLASS_ID", OracleDbType.Decimal, GetDecimal(stringArray[237]), ParameterDirection.Input);
                        insert.Parameters.Add("PK_UNIT_TYPE", OracleDbType.Varchar2, GetString(stringArray[238]), ParameterDirection.Input);
                        insert.Parameters.Add("LOOSE_MOVE_RANK_COUNT", OracleDbType.Decimal, GetDecimal(stringArray[239]), ParameterDirection.Input);
                        insert.Parameters.Add("PACK_MOVE_RANK_COUNT", OracleDbType.Decimal, GetDecimal(stringArray[240]), ParameterDirection.Input);
                        insert.Parameters.Add("PALLET_MOVE_RANK_COUNT", OracleDbType.Decimal, GetDecimal(stringArray[241]), ParameterDirection.Input);
                        insert.Parameters.Add("EXCL_WORKORDER_MAT", OracleDbType.Varchar2, GetString(stringArray[242]), ParameterDirection.Input);
                        insert.Parameters.Add("FIFO", OracleDbType.Varchar2, GetString(stringArray[243]), ParameterDirection.Input);
                        insert.Parameters.Add("COMPANY_ID", OracleDbType.Decimal, GetDecimal(stringArray[244]), ParameterDirection.Input);
                        insert.Parameters.Add("RECV_LOCATION_ID", OracleDbType.Decimal, GetDecimal(stringArray[245]), ParameterDirection.Input);
                        insert.Parameters.Add("SPC_INSPECTION_ID", OracleDbType.Decimal, GetDecimal(stringArray[246]), ParameterDirection.Input);
                        insert.Parameters.Add("AR_DISCOUNT_WATERFALL_ID", OracleDbType.Decimal, GetDecimal(stringArray[247]), ParameterDirection.Input);
                        insert.Parameters.Add("LBL_LAST_PRINT", OracleDbType.Date, GetDateTime(stringArray[248]), ParameterDirection.Input);
                        insert.Parameters.Add("EXCL_FROM_CTP_EXCEPTION", OracleDbType.Varchar2, GetString(stringArray[249]), ParameterDirection.Input);
                        insert.Parameters.Add("WMS_INV_GROUP_ID", OracleDbType.Decimal, GetDecimal(stringArray[250]), ParameterDirection.Input);
                        insert.Parameters.Add("CORE_SIZE", OracleDbType.Decimal, GetDecimal(stringArray[251]), ParameterDirection.Input);
                        insert.Parameters.Add("OD", OracleDbType.Decimal, GetDecimal(stringArray[252]), ParameterDirection.Input);
                        insert.Parameters.Add("PS_CONVERT_INFO", OracleDbType.Varchar2, GetString(stringArray[253]), ParameterDirection.Input);
                        insert.Parameters.Add("LOOSE_MOVE_RANK_LOCK", OracleDbType.Varchar2, GetString(stringArray[254]), ParameterDirection.Input);
                        insert.Parameters.Add("PACK_MOVE_RANK_LOCK", OracleDbType.Varchar2, GetString(stringArray[255]), ParameterDirection.Input);
                        insert.Parameters.Add("PALLET_MOVE_RANK_LOCK", OracleDbType.Varchar2, GetString(stringArray[256]), ParameterDirection.Input);
                        insert.Parameters.Add("CYCLE_COUNT_RANK_LOCK", OracleDbType.Varchar2, GetString(stringArray[257]), ParameterDirection.Input);
                        insert.Parameters.Add("MIN_SELL_QTY", OracleDbType.Decimal, GetDecimal(stringArray[258]), ParameterDirection.Input);
                        insert.Parameters.Add("INSP_LEAD_DAYS", OracleDbType.Decimal, GetDecimal(stringArray[259]), ParameterDirection.Input);
                        insert.Parameters.Add("LOOSE_WEIGHT", OracleDbType.Decimal, GetDecimal(stringArray[260]), ParameterDirection.Input);
                        insert.Parameters.Add("LOOSE_VOLUME", OracleDbType.Decimal, GetDecimal(stringArray[261]), ParameterDirection.Input);
                        insert.Parameters.Add("LOOSE_LENGTH", OracleDbType.Decimal, GetDecimal(stringArray[262]), ParameterDirection.Input);
                        insert.Parameters.Add("LOOSE_WIDTH", OracleDbType.Decimal, GetDecimal(stringArray[263]), ParameterDirection.Input);
                        insert.Parameters.Add("LOOSE_HEIGHT", OracleDbType.Decimal, GetDecimal(stringArray[264]), ParameterDirection.Input);
                        insert.Parameters.Add("IS_LOT_EXPIRY_DATE_MANDATORY", OracleDbType.Varchar2, GetString(stringArray[265]), ParameterDirection.Input);
                        insert.Parameters.Add("ICT_TRUCK_PTSPER", OracleDbType.Decimal, GetDecimal(stringArray[266]), ParameterDirection.Input);
                        insert.Parameters.Add("SAFETY_STOCK2", OracleDbType.Decimal, GetDecimal(stringArray[267]), ParameterDirection.Input);
                        insert.Parameters.Add("COST_CALC_USER_NAME", OracleDbType.Varchar2, GetString(stringArray[268]), ParameterDirection.Input);
                        insert.Parameters.Add("SHELF_LIFE2", OracleDbType.Decimal, GetDecimal(stringArray[269]), ParameterDirection.Input);
                        insert.Parameters.Add("ICT_AUTO_MRP_ORDER_QTY", OracleDbType.Decimal, GetDecimal(stringArray[270]), ParameterDirection.Input);
                        insert.Parameters.Add("ICT_SHIP_PULL_DEMAND", OracleDbType.Varchar2, GetString(stringArray[271]), ParameterDirection.Input);
                        insert.Parameters.Add("PLT_WRP_USE_QC", OracleDbType.Varchar2, GetString(stringArray[272]), ParameterDirection.Input);
                        insert.Parameters.Add("PLT_WRP_LOC_ID", OracleDbType.Decimal, GetDecimal(stringArray[273]), ParameterDirection.Input);
                        insert.Parameters.Add("HARD_ALLOC_ROUND_PRECISION", OracleDbType.Decimal, GetDecimal(stringArray[274]), ParameterDirection.Input);
                        insert.Parameters.Add("BACKFLUSH_BY_SERIAL", OracleDbType.Varchar2, GetString(stringArray[275]), ParameterDirection.Input);
                        insert.Parameters.Add("GROUP_CODE", OracleDbType.Varchar2, GetString(stringArray[276]), ParameterDirection.Input);
                        insert.Parameters.Add("PROPRIETARY_EFFECT_DATE", OracleDbType.Date, GetDateTime(stringArray[277]), ParameterDirection.Input);
                        insert.Parameters.Add("PROPRIETARY_DEACTIVE_DATE", OracleDbType.Date, GetDateTime(stringArray[278]), ParameterDirection.Input);
                        insert.Parameters.Add("DEMAND_CHANGE", OracleDbType.Varchar2, GetString(stringArray[279]), ParameterDirection.Input);
                        insert.Parameters.Add("TAX_CLASS_ID", OracleDbType.Decimal, GetDecimal(stringArray[280]), ParameterDirection.Input);
                        insert.Parameters.Add("DISCOUNT_GROUPS_ID", OracleDbType.Decimal, GetDecimal(stringArray[281]), ParameterDirection.Input);
                        insert.Parameters.Add("PHYS_CHAR_VOLUME", OracleDbType.Decimal, GetDecimal(stringArray[282]), ParameterDirection.Input);
                        insert.Parameters.Add("PHANTOM_KIT_USE_COMP_PRICE", OracleDbType.Varchar2, GetString(stringArray[283]), ParameterDirection.Input);
                        insert.Parameters.Add("ASSY1_EXCLUDE_FORECAST_WO", OracleDbType.Varchar2, GetString(stringArray[284]), ParameterDirection.Input);
                        insert.Parameters.Add("LAST_DEMAND_CHANGE", OracleDbType.Date, GetDateTime(stringArray[285]), ParameterDirection.Input);
                        insert.Parameters.Add("ARINVT_RECIPE_ID", OracleDbType.Decimal, GetDecimal(stringArray[286]), ParameterDirection.Input);
                        insert.Parameters.Add("GL_PLUG_VALUE", OracleDbType.Varchar2, GetString(stringArray[287]), ParameterDirection.Input);
                        insert.Parameters.Add("CAROUSEL_TARGET_ID", OracleDbType.Decimal, GetDecimal(stringArray[288]), ParameterDirection.Input);
                        insert.Parameters.Add("CAROUSEL_OPERATOR", OracleDbType.Decimal, GetDecimal(stringArray[289]), ParameterDirection.Input);
                        insert.Parameters.Add("CREATED", OracleDbType.Date, GetDateTime(stringArray[290]), ParameterDirection.Input);
                        insert.Parameters.Add("CREATEDBY", OracleDbType.Varchar2, GetString(stringArray[291]), ParameterDirection.Input);
                        insert.Parameters.Add("CHANGED", OracleDbType.Date, GetDateTime(stringArray[292]), ParameterDirection.Input);
                        insert.Parameters.Add("CHANGEDBY", OracleDbType.Varchar2, GetString(stringArray[293]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_INTRANSIT", OracleDbType.Decimal, GetDecimal(stringArray[294]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_IP_TRANS", OracleDbType.Decimal, GetDecimal(stringArray[295]), ParameterDirection.Input);
                        insert.Parameters.Add("ACCT_ID_IP_TRANS_VAR", OracleDbType.Decimal, GetDecimal(stringArray[296]), ParameterDirection.Input);

                        insert.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                Logger.logMessageOnly(pkgSpec.ServicePartNo + "\n" + newLine.ToString());
                throw;
            }
            //*/
        }

        private static object GetString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return value;
        }
        private static object GetDecimal(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return Decimal.Parse(value);
        }
        private static object GetDateTime(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return DateTime.Parse(value);
        }
    }
}
