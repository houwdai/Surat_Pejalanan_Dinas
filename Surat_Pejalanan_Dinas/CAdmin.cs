using Surat_Pejalanan_Dinas.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Surat_Pejalanan_Dinas
{
    public class CAdmin
    {
        //admin Create - Read - Update - Delete
        public void DeleteAdmin(Admin admin)
        {
            using SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");
            {
                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                SqlCommand cmd = sqlConnection.CreateCommand();
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@username";
                sqlParameter.Value = admin.username;
                cmd.Parameters.Add(sqlParameter);
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "DELETE FROM admins WHERE username=@username";
                   
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }

        public void CreateAdmin(Admin admin)
        {
            using SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.Transaction = sqlTransaction;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@username";
                sqlParameter.Value = admin.username;
                cmd.Parameters.Add(sqlParameter);

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@password";
                sqlParameter2.Value = admin.password;
                cmd.Parameters.Add(sqlParameter2);
                try
                {
                    cmd.CommandText = "INSERT INTO admins " + "(username, password) " +
                        "values (@username, @password)";

                   
                    cmd.ExecuteNonQuery();
                    sqlTransaction.Commit();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }

        }

        public void UpdatePass(Admin admin)
        {

            using SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.Transaction = sqlTransaction;
                SqlParameter diadmin = new SqlParameter();
                diadmin.ParameterName = "@diadmin";
                diadmin.Value = admin.username;
                cmd.Parameters.Add(diadmin);
                SqlParameter ubahpw = new SqlParameter();
                ubahpw.ParameterName = "@ubahpw";
                ubahpw.Value = admin.password;
                cmd.Parameters.Add(ubahpw);

                
                try
                {
                    cmd.CommandText = "UPDATE admins set "
                            +"password=@ubahpw where username = @diadmin";
                    
                    cmd.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void ReadAdmin()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "Select * from admins";
            try
            {
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine("Data Admin");
                        while (reader.Read())
                        {
                            Console.WriteLine("Username = " + reader[0]);
                            Console.WriteLine("Password = "+ reader[1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data Found");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}
