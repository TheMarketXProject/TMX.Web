using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using TMX.Web.Models.Requests;
using SendGrid;
using System.Configuration;
//using SendGrid.Helpers.Mail;

namespace TMX.Web.Services
{
  public class MessagingService : BaseService
  {
    public async Task SendConfirmationEmail(SendConfirmationEmailRequest model) //****guide
    {
      try
      {
        MailMessage myMessage = new MailMessage();
        myMessage.To.Add(model.Email);
        myMessage.From = new MailAddress("themarketx@gmail.com", "TMX Team");
        myMessage.Subject = "Please Confirm Email";

        string path = HttpContext.Current.Server.MapPath("~/Templates/ConfirmEmail.html");
        string contents = File.ReadAllText(path);
        contents = contents.Replace("{{domain}}", "http://localhost:53203/confirm/" + model.Token.ToString());
        contents = contents.Replace("<%body%>", "Please Confirm Email");

        myMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(contents, null, MediaTypeNames.Text.Html));

        await SendAsync(myMessage);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw new Exception(ex.Message, ex);
      }
    }

    private async Task SendAsync(MailMessage message)
    {
      // Init SmtpClient and send
      SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", 587);
      string apiKey = ConfigurationManager.AppSettings["tmx-sendgrid"];
      NetworkCredential credentials = new NetworkCredential("apikey", apiKey);
      smtpClient.Credentials = credentials;
      await smtpClient.SendMailAsync(message);
    }
  }
}