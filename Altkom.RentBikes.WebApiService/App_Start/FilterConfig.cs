using System.Web;
using System.Web.Mvc;

namespace Altkom.RentBikes.WebApiService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
