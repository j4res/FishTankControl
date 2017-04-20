namespace FishTankControl.Models
{
    public class Pez : BaseDataObject
    {
        string _nombre= string.Empty;
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        string _genero = string.Empty;
        public string Genero
        {
            get { return _genero; }
            set { SetProperty(ref _genero, value); }
        }

        string _especie = string.Empty;
        public string Especie
        {
            get { return _especie; }
            set { SetProperty(ref _especie, value); }
        }

        string _descripcion = string.Empty;
        public string Descripcion
        {
            get { return _descripcion; }
            set { SetProperty(ref _descripcion, value); }
        }
    }
}
