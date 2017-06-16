using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using VagasApp.Models;

namespace VagasApp.Services
{
	public interface IAzureService
	{
		Task<MobileServiceUser> LoginAsync();

		Task<List<Cargo>> GetCargoAsync();

		Task<List<Vaga>> GetVagaAsync();

		Task<List<Vaga>> GetVagaByCargoCodigoAsync(int cargoCodigo);
	}
}
