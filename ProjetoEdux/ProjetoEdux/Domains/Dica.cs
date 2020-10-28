using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEdux.Domains
{
    public class Dica
    {
        public Dica()
        {
            Curtida = new HashSet<Curtida>();
        }

        public int IdDica { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        public int? IdUsuario { get; set; }

        [NotMapped]
        [JsonIgnore]
        public static IFormFile imagem123 { get; set; }

        public static string URLImagem {get; set;}

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Curtida> Curtida { get; set; }
    }
}
