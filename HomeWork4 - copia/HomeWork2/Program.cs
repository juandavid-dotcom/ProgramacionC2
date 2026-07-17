using HomeWork2.Data;
using HomeWork2.Data.Entity;


var dataContext = new DataContext();

List<Person> persons = dataContext.People.ToList();
persons = dataContext.People.ToList();

bool running = true;
int typeOption;


while (running)
{
    try
    {
        Console.WriteLine("SISTEMA DE REGISTRO DE ENCOMIENDAS");
        Console.WriteLine("1. Registrar Nueva Encomienda");
        Console.WriteLine("2. Modificar Encomienda");
        Console.WriteLine("3. Listar Todas las Encomiendas");
        Console.WriteLine("4. Buscar Encomienda");
        Console.WriteLine("5. Eliminar Encomienda");
        Console.WriteLine("6. Salir");

        Console.Write("Seleccione una opción: ");


        if (!int.TryParse(Console.ReadLine(), out typeOption))
        {
            Console.WriteLine("Debe ingresar un número válido.");
            continue;
        }


        switch (typeOption)
        {
            case 1:
                RegisterPackage(persons, dataContext);
                break;

            case 2:
                UpdatePackage(persons, dataContext);
                break;

            case 3:
                ListPackages(dataContext);
                break;

            case 4:
                SearchPackage(dataContext);
                break;

            case 5:
                DeletePackage(persons, dataContext);
                break;

            case 6:
                running = false;
                Console.WriteLine("Programa cerrado.");
                break;

            default:
                Console.WriteLine("Opción inválida.");
                break;
        }


        if (running)
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        
    }

}
static void RegisterPackage(List<Person> persons, DataContext dataContext)
{

    Person person = new Person();

    Console.Write("Nombre del destinatario: ");
    person.names = Console.ReadLine();

    Console.Write("Apellido del destinatario: ");
    person.lastnames = Console.ReadLine();

    Console.Write("Correo electrónico: ");
    person.emails = Console.ReadLine();

    Console.Write("Dirección: ");
    person.addresses = Console.ReadLine();

    Console.Write("Edad: ");

    int age;

    while (!int.TryParse(Console.ReadLine(), out age))
    {
        Console.Write("Edad inválida: ");
    }

    person.ages = age;

    Console.Write("Descripción del paquete: ");
    person.descriptions = Console.ReadLine();

    Console.Write("Peso (kg): ");

    double weight;

    while (!double.TryParse(Console.ReadLine(), out weight))
    {
        Console.Write("Peso inválido: ");
    }

    person.weights = weight;

    Console.WriteLine("Estado del paquete");
    Console.WriteLine("1. Pendiente");
    Console.WriteLine("2. En Ruta");
    Console.WriteLine("3. Entregado");

    int statusOp;

    while (!int.TryParse(Console.ReadLine(), out statusOp)
        || statusOp < 1
        || statusOp > 3)
    {
        Console.Write("Seleccione 1, 2 o 3: ");
    }

    switch (statusOp)
    {
        case 1:
            {
                person.statuses = "Pendiente";
            }
        break;

        case 2:
            {
                person.statuses = "En Ruta";
            }
         break;

        case 3:
           {
                person.statuses = "Entregado";
           }
        break;
    }

    persons.Add(person);

    dataContext.People.Add(person);

    dataContext.SaveChanges();
    Console.WriteLine($"¡Encomienda registrada correctamente! ID asignado: {person.ids}");

    Console.WriteLine("¡Encomienda registrada correctamente!");
}
static void UpdatePackage(List<Person> persons, DataContext dataContext)
{
    Console.Write("Ingrese el ID de la encomienda que desea modificar: ");

    int id;


    if (!int.TryParse(Console.ReadLine(), out id))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    Person person = persons.FirstOrDefault(p => p.ids == id);

    if (person == null)
    {
        Console.WriteLine("No se encontró la encomienda.");
        return;
    }

    Console.Write($"Nuevo nombre ({person.names}): ");
    person.names = Console.ReadLine();

    Console.Write($"Nuevo apellido ({person.lastnames}): ");
    person.lastnames = Console.ReadLine();

    Console.Write($"Nuevo correo ({person.emails}): ");
    person.emails = Console.ReadLine();

    Console.Write($"Nueva dirección ({person.addresses}): ");
    person.addresses = Console.ReadLine();

    Console.Write("Nueva edad: ");

    int age;


    while (!int.TryParse(Console.ReadLine(), out age))
    {
        Console.Write("Edad inválida: ");
    }

    person.ages = age;

    Console.Write("Nueva descripción: ");
    person.descriptions = Console.ReadLine();

    Console.Write("Nuevo peso: ");

    double weight;

    while (!double.TryParse(Console.ReadLine(), out weight))
    {
        Console.Write("Peso inválido: ");
    }

    person.weights = weight;

    Console.WriteLine("Nuevo estado:");
    Console.WriteLine("1. Pendiente");
    Console.WriteLine("2. En Ruta");
    Console.WriteLine("3. Entregado");


    int statusOp;

    while (!int.TryParse(Console.ReadLine(), out statusOp)
        || statusOp < 1
        || statusOp > 3)
    {
        Console.Write("Seleccione 1, 2 o 3: ");
    }

    switch (statusOp)
    {

        case 1:
            person.statuses = "Pendiente";
            break;


        case 2:
            person.statuses = "En Ruta";
            break;


        case 3:
            person.statuses = "Entregado";
            break;

    }

    dataContext.SaveChanges();


    Console.WriteLine("¡Encomienda modificada correctamente!");

}
static void ListPackages(DataContext dataContext)
{
    List<Person> persons = dataContext.People.ToList();

    if (persons.Count == 0)
    {
        Console.WriteLine("No existen encomiendas.");
        return;
    }

    Console.WriteLine("LISTA DE ENCOMIENDAS");
    
    foreach (Person person in persons)
    {

        Console.WriteLine($"ID: {person.ids}");
        Console.WriteLine($"Destinatario: {person.names} {person.lastnames}");
        Console.WriteLine($"Email: {person.emails}");
        Console.WriteLine($"Dirección: {person.addresses}");
        Console.WriteLine($"Edad: {person.ages}");
        Console.WriteLine($"Descripción: {person.descriptions}");
        Console.WriteLine($"Peso: {person.weights} kg");
        Console.WriteLine($"Estado: {person.statuses}");
     
    }

}
static void SearchPackage(DataContext dataContext)
{

    List<Person> persons = dataContext.People.ToList();

    Console.WriteLine("Buscar encomienda por:");
    Console.WriteLine("1. ID");
    Console.WriteLine("2. Estado");

    Console.Write("Seleccione una opción: ");


    int option;


    if (!int.TryParse(Console.ReadLine(), out option))
    {
        Console.WriteLine("Opción inválida.");
        return;
    }

    if (option == 1)
    {

        Console.Write("Ingrese el ID: ");


        int id;


        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }



        Person person = persons.FirstOrDefault(p => p.ids == id);



        if (person == null)
        {
            Console.WriteLine("No se encontró la encomienda.");
            return;
        }

        Console.WriteLine("\nDATOS DE LA ENCOMIENDA");
        Console.WriteLine($"ID: {person.ids}");
        Console.WriteLine($"Nombre: {person.names} {person.lastnames}");
        Console.WriteLine($"Email: {person.emails}");
        Console.WriteLine($"Dirección: {person.addresses}");
        Console.WriteLine($"Edad: {person.ages}");
        Console.WriteLine($"Descripción: {person.descriptions}");
        Console.WriteLine($"Peso: {person.weights} kg");
        Console.WriteLine($"Estado: {person.statuses}");

    }

    else if (option == 2)
    {

        Console.Write("Ingrese el estado (Pendiente, En Ruta, Entregado): ");


        string status = Console.ReadLine();

        var results = persons
            .Where(p => p.statuses.Equals(status, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("No existen encomiendas con ese estado.");
            return;
        }

        foreach (Person person in results)
        {
            Console.WriteLine($"ID: {person.ids}");
            Console.WriteLine($"Descripción: {person.descriptions}");
            Console.WriteLine($"Destinatario: {person.names} {person.lastnames}");
            Console.WriteLine($"Estado: {person.statuses}");

        }

    }

    else
    {
        Console.WriteLine("Opción inválida.");
    }

}
static void DeletePackage(List<Person> persons, DataContext dataContext)
{

    Console.Write("Ingrese el ID de la encomienda que desea eliminar: ");
    int id;

    if (!int.TryParse(Console.ReadLine(), out id))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    Person person = persons.FirstOrDefault(p => p.ids == id);

    if (person == null)
    {
        Console.WriteLine("No se encontró la encomienda.");
        return;
    }

    persons.Remove(person);
    dataContext.People.Remove(person);


    dataContext.SaveChanges();

    Console.WriteLine("¡Encomienda eliminada correctamente!");

}