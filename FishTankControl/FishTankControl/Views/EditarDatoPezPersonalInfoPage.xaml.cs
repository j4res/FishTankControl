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
    public partial class EditarDatoPezPersonalInfoPage : ContentPage
    {

        DatosPezPersonalInfoDetailViewModel viewModel;

        public EditarDatoPezPersonalInfoPage(DatosPezPersonalInfoDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        
        async void Guardar_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "NuevoDatoPezPersonal", this.viewModel.DatoPezPersonal);
            await Navigation.PopAsync();
        }

    }
}
