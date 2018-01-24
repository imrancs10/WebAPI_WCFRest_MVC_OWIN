using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeApi.Provider
{
    public class MyAuthorizationProvider : OAuthAuthorizationServerProvider
    {
        enum UserRole
        {
            User = 1,
            Admin = 2,
            Guest = 3
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // TODO : remove login check seperate login and add that logic to here
            context.OwinContext.Set<string>("role", context.Parameters["role"]);
            context.OwinContext.Set<string>("name", context.Parameters["name"]);
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            string role = context.OwinContext.Environment["role"].ToString();
            string name = context.OwinContext.Environment["name"].ToString();
            if (int.Parse(role) == Convert.ToInt32(UserRole.Admin))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Name, name));
                context.Validated(identity);
            }
            else if (int.Parse(role) == Convert.ToInt32(UserRole.User))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Name, name));
                context.Validated(identity);
            }
            else if (int.Parse(role) == Convert.ToInt32(UserRole.Guest))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "guest"));
                identity.AddClaim(new Claim("username", context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Name, name));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Grant_Error", "Invalid UserName or Password");
                return;
            }
        }
    }
}