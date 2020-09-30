using System;
using System.Collections.Generic;

namespace ProjetoEdux.Domains
{
    public partial class Turma
    {
        public Turma()
        {
            Alunoturma = new HashSet<Alunoturma>();
            Professorturma = new HashSet<Professorturma>();
        }

        public int IdTurma { get; set; }
        public string Descricao { get; set; }
        public int? IdCurso { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual ICollection<Alunoturma> Alunoturma { get; set; }
        public virtual ICollection<Professorturma> Professorturma { get; set; }
    }
}
