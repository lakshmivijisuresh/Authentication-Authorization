using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Autth.Demo.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class NameController : ControllerBase
	{
		private readonly IJwtAuthenticationManager jwtAuthenticationManager;

		// GET: api/<NameController>
		public NameController(IJwtAuthenticationManager jwtAuthenticationManager)
		{
			this.jwtAuthenticationManager = jwtAuthenticationManager;
		}
		// GET api/<Name
		[HttpGet]

		public IEnumerable<string> Get()
		{
			return new string[] { "New Jersey", "New York" };

		}

		// GET : api/Name/5
		[HttpGet("{id}", Name = "Get")]
		public string Get(int id)
		{
			return "value";
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public IActionResult Authenticate([FromBody] UserCred userCred)
		{
			var token = jwtAuthenticationManager.Authenticate
			   (userCred.Username, userCred.Password);
			if (token == null)
				return Unauthorized();
			return Ok(token);
		}
	}

	public interface IJwtAuthenticationManager
	{
		object Authenticate(string username, string password);
	}
}