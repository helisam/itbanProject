﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Dtos
{
    public class ProjetoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public string Categoria { get; set; }
    }
}