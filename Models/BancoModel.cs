using OnloadMVC.Models;
using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

namespace OnloadMVC.Models
{
    public class BancoModel
    {
        private string camDB = @"Data Source=onload.db";

        public void salvarContato(ContatoModel ct)
        {
            string sql = "INSERT INTO contatos (data,nome,telefone,email) VALUES (@data,@nome,@telefone,@email);";
            using(var cnx = new SQLiteConnection(camDB))
            {
                cnx.Open();

                var cmd = new SQLiteCommand(sql,cnx);
                cmd.Parameters.AddWithValue("@data",ct.data);
                cmd.Parameters.AddWithValue("@nome",ct.nome);
                cmd.Parameters.AddWithValue("@telefone",ct.telefone);
                cmd.Parameters.AddWithValue("@email",ct.email);
              
                try
                {
                   
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    
                    Console.WriteLine("Salvo com sucesso!");
                }

            }
         
        }

        public List<ContatoModel> listarContatos(){

            List<ContatoModel> contatos = new List<ContatoModel>();
            ContatoModel ct;

            using(var cnx = new SQLiteConnection(camDB)){
                 var cmd = new SQLiteCommand("select * from contatos",cnx);
                 try
                 {
                     cnx.Open();
                     using( var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                     {
                         while(reader.Read())
                         {
                             ct = new ContatoModel();
                             ct.id = Convert.ToInt32(reader["id"]);
                             ct.data = reader["data"].ToString();
                             ct.nome = reader["nome"].ToString();
                             ct.telefone = reader["telefone"].ToString();
                             ct.email = reader["email"].ToString();
                             contatos.Add(ct);
        

                         }
                     }

                 }catch(SQLiteException ex)
                 {
                     Console.WriteLine("Erro: {0}",ex);
                 }
                 finally
                 {
                     cnx.Close();
                 }
                 return contatos;
                
            }
        }


    }

}