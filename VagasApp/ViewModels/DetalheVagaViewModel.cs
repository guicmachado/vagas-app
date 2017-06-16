using VagasApp.Models;
using Xamarin.Forms;

namespace VagasApp.ViewModels
{
	public class DetalheVagaViewModel : BaseViewModel
	{
		public Vaga Vaga { get; set; }
		
		public Command ApplyCommand { get; }

		public DetalheVagaViewModel()
		{
			Title = "Detalhe da Vaga";
			ApplyCommand = new Command(ExecuteApplyCommand);
		}

		private async void ExecuteApplyCommand()
		{
			var aplicacaoPage = new AplicacaoPage();
			aplicacaoPage.BindingContext = new AplicacaoViewModel();

			await Application.Current.MainPage.Navigation.PushAsync(aplicacaoPage);
		}
	}
}
