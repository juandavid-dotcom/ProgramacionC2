






decimal temperatura;
int opcion;

Console.WriteLine("CONVERSOR DE TEMPERATURA");
Console.WriteLine("1. Celsius a Fahrenheit");
Console.WriteLine("2. Fahrenheit a Celsius");
Console.Write("Seleccione una opcion: ");

try
{
    opcion = Convert.ToInt32(Console.ReadLine());



    Console.Write("Ingrese la temperatura: ");
    temperatura = Convert.ToDecimal(Console.ReadLine());



    if (opcion == 1)
    {
        decimal fahrenheit = (temperatura * 9 / 5) + 32;
        Console.WriteLine("Resultado: " + fahrenheit + " °F");
    }
    else if (opcion == 2)
    {
        decimal celsius = (temperatura - 32) * 5 / 9;
        Console.WriteLine("Resultado: " + celsius + " °C");
    }
    else
    {
        Console.WriteLine("opcion no valida.");
    }



}
catch
{
    Console.WriteLine(" debe ingresar numeros validos");
}

Console.ReadKey();
