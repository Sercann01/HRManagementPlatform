using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Concrete.SendMailService
{
    public class SendMailService
    {
        public static bool SendMail(string userMailAddress,string password )
        {

            MailMessage msg = new MailMessage();
            msg.To.Add(userMailAddress);
            msg.Subject = "Hr Management Activasyon Maili";
            msg.IsBodyHtml = true;
            msg.Body = string.Format($"<h1 style='font-size:28px;font-weight:300;line-height:150%;margin:0;text-align:center;color:black;background-color:inherit'>Merhabalar</h1>Değerli kullanıcımız  Şifreniz değiştirilmiştir.<br/> Şifreniz {password}");

            msg.From = new MailAddress("redteamproject@outlook.com");

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("redteamproject@outlook.com", "123toci123");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;


            try
            {
                smtp.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
