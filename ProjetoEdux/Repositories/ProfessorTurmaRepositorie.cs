using ProjetoEdux.Contexts;
using ProjetoEdux.Domains;
using ProjetoEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux.Repositories
{
    public class ProfessorTurmaRepositorie : IProfessorturma
    {

        EduxContext conexao = new EduxContext();

        SqlCommand cmd = new SqlCommand();

        public Professorturma Alterar(Professorturma a, int id)
        {
            conexao.Conectar();
            cmd.CommandText = "UPDATE Professorturma " +
                "SET Descricao = @Descricao, " +
                "WHERE IdProfessorTurma = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Descricao", a.Descricao);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

        public Professorturma BuscarPorID(int Id)
        {
            conexao.Conectar();
            cmd.CommandText = "SELECT * FROM Professorturma WHERE" +
                " IdProfessorTurma = @id";
            cmd.Parameters.AddWithValue("@id", Id);

            SqlDataReader dados = cmd.ExecuteReader();

            Professorturma professorturma = new Professorturma();

            while (dados.Read())
            {
                professorturma.IdProfessorTurma = Convert.ToInt32(dados.GetValue(0));
                professorturma.Descricao = dados.GetValue(1).ToString();
            }

            conexao.Desconectar();
            return professorturma;
        }

        public Professorturma Cadastrar(Professorturma a)
        {
            conexao.Conectar();
            cmd.CommandText =
               "INSERT INTO Professorturma (Descricao)" +
               "VALUES" +
               "(@Descricao)";
            cmd.Parameters.AddWithValue("@Descricao", a.Descricao);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

        public Professorturma Excluir(Professorturma a, int id)
        {
            conexao.Conectar();
            cmd.CommandText = "DELETE Professorturma " +
              "WHERE IdProfessorTurma = @id";
            cmd.Parameters.AddWithValue("@id", id);

            conexao.Desconectar();

            return a;
        }
        

        public List<Professorturma> ListarTodos()
        {
            conexao.Conectar();
            cmd.CommandText = "SELECT * FROM Professorturma";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Professorturma> professorturma = new List<Professorturma>();

            while (dados.Read())
            {
                professorturma.Add(
                    new Professorturma()
                    {
                        IdProfessorTurma = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                    }
                );
                conexao.Desconectar();
            }

            return professorturma;
        }

    }
}
