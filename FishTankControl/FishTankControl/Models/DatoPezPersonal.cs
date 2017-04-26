using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTankControl.Models
{
    public class DatoPezPersonal : BaseDataObject
    {
        string _id = string.Empty;
        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        string _nombre = string.Empty;
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        string _descripcion = string.Empty;
        public string Descripcion
        {
            get { return _descripcion; }
            set { SetProperty(ref _descripcion, value); }
        }
    }
}
