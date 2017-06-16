using System.Threading.Tasks;
using Xamarin.Forms;

namespace VagasApp.ViewModels
{
	public class AplicacaoViewModel : BaseViewModel
	{
		private string _nome;
		public string Nome
		{
			get { return _nome; }
			set { SetProperty(ref _nome, value); }
		}

		private string _email;
		public string Email
		{
			get { return _email; }
			set { SetProperty(ref _email, value); }
		}

		private string _telefone;
		public string Telefone
		{
			get { return _telefone; }
			set { SetProperty(ref _telefone, value); }
		}

		public string Informacoes { get; set; }

		public Command SendCommand { get; }

		public AplicacaoViewModel()
		{
			Title = "Aplicar";
			SendCommand = new Command(ExecuteSendCommand);
		}

		private async void ExecuteSendCommand()
		{
			await Application.Current.MainPage.DisplayAlert("VagasApp", "Os seus dados estão sendo enviados...", "OK");

			await Application.Current.MainPage.Navigation.PopToRootAsync();
		}

		public override Task LoadAsync()
		{
			Nome = "Guilherme Machado";
			Email = "guilhermecm@gmail.com";
			Telefone = "(11) 98578-5777";

			return base.LoadAsync();
		}
	}
}
