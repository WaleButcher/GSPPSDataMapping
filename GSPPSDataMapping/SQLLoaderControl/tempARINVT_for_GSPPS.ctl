LOAD DATA
INFILE 'D:\SPECSCSV\ARINVT\Loader\tempARINVT_for_GSPPS.csv'
BADFILE 'D:\SPECSCSV\ARINVT\Loader\tempARINVT_for_GSPPS.bad'
DISCARDFILE 'D:\SPECSCSV\ARINVT\Loader\tempARINVT_for_GSPPS.dsc'
INSERT INTO TABLE tempARINVT_for_GSPPS
FIELDS TERMINATED BY "|" TRAILING NULLCOLS
(ID,ARCUSTO_ID,CLASS,ITEMNO,REV,DESCRIP,DESCRIP2,AVG_COST,VENDOR_ID,UNIT,BLEND,CUSER1,CUSER2,CUSER3,NUSER1,NUSER2,NUSER3,BOM_ACTIVE,ONHAND,RG_ONHAND,NON_SALABLE,NON_CONFORM_TOTAL,SERIALIZED,SAFETY_STOCK,MIN_ORDER_QTY,MAX_ORDER_QTY,MULTIPLE,YTDQTY,PTDQTY,CODE,LDATE,LBUY_DATE,TYPE,SERIES,LEAD_DAYS,LEAD_TIME,SPG,DRYTIME,DRYTEMP,RGPRCNT,AUTO_MJO,MFG_QUAN,AUX_AMT,STDQUAN,LOW_LEVEL_CODE,MPS_CODE,ARINVT_FAMILY_ID,BACKFLUSH,DRAWING,ECNO,STD_PRICE,STD_COST,STANDARD_ID,ACCT_ID_SALES,ACCT_ID_INV,MFG_SPLIT,PRICE_PER_1000,COMIS_PRCNT,UNQUE_DATE_IN,SHELF_LIFE,ECODE,EID,EDATE_TIME,ECOPY,ACCT_ID_PPV,ACCT_ID_OH_DISPO,ACCT_ID_LABOR_DISPO,ACCT_ID_HOLDING,ITEM_TYPE_ID,NMFC_ID,VOLUME,AUTO_MRP_REORD_POINT,AUTO_MRP_ORDER_QTY,AUTO_MRP_LEAD_DAYS,EPLANT_ID,COMMISSIONS_ID,STD_COST_CONTROL,PO_SCOPE,PO_SAFETY,PO_MOVE_RANGE,LM_IMAGE_FILENAME,CYCLE_COUNT_CODE,CUSER4,CUSER5,CUSER6,CUSER7,CUSER8,CUSER9,CUSER10,NUSER4,NUSER5,NUSER6,NUSER7,NUSER8,NUSER9,NUSER10,PROCESS_SAFETY_STOCK,MX_GROUP_ID,FR_GROUP_ID,SETUP_CHARGE,MOVE_TIME,CARTONS_PALLET,PIECES_CARTON,AUTO_MRP_FIRM_WO,FLOOR_BACKFLUSH,MPS,CUM_LEADTIME,PHANTOM,CRITICAL_FENCE,USER_NAME,PK_HIDE,ACCT_ID_PRODVAR,PHANTOM_ONHAND,LM_LABELS_ID,DRIVE_PHANTOM_NEGATIVE,NO_STDCOST_RECALC,ACCT_ID_INTPLANT_SALES,IMAGE_FILENAME,NON_ALLOCATE_TOTAL,INSP_RECEIPT_THRES,INSP_RECEIPT_COUNT,COST_STANDARD_ID_FUTURE,COST_STANDARD_ID,COST_DESCRIP_FUTURE,COST_DESCRIP,COST_CALC_DATE_FUTURE,COST_CALC_DATE,AUTO_MRP_INCLUDE_VMI,PROD_CODE_ID,DO_NOT_DISPO_FLOOR_PARTIAL,INFO_SO,INFO_PO,EXCL_RECEIPT_TIME_PPV,CYCLE_COUNT_ID,CYCLE_COUNT_DATE,NON_MATERIAL,MFG_MIN_QTY,MFG_MULTIPLE,BUYER_CODE_ID,COST_CALC_BATCH,INTRASTAT_CODE,FAB_START,MFG_SAFETY_QTY,PLANNER_CODE_ID,IS_LOT_MANDATORY,PK_WEIGHT,PK_PTSPER,DO_NOT_SCHED_FORECAST_WO,IS_PALLET,IS_AUTO_RT_LABELS,IS_LINKED_TO_SERIAL,FR_INCLUDE,MIN_CPK,LBL_ASSIST_LAST_PRINT,LBL_ASSIST_PRINT_INTERVAL,COC_EXCLUDE,ICT_REORD_POINT,ICT_REPLENISH_SCOPE_DAYS,ICT_LEAD_DAYS,ICT_SHIP_TO_ID,AUTO_MRP_KANBAN_LOT_SIZE,ICT_FIRE_TRIGGER,COLOR_GROUP_ID,FR_WO_TIME_FENCE,PK_LENGTH,PK_WIDTH,PK_HEIGHT,PALLET_LENGTH,PALLET_WIDTH,PALLET_HEIGHT,PALLET_VOLUME,PALLET_PTSPER,PALLET_WEIGHT,LENGTH,WIDTH,GAUGE,IS_BY_PRODUCT,EXCLUDE_FROM_COMMISSIONS,AUTO_RT_LABELS_PK_SEQ,PALLET_PATTERN_ID,WEB_SALABLE,PO_MULTIPLE,FIFO_THRESHOLD,COST_STANDARD_ID_FORECAST,COST_STANDARD_ID_BUDGET,COST_DESCRIP_FORECAST,COST_DESCRIP_BUDGET,COST_CALC_DATE_FORECAST,COST_CALC_DATE_BUDGET,KEEP_LABEL_BOM_INTERPLANT_TRAN,ECO_ORIG_CLASS,ACCT_ID_WIP,IRV32_NO_PLAN_WO,INFO_REC,IS_LOT_DATE_MANDATORY,USE_THIS_UOM_FOR_MRP,WAIT_TIME,BOL_CALC_OVERRIDE,RFQ_USE_STD_COST,ACCT_ID_PHYS_VAR,ACCT_ID_INV_COST_REV,EXCLUDE_BACKFLUSH,NONTAXABLE,ACCT_ID_SHIPMENT,AUTO_MRP_EXCLUDE_HARD_ALLOC,MIN_PPK,RUN_RULES,RTPM_TRG_RTLABEL,REBATE_PARAMS_ID,TARIFF_CODE_ID,WEBDIRECT_LEAD_DAYS,USE_COST_DEFAULT_STANDARD_ID,ARINVT_GROUP_ID,CLONED_FROM_ARINVT_ID,USE_LOT_CHARGE,LOT_CHARGE,UNIQUE_DISPO_LOC,HEIJUNKA_SINCE_SCHED_DEMAND,CONFIG_CODE,AUTO_MRP_INCLUDE_VMI_MFG_CALC,FR_WO_SCOPE,AUTO_MRP_APPLY_TO_SCHED_ALLOC,PHANTOM_COMPONENTS_ON_SO,SCHED_CASCADE_PARENT_MTO,AUTO_POP_SERV_CTR,EXCL_MARK_WO_MAT_XCPT,IS_ALC,MARK_ORD_DETAIL_MTO,MSDS_AUTHORABLE,IS_MSDS,MSDS_UPLOAD,NONTAXABLE_PO,OVERRIDE_REC_LOC,IS_DROP_SHIP,MAX_PALLET_STACK,LOOSE_INV_MOVE_CLASS_ID,PACK_INV_MOVE_CLASS_ID,PALLET_INV_MOVE_CLASS_ID,PK_UNIT_TYPE,LOOSE_MOVE_RANK_COUNT,PACK_MOVE_RANK_COUNT,PALLET_MOVE_RANK_COUNT,EXCL_WORKORDER_MAT,FIFO,COMPANY_ID,RECV_LOCATION_ID,SPC_INSPECTION_ID,AR_DISCOUNT_WATERFALL_ID,LBL_LAST_PRINT,EXCL_FROM_CTP_EXCEPTION,WMS_INV_GROUP_ID,CORE_SIZE,OD,PS_CONVERT_INFO,LOOSE_MOVE_RANK_LOCK,PACK_MOVE_RANK_LOCK,PALLET_MOVE_RANK_LOCK,CYCLE_COUNT_RANK_LOCK,MIN_SELL_QTY,INSP_LEAD_DAYS,LOOSE_WEIGHT,LOOSE_VOLUME,LOOSE_LENGTH,LOOSE_WIDTH,LOOSE_HEIGHT,IS_LOT_EXPIRY_DATE_MANDATORY,ICT_TRUCK_PTSPER,SAFETY_STOCK2,COST_CALC_USER_NAME,SHELF_LIFE2,ICT_AUTO_MRP_ORDER_QTY,ICT_SHIP_PULL_DEMAND,PLT_WRP_USE_QC,PLT_WRP_LOC_ID,HARD_ALLOC_ROUND_PRECISION,BACKFLUSH_BY_SERIAL,GROUP_CODE,PROPRIETARY_EFFECT_DATE,PROPRIETARY_DEACTIVE_DATE,DEMAND_CHANGE,TAX_CLASS_ID,DISCOUNT_GROUPS_ID,PHYS_CHAR_VOLUME,PHANTOM_KIT_USE_COMP_PRICE,ASSY1_EXCLUDE_FORECAST_WO,LAST_DEMAND_CHANGE,ARINVT_RECIPE_ID,GL_PLUG_VALUE,CAROUSEL_TARGET_ID,CAROUSEL_OPERATOR,CREATED,CREATEDBY,CHANGED,CHANGEDBY,ACCT_ID_INTRANSIT,ACCT_ID_IP_TRANS,ACCT_ID_IP_TRANS_VAR)