namespace MCS_PBXWebAPI.Models
{
    public class PBXMessage
    {
        public List<ttPBXMessTopCls> ttPBXMessTop { get; set; }
        public List<ttPBXMessSendDataCls> ttPBXMessSendData { get; set; }
        public ttPBXMessReturnDataCls ttPBXMessReturnData { get; set; }
        public List<ttPBXMessEndCls> ttPBXMessEnd { get; set; }

    }

    public class ttPBXMessTopCls
    {
        public string ttchSunSiteID { get; set; }
        public string ttchSunMessVersion { get; set; }
        public string ttchSunMode { get; set; }
        public string ttchSunModeData { get; set; }
        public string ttchSunDirection { get; set; }
        public string ttchSunMessStage { get; set; }
        public string ttchSunMessStatus { get; set; }

        public List<string> ttchSunDataMode { get; set; }
    }

    public class ttPBXMessSendDataCls
    {
        public int ttdecSunSendPrntRecID { get; set; }
        public int ttdecSunSendMyRecID { get; set; }
        public string ttchSunSendLabel { get; set; }
        public string ttchSunSendValue { get; set; }
        public string ttchSunSendExtra1 { get; set; }
        public string ttchSunSendExtra2 { get; set; }

    }

    public class ttPBXMessReturnDataCls
    {
        public SunWebClaimHdr ttWebClaimHdr { get; set; }
        public sunClaimHdrCodesData ttwebClaimHdrCodes { get; set; }
        public List<SunClaimDetailMap> ttClaimDtlMap { get; set; }

        //public string ttchMCS { get; set; }
        //public decimal ttdecadjustmentamount { get; set; }
        //public string ttdadjustmentdate { get; set; }
        //public string ttchbatch { get; set; }
        //public string ttchclaimNote { get; set; }
        //public string ttchclaimType { get; set; }
        //public string ttchclaimSubType { get; set; }
        //public string ttchclaimNumber { get; set; }
        //public string ttdcreateDate { get; set; }
        //public string ttdchcreateUser { get; set; }
        //public string ttdchStatus { get; set; }

        //public sunClaimHdrCodesData ttwebClaimHdrCodes { get; set; }
        //public List<SunClaimDetailMap> ttClaimDtlMap { get; set; }





        //public decimal? ttdecSunRtnPrntRecID { get; set; }
        //public decimal? ttdecSunRtnMyRecID { get; set; }

        //public string ttchSunRtnLabel { get; set; }
        //public string ttchSunRtnValue { get; set; }
        //public string ttchSunRtnExtra1 { get; set; }
        //public string ttchSunRtnExtra2 { get; set; }

        ////claim
        //public string ttchSunRtnClaimDetail1 { get; set; }
        //public string ttchSunRtnClaimDetail2 { get; set; }
        //public List<ClaimsHeader> lstClaimsHeader { get; set; }

        ////member
        //public string ttchSunRtnMemberDetail1 { get; set; }
        //public string ttchSunRtnMemberDetail2 { get; set; }

    }

    public class ttPBXMessEndCls
    {
        public string ttchSunErrorNum { get; set; }
        public string ttchSunRtnMessage { get; set; }
        public bool ttlogRanOnServer1 { get; set; }
        public bool ttlogRanOnServer2 { get; set; }

    }

    public class ClaimsHeader
    {
        public int CLAIMID { get; set; }
        public int CLAIMNUMBER { get; set; }
        public string SERVDATE { get; set; }
        public int MEMBERID { get; set; }
        public int GROUPID { get; set; }
        public int PROVIDERID { get; set; }
        public int ADJUSTMENTID { get; set; }
        public string DIAG1 { get; set; }
        public string DIAG2 { get; set; }
        public string DIAG3 { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
}
