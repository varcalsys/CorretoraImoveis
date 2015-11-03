using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorretoraImoveis.Web.Models
{
    public class FiltroViewModel
    {
        public string Ville { get; set; }
        public int Bedrooms { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}