//using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.IdentityModel.Tokens;

namespace Autth.Demo
{
	internal class SymmetricSecurityKey
	{
		private object tokenKey;

		public SymmetricSecurityKey(object tokenKey)
		{
			this.tokenKey = tokenKey;
		}

		public static implicit operator SecurityKey(SymmetricSecurityKey v)
		{
			throw new NotImplementedException();
		}
	}
}