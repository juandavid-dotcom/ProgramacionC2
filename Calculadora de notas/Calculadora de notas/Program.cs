

decimal nota;

Console.WriteLine("Calculadora de notas");
Console.Write("Ingrese una calificacion ");

try
{
    nota = Convert.ToDecimal(Console.ReadLine());

    if (nota < 0 || nota > 100)
    {
        Console.WriteLine("La nota debe estar entre 0 y 100.");
    }
    else if (nota >= 90)
    {
        Console.WriteLine("Calificaci0n : A");
    }
    else if (nota >= 80)
    {
        Console.WriteLine("Calificacion : B");
    }
    else if (nota >= 70)
    {
        Console.WriteLine("Calificacion: C ");
    }
    else if (nota >= 60)
    {
        Console.WriteLine("Calificacion: D ");
    }
    else
    {
        Console.WriteLine("Calificacion : F");
    }
}
catch
{
    Console.WriteLine("Debe ingresar un número válido.");
}

Console.ReadKey();







