using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace VagasApp.Services
{
	public interface IAuthenticate
	{
		Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider);
	}
}
