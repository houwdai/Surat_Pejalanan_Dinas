using Surat_Pejalanan_Dinas.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Surat_Pejalanan_Dinas
{
    public class CPegawai
    {
        //Pegawai Create - Read - Update - Delete
        public string connectionString = "Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True";

        public void DeletePegawai(Pegawai pegawai)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            {
                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.Transaction = transaction;
                try
                {
                    cmd.CommandText = "DELETE FROM pegawai WHERE namaPegawai=@nama";
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@nama";
                    sqlParameter.Value = pegawai.namePegawai;
                    cmd.Parameters.Add(sqlParameter);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }

        public void CreatePegawai(Pegawai pegawai)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.Transaction = sqlTransaction;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@nama";
                sqlParameter.Value = pegawai.namePegawai;
                cmd.Parameters.Add(sqlParameter);

                SqlParameter sqlParameter2 = new SqlParameter();
                sqlParameter2.ParameterName = "@nip";
                sqlParameter2.Value = pegawai.nipPegawai;
                cmd.Parameters.Add(sqlParameter2);
               

                SqlParameter sqlParameter3 = new SqlParameter();
                sqlParameter3.ParameterName = "@jabatan";
                sqlParameter3.Value = pegawai.jabatanPegawai;
                cmd.Parameters.Add(sqlParameter3);

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@golongan";
                sqlParameter4.Value = pegawai.golonganPegawai;
                cmd.Parameters.Add(sqlParameter4);
                try
                {
                    cmd.CommandText = "INSERT INTO pegawai " + "(namaPegawai, nipPegawai, jabatanPegawai, golonganPegawai) " +
                        "values (@nama, @nip, @jabatan, @golongan)";

                    cmd.ExecuteNonQuery();
                    sqlTransaction.Commit();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }

        }

        public void UpdatePegawai(Pegawai pegawai)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.Transaction = sqlTransaction;
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@nama";
                sqlParameter.Value = pegawai.namePegawai;
                cmd.Parameters.Add(sqlParameter);

                SqlParameter sqlParameter4 = new SqlParameter();
                sqlParameter4.ParameterName = "@golongan";
                sqlParameter4.Value = pegawai.golonganPegawai;
                cmd.Parameters.Add(sqlParameter4);
                try
                {
                    cmd.CommandText = "UPDATE pegawai set "
                            + "golonganPegawai = @golongan where namaPegawai = @nama";
                    
                    cmd.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void ReadPegawai()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-3EQ7S2P;Initial Catalog=SuratPerjalananDinass;Integrated Security=True");

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "Select * from pegawai";
            try
            {
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        while (reader.Read())
                        {
                            Console.Write(reader[0]);
                            Console.Write(", ");
                            Console.Write(reader[1]);
                            Console.Write(", ");
                            Console.Write(reader[2]);
                            Console.Write(", ");
                            Console.Write(reader[3]);
                            Console.Write(", ");
                            Console.WriteLine(reader[4]);
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
//}
