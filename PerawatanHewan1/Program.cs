using System;
using System.Data;
using System.Data.SqlClient;


namespace KoneksiDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strKoneksi = "Data Source = LAPTOP-4U8KKFFT\\YUSVANTRIATMOJO; " +
                " Initial Catalog = jurusan; Integrated Security = True;";
            string strKoneksiSA = "Data Source = LAPTOP-4U8KKFFT\\YUSVANTRIATMOJO;" +
                " Initial Catalog = ZOO; User ID = sa ; Password = yusvantri12103";
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Koneksi Menggunakan Windows Authentication");
                    Console.WriteLine("2. Koneksi Menggunakan SQL Server Authentication");
                    Console.WriteLine("3. Buat Database ZOO");
                    Console.WriteLine("4. Buat Tabel Hewan");
                    Console.WriteLine("5. Buat Tabel Keeper");
                    Console.WriteLine("6. Buat Tabel Dokter_Hewan");
                    Console.WriteLine("7. Buat Tabel Perawatan");
                    Console.WriteLine("8. Buat Tabel Pemeriksaan");
                    Console.WriteLine("A. Buat Trigger Umur Tabel Hewan");
                    Console.WriteLine("B. Buat Trigger Umur Tabel Perawatan");
                    Console.WriteLine("C. Buat indeks di Kondisi hewan dan tanggal");
                    Console.WriteLine("D. Exit");
                    Console.WriteLine("\nEnter your Choice (1-8) OR (A-D): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                try
                                {

                                    SqlConnection koneksi = new SqlConnection();
                                    koneksi.ConnectionString = strKoneksi;
                                    koneksi.Open();
                                    if (koneksi.State == ConnectionState.Open)
                                    {
                                        koneksi.Close();
                                    }
                                    Console.WriteLine("Koneksi Berhasil");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Periksa Kembali Server Anda!\n" + ex.Message);
                                    Console.ReadLine();

                                }
                            }
                            break;
                        case '2':
                            {
                                try
                                {
                                    SqlConnection koneksi = new SqlConnection();
                                    koneksi.ConnectionString = strKoneksiSA;
                                    koneksi.Open();
                                    if (koneksi.State == ConnectionState.Open)
                                    {
                                        koneksi.Close();
                                    }
                                    Console.WriteLine("Koneksi Berhasil");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Periksa Kembali Server Anda!\n" + ex.Message.ToString());
                                    Console.ReadLine();
                                }
                            }
                            break;
                        case '3':
                            {
                                SqlConnection koneksi = new SqlConnection();
                                koneksi.ConnectionString = strKoneksi;

                                string str = "CREATE DATABASE ZOO ON PRIMARY " +
                                    "(NAME = PerawatanHewan_Data, " +
                                    "FILENAME = 'D:\\Semester 4\\Pengaplikasian Basis Data\\KoneksiDBhewan\\PerawatanHewanData.mdf', SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
                                    "LOG ON (NAME = PerawatanHewan_Log, " +
                                    "FILENAME = 'D:\\Semester 4\\Pengaplikasian Basis Data\\KoneksiDBhewan\\PerawatanHewanLog.ldf', SIZE = 1MB,MAXSIZE = 5MB,FILEGROWTH = 10%)";
                                SqlCommand cmd = new SqlCommand(str, koneksi);
                                try
                                {
                                    koneksi.Open();
                                    cmd.ExecuteNonQuery();
                                    Console.WriteLine("Database Berhasil diBuat");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Terjadi Kesalahan! Cek Ulang Server Anda!\n" + ex.Message.ToString());
                                    Console.ReadLine();
                                }
                            }
                            break;
                        case '4':
                            {
                                SqlConnection koneksi = new SqlConnection();
                                koneksi.ConnectionString = strKoneksiSA;

                                string str = "CREATE TABLE Hewan(" +
                                    "Id_hewan CHAR(8) PRIMARY KEY CONSTRAINT ck_idh check (Id_hewan LIKE '[A-Z][A-Z][A-Z][A-Z][0-9][0-9][0-9][0-9]')," +
                                    "Nama_hewan VARCHAR(50)," +
                                    "Jenis_hewan VARCHAR(50)," +
                                    "Spesies_hewan VARCHAR(50)," +
                                    "Jk_hewan CHAR(6) CONSTRAINT CKJk_hewan CHECK(Jk_hewan LIKE 'Jantan' OR Jk_hewan LIKE 'Betina')," +
                                    "Tgl_lahir DATE," +
                                    "Tgl_masuk DATE," +
                                    "Umur CHAR(2)," +
                                    "Berat VARCHAR(10)" +
                                    ")";
                                SqlCommand cmd = new SqlCommand(str, koneksi);
                                try
                                {
                                    koneksi.Open();
                                    cmd.ExecuteNonQuery();
                                    Console.WriteLine("Tabel Berhasil diBuat");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Terjadi Kesalahan! Cek Ulang Server Anda!\n" + ex.Message.ToString());
                                    Console.ReadLine();

                                }
                            }
                            break;
                        case '5':
                            {
                                SqlConnection koneksi = new SqlConnection();
                                koneksi.ConnectionString = strKoneksiSA;

                                string str = "CREATE TABLE Keeper(" +
                                    "Id_keeper CHAR(18) PRIMARY KEY CONSTRAINT ckidK CHECK(Id_keeper LIKE ('[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))," +
                                    "Nama_keeper VARCHAR(50)," +
                                    "Almt_keeper VARCHAR(255)," +
                                    "Notlp_keeper VARCHAR(13)" +
                                    ")";
                                SqlCommand cmd = new SqlCommand(str, koneksi);
                                try
                                {
                                    koneksi.Open();
                                    cmd.ExecuteNonQuery();
                                    Console.WriteLine("Tabel Berhasil diBuat");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Terjadi Kesalahan! Cek Ulang Server Anda!\n" + ex.Message.ToString());
                                    Console.ReadLine();

                                }
                            }
                            break;
                        case '6':
                            {
                                SqlConnection koneksi = new SqlConnection();
                                koneksi.ConnectionString = strKoneksiSA;

                                string str = "CREATE TABLE Dokter_hewan(" +
                                    "Id_Dhewan CHAR(18) PRIMARY KEY CONSTRAINT ckidD CHECK(Id_Dhewan LIKE ('[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))," +
                                    "Nama_Dhewan VARCHAR(50)," +
                                    "Almt_Dhewan VARCHAR(255)," +
                                    "Notlp_Dhewan VARCHAR(13)" +
                                    ")";
                                SqlCommand cmd = new SqlCommand(str, koneksi);
                                try
                                {
                                    koneksi.Open();
                                    cmd.ExecuteNonQuery();
                                    Console.WriteLine("Tabel Berhasil diBuat");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Terjadi Kesalahan! Cek Ulang Server Anda!\n" + ex.Message.ToString());
                                    Console.ReadLine();

                                }
                            }
                            break;
                        case '7':
                            {
                                SqlConnection koneksi = new SqlConnection();
                                koneksi.ConnectionString = strKoneksiSA;

                                string str = "CREATE TABLE Perawatan(" +
                                    "Id_prwtn CHAR(15) PRIMARY KEY CONSTRAINT ckidpr CHECK(Id_prwtn LIKE ('[A-Z][A-Z][A-Z][A-Z][A-Z][A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][A-Z]'))," +
                                    "Id_keeper CHAR(18) FOREIGN KEY (Id_keeper) REFERENCES Keeper(Id_keeper)," +
                                    "Id_hewan CHAR(8) FOREIGN KEY (Id_hewan) REFERENCES Hewan(Id_hewan)," +
                                    "Tgl_prwtn DATE," +
                                    "Kondisi_hewan CHAR(5) CONSTRAINT CKKondisi_hewan CHECK(Kondisi_hewan LIKE 'Sehat' OR Kondisi_hewan LIKE 'Sakit')," +
                                    "Detail_prwtn VARCHAR(MAX)" +
                                    ")";
                                SqlCommand cmd = new SqlCommand(str, koneksi);
                                try
                                {
                                    koneksi.Open();
                                    cmd.ExecuteNonQuery();
                                    Console.WriteLine("Tabel Berhasil diBuat");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Terjadi Kesalahan! Cek Ulang Server Anda!\n" + ex.Message.ToString());
                                    Console.ReadLine();

                                }
                            }
                            break;
                        case '8':
                            {
                                SqlConnection koneksi = new SqlConnection();
                                koneksi.ConnectionString = strKoneksiSA;

                                string str = "CREATE TABLE Pemeriksaan(" +
                                    "Id_Periksa CHAR(15) PRIMARY KEY CONSTRAINT ckidpm CHECK(Id_Periksa LIKE ('[A-Z][A-Z][A-Z][A-Z][A-Z][A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][A-Z]'))," +
                                    "Id_hewan CHAR(8) FOREIGN KEY (Id_hewan) REFERENCES Hewan(Id_hewan)," +
                                    "Id_Dhewan CHAR(18) FOREIGN KEY (Id_Dhewan) REFERENCES Dokter_Hewan(Id_Dhewan)," +
                                    "Tgl_Periksa DATE," +
                                    "Diagnosis VARCHAR(MAX)," +
                                    "Pengobatan VARCHAR(MAX)," +
                                    "Saran VARCHAR(MAX)" +
                                    ")";
                                SqlCommand cmd = new SqlCommand(str, koneksi);
                                try
                                {
                                    koneksi.Open();
                                    cmd.ExecuteNonQuery();
                                    Console.WriteLine("Tabel Berhasil diBuat");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Terjadi Kesalahan! Cek Ulang Server Anda!\n" + ex.Message.ToString());
                                    Console.ReadLine();
                                }
                            }
                            break;
                        case 'A':
                            {
                                SqlConnection koneksi = new SqlConnection();
                                koneksi.ConnectionString = strKoneksiSA;

                                string str = "CREATE TRIGGER UpdateUmurHewan1 " +
                                    "ON Hewan " +
                                    "AFTER INSERT, UPDATE " +
                                    "AS BEGIN " +
                                    "SET NOCOUNT ON; " +
                                    "update Hewan set Umur = DATEDIFF(YEAR, h.Tgl_lahir, GETDATE()) " +
                                    "- CASE " +
                                    "WHEN MONTH(h.Tgl_lahir) > MONTH(GETDATE()) OR (MONTH(h.Tgl_lahir) = MONTH(GETDATE()) AND DAY(h.Tgl_lahir) > DAY(GETDATE())) " +
                                    "THEN 1 " +
                                    "ELSE 0 " +
                                    "END " +
                                    "FROM Hewan h " +
                                    "JOIN inserted i ON h.Id_hewan = i.Id_hewan WHERE h.Id_hewan IN (SELECT Id_hewan FROM inserted); " +
                                    "END ";
                                SqlCommand cmd = new SqlCommand(str, koneksi);
                                try
                                {
                                    koneksi.Open();
                                    cmd.ExecuteNonQuery();
                                    Console.WriteLine("Trigger Berhasil diBuat");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Terjadi Kesalahan! Cek Ulang Server Anda!\n" + ex.Message.ToString());
                                    Console.ReadLine();
                                }
                            }
                            break;
                        case 'B':
                            {
                                SqlConnection koneksi = new SqlConnection();
                                koneksi.ConnectionString = strKoneksiSA;

                                string str = "CREATE TRIGGER UpdateUmurHewan2 " +
                                    "ON Perawatan " +
                                    "AFTER INSERT, UPDATE " +
                                    "AS BEGIN " +
                                    "SET NOCOUNT ON; " +
                                    "update Hewan set Umur = DATEDIFF(YEAR, h.Tgl_lahir, i.Tgl_prwtn) " +
                                    "- CASE " +
                                    "WHEN MONTH(h.Tgl_lahir) > MONTH(i.Tgl_prwtn) OR (MONTH(h.Tgl_lahir) = MONTH(i.Tgl_prwtn) AND DAY(h.Tgl_lahir) > DAY(i.Tgl_prwtn)) " +
                                    "THEN 1 " +
                                    "ELSE 0 " +
                                    "END " +
                                    "FROM Hewan h " +
                                    "JOIN inserted i ON h.Id_hewan = i.Id_hewan WHERE h.Id_hewan IN (SELECT Id_hewan FROM inserted); " +
                                    "END ";
                                SqlCommand cmd = new SqlCommand(str, koneksi);
                                try
                                {
                                    koneksi.Open();
                                    cmd.ExecuteNonQuery();
                                    Console.WriteLine("Trigger Berhasil diBuat");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Terjadi Kesalahan! Cek Ulang Server Anda!\n" + ex.Message.ToString());
                                    Console.ReadLine();
                                }
                            }
                            break;
                        case 'C':
                            { 
                                SqlConnection koneksi = new SqlConnection();
                                koneksi.ConnectionString = strKoneksiSA;

                                string str = "CREATE INDEX idx_kondisiHewan ON Perawatan (Kondisi_hewan, Tgl_prwtn) ";
                                SqlCommand cmd = new SqlCommand(str, koneksi);
                                try
                                {
                                    koneksi.Open();
                                    cmd.ExecuteNonQuery();
                                    Console.WriteLine("Indeks Berhasil diBuat");
                                    Console.ReadLine();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Terjadi Kesalahan! Cek Ulang Server Anda!\n" + ex.Message.ToString());
                                    Console.ReadLine();
                                }
                            }
                            break;
                        case 'D':
                            return;
                        default:
                            {
                                Console.WriteLine("\nOpsi tidak valid");
                                break;
                            }
                    }
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nPeriksa angka dan huruf yang dimasukkan.\n" + e.Message.ToString());
                }
            }
        }
    }
}

