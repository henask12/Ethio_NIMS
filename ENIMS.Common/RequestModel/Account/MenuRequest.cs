namespace ENIMS.Common.RequestModel.Account
{
    public class MenuRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public long? ParentId { get; set; }
        public string Privilages { get; set; }
    }
}
