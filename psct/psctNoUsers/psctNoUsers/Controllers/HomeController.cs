using psct.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace psct.Controllers;

public class HomeController : Controller
{
    [ HtmlgZip ]
    public ActionResult Index( )
    {
        string resources = Server.MapPath( "~/Content/resources/" );

        //get all file names in the resources folder
        IEnumerable< string > files = Directory.EnumerateFiles( resources )
                                               .Select( Path.GetFileName );

        //split the files into groups of 2
        ViewBag.imgGroups = files.Select( ( x, i ) => new { Index = i, Value = x } )
                                 .GroupBy( x => x.Index / 2 )
                                 .Select( x => x.Select( v => v.Value ) );

        return View( );
    }

    public ActionResult Download( )
    {
        string file = Server.MapPath( "~/Files/Projected SHE Profile.pdf" );

        if ( System.IO.File.Exists( file ) )
            return File( file, "application/pdf", "Projected SHE.pdf" );
        else
            return RedirectToAction( "Index" );
    }

    [ HttpPost ]
    public ActionResult ContactForm( string name, string email, string message )
    {
        using ( SmtpClient client = new( ) )
        {
            // Configure the SMTP client with your email server settings
            client.Host        = "mail.psct.co.za";
            client.Port        = 465;
            client.EnableSsl   = true;
            client.Credentials = new NetworkCredential( "info@psct.co.za", "Wp{KqhecC&A]" );

            // Create the email message
            MailMessage mailMessage = new( );
            mailMessage.From = new MailAddress( "info@psct.co.za" );
            mailMessage.To.Add( "info@psct.co.za" );
            mailMessage.Subject = "Client contact from webSite";
            mailMessage.Body    = $"Name: {name}\nEmail: {email}\nMessage: {message}";

            // Send the email
            client.Send( mailMessage );
        }
        
        return RedirectToAction( "Index" );
    }
}