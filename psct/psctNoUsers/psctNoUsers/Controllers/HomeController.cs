using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;

namespace psct.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index( )
        {
            string resources = Server.MapPath( "~/Content/resources/" );

            //get all file names in the resources folder
            IEnumerable<string> files = Directory.EnumerateFiles( resources )
                .Select( Path.GetFileName );

            //split the files into groups of 2
            ViewBag.imgGroups = files.Select( ( x, i ) => new { Index = i, Value = x } )
                .GroupBy( x => x.Index / 2 )
                .Select( x => x.Select( v => v.Value ) );
            
            return View( );
        }
    }
}