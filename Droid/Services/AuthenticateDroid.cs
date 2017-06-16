using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using VagasApp.Droid.Services;
using VagasApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateDroid))]
namespace VagasApp.Droid.Services
{
	public class AuthenticateDroid : IAuthenticate
	{
		public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
		{
			try
			{
				return await client.LoginAsync(Xamarin.Forms.Forms.Context, provider);
			}
			catch (Exception ex)
			{
				return null;
			}

		}
	}
}
