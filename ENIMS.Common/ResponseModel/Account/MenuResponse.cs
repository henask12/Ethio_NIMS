using System.Collections.Generic;

namespace ENIMS.Common.ResponseModel.Account
{
    public class MenusResponse: OperationStatusResponse
    {
        public List<MenuRes> Menus { get; set; }
        public MenusResponse()
        {
            Menus = new List<MenuRes>();
        }
    }
    public class MenuResponse : OperationStatusResponse
    {
        public MenuRes Menu { get; set; }
    }

    public class MenuRes
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public long? ParentId { get; set; }
        public string Url { get; set; }
        public string Privilages { get; set; }
    }
}
