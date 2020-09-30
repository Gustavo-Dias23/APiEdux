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
        Context conexao = new Context();

        SqlCommand cmd = new SqlCommand();

        public Dica Alterar(Dica a, int id)
        {
            cmd.CommandText = "UPDATE Dica " +
                "SET Texto = @Texto, " +
                "Imagem = @Imagem " +
                "WHERE IdDica = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Texto", a.Texto);
            cmd.Parameters.AddWithValue("@Imagem", a.Imagem);

            cmd.ExecuteNonQuery();


            return a;
        }

        public Dica BuscarPorID(int Id)
        {
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


            return dica;
        }

        public Dica Cadastrar(Dica a)
        {
            cmd.CommandText =
               "INSERT INTO Dica (Texto, Imagem)" +
               "VALUES" +
               "(@Texto, @Imagem)";
            cmd.Parameters.AddWithValue("@Texto", a.Texto);
            cmd.Parameters.AddWithValue("@Imagem", a.Texto);

            cmd.ExecuteNonQuery();


            return a;
        }

        public Dica Excluir(Dica a, int id)
        {
            cmd.CommandText = "DELETE Dica " +
              "WHERE IdDica = @id";
            cmd.Parameters.AddWithValue("@id", id);

            return a;
        }

        public List<Dica> ListarTodos()
        {
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
            }

            return dica;
        }
    }
}
