using FishTankControl.Models;
using System;

using Xamarin.Forms;

namespace FishTankControl.Views
{
    public partial class NuevoAcuarioPage : ContentPage
    {

        public Acuario Acuario { get; set; }

        public NuevoAcuarioPage()
        {
            InitializeComponent();

            Acuario = new Acuario
            {
                Text = "Nuevo Acuario",
                Description = "Descripción del nuevo acuario"
            };

            BindingContext = this;
        }

        async void Guardar_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "NuevoAcuario", Acuario);
            await Navigation.PopToRootAsync();
        }

    }
}
