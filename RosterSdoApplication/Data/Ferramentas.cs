using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace RosterSdoApplication.Data
{
    public class Ferramentas
    {
        public string TratarCampos(object value, PropertyInfo prop)
        {
            string valor = "";

            if (value != null)
            {
                if (prop.PropertyType == typeof(int))
                {
                    valor = value.ToString();
                }
                else if (prop.PropertyType == typeof(DateTime))
                {
                    valor = $"'{value.ToString()}'";
                }
                else if (prop.PropertyType == typeof(string))
                {
                    valor = $"'{value.ToString()}'";
                }
                else if (prop.PropertyType == typeof(float))
                {
                    valor = value.ToString();
                }
            }
            else
            {
                valor = "Null";
            }
            return valor;
        }

    }
}