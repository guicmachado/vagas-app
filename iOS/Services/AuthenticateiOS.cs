using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using VagasApp.iOS.Services;
using VagasApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateiOS))]
namespace VagasApp.iOS.Services
{
	public class AuthenticateiOS : IAuthenticate
	{
		public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
		{
			try
			{
				return await client.LoginAsync(UIKit.UIApplication.SharedApplication.KeyWindow.RootViewController, provider);
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
