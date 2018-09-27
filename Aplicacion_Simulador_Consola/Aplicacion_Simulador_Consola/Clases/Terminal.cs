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
        private string contrase;
        private static string DireccionSistema = Application.StartupPath + @"\" + "C" + @"\" + "Sistema" + @"\" + "Usuario.tm";

        public Terminal()
        {
            Start();
        }

        /// <summary>
        /// Iniciliza los valores de la consola y verificar si existe Sistema
        /// </summary>
        private void Start()
        {
            Console.Title = "Terminal";
            Informacion();
            Cargando();


            try
            {

                if (File.Exists(DireccionSistema))
                {
                    CargarUsuario();
                }
                else
                {
                    Iniciar();
                }


            }
            catch (Exception)
            {
                Console.WriteLine("Error en el Arranque del Terminal");
                throw;
            }

            
            
            
            

        }

        public static void CargarUsuario()
        {
            try
            {
                TextReader archivoUsuario;
                archivoUsuario = new StreamReader(Terminal.DireccionSistema);
                string nombreUsuario = archivoUsuario.ReadLine().Split(';')[0];
                TerminalUsuario Usuario = new TerminalUsuario(nombreUsuario, Application.StartupPath + @"\" + "C" + @"\" + "Usuario" + @"\" + nombreUsuario);
                archivoUsuario.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("No es posible cargar el Usuario");
                throw;
            }
            
        }

        /// <summary>
        /// Primer uso de la consola
        /// </summary>
        private void Iniciar()
        {
            bool validar = false;
            Console.WriteLine("Bienvenido");
            Console.WriteLine("Para el primer uso de la consola es necesario su nombre de usuario");
            
            do
            {
                
                string datos = "";
                Console.WriteLine("Ingrese su nombre de usuario");
                this.nombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese su contraseña");
                this.contrase = Console.ReadLine();

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Su nombre de usuario sera: " + nombreUsuario);
                Console.WriteLine("¿Desea utilizar este nombre? s/n");
                datos = Console.ReadLine();
                datos = datos.ToLower();

                if (datos == "s" || datos == "si")
                {
                    validar = false;
                    CrearArchivo("Sistema", "Usuario", nombreUsuario + ";" + contrase);
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
            CargarUsuario();

        }

        private void Informacion()
        {
            Console.WriteLine("Corriendo en Sistema Operativo " + Environment.OSVersion.ToString());
            Console.WriteLine();
            Console.WriteLine("Terminal VladeDesigners");
            Console.WriteLine("2018");
            Console.WriteLine();
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
            string direccionUsuario = Application.StartupPath + @"\" + "C" + @"\" + "Usuario" + @"\";
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
                    archivo = new StreamWriter(direccion + nombreArchivo + ".tm"); //Es un archivo de texto para guardar datos del sistema
                    CrearCarpetasUsuario(direccionUsuario, this.nombreUsuario);
                    Directory.CreateDirectory(Application.StartupPath + @"\" + "C" + @"\" + "Archivos de programas");//Carpeta de aplicaciones
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

        private void CrearCarpetasUsuario(string directorio,string usuario)
        {
            Directory.CreateDirectory(directorio + @"\" + usuario);//Creo el directorio usuario
            Directory.CreateDirectory(directorio + @"\" + usuario + @"\" + "Documentos");
            Directory.CreateDirectory(directorio + @"\" + usuario + @"\" + "Escritorio");
            Directory.CreateDirectory(directorio + @"\" + usuario + @"\" + "Musica");
            Directory.CreateDirectory(directorio + @"\" + usuario + @"\" + "Videos");
            Directory.CreateDirectory(directorio + @"\" + usuario + @"\" + "AppData");
        }
    }
}
