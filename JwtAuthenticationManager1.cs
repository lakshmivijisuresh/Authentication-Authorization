namespace Autth.Demo
{
	public interface IJwtAuthenticationManager
	{
		object Authenticate(string username, string password);
	}
}