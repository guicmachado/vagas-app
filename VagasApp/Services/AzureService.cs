using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using VagasApp.Models;
using Xamarin.Forms;

//[assembly: Dependency(typeof(VagasApp.Services.AzureService))]
namespace VagasApp.Services
{
	public class AzureService : IAzureService
	{
		static readonly string AppUrl = "";

		public MobileServiceClient Client { get; set; } = null;

		private readonly HttpClient _httpClient;

		public AzureService()
		{
			Client = new MobileServiceClient(AppUrl);
			_httpClient = new HttpClient();
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			_httpClient.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
		}

		public async Task<MobileServiceUser> LoginAsync()
		{
			var auth = DependencyService.Get<IAuthenticate>();
			var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

			if (user == null)
			{
				Device.BeginInvokeOnMainThread(async () => 
				{
					await App.Current.MainPage.DisplayAlert("Ops!", "Não conseguimos efetuar o seu login, tente novamente!", "OK");
				});
				return null;
			}
			return user;
		}

		public async Task<List<Cargo>> GetCargoAsync()
		{
			var response = await _httpClient.GetAsync($"{AppUrl}/api/cargos").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Cargo>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
		}

		public async Task<List<Vaga>> GetVagaAsync()
		{
			var response = await _httpClient.GetAsync($"{AppUrl}/api/vagas").ConfigureAwait(false);

			return await GetVagaResponse(response);
		}

		public async Task<List<Vaga>> GetVagaByCargoCodigoAsync(int cargoCodigo)
		{
			var response = await _httpClient.GetAsync($"{AppUrl}/api/vagas/{cargoCodigo}").ConfigureAwait(false);

			return await GetVagaResponse(response);
		}

		private async Task<List<Vaga>> GetVagaResponse(HttpResponseMessage response)
		{ 
			if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Vaga>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
		}
	}
}
