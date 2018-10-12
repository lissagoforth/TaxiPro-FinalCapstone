using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TaxiPro.Services;

namespace TaxiPro.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>Click Here</a>");
        }

        public static Task SendTestCompletionAsync(this IEmailSender emailSender, string email, string fname, string lname, string link)
        {
            return emailSender.SendEmailAsync(email, "Course Completed for " + fname + " " + lname, fname + " " + lname + $"  has completed the TaxiPro Course. For detailed results please follow this link to the student's profiles:  <a href='{HtmlEncoder.Default.Encode(link)}'>Student Profile</a>");
        }
    }
}
