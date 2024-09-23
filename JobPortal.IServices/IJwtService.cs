using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IJwtService
    {
        (string accessToken, string refreshToken) GenerateTokens(string emailAddress);
    }
}
