

int option = 0;

while (option != 6)
{
    try
    {
        Console.WriteLine("Elije lo que Necesitas");
        Console.WriteLine("1. Suma");
        Console.WriteLine("2. Resta");
        Console.WriteLine("3. Multiplicacion");
        Console.WriteLine("4. Dividicion");
        Console.WriteLine("5. Evaluar al Estudiante");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opcion: ");

        option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                Console.WriteLine("Opcion Suma");
                break;

            case 2:
                Console.WriteLine("Opcion Resta");
                break;

            case 3:
                Console.WriteLine("Opcion Multiplicacion");
                break;

            case 4:
                Console.WriteLine("Opcion Dividicion");
                break;

            case 5:
                Console.WriteLine("Opcion Evaluar al Estudiante");
                break;

            case 6:
                Console.WriteLine("Programa finalizado.");
                break;

            default:
                Console.WriteLine("Opcion no valida.");
                break;
        }

        
    }
    catch
    {
        Console.WriteLine("Debes ingresar datos validos.");
        Console.ReadKey();
        
    }
}






