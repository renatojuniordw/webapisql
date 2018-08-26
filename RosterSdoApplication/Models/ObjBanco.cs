using System;
using System.Data.SqlClient;

namespace RosterSdoApplication.Models
{
    public class ObjBanco
    {
        public int id { get; set; }
        public String nm_usuario { get; set; }
        public DateTime dt { get; set; }
    }
}