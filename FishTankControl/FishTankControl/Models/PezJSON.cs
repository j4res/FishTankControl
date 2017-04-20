using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTankControl.Models
{

    public class Normalized
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class Redirect
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class __invalid_type__169799
    {
        public int pageid { get; set; }
        public int ns { get; set; }
        public string title { get; set; }
        public string extract { get; set; }
    }

    public class Pages
    {
        public __invalid_type__169799 __invalid_name__169799 { get; set; }
    }

    public class Query
    {
        public List<Normalized> normalized { get; set; }
        public List<Redirect> redirects { get; set; }
        public Pages pages { get; set; }
    }

    public class RootObject
    {
        public string batchcomplete { get; set; }
        public Query query { get; set; }
    }
}
