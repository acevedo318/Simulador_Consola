using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Simulador_Consola.Clases
{
    class TerminalUsuario
    {
        private string nombreUsuario;
        private string direccionUbicacion;

        private static string Maquina = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split(@"\"[0])[0];

        public TerminalUsuario(string nombreUsuario,string direccionUbicacion)
        {
            this.nombreUsuario = nombreUsuario;
            this.direccionUbicacion = direccionUbicacion;
            Console.Clear();
            Console.Write(GetPrompt());
            Console.WriteLine(direccionUbicacion);
        }


        private string GetPrompt()
        {
            return Maquina + "@" + this.nombreUsuario + ":~$ "; // Nombre Maquina,nombre Usuario, Ubicacion Comando
        }

    }
}
