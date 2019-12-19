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
using SendGrid.Helpers.Mail;

namespace TMX.Web.Services
{
  public class MessagingService : BaseService
  {
    public async Task SendConfirmationEmail(SendConfirmationEmailRequest model) //****guide
    {
      try
      {
        //SendGridMessage myMessage = new SendGridMessage();
        //myMessage.AddTo(model.Email);
        //myMessage.From = new EmailAddress("themarketx@gmail.com", "TMX Team");
        //myMessage.Subject = "Please Confirm Email";


        MailMessage myMessage = new MailMessage();
        myMessage.To.Add(model.Email);
        myMessage.From = new MailAddress("themarketx@gmail.com", "TMX Team");
        myMessage.Subject = "Please Confirm Email";

        string path = HttpContext.Current.Server.MapPath("~/Templates/ConfirmEmail.html");
        string contents = File.ReadAllText(path);
        contents = contents.Replace("{{domain}}", "http://lms.dev/confirm/" + model.Token.ToString());
        contents = contents.Replace("<%body%>", "Please Confirm Email");

        myMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(contents, null, MediaTypeNames.Text.Html));

        await SendAsync(myMessage);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private async Task SendAsync(MailMessage message)
    {
      // Init SmtpClient and send
      SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
      NetworkCredential credentials = new NetworkCredential("h2rnng@yahoo.com", "CPIpass1!");
      smtpClient.Credentials = credentials;
      await smtpClient.SendMailAsync(message);
    }
  }
}