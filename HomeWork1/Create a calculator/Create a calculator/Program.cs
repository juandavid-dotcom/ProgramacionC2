

int typedOption = 0;

while (typedOption != 6)
{
    try
    {
        Console.WriteLine("Bienvenido a la Calculadora");
        Console.WriteLine("Elije lo que Deseas");
        Console.WriteLine("1. Suma");
        Console.WriteLine("2. Resta");
        Console.WriteLine("3. Multiplicacion");
        Console.WriteLine("4. Dividicion");
        Console.WriteLine("5. Evaluar al Estudiante");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opcion: ");

        typedOption = Convert.ToInt32(Console.ReadLine());

        switch (typedOption)
        {
            case 1:

            case 2:

            case 3:

            case 4:

              decimal[]typednumbers = new decimal[2];

              Console.WriteLine(" Escribe el primer numero");
                typednumbers[0] = Convert.ToDecimal(Console.ReadLine());

              Console.WriteLine(" Escribe el segundo nuemro");
                typednumbers[1]= Convert.ToDecimal(Console.ReadLine());

                int wantToContinue = 1;
                while (wantToContinue == 1)
                {
                    Console.WriteLine("Deseas agregar otro numero? (1=Si, 0=No)");
                    wantToContinue = Convert.ToInt32(Console.ReadLine());

                    if (wantToContinue == 1)
                    {
                        decimal[] newArray = new decimal[typednumbers.Length + 1];
                        for (int i = 0; i < typednumbers.Length; i++) newArray[i] = typednumbers[i];

                        Console.WriteLine(" Escribe el nuevo numero");
                        newArray[typednumbers.Length] = Convert.ToDecimal(Console.ReadLine());
                        typednumbers = newArray;
                    }
                }

                decimal result = typednumbers[0];

                switch (typedOption)
                {
                    case 1: 
                        for (int i= 1; i < typednumbers.Length; i++) result += typednumbers[i];

                    break;

                    case 2: 
                        for (int i= 1; i < typednumbers.Length; i++) result -= typednumbers[i];

                    break;

                    case 3: 
                        for (int i= 1; i < typednumbers.Length; i++) result *= typednumbers[i];

                    break;

                    case 4: 
                           for (int i= 1; i < typednumbers.Length; i++)
                           {
                               if (typednumbers[i] == 0)
                               {
                                Console.WriteLine(" Recuerda que no se puede dividir entre cero!");
                                result = 0;
                                break;
                               }
                               else
                               {
                                result /= typednumbers[i];
                               }
                           }
                    break;

                        
                }


                Console.WriteLine(" Total: " + result);
                break;

            case 5:


                decimal[] grades = new decimal[3];
                decimal average = 0;
                               
                Console.WriteLine("Escribe la primera nota:");
                grades[0] = Convert.ToDecimal(Console.ReadLine());

                while (grades [0] < 0 || grades[0] > 100)
                {
                    Console.WriteLine(" La nota esta fuera de rango. Escribe de (0-100)");
                    grades[0] = Convert.ToDecimal(Console.ReadLine());
                }

                Console.WriteLine("Escribe la segunda nota:");
                grades[1] = Convert.ToDecimal(Console.ReadLine());

                while (grades[1] < 0 || grades[1] > 100)
                {
                    Console.WriteLine(" La nota esta fuera de rango. Escribe de (0-100)");
                    grades[0] = Convert.ToDecimal(Console.ReadLine());
                }

                Console.WriteLine("Escribe la tercera nota:");
                grades[2] = Convert.ToDecimal(Console.ReadLine());

                while (grades[2] < 0 || grades[2] > 100)
                {
                    Console.WriteLine(" La nota esta fuera de rango. Escribe de (0-100)");
                    grades[0] = Convert.ToDecimal(Console.ReadLine());
                }

                average = (grades[0] + grades[1] + grades[2]) / 3;
 
                Console.WriteLine(" Calificacion : " + average);

                if (average >= 70)
                {  

                    Console.WriteLine("El estudiante ha Aprobado");

                }
                else
                {

                   Console.WriteLine("El estudiante ha Reprobado");

                }
                             


            break;


               
        }


    }
    catch
    {
        Console.WriteLine("Debes ingresar datos validos.");
        Console.ReadKey();
        
    }
}






