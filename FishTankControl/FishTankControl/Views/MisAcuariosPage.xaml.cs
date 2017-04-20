using FishTankControl.Models;
using FishTankControl.ViewModels;
using System;

using Xamarin.Forms;

namespace FishTankControl.Views
{
    public partial class MisAcuariosPage : ContentPage
    {

        MisAcuariosViewModel viewModel;

        public MisAcuariosPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MisAcuariosViewModel();
            
        }

        async void AcuariosListView_OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var acuario = args.SelectedItem as Acuario;
            if (acuario == null)
                return;

            await Navigation.PushAsync(new AcuarioDetailPage(new MisAcuariosDetailViewModel(acuario)));

            AcuariosListView.SelectedItem = null;
        }
                
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Acuarios.Count == 0)
                viewModel.LoadAcuariosCommand.Execute(null);
        }

        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevoAcuarioPage());
        }
    }
}
