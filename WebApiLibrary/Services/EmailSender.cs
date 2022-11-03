namespace WebApiLibrary.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string fromAddress,
        string destinationAddress,
        string subject,
        string textMessage);
    }
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string fromAddress,
                                            string destinationAddress,
                                            string subject,
                                            string textMessage)
        {
            //Sending email...
            await Task.CompletedTask;
        }
    }
}