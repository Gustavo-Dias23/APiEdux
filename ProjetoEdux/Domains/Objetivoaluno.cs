using System;
using System.Collections.Generic;

namespace ProjetoEdux.Domains
{
    public partial class Objetivoaluno
    {
        public int IdObjetivoAluno { get; set; }
        public decimal? Nota { get; set; }
        public DateTime? DataAlcancado { get; set; }
        public int? IdAlunoTurma { get; set; }
        public int? IdObjetivo { get; set; }

        public virtual Alunoturma IdAlunoTurmaNavigation { get; set; }
        public virtual Objetivo IdObjetivoNavigation { get; set; }
    }
}
