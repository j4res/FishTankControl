namespace FishTankControl.Models
{
    public class Acuario : BaseDataObject
    {

        string _id = string.Empty;
        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        string _text = string.Empty;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
    }
}
