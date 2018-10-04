using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Simulador_Consola.Clases
{
    /// <summary>
    /// Recibe todos los llamados
    /// </summary>
    public class Comando
    {
        public enum ListaComandos {Listar,ver,ayuda,Limpiar,Terminal}
        public string[] cadenaDatas = {"","",""};
        public Comando()
        {

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
            


        public void Listar(string[] data)
        {
            if (data.Count() <= 2)
            {
                Console.WriteLine("Listando");
            }
            else
            {
                ComandoInvalido(data[0]);
            }
            
        }

        public void Limpiar(string[] data)
        {
            Console.Clear();
        }

        public void Terminal(string[] data)
        {
            string opciones = "consolaColor";

            if (opciones == "consolaColor")
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Limpiar(null);
            }
            else
            {
                ComandoInvalido("");
            }
        }

        private void ComandoInvalido(string comando)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opcion Invalida puede usar {0} help para mas informacion de este comando",comando);
            Console.ResetColor();
        }


    }
}
