using FishTankControl.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace FishTankControl.ViewModels
{
    public class InicioPageMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<InicioPageMenuItem> MenuItems { get; }
        public InicioPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<InicioPageMenuItem>(new[]
            {
                    new InicioPageMenuItem { Id = 0, Title = "Buscar Peces" },
                    new InicioPageMenuItem { Id = 1, Title = "Mis Acuarios" },
                    new InicioPageMenuItem { Id = 2, Title = "Configuración" },
                    new InicioPageMenuItem { Id = 3, Title = "Ayuda" },
                    new InicioPageMenuItem { Id = 4, Title = "Acerca de" },
                });
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


    }
}