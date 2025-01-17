﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion_Simulador_Consola.Clases
{
    /// <summary>
    /// Recibe todos los llamados
    /// </summary>
    public class Comando
    {
        public enum ListaComandos {Listar,ver,ayuda,Limpiar,Terminal,Explorador,Abrir}
        public string[] cadenaDatas = {"","",""};
        private string directorioLocal = "";
        public Comando(string directorioLocal)
        {
            this.directorioLocal = directorioLocal;
        }

        public void Buscar(string data)
        {
            try
            {

                string[] cadenaData = data.Split(' ');
                if (Enum.GetNames(typeof(ListaComandos)).Contains(cadenaData[0]))
                {
                    List<string[]> nuevacadena = new List<string[]>();
                    nuevacadena.Add(cadenaData);
                    Type thisType = this.GetType();
                    MethodInfo theMethod = thisType.GetMethod(nuevacadena[0][0]);
                    
                    //
                    theMethod.Invoke(this, nuevacadena.ToArray());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Comando Invalido");
                    Console.ResetColor();
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error en codigo");
                Console.ResetColor();
                
            }
            
        }
            

        /// <summary>
        /// Lista las carpetas y archivos en el directorio
        /// </summary>
        /// <param name="data">opciones o directorio</param>
        public void Listar(string[] data)
        {
            if (data.Count() <= 2)
            {
                try
                {
                    listar(data);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Directorio no valido");
                    Console.ResetColor();
                }
                
                
            }
            else
            {
                ComandoInvalido(data[0]);
            }
            
        }
        /// <summary>
        /// Limpia la consola
        /// </summary>
        /// <param name="data"></param>
        public void Limpiar(string[] data)
        {
            if (data.Count()>1)
            {
                ComandoInvalido(data[0]);
            }
            else
            {
                Console.Clear();
            }
            
            
        }

        public void Abrir(string[] data)
        {
            if (data.Count() > 1)
            {
                if (data[1] == "volver")
                {
                    DirectoryInfo info = new DirectoryInfo(this.directorioLocal);
                    Console.WriteLine(info.FullName);
                }
            }
            else
            {
                ComandoInvalido(data[0]);
            }
        }

        public void Explorador(string[] data)
        {
            Process.Start("explorer.exe", this.directorioLocal);
        }

        public void Terminal(string[] data)
        {
            string opciones = "consolaColor";

            if (opciones == "consolaColor")
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Limpiar(data);
            }
            else
            {
                ComandoInvalido("");
            }
        }

        private void ComandoInvalido(string comando)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opcion Invalida puede usar {0} ayuda para mas informacion de este comando",comando);
            Console.ResetColor();
        }

        /// <summary>
        /// Lista la data de ayuda
        /// </summary>
        /// <param name="data"></param>
        public void ayuda(string[] data)
        {
            if (data.Count() > 1)
            {
                ComandoInvalido(data[0]);
            }
            else{
                string sLine = "" + Properties.Resources.help;
                Console.WriteLine(sLine);
            }
            
        }
        /// <summary>
        /// muestra el sistema operativo
        /// </summary>
        /// <param name="data">Los datos que se necesita para funcionar</param>
        public void ver(string[] data)
        {
            if (data.Count() > 1)
            {
                ComandoInvalido(data[0]);
            }
            else{

                Console.WriteLine("Corriendo en Sistema Operativo " + Environment.OSVersion.ToString());
                Console.WriteLine();
                Console.WriteLine("Terminal VladeDesigners");
                Console.WriteLine("2018");
                Console.WriteLine();
            }
        }

      

        /// <summary>
        /// funcion de Listar
        /// </summary>
        /// <param name="data"></param>
        private void listar(string[] data)
        {
            if (data.Count() == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                string[] Paths = Directory.GetDirectories(this.directorioLocal, "*", SearchOption.TopDirectoryOnly);

                Console.WriteLine("Carpetas");
                Console.WriteLine();
                foreach (var item in Paths)
                {
                    Console.WriteLine(item.Split('\\').GetValue(item.Split('\\').Length - 1));
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Archivos");
                Console.WriteLine();
                string[] filePaths = Directory.GetFiles(this.directorioLocal, "*", SearchOption.TopDirectoryOnly);
                foreach (var item in filePaths)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                string[] Paths = Directory.GetDirectories(this.directorioLocal + @"\" + data[1], "*", SearchOption.TopDirectoryOnly);

                Console.WriteLine("Carpetas");
                Console.WriteLine();
                foreach (var item in Paths)
                {
                    Console.WriteLine(item.Split('\\').GetValue(item.Split('\\').Length - 1));
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Archivos");
                Console.WriteLine();
                string[] filePaths = Directory.GetFiles(this.directorioLocal + @"\" + data[1], "*", SearchOption.TopDirectoryOnly);
                foreach (var item in filePaths)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }


    }
}
