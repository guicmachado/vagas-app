using System.ComponentModel;
using VagasApp.ViewModels;
using Xamarin.Forms;

namespace VagasApp
{
	public abstract class BasePage : ContentPage
	{
		private BaseViewModel ViewModel => BindingContext as BaseViewModel;

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			if (ViewModel == null) return;
			Title = ViewModel.Title;
			ViewModel.PropertyChanged += TitlePropertyChanged;
			await ViewModel.LoadAsync();
		}

		private void TitlePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName != nameof(ViewModel.Title)) return;

			Title = ViewModel.Title;
		}
	}
}
