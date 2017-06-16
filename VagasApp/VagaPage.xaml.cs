using System;
using VagasApp.ViewModels;
using Xamarin.Forms;

namespace VagasApp
{
	public partial class VagaPage
	{
		private VagaViewModel ViewModel => BindingContext as VagaViewModel;

		public VagaPage()
		{
			InitializeComponent();
		}

		private void PckCargo_SelectedIndexChanged(object sender, EventArgs e) 
		{
			if (ViewModel.SelectedIndexCargo >= 0)
			{
				ViewModel.LoadVagasCommand.Execute(ViewModel.SelectedIndexCargo);	
			}
		}

		private void ListView_SelectedItem(object sender, EventArgs e)
		{
			ViewModel.ShowDetalheVagaCommand.Execute(ViewModel.SelectedItemVaga);
		}
	}
}
