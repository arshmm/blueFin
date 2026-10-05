using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace backend.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user?.Claims?.SingleOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value ?? string.Empty;
        }
    }
}
