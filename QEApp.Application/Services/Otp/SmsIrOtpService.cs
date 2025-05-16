using Microsoft.Extensions.Configuration;
using SmsIrRestfulNetCore;

namespace QEApp.Application.Services.Otp
{
    public class SmsIrOtpService : IOtpService
    {
        private readonly IConfiguration _configuration;
        public SmsIrOtpService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<bool> SendOtpAsync(long mobile, string code)
        {
            var apiKey = _configuration["SmsIr:ApiKey"];
            var secretKey = _configuration["SmsIr:SecretKey"];
            var lineNumber = _configuration["SmsIr:LineNumber"];
            var templateId = int.Parse(_configuration["SmsIr:TemplateId"]);

            var token = new Token().GetToken(apiKey, secretKey);
            if (string.IsNullOrWhiteSpace(token))
                return Task.FromResult(false);

            var restVerificationCode = new UltraFastSend
            {
                Mobile = mobile,
                TemplateId = templateId,
                ParameterArray = new[]
                {
                    new UltraFastParameters
                    {
                        Parameter = "Code",
                        ParameterValue = code
                    }
                 }
            };

            var result = new UltraFast().Send(token, restVerificationCode);
            return Task.FromResult(result?.IsSuccessful ?? false);
        }

    }
}
