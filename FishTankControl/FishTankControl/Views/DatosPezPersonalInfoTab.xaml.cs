using FishTankControl.Models;
using FishTankControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FishTankControl.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatosPezPersonalInfoTab : ContentPage
    {

        DatosPezPersonalInfoTabViewModel viewModel;

        public DatosPezPersonalInfoTab()
        {
            InitializeComponent();
            BindingContext = viewModel = new DatosPezPersonalInfoTabViewModel();
        }
        
        async void AcuariosListView_OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var datoPezPersonal = args.SelectedItem as DatoPezPersonal;
            if (datoPezPersonal == null)
                return;

            await Navigation.PushAsync(new DatoPezPersonalInfoDetailPage(new DatosPezPersonalInfoDetailViewModel(datoPezPersonal)));

            DatosPezPersonalInfoListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.DatosPezPersonal.Count == 0)
                viewModel.LoadDatosPezPersonalCommand.Execute(null);
        }

        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevoDatoPezPersonalInfoPage());
        }

        async private void DatosPezPersonalInfoListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var datoPezPersonal = e.SelectedItem as DatoPezPersonal;
            if (datoPezPersonal == null)
                return;

            await Navigation.PushAsync(new DatoPezPersonalInfoDetailPage(new DatosPezPersonalInfoDetailViewModel(datoPezPersonal)));

            DatosPezPersonalInfoListView.SelectedItem = null;
        }
    }
}
