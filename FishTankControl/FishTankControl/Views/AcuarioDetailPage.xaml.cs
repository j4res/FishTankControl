using FishTankControl.ViewModels;

using Xamarin.Forms;

namespace FishTankControl.Views
{
    public partial class AcuarioDetailPage : ContentPage
    {
        MisAcuariosDetailViewModel viewModel;
        
        public AcuarioDetailPage()
        {
            InitializeComponent();
        }

        public AcuarioDetailPage(MisAcuariosDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async private void Editar_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new EditarAcuarioPage(new MisAcuariosDetailViewModel(this.viewModel.Acuario)));
        }
    }
    
}
