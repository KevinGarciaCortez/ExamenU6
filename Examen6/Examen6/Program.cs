using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Examen6
{ 
class Amazon
{
        StreamReader sr;
        StreamWriter sw;
    string Nombre, Descripcion,str;
    int cantidad;
    float precio;
    
        public void Registro()
        {
            sw = new StreamWriter("Productos.txt", true);
            char resp;
            try { 
            do
            {
                Console.Clear();
                Console.Write("Ingresa el Nombre del producto: ");
                Nombre = Console.ReadLine();
                Console.Write("Ingresa la descripcion del producto: ");
                Descripcion = Console.ReadLine();
                Console.Write("Ingresa el precio del producto: ");
                precio = float.Parse(Console.ReadLine());
                Console.Write("Ingresa la cantidad en stock del producto: ");
                cantidad = int.Parse(Console.ReadLine());


                sw.Write("Nombre: " + Nombre + "\t" + "Precio: " + precio + "\t" + "Cantidad en Stock: " + cantidad + "\t" + "Descripcion: " + Descripcion+"\n");


                Console.Write("\n\nDesea Almacenar otro Registro (s/n)?");
                resp = Char.Parse(Console.ReadLine());

            } while ((resp == 's') || (resp == 'S'));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { 
                if (sw != null) sw.Close();
            }
           

        }
        public void MostrarRegistro()
    {
            try
            {
                if (File.Exists("Productos.txt"))
                {
                    sr = new StreamReader("Productos.txt");

                    Console.Clear();
                    Console.WriteLine("\t"+"Productos"+"\t");

                    str = sr.ReadLine();
                    while (str != null)
                    {
                        Console.WriteLine(str);
                        Console.Write("\n");
                        str = sr.ReadLine();
                    }
                    Console.Write("Da ENTER para seguir");
                    Console.ReadKey();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("\n\nFin del listado");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
                else
                {
                    Console.Clear();
                    Console.WriteLine("No hay Productos aun");
                    Console.ReadKey();
                    
                }
            }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        int opc;
        Amazon Amazon1 = new Amazon();

        do
        {
            Console.Clear();
            Console.WriteLine("\n****Inventario Amazon****");
            Console.WriteLine("1)Resgistrar Producto");
            Console.WriteLine("2)Consulta de Productos");
            Console.WriteLine("3)Salida del programa");

            Console.Write("Ingrese una opcion: ");
            opc = int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    Amazon1.Registro();            
                    break;
                case 2:
                    Amazon1.MostrarRegistro();
                    break;
                case 3:
                    Console.Write("Da ENTER para salir");
                    Console.ReadKey();
                    break;
                default:
                        Console.Clear();
                        Console.WriteLine("Opcion inexistente");
                        Console.ReadKey();
                        
                    break;
            }
        } while (opc != 3);
    }
}
}
