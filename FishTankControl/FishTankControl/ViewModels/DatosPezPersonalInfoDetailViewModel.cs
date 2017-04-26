using FishTankControl.Models;

namespace FishTankControl.ViewModels
{
    public class DatosPezPersonalInfoDetailViewModel : BaseViewModel
    {
        public DatoPezPersonal DatoPezPersonal { get; set; }

        public DatosPezPersonalInfoDetailViewModel(DatoPezPersonal datoPezPersonal = null)
        {
            Title = datoPezPersonal.Nombre;
            DatoPezPersonal = datoPezPersonal;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}