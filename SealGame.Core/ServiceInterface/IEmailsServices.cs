using System;
using SealGame.Core.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealGame.Core.ServiceInterface
{
    public interface IEmailsServices
    {
        void SendEmail(EmailDto dto);
        void SendEmailToken(EmailTokenDto dto, string token);
    }
}
