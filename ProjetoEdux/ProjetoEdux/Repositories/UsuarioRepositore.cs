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
    public class UsuarioRepositore : IUsuario
    {

        Context conexao = new Context();

        SqlCommand cmd = new SqlCommand();

        public Usuario Alterar(Usuario a, int id)
        {

            
            cmd.CommandText = "UPDATE Usuario " +
                "SET Nome = @Nome, " +
                "Email = @Email " +
                "WHERE IdUsuario = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Nome", a.Nome);
            cmd.Parameters.AddWithValue("@Email", a.Email);

            cmd.ExecuteNonQuery();


            return a;

        }

        public Usuario BuscarPorID(int Id)
        {
            cmd.CommandText = "SELECT * FROM Usuario WHERE IdUsuario = @id";
            cmd.Parameters.AddWithValue("@id", Id);

            SqlDataReader dados = cmd.ExecuteReader();

            Usuario usuario = new Usuario();

            while (dados.Read())
            {
                usuario.IdUsuario = Convert.ToInt32(dados.GetValue(0));
                usuario.Nome = dados.GetValue(1).ToString();
                usuario.Email = dados.GetValue(2).ToString();
            }


            return usuario;

        }

        public Usuario Cadastrar(Usuario a)
        {
            cmd.CommandText =
                "INSERT INTO USuario (Nome, Email Senha)" +
                "VALUES" +
                "(@Nome, @Email, @Senha)";
            cmd.Parameters.AddWithValue("@Nome", a.Nome);
            cmd.Parameters.AddWithValue("@Email", a.Email);
            cmd.Parameters.AddWithValue("@Senha", a.Senha);

            cmd.ExecuteNonQuery();


            return a;
        }

        public Usuario Excluir(Usuario a, int id)
        {
            cmd.CommandText = "DELETE Usuario " +
                "WHERE IdUsuario = @id";
            cmd.Parameters.AddWithValue("@id", id);

            return a;

        }

        public List<Usuario> ListarTodos()
        {

            cmd.CommandText = "SELECT * FROM Usuario";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Usuario> usuario = new List<Usuario>();

            while (dados.Read())
            {
                usuario.Add(
                    new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        Email = dados.GetValue(2).ToString(),
                    }
                );
            }

            return usuario;

        }
    }
}

