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
    public partial class InicioPage : MasterDetailPage
    {

        private BuscarPecesPage _buscarPecesPage;
        private MisAcuariosPage _misAcuarioPage;
        private ConfiguracionPage _configuracionPage;
        private AyudaPage _ayudaPage;
        private AcercaDePage _acercaDePage;

        public InicioPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as InicioPageMenuItem;
            if (item == null)
                return;

            switch (item.Id)
            {
                case 0:
                    Detail = new BuscarPecesPage();
                    break;
                case 1:
                    Detail = new MisAcuariosPage();
                    break;
                case 2:
                    Detail = new ConfiguracionPage();
                    break;
                case 3:
                    Detail = new AyudaPage();
                    break;
                case 4:
                    Detail = new AcercaDePage();
                    break;
            }

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;
            //Detail = new NavigationPage(page);

            MasterPage.ListView.SelectedItem = null;
            IsPresented = false;

        }
    }

}
