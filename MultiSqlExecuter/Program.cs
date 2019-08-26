using System;

namespace MultiSqlExecuter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Multi ejecutor de sql's");
            Console.WriteLine("Ingrese la ruta de la carpeta que contiene los archivos");
            var route = Console.ReadLine();
            if (route != "")
            {
                SqlExecuter.ExecuteFromFolder(route);
                Console.WriteLine("Comandos ejecutados correctamente...");
                Console.ReadKey();
            }
        }
    }
}
