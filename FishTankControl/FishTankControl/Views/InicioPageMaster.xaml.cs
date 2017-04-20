using FishTankControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FishTankControl.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPageMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;

        public InicioPageMaster()
        {
            InitializeComponent();
            BindingContext = new InicioPageMasterViewModel();
        }
                
    }
}
