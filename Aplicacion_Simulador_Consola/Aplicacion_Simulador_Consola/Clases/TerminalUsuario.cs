using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Simulador_Consola.Clases
{
    class TerminalUsuario
    {
        private string nombreUsuario;
        private string direccionUbicacion;

        /// <summary>
        /// Nombre de la maquina
        /// </summary>
        private static string Maquina = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split(@"\"[0])[0];

        public TerminalUsuario(string nombreUsuario,string direccionUbicacion)
        {
            this.nombreUsuario = nombreUsuario;
            this.direccionUbicacion = direccionUbicacion;
            Console.Clear();
            Console.Write(GetPrompt());
            Comandos();
 
        }


        private string GetPrompt()
        {
            Console.WriteLine();
            return Maquina + "@" + this.nombreUsuario + ":~$ "; // Nombre Maquina,nombre Usuario, Ubicacion Comando
        }

        private void Comandos()
        {
            string data = "";
            bool salir = false;
            Comando comando = new Comando();
            
            do
            {
                data = Console.ReadLine();
                if (data.ToLower() == "salir")
                {
                    Console.WriteLine();
                    Console.WriteLine("Finalizada Sesion");
                    salir = true;
                    Terminal.Cargando();
                }
                else
                {
                    Console.WriteLine();
                    comando.Buscar(data);
                    Console.Write(GetPrompt());
                    
                }
                
            } while (!salir);

        }


        /*
        
         string data = "";
            DirectoryInfo Dir = new DirectoryInfo(@"c:\Users\kevin\Documents\GitHub\Simulador_Consola\Aplicacion_Simulador_Consola\Aplicacion_Simulador_Consola\bin\Debug\C");
            do
            {
                
                data = Console.ReadLine();
                foreach (var file in Dir.GetDirectories())
                {

                    Console.WriteLine(file);

                }
            } while (true);
            

    */

    }
}
