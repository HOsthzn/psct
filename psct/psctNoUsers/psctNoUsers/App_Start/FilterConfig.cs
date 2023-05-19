using System.Web.Mvc;

namespace psct
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters( GlobalFilterCollection filters )
        {
            filters.Add( new HandleErrorAttribute( ) );
            filters.Add( new RequireHttpsAttribute( ) );
        }
    }
}