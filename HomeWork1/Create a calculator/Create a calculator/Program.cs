

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

            case 2:

            case 3:

            case 4:

              decimal[]numbers = new decimal[2];

              Console.WriteLine(" Escribe el primer numero");
              numbers[0] = Convert.ToDecimal(Console.ReadLine());

              Console.WriteLine(" Escribe el segundo nuemro");
              numbers[1]= Convert.ToDecimal(Console.ReadLine());

              decimal result = 0;

                 switch(option)
                {
                    case 1:
                        result=numbers[0] + numbers[1];
                        Console.WriteLine(" Total:" + result);
                        break;

                    case 2:
                        result=numbers[0] - numbers[1];
                        Console.WriteLine(" Total:" + result);
                        break;

                    case 3:
                        result=numbers[0] * numbers[1];
                        Console.WriteLine(" Total:" + result);
                        break;

                    case 4:
                        if(numbers[1] == 0)
                        {
                            Console.WriteLine(" Recuerda que no se puede dividir entre cero!");
                        }
                        else
                        {
                            result=numbers[0] / numbers[1];
                            Console.WriteLine(" Total:" + result);
                        }
                        break;
                }

                break;

                /*  switch (option)
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
                          break; */
        }


    }
    catch
    {
        Console.WriteLine("Debes ingresar datos validos.");
        Console.ReadKey();
        
    }
}






