using System;
using System.Collections.Generic;

namespace ProjetoEdux.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Alunoturma = new HashSet<Alunoturma>();
            Curtida = new HashSet<Curtida>();
            Dica = new HashSet<Dica>();
            Professorturma = new HashSet<Professorturma>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataUltimoAcesso { get; set; }
        public int? IdPerfil { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual ICollection<Alunoturma> Alunoturma { get; set; }
        public virtual ICollection<Curtida> Curtida { get; set; }
        public virtual ICollection<Dica> Dica { get; set; }
        public virtual ICollection<Professorturma> Professorturma { get; set; }
    }
}
