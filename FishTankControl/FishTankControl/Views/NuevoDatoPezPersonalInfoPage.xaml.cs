using FishTankControl.Models;
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
    public partial class NuevoDatoPezPersonalInfoPage : ContentPage
    {

        public DatoPezPersonal DatoPezPersonal { get; set; }

        public NuevoDatoPezPersonalInfoPage()
        {
            InitializeComponent();

            DatoPezPersonal = new DatoPezPersonal
            {
                Nombre = "Nuevo Dato",
                Descripcion = "Descripción del nuevo dato"
            };

            BindingContext = this;
        }
                
        async void Guardar_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "NuevoDatoPezPersonal", DatoPezPersonal);
            await Navigation.PopAsync();
        }
    }
}
