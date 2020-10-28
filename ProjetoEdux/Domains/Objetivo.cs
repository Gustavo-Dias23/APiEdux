using System;
using System.Collections.Generic;

namespace ProjetoEdux.Domains
{
    public partial class Objetivo
    {
        public Objetivo()
        {
            Objetivoaluno = new HashSet<Objetivoaluno>();
        }

        public int IdObjetivo { get; set; }
        public string Descricao { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<Objetivoaluno> Objetivoaluno { get; set; }
    }
}
