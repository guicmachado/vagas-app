using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VagasApp.Models;
using VagasApp.Services;
using Xamarin.Forms;

namespace VagasApp.ViewModels
{
	public class VagaViewModel : BaseViewModel
	{
		private readonly IAzureService _azureService;

		public int SelectedIndexCargo { get; set; }

		public Vaga SelectedItemVaga { get; set; }

		public ObservableCollection<Cargo> Cargos { get; }

		public ObservableCollection<Vaga> Vagas { get; }

		public Command<int> LoadVagasCommand { get; }

		public Command<Vaga> ShowDetalheVagaCommand { get; }

		public VagaViewModel()
		{
			_azureService = DependencyService.Get<IAzureService>();
			Title = "Vagas";
			Cargos = new ObservableCollection<Cargo>();
			Vagas = new ObservableCollection<Vaga>();
			LoadVagasCommand = new Command<int>(ExecuteLoadVagasCommand);
			ShowDetalheVagaCommand = new Command<Vaga>(ExecuteShowDetalheVagaCommand);
		}

		public override async Task LoadAsync()
		{
			Cargos.Clear();
			Vagas.Clear();

			var listaCargos = await _azureService.GetCargoAsync();

			if (listaCargos != null)
			{
				foreach (var cargo in listaCargos)
				{
					Cargos.Add(cargo);
				}	
			}
		}

		private async void ExecuteLoadVagasCommand(int cargoSelecionado)
		{
			Vagas.Clear();

			var cargo = Cargos[cargoSelecionado];

			var listaVagas = await _azureService.GetVagaByCargoCodigoAsync(cargo.Codigo);

			if (listaVagas != null)
			{
				foreach (var vaga in listaVagas)
				{
					Vagas.Add(vaga);
				}
			}
		}

		private async void ExecuteShowDetalheVagaCommand(Vaga vaga)
		{
			var detalheVagaPage = new DetalheVagaPage();
			var detalheVagaViewModel = new DetalheVagaViewModel();
			detalheVagaViewModel.Vaga = vaga;
			detalheVagaPage.BindingContext = detalheVagaViewModel;

			await Application.Current.MainPage.Navigation.PushAsync(detalheVagaPage);
		}
	}
}
