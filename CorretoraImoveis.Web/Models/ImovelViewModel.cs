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
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public ImovelViewModel()
        {
            
        }

        public ImovelViewModel(Imovel entity)
        {
            Id = entity.Id;
            Descricao = entity.Descricao;
            Valor = entity.Valor;
            DataCadastro = entity.DataCadastro;
            Ativo = entity.Ativo;
        }
    }
}