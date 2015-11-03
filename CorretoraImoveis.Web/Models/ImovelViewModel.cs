using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorretoraImoveis.Domain.Entities;

namespace CorretoraImoveis.Web.Models
{
    public class ImovelViewModel
    {
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
        public string Image { get; set; }
        public ICollection<Foto> Photos { get; set; }

        public ImovelViewModel()
        {
         
            Photos = new List<Foto>();
        }

        public ImovelViewModel(Imovel entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Description = entity.Description;
            Type = entity.Type;
            Price = entity.Price;
            Address = entity.Address;
            Bathrooms = entity.Bathrooms;
            Bedrooms = entity.Bedrooms;
            Area = entity.Area;
            Lat = entity.Lat;
            Lng = entity.Lng;
            Garage = entity.Garage;
            SecuritySystem = entity.SecuritySystem;
            AirConditioning = entity.AirConditioning;
            Balcony = entity.Balcony;
            OutdoorPool = entity.OutdoorPool;
            Internet = entity.Internet;
            Heating = entity.Heating;
            TvCable = entity.TvCable;
            Garden = entity.Garden;
            Telephone = entity.Telephone;
            FirePlace = entity.FirePlace;
            Image = entity.Image;
            Photos = entity.Fotos;
        }
    }
}