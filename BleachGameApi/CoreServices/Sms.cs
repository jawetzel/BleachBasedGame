using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CoreServices
{
    public static class Sms
    {
        public static bool SendSms(string number, string body)
        {
            const string accountSid = "ACc99a3c101d2bb9846bcf0ff2be77644b";
            const string authToken = "d399de8fdf2a9420ba7d813fe1319054";

            TwilioClient.Init(accountSid, authToken);
            
            MessageResource.Create(
                from: new PhoneNumber("225-361-8457"),
                to: new PhoneNumber(number), // +12345678901
                body: body);

            return true;
        }
    }
}
