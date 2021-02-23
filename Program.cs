using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lista_Circulares
{
    class Nodo  //creamos una clase Nodo
    {
        private int Dato;//Los nodos almacenaran un valor entero, para este ejemplo sera datos
        private Nodo Siguiente;//Declaramos el puntero al siguiente nodo


        public int dato //Ahora pasamos al encapsulamiento, lo cual permite obtener y establecer los valores para los nodos
        {
            get { return Dato; }
            set { Dato = value; }
        }

        public Nodo siguiente //Hacemos lo mismo para el puntero
        {
            get { return Siguiente; }
            set { Siguiente = value; }
        }
        
    }

    class Lista  //creamos la clase Lista y pasamos a definir un inicio y un final para esta
    {
        private Nodo primero = new Nodo(); //declaramos la cabeza o inicio de la lista de tipo nodo
        private Nodo ultimo = new Nodo (); //declaramos la cola o final de la lista 

        public Lista()
        {
            //pasaos a inicializar tanto la cabeza como la cola en valor nulo
            primero = null;
            ultimo = null;

        }

        public void insertarnodo() //luego construimos el metodo Insertar nodo
        {
            Nodo nuevo = new Nodo();
            // con esta sentencia, pediremos los valores para nuestros nodos
            Console.Write(" Ingrese dato del nuevo nodo: ");

            //esta sentencia convierte a enteros los valores ingresados para los nodos
            nuevo.dato = int.Parse(Console.ReadLine());

            //colocamos una condicional, si la cabeza de la lista es null, entonces tomara el valor insertado
            if(primero == null)
            {
                primero = nuevo;
                primero.siguiente = primero;  // el puntero apunta al siguiente nodo en la lista que en este caso es la cabeza porque no hay mas nodos
                ultimo = primero; //la cabeza es la cola por ser el unico nodo hasta el momento

            }
            else
            {
                ultimo.siguiente = nuevo;  // si no la cabeza es diferente de null entonces el puntero apuntara al nuevo valor ingresado
                nuevo.siguiente = primero; //el nuevo valor ingresado apunta a la cabeza de la lista
                ultimo = nuevo;   // ahora la cola es el nuevo valor ingresado.

            }

            Console.WriteLine("\n Nodo ingresado con Existo\n");

        }

        public void desplegarlista()//construccion del metodo para desplegar la lista
        {
            Nodo actual = new Nodo();//para comezar a recorrer la lista declaramos un nodo actual
            actual = primero;  //el nodo actual sera la cabeza porque desde ahi iniciamos a recorrer la lista
            
            if(actual != null)
            {
                do
                {
                  Console.WriteLine(" " + actual.dato);  //recorremos la lista y vamos imprimiendo los valores de los nodos siempe que el nodo actual sea diferente de null
                  actual = actual.siguiente;
                } while (actual != primero);
            }
            else
            {
                Console.WriteLine("\n la lista se encuentra vacia");
            }
        }

        public void BuscarNodo() // metodo buscar
    
        {

            Nodo actual = new Nodo();
            actual = primero;
            bool encontrado = false;
            Console.Write(" Ingrese el valor del Nodo a buscar: ");
            int nodoBuscado = int.Parse(Console.ReadLine());
            if (actual != null)
            {
                do
                {
                    if(actual.dato == nodoBuscado)
                    {
                        Console.WriteLine("\n Nodo con el dato ({0}) encontrado\n ", actual.dato);
                        encontrado = true;

                    }
                    actual = actual.siguiente;
                }
                while (actual != primero && encontrado != true);
                if (!encontrado)
                {
                    Console.WriteLine("\n Nodo no encontrado\n");
                }

            
            }
            else
            {
                Console.WriteLine("\n La lista se encuentra vacia");
            }
        
        }

        public void ModificarNodo()
        {
        Nodo actual = new Nodo();
        actual = primero;
        bool encontrado = false;
        Console.Write(" Ingrese el valor del Nodo a modificar: ");
        int nodoBuscado = int.Parse(Console.ReadLine());
        if (actual != null)
        {
            do
            {
                if (actual.dato == nodoBuscado)
                {
                    Console.WriteLine("\n Nodo con el dato ({0}) encontrado\n", actual.dato);
                    Console.WriteLine(" Ingrese el nuevo dato para el nodo: ");
                    actual.dato = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n Nodo modificaco con exito\n");
                    encontrado = true;

                }
                actual = actual.siguiente;
            } 
            while (actual != primero && encontrado != true);
            if (!encontrado)
            {
                Console.WriteLine("\n Nodo no encontrado\n");
            }    
            
        }
        else
        {
            Console.WriteLine("\n La lista se encuentra vacia ");
        }
    }    

    public void EliminarNodo()
    {
        Nodo actual = new Nodo();
        actual = primero;
        Nodo anterior = new Nodo();
        anterior = null;
        bool encontrado = false;
        Console.Write(" Ingrese el valor del Nodo a eliminar: ");
        int nodoBuscado = int.Parse(Console.ReadLine());
        if (actual != null)
        {
            do
            {
                if (actual.dato == nodoBuscado)
                {
                  
                    if (actual == primero)
                    {
                        primero = primero.siguiente;
                        ultimo.siguiente = primero;

                    }else if(actual == ultimo)
                    {
                        anterior.siguiente = primero;
                        ultimo = anterior;

                    }
                    else
                    {
                        anterior.siguiente = actual.siguiente;
                    }

                    encontrado = true;

                }
                anterior = actual;
                actual = actual.siguiente;
            } 
            while (actual != primero && encontrado != true);
            if (!encontrado)
            {
            Console.WriteLine("\n Nodo no encontrado\n");
            }

            
        }
        else
        {
            Console.WriteLine("\n La lista se encuentra vacia");
        }
    }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Lista l = new Lista(); // intancias de la clase lista
            // opcion menu es para realizar un menu simple por consola
            int opcionmenu = 0;

            do
            {
                Console.WriteLine("\n |-------------------------------------|");
                Console.WriteLine(" |    ~ LISTA CIRCULARES SIMPLE ~      |");
                Console.WriteLine(" |----------------|--------------------|");
                Console.WriteLine(" | 1. Insertar    | 4. Eliminar        |");
                Console.WriteLine(" | 2. Buscar      | 5. Desplegar       |");
                Console.WriteLine(" | 3. Modificar   | 6. Salir           |");
                Console.WriteLine(" |________________|____________________|");
                Console.WriteLine(" Escoje una Opcion: ");

                
                opcionmenu = int.Parse(Console.ReadLine());

                switch (opcionmenu)
                {
                    case 1:
                        Console.WriteLine("\n Inserta nodo en la lista \n");
                        l.insertarnodo();
                    break;
                    case 2:
                        Console.WriteLine("\n Buscar un nodo en la lista \n");
                        l.BuscarNodo();
                    break;
                    case 3:
                        Console.WriteLine("\n Modificar un nodo de la lista \n");
                        l.ModificarNodo();
                    break;

                    case 4:
                        Console.WriteLine("\n Eliminar un nodo en la lista \n");
                        l.EliminarNodo();
                    break;

                    case 5:
                        Console.WriteLine("\n Elementos de la lista \n");
                        l.desplegarlista();
                    break;
                }
            }
            while (opcionmenu != 6);

            Console.ReadKey();
        }
    }
}
