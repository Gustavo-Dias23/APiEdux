using Microsoft.Data.SqlClient;
using ProjetoEdux.Contexts;
using ProjetoEdux.Domains;
using ProjetoEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux.Repositories
{
    public class DicasRepositores : IDicas
    {
        EduxContext conexao = new EduxContext();

        SqlCommand cmd = new SqlCommand();

        public Dica Alterar(Dica a, int id)
        {
            conexao.Conectar();
            cmd.CommandText = "UPDATE Dica " +
                "SET Texto = @Texto, " +
                "Imagem = @Imagem " +
                "WHERE IdDica = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Texto", a.Texto);
            cmd.Parameters.AddWithValue("@Imagem", a.Imagem);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

        public Dica BuscarPorID(int Id)
        {
            conexao.Conectar();
            cmd.CommandText = "SELECT * FROM Dica WHERE IdDica = @id";
            cmd.Parameters.AddWithValue("@id", Id);

            SqlDataReader dados = cmd.ExecuteReader();  

            Dica dica = new Dica();

            while (dados.Read())
            {
                dica.IdDica = Convert.ToInt32(dados.GetValue(0));
                dica.Texto = dados.GetValue(1).ToString();
                dica.Imagem = dados.GetValue(2).ToString();
            }

            conexao.Desconectar();
            return dica;
        }

        public Dica Cadastrar(Dica a)
        {
            conexao.Conectar();
            cmd.CommandText =
               "INSERT INTO Dica (Texto, Imagem)" +
               "VALUES" +
               "(@Texto, @Imagem)";
            cmd.Parameters.AddWithValue("@Texto", a.Texto);
            cmd.Parameters.AddWithValue("@Imagem", a.Imagem);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

        public Dica Excluir(Dica a, int id)
        {
            conexao.Conectar();
            cmd.CommandText = "DELETE Dica " +
              "WHERE IdDica = @id";
            cmd.Parameters.AddWithValue("@id", id);

            conexao.Desconectar();

            return a;
        }

        public List<Dica> ListarTodos()
        {
            conexao.Conectar();
            cmd.CommandText = "SELECT * FROM Dica";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Dica> dica = new List<Dica>();

            while (dados.Read())
            {
                dica.Add(
                    new Dica()
                    {
                        IdDica = Convert.ToInt32(dados.GetValue(0)),
                        Texto = dados.GetValue(1).ToString(),
                        Imagem = dados.GetValue(2).ToString(),
                    }
                );
                conexao.Desconectar();
            }

            return dica;
        }
    }
}
