using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RosterSdoApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace RosterSdoApplication.Data
{
    public class DataBanco
    {
        private Connection _connection = new Connection();
        private Ferramentas _ferramentas = new Ferramentas();

        public String Get()
        {
            var jsonResult = new StringBuilder();

            using (SqlConnection conexao = _connection.Conectar())
            {
                string commandText = "SELECT * FROM [TABLE] for json PATH, INCLUDE_NULL_VALUES";
                //for json PATH = Tansforma o SQL em JSON
                //INCLUDE_NULL_VALUES =  Traz os valores null do banco

                using (SqlCommand cmd = new SqlCommand(commandText, conexao))
                {
                    cmd.CommandText = commandText;

                    conexao.Open();
                    var reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        jsonResult.Append("[]");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            jsonResult.Append(reader.GetValue(0).ToString());
                        }
                    }
                }

                return jsonResult.ToString();
            }
        }

        public int Post(ObjBanco Aloc)
        {

            StringBuilder script = new StringBuilder();
            script.AppendLine("INSERT INTO [TABLE](");
            script.AppendLine(_GetCampos());
            script.AppendLine($") VALUES ({_GetValuesAlocacoes(Aloc)})");

            using (SqlConnection conexao = _connection.Conectar())
            {
                int rowAffected;

                using (SqlCommand cmd = new SqlCommand(script.ToString(), conexao))
                {
                    cmd.CommandText = script.ToString();

                    conexao.Open();
                    rowAffected = cmd.ExecuteNonQuery();

                }

                return rowAffected;
            }
        }

        //Monta os campos do insert de acordo com o objeto do banco
        private string _GetCampos()
        {
            try
            {
                StringBuilder campos = new StringBuilder();
                PropertyInfo[] propriedades = typeof(ObjBanco).GetProperties();
                int i = 1;

                foreach (PropertyInfo prop in propriedades)
                {
                    if (prop.Name.ToUpper() != "ID")
                    {
                        if (i == propriedades.Length)
                            campos.AppendLine($"{prop.Name}");
                        else
                            campos.AppendLine($"{prop.Name},");
                    }

                    i++;
                }

                string script = campos.ToString();
                return script;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //Monta o values do insert
        private string _GetValuesAlocacoes(ObjBanco objBanco)
        {
            try
            {
                StringBuilder campos = new StringBuilder();
                PropertyInfo[] propriedades = typeof(ObjBanco).GetProperties();
                int i = 1;

                foreach (PropertyInfo prop in propriedades)
                {
                    if (prop.Name.ToUpper() != "ID")
                    {
                        if (i == propriedades.Length)
                            campos.AppendLine($"{_ferramentas.TratarCampos(prop.GetValue(objBanco), prop)}");
                        else
                            campos.AppendLine($"{_ferramentas.TratarCampos(prop.GetValue(objBanco), prop)},");

                    }
                    i++;
                }

                string script = campos.ToString();
                return script;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}