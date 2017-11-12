using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WeatherService.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WeatherService.DAL
{
    public class UserDB
    {
        public User GetAll()
        {
            string query = "select * from users";
            User result = SqlHelper.ExecScalarSql<User>(query);
            return result;
        }

        public User GetOne(int id)
        {
            using (IDbConnection connection = SqlHelper.OpenConnect())
            {
                string query = "select * from user where Id=@id";
                return connection.Query<User>(query, new { id = id })
                                .SingleOrDefault<User>();
            }

        }

        public bool Add(User user)
        {
            string query = string.Format("INSERT INTO [dbo].[User]([UserName],[Password],[Discribe],[SubmitTime]) VALUES('{0}','{1}','{2}','{3}')",
                user.UserName, user.Password, user.Discribe, user.SubmitTime);
            int result = SqlHelper.ExecuteNonQuery(query);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Save(Model.User user)
        {
            string query = string.Format("UPDATE [dbo].[User] SET [UserName] = '{0}',[Discribe] = '{2}',[SubmitTime] = '{3}' WHERE UserID = {4}", user.UserName, user.Password, user.Discribe, user.SubmitTime, user.UserID);
            int result = SqlHelper.ExecuteNonQuery(query);
            if (result > 0)
                return true;
            else
                return false;
        }

        //删除
        public bool Remove(int UserID)
        {
            string query = string.Format("DELETE FROM [dbo].[User] WHERE UserID = {0}", UserID);
            int result = SqlHelper.ExecuteNonQuery(query);
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
