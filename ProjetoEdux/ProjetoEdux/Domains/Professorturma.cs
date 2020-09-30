using System;
using System.Collections.Generic;

namespace ProjetoEdux.Domains
{
    public partial class Professorturma
    {
        public int IdProfessorTurma { get; set; }
        public string Descricao { get; set; }
        public int? Idusuario { get; set; }
        public int? IdTurma { get; set; }

        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
    }
}
