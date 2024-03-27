namespace Punto
{
    using System;

    public class Program
    {
        private static Empleado[] empleados;
        private static int contadorEmpleados = 0;

        public static void Main(string[] args)
        {
            empleados = new Empleado[10];

            int opcion;
            do
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Ingresar nuevo empleado");
                Console.WriteLine("2. Modificar salario básico mensual");
                Console.WriteLine("3. Ingresar cantidad de horas extras");
                Console.WriteLine("4. Ingresar deducción y bonificación");
                Console.WriteLine("5. Obtener planilla de pagos");
                Console.WriteLine("6. Salir");
                Console.Write("Ingrese su opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Ingresar();
                        break;
                    case 2:
                        Salariob();
                        break;
                    case 3:
                        Horaextra();
                        break;
                    case 4:
                        DeduBon();
                        break;
                    case 5:
                        Planilla();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del programa.");
                        break;
                    case 7:
                        if (opcion > 6 | opcion < 1)
                        {
                            Console.WriteLine("Opción no válida.");
                        }
                            break;
                }
            } while (opcion != 6);
        }

        public static void Ingresar()
        {
            Console.Write("Ingrese el código del empleado: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el nombre del empleado: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el salario básico del empleado: ");
            double salariobasico = double.Parse(Console.ReadLine());

            empleados[contadorEmpleados++] = new Empleado(codigo, nombre, salariobasico);
            Console.WriteLine("Empleado ingresado correctamente.");
        }

        public static void Salariob()
        {
            Console.Write("Ingrese el código del empleado: ");
            int codigo = int.Parse(Console.ReadLine());

            Empleado empleado = BuscarEmpleado(codigo);
            if (empleado != null)
            {
                Console.Write("Ingrese el nuevo salario básico: ");
                double salariobasico = double.Parse(Console.ReadLine());
                empleado.SalarioBasico = salariobasico;
                Console.WriteLine("Salario básico modificado correctamente.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }


        public static void Horaextra()
        {
            Console.Write("Ingrese el código del empleado: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Ingrese la cantidad de horas extras: ");
            int horasExtras = int.Parse(Console.ReadLine());

            Empleado empleado = BuscarEmpleado(codigo);
            if (empleado != null)
            {
                empleado.HorasExtras = horasExtras;
                Console.WriteLine("Horas extras ingresadas correctamente.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public static void DeduBon()
        {
            Console.Write("Ingrese el código del empleado: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Ingrese la deducción: ");
            double deduccion = double.Parse(Console.ReadLine());
            Console.Write("Ingrese la bonificación: ");
            double bonificacion = double.Parse(Console.ReadLine());

            Empleado empleado = BuscarEmpleado(codigo);
            if (empleado != null)
            {
                empleado.Deducciones = deduccion;
                empleado.Bonificacion = bonificacion;
                Console.WriteLine("Deducción y bonificación ingresadas correctamente.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public static void Planilla()
        {
            Console.WriteLine("Planilla de pagos:");
            for (int i = 0; i < contadorEmpleados; i++)
            {
                double salarioTotal = empleados[i].CalcularSalarioTotal();
                Console.WriteLine($"Empleado: {empleados[i].Nombre}, Salario Total: {salarioTotal}");
            }
        }

        public static Empleado BuscarEmpleado(int codigo)
        {
            for (int i = 0; i < contadorEmpleados; i++)
            {
                if (empleados[i].Codigo == codigo)
                {
                    return empleados[i];
                }
            }
            return null;
        }
    }

}