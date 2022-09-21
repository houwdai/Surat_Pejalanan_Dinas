using Surat_Pejalanan_Dinas.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Surat_Pejalanan_Dinas
{
    public class CTiket
    {
        public void getAllData()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "Select * from tiketPesawat";
            try
            {
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Rute Awal = " + reader[2]);
                            Console.WriteLine("Rute Tujuan = " + reader[3]);
                            Console.WriteLine("Harga = Rp." + reader[1]);
                            Console.WriteLine(" ");
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
        
        public void getHarga(Tiket tiket)
        {
            string query = "SELECT hargaTiket FROM tiketPesawat WHERE ruteAwal = @rute1 and ruteTujuan = @rute2";

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@rute1";
            sqlParameter.Value = tiket.ruteAwal;

            SqlParameter sqlParameter2 = new SqlParameter();
            sqlParameter2.ParameterName = "@rute2";
            sqlParameter2.Value = tiket.ruteTujuan;

            using SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.Add(sqlParameter);
            sqlCommand.Parameters.Add(sqlParameter2);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine("Rp.  "+ sqlDataReader[0]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
        }
    }
    
