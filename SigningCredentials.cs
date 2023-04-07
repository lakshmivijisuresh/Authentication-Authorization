//using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
namespace Autth.Demo
{
	internal class SigningCredentials
	{
		private SymmetricSecurityKey symmetricSecurity;
		private object hmacSha256Signature;

		public SigningCredentials(SymmetricSecurityKey symmetricSecurity, object hmacSha256Signature)
		{
			this.symmetricSecurity = symmetricSecurity;
			this.hmacSha256Signature = hmacSha256Signature;
		}
	}
}