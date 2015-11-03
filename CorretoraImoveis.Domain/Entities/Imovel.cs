using System;
using System.Collections.Generic;

namespace CorretoraImoveis.Domain.Entities
{
    public class Imovel
    {
        public Imovel()
        {
            DataRecord = DateTime.Now;
            Active = true;
            Fotos = new List<Foto>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public int Bathrooms { get; set; }
        public int Bedrooms { get; set; }
        public int Area { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public DateTime DataRecord { get; set; }
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
        public string Image { get; set; }

        public virtual ICollection<Foto> Fotos { get; set; }


        
    }
}
