using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using VagasApp.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(VagasApp.Services.AzureServiceMock))]
namespace VagasApp.Services
{
	public class AzureServiceMock : IAzureService
	{
		private readonly List<Vaga> _vagas = new List<Vaga>
		{
			new Vaga
			{
				Codigo = 1,
				Titulo = "Arquiteto Sr",
				Local = "Santos",
				Empresa = "XY Consultoria",
				FormaContratacao = "PJ",
				Data = "03/06/2017",
				Cargo = new Cargo
				{
					Codigo = 1,
					Descricao = "Arquiteto"
				},
				Descricao = "Experiencia em ..."
			},

			new Vaga
			{
				Codigo = 2,
				Titulo = "Programador Jr",
				Local = "Barueri",
				Empresa = "AB Solutions",
				FormaContratacao = "CLT",
				Data = "03/06/2017",
				Cargo = new Cargo
				{
					Codigo = 2,
					Descricao = "Programador"
				},
				Descricao = "Conhecimento em ..."
			}
		};

		public Task<List<Cargo>> GetCargoAsync()
		{
			return Task.FromResult(_vagas.GroupBy(c => c.Cargo.Codigo).Select(g => g.First().Cargo).ToList());
		}

		public Task<List<Vaga>> GetVagaAsync()
		{
			return Task.FromResult(_vagas);
		}

		public Task<List<Vaga>> GetVagaByCargoCodigoAsync(int cargoCodigo)
		{
			return Task.FromResult(_vagas.Where(c => c.Cargo.Codigo.Equals(cargoCodigo)).ToList());
		}

		public Task<MobileServiceUser> LoginAsync()
		{
			return Task.FromResult(new MobileServiceUser("teste"));
		}
	}
}
