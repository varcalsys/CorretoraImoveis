using System;
using System.Collections.Generic;

namespace CorretoraImoveis.Domain.Entities
{
    public class Foto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UrlFoto { get; set; }
        public string UrlThumb { get; set; }
        public int ImovelId { get; set; }
        public virtual Imovel Imovel { get; set; }

    }
}
