using Surat_Pejalanan_Dinas.Model;
using System;
using System.ComponentModel;
//using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Surat_Pejalanan_Dinas
{
    internal class Program
    {
        void Activity()
        {
            Console.WriteLine("1. Create admin");
            Console.WriteLine("2. Update password admin by username");
            Console.WriteLine("3. Delete admin by username");
            Console.WriteLine("4. Read Admin");
            Console.WriteLine("5. Read Pegawai");
            Console.WriteLine("6. Create Pegawai");
            Console.WriteLine("7. Update pegawai by nama");
            Console.WriteLine("8. Delete pegawai by name");
            Console.WriteLine("9. Read Admin");
            Console.WriteLine("10. Read All Data Tiket Pesawat");
            Console.WriteLine("11. Get Harga tiket by rute awal dan rute tujuan");
            Console.WriteLine("0. Keluar");
            Console.Write("Pilih aktivitas yang ingin anda lakukan >> ");
            
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            var adminss = new CAdmin();
            var pegawai = new CPegawai();
            var tiket = new CTiket();

            program.Activity();

            string pilihan = Console.ReadLine();
            //clear
            if (pilihan == "1")
            {
                adminss.ReadAdmin();
                Console.Write("Masukan Username = ");
                string inputAdmin = Console.ReadLine();
                Console.Write("Masukan Password = ");
                string inputPassword = Console.ReadLine();
                Admin admin = new Admin()
                {
                    // username = "admin3",
                    //password = "admin3"
                    username = inputAdmin,
                    password = inputPassword
                };
                adminss.CreateAdmin(admin);
                adminss.ReadAdmin();
            }
            //clear
            if (pilihan == "2")
            {
                adminss.ReadAdmin();
                Console.Write("Masukan Password yang ingin dirubah >> "); 
                string passw = Console.ReadLine();
                Console.Write("Masukan Usernama >> ");
                string uname = Console.ReadLine();
                Admin updatePass = new Admin()
                {
                    username = uname,
                    password = passw
                };
                adminss.UpdatePass(updatePass);
                adminss.ReadAdmin();

            }
            //clear
            if (pilihan == "3")
            {
                Console.Write("Masukan Username yang ingin dihapus aksesnya>> ");
                string inputAdmin = Console.ReadLine();
                Admin delAdmin = new Admin()
                {
                    username = inputAdmin
                };
                adminss.DeleteAdmin(delAdmin);
            }
            //clear
            if (pilihan == "4")
            {
                adminss.ReadAdmin();

            }

            //clear
            if (pilihan == "5")
            {
                pegawai.ReadPegawai();
            }
            //clear
            if (pilihan == "6")
            {
                Console.Write("Masukan nama pegawai >> ");
                string inputpegawai = Console.ReadLine();
                Console.Write("Masukkan NIP >> ");
                string inputnip  = Console.ReadLine();
                int inip = Int32.Parse(inputnip);
                Console.Write("Masukkan Jabatan >> ");
                string inputjabatan = Console.ReadLine();
                Console.Write("Msukkan Golongan >> ");
                string igol  = Console.ReadLine();
                Pegawai addPegawai = new Pegawai
                {
                    namePegawai = inputpegawai,
                    nipPegawai = inip,
                    jabatanPegawai = inputjabatan,
                    golonganPegawai = igol
                };
                pegawai.CreatePegawai(addPegawai);
                pegawai.ReadPegawai();
            }

            //Clear
            if (pilihan== "7")
            {
                pegawai.ReadPegawai();

                Console.Write("Masukan nama pegawai yang golongannya ingin diubah >> ");
                string inputpegawai = Console.ReadLine();
                
                Console.Write("Masukkan Jabatan >> ");
                string igol = Console.ReadLine();
               
                Pegawai updt = new Pegawai
                {
                    namePegawai = inputpegawai,
                    golonganPegawai = igol,
                };
                pegawai.UpdatePegawai(updt);
                pegawai.ReadPegawai();
            }
            
            //clear
            if (pilihan == "8")
            {
                pegawai.ReadPegawai();
                Console.Write("Masukan nama Pegawai yang ingin dihapus aksesnya>> ");
                string iname = Console.ReadLine();
                Pegawai delPeg = new Pegawai()
                {
                    namePegawai = iname
                };
                pegawai.DeletePegawai(delPeg);
                pegawai.ReadPegawai();
            }
            //clear  
            if (pilihan == "10")
            {
                tiket.getAllData();
            }
           //clear
            if (pilihan == "11")
            {
                Console.Write("Masukan Rute Awal >> ");
                string inputrute1 = Console.ReadLine();
                Console.Write("Masukan Rute Tujuan >> ");
                string inputrute2 = Console.ReadLine();
                Tiket getharga = new Tiket()
                {
                    ruteAwal = inputrute1,
                    ruteTujuan = inputrute2,

                };
                tiket.getHarga(getharga);

            }

            if (pilihan== "0")
            {
                program.back();
            }
            
        }

        void back()
        {
            Console.WriteLine("Selesai");
        }

    }
}