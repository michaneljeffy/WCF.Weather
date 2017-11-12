using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace WeatherService.DAL
{
    public static class SqlHelper
    {
        private static string connectString = ConfigurationManager.ConnectionStrings["MySqlConnect"].ConnectionString;
        public static T ExecScalarSql<T>(string sqlContent)
        {
            try
            {
                //var connectString = ConfigurationManager.ConnectionStrings["MySqlConnect"].ConnectionString;
                using (var connect = new MySqlConnection(connectString))
                {
                    var resutl = connect.ExecuteScalar<T>(sqlContent,CommandType.Text);
                    connect.Close();
                    return resutl;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int ExecuteNonQuery(string sqlContent)
        {
            try
            {
                using (var connect = new MySqlConnection(connectString))
                {
                    var result = connect.Execute(sqlContent, CommandType.Text);
                    return result;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
         }

        public static IDbConnection OpenConnect()
        {           
            using (var connect = new MySqlConnection(connectString))
            {
                connect.Open();
                return connect;
            }
        }
    }
}
