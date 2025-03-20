using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using HoLWeb.DataLayer.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace HoLWeb.Components.Account
{
    public class FluentEmailSender : IEmailSender<ApplicationUser>
    {
        private readonly IFluentEmail fluentEmailSender;

        public FluentEmailSender(IFluentEmail fluentEmailSender)
        {
            this.fluentEmailSender = fluentEmailSender;
        }


        public async Task SendEmailAsync(string email,string subject,string htmlMessage)
        {
            //ALTERNATIVE WAY TO SEND EMAIL

            //var sender = new SmtpSender(() => new System.Net.Mail.SmtpClient("localhost")
            //{
            //    EnableSsl = false,
            //    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
            //    Port = 25
            //});
            //Email.DefaultSender = sender;
            //Email.DefaultRenderer = new RazorRenderer();

            //var emailToSend = Email
            //    .From("tester@test.com")
            //    .To(email)
            //    .Subject(subject)
            //    .Body(htmlMessage,true);

            //await emailToSend.SendAsync();

            await fluentEmailSender
                .SetFrom("tester@test.com","Test")
                .To(email)
                .Subject(subject)
                .UsingTemplate(htmlMessage,new { })
                //.Header("<h1>Header</h1>",htmlMessage)
                //.Body(htmlMessage)
                .SendAsync();

        }




        public Task SendConfirmationLinkAsync(ApplicationUser user,string email,string confirmationLink) =>
       SendEmailAsync(email,"Confirm your email",$"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");

        public Task SendPasswordResetLinkAsync(ApplicationUser user,string email,string resetLink) =>
            SendEmailAsync(email,"Reset your password",$"Please reset your password by <a href='{resetLink}'>clicking here</a>.");

        public Task SendPasswordResetCodeAsync(ApplicationUser user,string email,string resetCode) =>
            SendEmailAsync(email,"Reset your password",$"Please reset your password using the following code: {resetCode}");
    }
}


