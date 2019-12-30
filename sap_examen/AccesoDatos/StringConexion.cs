using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos
{
    class StringConexion
    {
        private static readonly string cName = @"Data Source=.\SQLEXPRESS;Initial Catalog=db_ventas;User ID=sa;Password=7soe600@";

        public static string ServerName
        {
            get => cName;
        }
    }
}
