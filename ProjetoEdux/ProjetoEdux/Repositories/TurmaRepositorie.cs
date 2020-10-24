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
    public class TurmaRepositorie : ITurma
    {

        EduxContext conexao = new EduxContext();

        SqlCommand cmd = new SqlCommand();

        public Turma Alterar(Turma a, int id)
        {
            conexao.Conectar();
            cmd.CommandText = "UPDATE Turma " +
                "SET Descricao = @Descricao, " +
                "WHERE IdTurma = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Descricao", a.Descricao);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

        public Turma BuscarPorID(int Id)
        {
            conexao.Conectar();
            cmd.CommandText = "SELECT * FROM Turma WHERE" +
                " IdTurma = @id";
            cmd.Parameters.AddWithValue("@id", Id);

            SqlDataReader dados = cmd.ExecuteReader();

            Turma turma = new Turma();

            while (dados.Read())
            {
                turma.IdTurma = Convert.ToInt32(dados.GetValue(0));
                turma.Descricao = dados.GetValue(1).ToString();
            }

            conexao.Desconectar();
            return turma;
        }

        public Turma Cadastrar(Turma a)
        {
            conexao.Conectar();
            cmd.CommandText =
               "INSERT INTO Turma (Descricao)" +
               "VALUES" +
               "(@Descricao)";
            cmd.Parameters.AddWithValue("@Descricao", a.Descricao);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

        public Turma Excluir(Turma a, int id)
        {
            conexao.Conectar();
            cmd.CommandText = "DELETE Turma " +
              "WHERE IdTurma = @id";
            cmd.Parameters.AddWithValue("@id", id);

            conexao.Desconectar();

            return a;
        }

        public List<Turma> ListarTodos()
        {
            conexao.Conectar();
            cmd.CommandText = "SELECT * FROM Turma";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Turma> turma = new List<Turma>();

            while (dados.Read())
            {
                turma.Add(
                    new Turma()
                    {
                        IdTurma = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                    }
                );
                conexao.Desconectar();
            }

            return turma;
        }
    }
}
