using VagasApp.Services;
using VagasApp.ViewModels;
using Xamarin.Forms;

namespace VagasApp
{
	public partial class MainPage : ContentPage
	{
		private readonly IAzureService _azureService;

		public MainPage()
		{
			InitializeComponent();

			_azureService = DependencyService.Get<IAzureService>();

			BtnLogin.Clicked += async (sender, e) => 
			{
				var user = await _azureService.LoginAsync();

				if (user != null)
				{
					var vagaPage = new VagaPage();
					vagaPage.BindingContext = new VagaViewModel();

					Application.Current.MainPage.Navigation.InsertPageBefore(vagaPage, this);
					await Application.Current.MainPage.Navigation.PopAsync();	
				}
			};
		}
	}
}
