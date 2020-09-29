using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetoEdux.Domains;

namespace ProjetoEdux.Contexts
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Alunoturma> Alunoturma { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Curtida> Curtida { get; set; }
        public virtual DbSet<Dica> Dica { get; set; }
        public virtual DbSet<Instituicao> Instituicao { get; set; }
        public virtual DbSet<Objetivo> Objetivo { get; set; }
        public virtual DbSet<Objetivoaluno> Objetivoaluno { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Professorturma> Professorturma { get; set; }
        public virtual DbSet<Turma> Turma { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-TSI8JUU\\SQLEXPRESS;Initial Catalog=APIEDUX;Persist Security Info=True;User ID=sa;Password=sa132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alunoturma>(entity =>
            {
                entity.HasKey(e => e.IdAlunoTurma)
                    .HasName("PK__ALUNOTUR__8F3223BD14B9E985");

                entity.ToTable("ALUNOTURMA");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.Alunoturma)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__ALUNOTURM__IdTur__48CFD27E");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Alunoturma)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__ALUNOTURM__IdUsu__47DBAE45");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__CATEGORI__A3C02A1066CFB957");

                entity.ToTable("CATEGORIA");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__CURSO__085F27D6258D1E8A");

                entity.ToTable("CURSO");

                entity.Property(e => e.IdInstituicao).HasColumnName("idInstituicao");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__CURSO__idInstitu__3C69FB99");
            });

            modelBuilder.Entity<Curtida>(entity =>
            {
                entity.HasKey(e => e.IdCurtida)
                    .HasName("PK__CURTIDA__2169583A06EC101A");

                entity.ToTable("CURTIDA");

                entity.HasOne(d => d.IdDicaNavigation)
                    .WithMany(p => p.Curtida)
                    .HasForeignKey(d => d.IdDica)
                    .HasConstraintName("FK__CURTIDA__IdDica__5812160E");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Curtida)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__CURTIDA__IdUsuar__571DF1D5");
            });

            modelBuilder.Entity<Dica>(entity =>
            {
                entity.HasKey(e => e.IdDica)
                    .HasName("PK__DICA__F1688516A98B98FE");

                entity.ToTable("DICA");

                entity.Property(e => e.Imagem)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Texto)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Dica)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__DICA__IdUsuario__5441852A");
            });

            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao)
                    .HasName("PK__INSTITUI__B771C0D8FBB678F9");

                entity.ToTable("INSTITUICAO");

                entity.Property(e => e.IdInstituicao).ValueGeneratedNever();

                entity.Property(e => e.Bairro)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .HasColumnName("logradouro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Objetivo>(entity =>
            {
                entity.HasKey(e => e.IdObjetivo)
                    .HasName("PK__OBJETIVO__E210F0715DC4080E");

                entity.ToTable("OBJETIVO");

                entity.Property(e => e.IdObjetivo).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Objetivo)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__OBJETIVO__IdCate__3F466844");
            });

            modelBuilder.Entity<Objetivoaluno>(entity =>
            {
                entity.HasKey(e => e.IdObjetivoAluno)
                    .HasName("PK__OBJETIVO__81E21D7AFAD8FDE3");

                entity.ToTable("OBJETIVOALUNO");

                entity.Property(e => e.DataAlcancado).HasColumnType("datetime");

                entity.Property(e => e.Nota).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdAlunoTurmaNavigation)
                    .WithMany(p => p.Objetivoaluno)
                    .HasForeignKey(d => d.IdAlunoTurma)
                    .HasConstraintName("FK__OBJETIVOA__IdAlu__4CA06362");

                entity.HasOne(d => d.IdObjetivoNavigation)
                    .WithMany(p => p.Objetivoaluno)
                    .HasForeignKey(d => d.IdObjetivo)
                    .HasConstraintName("FK__OBJETIVOA__IdObj__4D94879B");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PK__PERFIL__C7BD5CC1A6C18F63");

                entity.ToTable("PERFIL");

                entity.Property(e => e.Permissao)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Professorturma>(entity =>
            {
                entity.HasKey(e => e.IdProfessorTurma)
                    .HasName("PK__PROFESSO__60BE3B7A3DB98B8F");

                entity.ToTable("PROFESSORTURMA");

                entity.Property(e => e.IdProfessorTurma).HasColumnName("idProfessorTurma");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.Professorturma)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__PROFESSOR__IdTur__5165187F");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Professorturma)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK__PROFESSOR__Idusu__5070F446");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.HasKey(e => e.IdTurma)
                    .HasName("PK__TURMA__C1ECFFC9FE6F0929");

                entity.ToTable("TURMA");

                entity.Property(e => e.IdTurma).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Turma)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__TURMA__IdCurso__4222D4EF");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__5B65BF9791956E85");

                entity.ToTable("USUARIO");

                entity.Property(e => e.DataCadastro).HasColumnType("datetime");

                entity.Property(e => e.DataUltimoAcesso).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK__USUARIO__IdPerfi__44FF419A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
