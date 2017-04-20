using FishTankControl.Models;

namespace FishTankControl.ViewModels
{
    public class MisAcuariosDetailViewModel : BaseViewModel
    {
        public Acuario Acuario { get; set; }
        public MisAcuariosDetailViewModel(Acuario acuario = null)
        {
            Title = acuario.Text;
            Acuario = acuario;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}