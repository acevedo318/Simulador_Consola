using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Simulador_Consola.Clases
{
    /// <summary>
    /// La clase principal de la consola
    /// </summary>
    class Terminal
    {

        public Terminal()
        {


            Start();
        }

        /// <summary>
        /// Iniciliza los valores de la consola
        /// </summary>
        private void Start()
        {
            Console.Title = "Terminal";
            
            Informacion();
            

        }

        private void Informacion()
        {
            Console.WriteLine("Microsoft Windows [Versión 10.0.17134.285] \n(c) 2018 Microsoft Corporation.Todos los derechos reservados.");
        }
    }
}
