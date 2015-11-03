using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Antlr.Runtime.Misc;

namespace CorretoraImoveis.Web.Areas.Admin.Models
{
    public class ImovelViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Bathrooms { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Bedrooms { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Area { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public DateTime DateRecord { get; set; }
        public bool Garage { get; set; }
        public bool SecuritySystem { get; set; }
        public bool AirConditioning { get; set; }
        public bool Balcony { get; set; }
        public bool OutdoorPool { get; set; }
        public bool Internet { get; set; }
        public bool Heating { get; set; }
        public bool TvCable { get; set; }
        public bool Garden { get; set; }
        public bool Telephone { get; set; }
        public bool FirePlace { get; set; }
        public bool Active { get; set; }
        [Required(ErrorMessage = "Obrigatório no minimo 1 imagem")]
        public HttpPostedFileBase[] Images { get; set; }
        List<string> UrlFotos { get; set; }
        private List<string> UrlThumbs { get; set; }

        public ImovelViewModel()
        {
            UrlFotos = new List<string>();
            UrlThumbs = new List<string>();
        }
    }
}