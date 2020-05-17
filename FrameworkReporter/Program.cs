using System.Configuration;
using System.Diagnostics;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace FrameworkReporter
{
    class Program
    {
        static void Main(string[] args)
        {
            // TLS 1.2 is not enabled by default in .NET Framework 4.5.2 and is required by the Twilio API.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var appSettings = ConfigurationManager.AppSettings;

            TwilioClient.Init(appSettings["TWILIO_ACCOUNT_SID"], appSettings["TWILIO_AUTH_TOKEN"]);

            //Use your registered phone number to test with a Twilio trial account.
            var recipient = new PhoneNumber("+8005551212"); 

            var message = MessageResource.Create(
                to: recipient,
                from: new PhoneNumber(appSettings["TWILIO_SMS_PHONE_NUMBER"]),
                body: "This runs on .NET Framework 4.5.2");
            Debug.WriteLine(message.ToString());
        }
    }
}
