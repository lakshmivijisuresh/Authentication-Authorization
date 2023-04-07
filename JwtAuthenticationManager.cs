namespace Autth.Demo
{
	internal class IJwtAuthenticationManager
	{
		private string key;

		public IJwtAuthenticationManager(string key)
		{
			this.key = key;
		}
	}
}