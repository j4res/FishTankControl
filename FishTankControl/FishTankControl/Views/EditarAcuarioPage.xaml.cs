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
    public partial class EditarAcuarioPage : ContentPage
    {
        
        MisAcuariosDetailViewModel viewModel;

        public EditarAcuarioPage(MisAcuariosDetailViewModel viewModel)
        {
            InitializeComponent();
            
            BindingContext = this.viewModel = viewModel;
        }

        async void Guardar_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "NuevoAcuario", this.viewModel.Acuario);
            await Navigation.PopToRootAsync();
        }
    }
}
