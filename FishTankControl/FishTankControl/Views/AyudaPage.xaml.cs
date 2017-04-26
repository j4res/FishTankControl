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
    public partial class AyudaPage : ContentPage
    {
        public AyudaPage()
        {
            
            InitializeComponent();

            TextoAyuda.Text = "Utilizar FishTankControl es muy sencillo:\n\n1-) La aplicación cuenta con un menú en la sección izquierda "
                +"donde se enlistan una serie de funcionalidades:\n\nBuscar Peces:\nPermite buscar peces por medio de su nombre científico (género y especie) "
                + "para seleccionarlos y agregarlos a nuestros acuarios.\n\nMis Acuarios:\nPermite observar los acuarios que se han creado en la aplicación. " 
                + "Adicional a esto, podemos agregar nuevos acuarios, editarlos, ingresar en cada uno de ellos para observar qué peces se encuentran " 
                + "asociados a él, y observar el detalle (información) de cada pez.\n\nAyuda:\nEsta es la sección en la que estamos en este momento. " 
                + "Brinda información sobre el uso del app en general.\n\nAcera De:\nMuestra los créditos de la aplicación, así como información " 
                + "de la tecnología utilizada para su desarrollo.\n\n2-) La aplicación permite buscar peces, seleccionarlos y agregarlos a un acuario " 
                + "previamente creado.\n\n3-) Se puede ingresar a cada acuario para observar el detalle y la información que hemos agregado durante su "
                + "creación.\n\n4-) Adicional, podemos ingresar a cada acuario y observar los peces que hemos agregado a cada uno.\n\n5-) Dentro de cada pez, "
                + "es posible observar la información básica del mismo, así como administrar una bitácora con información propia que queramos almacenar.\n";

            BindingContext = this;

        }
    }
}
