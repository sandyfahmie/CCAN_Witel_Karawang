using System.Web;
using System.Web.Mvc;

namespace CCAN_Witel_Karawang
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
