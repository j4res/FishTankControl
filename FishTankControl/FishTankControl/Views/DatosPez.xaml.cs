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
    public partial class DatosPez : TabbedPage
    {

        public Pez Pez { get; set; }

        public DatosPez(string IdPez)
        {
            InitializeComponent();

            Pez = new Pez
            {
                Genero = "paracheirodon",
                Especie = "innesi"
            };

            //Children.Add(new DatosPezBasicInfoTab(IdPez));
            //Children.Add(new DatosPezPersonalInfoTab(IdPez));

            BindingContext = this;
            this.Title = Pez.Genero.ToUpper() +" "+Pez.Especie.ToUpper();

        }

       
    }
}
