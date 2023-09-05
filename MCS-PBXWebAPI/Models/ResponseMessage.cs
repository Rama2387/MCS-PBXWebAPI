namespace MCS_PBXWebAPI.Models
{
    public class ResponseMessage
    {
        public SunWebClaimHdr ttWebClaimHdr { get; set; }
        public sunClaimHdrCodesData ttwebClaimHdrCodes { get; set; }
        public List<SunClaimDetailMap> ttClaimDtlMap { get; set; }

    }

    public class sunClaimHdrCodesData
    {
        public string ttchControlNumber { get; set; }
        public int ttintCdCount { get; set; }
        public string ttchCdType { get; set; }
        public string ttchCdCode { get; set; }
        public string ttchCdDesc { get; set; }
        public string ttchCdQualifier { get; set; }
        public string ttchCdPOA { get; set; }
    }
  
    public class SunClaimDetailMap
    {
        public string ttmcsMCHLineNum { get; set; }
        public string ttmcsMCHDiagCode { get; set; }
        public string ttmcsMCHProcCode { get; set; }
        public string ttmcsMCSCharge { get; set; }
        public string ttmcsMCSAllowed { get; set; }
        public string ttmcsMCSCoInsurance { get; set; }
        public string ttmcsMCSCoPay { get; set; }
        public string ttmcsMCSStatus { get; set; }
    }
  
    public class SunWebClaimHdr
    {
        public string ttchMCS { get; set; }
        public decimal ttdecadjustmentamount { get; set; }
        public string ttdadjustmentdate { get; set; }
        public string ttchbatch { get; set; }
        public string ttchclaimNote { get; set; }
        public string ttchclaimType { get; set; }
        public string ttchclaimSubType { get; set; }
        public string ttchclaimNumber { get; set; }
        public string ttdcreateDate { get; set; }
        public string ttdchcreateUser { get; set; }
        public string ttdchStatus { get; set; }

    }
}
