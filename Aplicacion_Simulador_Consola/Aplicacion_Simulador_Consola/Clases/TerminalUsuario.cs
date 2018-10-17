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
            GetPrompt();
            Comandos();
 
        }

        /// <summary>
        /// // Nombre Maquina,nombre Usuario, Ubicacion Comando
        /// </summary>
        private void GetPrompt()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(Maquina);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(this.nombreUsuario);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(":~$ ");
            Console.ResetColor();
            
        }

        private void Comandos()
        {
            string data = "";
            bool salir = false;
            Comando comando = new Comando(this.direccionUbicacion);
            
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
                    GetPrompt();
                    
                }
                
            } while (!salir);

        }

    }
}
