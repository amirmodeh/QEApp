using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QEApp.Application.Services.Otp
{
    public interface IOtpService
    {
        Task<bool> SendOtpAsync(string mobile, string code);
    }
}
