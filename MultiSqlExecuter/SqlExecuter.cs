using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Microsoft.SqlServer;

namespace MultiSqlExecuter
{
    public class SqlExecuter
    {
        const string SqlConnectionString = "Server=DESKTOP-JK7B2S8;Database=QUANTICADB;Integrated Security=True;MultipleActiveResultSets=True";
        public static void ExecuteFromFolder(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.sql");
            Console.WriteLine($"{Files.Length} archivos encontrados");
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConnectionString))
                {
                    conn.Open();
                    foreach (FileInfo file in Files)
                    {
                        try
                        {
                            Console.WriteLine($"Ejecutando elementos en {file.FullName}");
                            string data = System.IO.File.ReadAllText(file.FullName);
                            data = data.Replace("GO", "");

                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = data;
                                cmd.ExecuteNonQuery();
                            }
                            Console.WriteLine("Comando ejecutado...");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"NO SE PUDO EJECUTAR: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepcion desconocida {ex.Message}");
                throw ex;
            }
        }
    }
}
