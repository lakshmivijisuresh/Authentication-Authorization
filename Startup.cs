using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autth.Demo.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Autth.Demo

{
	public class startup
	{
		public startup(IConfiguration configuration)
		{
			configuration = configuration;
		}
		public IConfiguration Configuration { get; }
		public bool ValidateIssuer { get; private set; }

		public bool GetValidateIssuer()
		{
			return ValidateIssuer;
		}

		//This method gets called by the runtime. Use this method to add services to the container

		public void ConfigureServices(IServiceCollection services, bool validateIssuer)
		{
			services.AddControllers();
			var key = "This is my test key";

			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(x =>
			{
			x.RequireHttpsMetadata = false;
			x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                   ValidateIssuer = false,
				   ValidateAudience = false
				};

			});
			services.AddSingleton<IJwtAuthenticationManager>(new IJwtAuthenticationManager(key));
		}

		// This method gets called by thr runtime. Use this method to configure the HTTP request
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}