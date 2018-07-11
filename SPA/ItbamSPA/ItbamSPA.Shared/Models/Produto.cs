using System;
using System.Collections.Generic;

namespace ItbamSPA.Shared.Models
{
    public partial class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public string Categoria { get; set; }
    }
}
