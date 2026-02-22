using Hangfire;
using KwikNesta.Shared.Contracts;
using KwikNesta.Shared.Models.Enumerations;

namespace KwikNesta.Shared.Implementations
{
    public class Notifications
    {
        public static void SendEmail(string to, 
                                    string subject, 
                                    string message)
        {
            BackgroundJob.Enqueue<INotificationService>(x => x.SendEmailAsync(to, subject, message, message));
        }

        public static void SendEmail(string to, 
                                    string subject, 
                                    string message, 
                                    byte[] fileBytes, 
                                    string fileName, 
                                    EContentTypes contentType)
        {
            BackgroundJob.Enqueue<INotificationService>(x => x.SendEmailAsync(to, subject, message, message, fileBytes, fileName, contentType));
        }
    }
}
