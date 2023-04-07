//using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using System.Security.Claims;

namespace Autth.Demo
{
	internal class SecurityTokenDescriptor
	{
		public ClaimsIdentity Subject { get; set; }
		public DateTime Expires { get; set; }
		public SigningCredentials SigningCredentials { get; set; }
	}
}