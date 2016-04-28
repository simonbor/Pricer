using LandingPage.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LandingPage.TierBll
{
    public class EmailContributorSubmitter : IContributorSubmitter
    {
        private List<string> mailTos;
        public EmailContributorSubmitter(List<string> mailTos)
        {
            this.mailTos = mailTos;
        }

        public async Task SubmitOrder(Contributor contributor, List<Contributor> contributors)
        {
            // If you're using .NET 4, you need to dispose the objects, so write this:
            using (var smtpClient = new SmtpClient())
            {
                foreach (string mailTo in mailTos)
                {
                    using (var mailMessage = BuildMailMessage(mailTo, contributor, contributors))
                    {
                        smtpClient.Send(mailMessage);
                    }
                }
            }
        }

        private MailMessage BuildMailMessage(string mailTo, Contributor contributor, List<Contributor> contributors)
        {
            StringBuilder body = new StringBuilder();
            body.AppendLine("A new contributer has been submitted");
            body.AppendLine("---");
            body.AppendFormat("Contributor Email: {0}\n", contributor.Email);
            body.AppendFormat("Contributor Lang: {0}\n", contributor.Language);
            body.AppendFormat("Total contributors: {0}\n", contributors.Count());

            return new MailMessage(ConfigurationManager.AppSettings["EmailOrderSubmitter.MailTo"],  // From
            mailTo,                                                                                 // To
            "New Contributor submitted!",                                                           // Subject
            body.ToString());                                                                       // Body
        }
    
    }
}