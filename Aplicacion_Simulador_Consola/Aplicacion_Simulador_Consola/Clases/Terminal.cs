using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Aplicacion_Simulador_Consola.Clases
{
    /// <summary>
    /// La clase principal de la consola
    /// </summary>
    class Terminal
    {
        private string nombreUsuario;

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
            Cargando();
            Inicio();
            

        }

        /// <summary>
        /// Primer uso de la consola
        /// </summary>
        private void Inicio()
        {
            bool validar = false;
            Console.WriteLine("Bienvenido");
            Console.WriteLine("Para el primer uso de la consola es necesario su nombre de usuario");
            
            do
            {
                
                string datos = "";
                Console.WriteLine("Ingrese su nombre de usuario");
                this.nombreUsuario = Console.ReadLine();

                Console.WriteLine("Su nombre de usuario sera: " + nombreUsuario);
                Console.WriteLine("¿Desea utilizar este nombre? s/n");
                datos = Console.ReadLine();
                datos = datos.ToLower();

                if (datos == "s" || datos == "si")
                {
                    validar = false;
                    CrearArchivo("Recursos", "Usuario", nombreUsuario);
                    Console.WriteLine("Usuario Guardado");
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey();
                }else if (datos == "n" || datos == "no")
                {
                    validar = true;
                }
                else
                {
                    Console.WriteLine("Valor Incorrecto");
                    validar = true;
                }

            } while (validar);
            

        }

        private void Informacion()
        {
            Console.WriteLine("Sistema Operativo " + Environment.OSVersion.ToString());
            Console.WriteLine("Terminal VladeDesigners");
            Console.WriteLine("2018");
        }

        private void Cargando()
        {
            
            Console.Write("Cargando: ");
            for (int i = 0; i < 50; i++)
            {
                Console.Write("*");
                Espera(1);
            }
            Console.WriteLine();
           
            Console.Clear();
        }

        private void Espera(int decimasegundos)
        {
            System.Threading.Thread.Sleep((decimasegundos*100));
        }

        private void CrearArchivo(string nombreCarpeta,string nombreArchivo,string contenido)
        {
            string direccion = Application.StartupPath + @"\" + "C"+ @"\" + nombreCarpeta + @"\";
            Console.WriteLine(direccion);
            TextWriter archivo;
            
            try
            {
                if (File.Exists(direccion+nombreArchivo))
                {
                    //Direcctorio Existe guardo archivo
                    archivo = new StreamWriter(direccion + nombreArchivo + ".txt");
                }
                else
                {
                    Directory.CreateDirectory(direccion);//Creo el directorio
                    archivo = new StreamWriter(direccion + nombreArchivo + ".txt");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error de escritura en ruta");
                throw;
            }

            archivo.Write(contenido);
            archivo.Close();
        }
    }
}
