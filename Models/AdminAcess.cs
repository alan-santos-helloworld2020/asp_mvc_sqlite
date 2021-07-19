using OnloadMVC.Models;
using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

namespace OnloadMVC
{
    public class AdminAcess{

        public AdminModel buscar(AdminModel admin)
        {
            AdminModel model = null;
            string sql = "SELECT * FROM user WHERE username=@username AND password=@password;";
            using(var cnx = new SQLiteConnection("Data Source=onload.db"))
            {
                var cmd = new SQLiteCommand(sql,cnx);
                cmd.Parameters.AddWithValue("@username",admin.username);
                cmd.Parameters.AddWithValue("@password",admin.password);

                try
                {
                    cnx.Open();
                    using(var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while(reader.Read())
                        {
                            model = new AdminModel();
                            model.username  = reader["username"].ToString();
                            model.password  = reader["password"].ToString();

                        }

                    }
                    
                }
                catch(SQLiteException ex)
                {
                     Console.WriteLine("Erro: {0}",ex);
                }
                finally
                {
                     cnx.Close();
                }
                return model;

            }

        }


    }

    
}