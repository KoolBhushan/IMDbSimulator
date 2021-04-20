using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDbSimulator.UI.Models
{
    public class SearchMovie
    {
        public List<Search> Search { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }

    }
}
