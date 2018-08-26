using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RosterSdoApplication.Models
{
    public class Connection
    {
        public SqlConnection Conectar()
        {
            String nmUsuario = "nmUsuario",
                   senha = "senha",
                   server = "server",
                   catalog = "catalog";

            SqlConnection conexao = new SqlConnection($"Server=tcp:{server},1433; Initial Catalog={catalog};" +
                                                      $"Persist Security Info=False;User ID={nmUsuario};Password={senha};" +
                                                      $"MultipleActiveResultSets=False;" +
                                                      $"Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return conexao;
        }

        //Desconectar
        private static void Desconectar(SqlConnection conn)
        {
            try
            {
                if (conn != null)
                {
                    //conn.Close();
                    conn.Dispose();
                }

                conn = null;
            }
            catch
            {
                throw;
            }
        }
    }
}