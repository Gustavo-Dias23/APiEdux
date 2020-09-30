using System;
using System.Collections.Generic;

namespace ProjetoEdux.Domains
{
    public partial class Alunoturma
    {
        public Alunoturma()
        {
            Objetivoaluno = new HashSet<Objetivoaluno>();
        }

        public int IdAlunoTurma { get; set; }
        public string Matricula { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTurma { get; set; }

        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Objetivoaluno> Objetivoaluno { get; set; }
    }
}
