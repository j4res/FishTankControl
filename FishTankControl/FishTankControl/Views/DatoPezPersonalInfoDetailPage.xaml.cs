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
    public partial class DatoPezPersonalInfoDetailPage : ContentPage
    {
        DatosPezPersonalInfoDetailViewModel viewModel;

        public DatoPezPersonalInfoDetailPage()
        {
            InitializeComponent();
        }
        
        public DatoPezPersonalInfoDetailPage(DatosPezPersonalInfoDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async private void Editar_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new EditarDatoPezPersonalInfoPage(new DatosPezPersonalInfoDetailViewModel(this.viewModel.DatoPezPersonal)));
        }
        
    }
}
