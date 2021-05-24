using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;

namespace P39.Course.dotnetCoreLib.Authentications
{
    public class TicketDataFormat : SecureDataFormat<AuthenticationTicket>// IDataSerializer<AuthenticationTicket>//
    {
        public TicketDataFormat(IDataProtector protector)
            : base(TicketSerializer.Default, protector)
        {
        }
    }
}
