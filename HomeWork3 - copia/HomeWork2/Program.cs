/*List<int> ids = new List<int>();

Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, string> descriptions = new Dictionary<int, string>();
Dictionary<int, double> weights = new Dictionary<int, double>();
Dictionary<int, string> statuses = new Dictionary<int, string>();*/


using HomeWork2;

List<Person> persons = new List<Person>();

bool running = true;
int typeOption = 0;

while (running)
{
    try
    {
        Console.WriteLine("SISTEMA DE REGISTRO DE ENCOMIENDAS ");
        Console.WriteLine("1. Registrar Nueva Encomienda");
        Console.WriteLine("2. Modificar Encomienda");
        Console.WriteLine("3. Listar Todas las Encomiendas");
        Console.WriteLine("4. Buscar Encomienda");
        Console.WriteLine("5. Eliminar Encomienda");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out typeOption))
        {
            Console.WriteLine("Debe ingresar un número del 1 al 6.");
            Console.ReadKey();
            continue;
        }

        switch (typeOption)
        {
            case 1:
                RegisterPackage(persons);
                break;

            case 2:
                UpdatePackage(persons);
                break;

            case 3:
                ListPackages(persons);
                break;

            case 4:
                SearchPackage(persons);
                break;

            case 5:
                DeletePackage(persons);
                break;

            case 6:
                running = false;
                Console.WriteLine("\nCerrando el programa...");
                break;

            default:
                Console.WriteLine("\nOpción inválida.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocurrió un error: {ex.Message}");
    }

    if (running)
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }
}

Console.WriteLine("Aplicación finalizada.");
Console.ReadKey();

static void RegisterPackage(List<Person> persons)
{
    Person person = new Person();

    Console.Write("Ingrese el ID de la encomienda: ");

    while (!int.TryParse(Console.ReadLine(), out person.ids))
    {
        Console.Write("ID inválido. Intente nuevamente: ");
    }

    if (persons.Exists(p => p.ids == person.ids))
    {
        Console.WriteLine("Ese ID ya existe.");
        return;
    }

    Console.Write("Nombre del destinatario: ");
    person.names = Console.ReadLine();

    Console.Write("Apellido del destinatario: ");
    person.lastnames = Console.ReadLine();

    Console.Write("Correo electrónico: ");
    person.emails = Console.ReadLine();

    Console.Write("Dirección: ");
    person.addresses = Console.ReadLine();

    Console.Write("Edad: ");

    while (!int.TryParse(Console.ReadLine(), out int age))
    {
        Console.Write("Edad inválida. Intente nuevamente: ");
    }

    person.ages = age;

    Console.Write("Descripción del paquete: ");
    person.descriptions = Console.ReadLine();

    Console.Write("Peso (kg): ");

    while (!double.TryParse(Console.ReadLine(), out double weight))
    {
        Console.Write("Peso inválido. Intente nuevamente: ");
    }

    person.weights = weight;

    int statusOp;

    Console.WriteLine("Estado del paquete");
    Console.WriteLine("1. Pendiente");
    Console.WriteLine("2. En Ruta");
    Console.WriteLine("3. Entregado");
    Console.Write("Seleccione: ");

    while (!int.TryParse(Console.ReadLine(), out statusOp) || statusOp < 1 || statusOp > 3)
    {
        Console.Write("Opción inválida. Seleccione 1, 2 o 3: ");
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

    persons.Add(person);

    Console.WriteLine("¡Encomienda registrada correctamente!");
}

static void UpdatePackage(List<Person> persons)
{
    Console.Write("Ingrese el ID de la encomienda que desea modificar: ");

    int id;

    if (!int.TryParse(Console.ReadLine(), out id))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    Person person = persons.Find(p => p.ids == id);

    if (person == null)
    {
        Console.WriteLine("¡Encomienda no encontrada!");
        return;
    }

    Console.Write($"Nuevo nombre (Actual: {person.names}): ");
    person.names = Console.ReadLine();

    Console.Write("Nuevo apellido: ");
    person.lastnames = Console.ReadLine();

    Console.Write("Nueva dirección: ");
    person.addresses = Console.ReadLine();

    Console.Write("Nuevo email: ");
    person.emails = Console.ReadLine();

    Console.Write("Nueva edad: ");

    int age;

    while (!int.TryParse(Console.ReadLine(), out age))
    {
        Console.Write("Edad inválida. Intente nuevamente: ");
    }

    person.ages = age;

    Console.Write("Nueva descripción del paquete: ");
    person.descriptions = Console.ReadLine();

    Console.Write("Nuevo peso (kg): ");

    double weight;

    while (!double.TryParse(Console.ReadLine(), out weight))
    {
        Console.Write("Peso inválido. Intente nuevamente: ");
    }

    person.weights = weight;

    Console.WriteLine("Seleccione el nuevo estado:");
    Console.WriteLine("1. Pendiente");
    Console.WriteLine("2. En Ruta");
    Console.WriteLine("3. Entregado");

    int statusOp;

    while (!int.TryParse(Console.ReadLine(), out statusOp) || statusOp < 1 || statusOp > 3)
    {
        Console.Write("Seleccione una opción válida (1-3): ");
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

    Console.WriteLine("¡Encomienda actualizada correctamente!");
}

static void ListPackages(List<Person> persons)
{
    if (persons.Count == 0)
    {
        Console.WriteLine("No hay encomiendas registradas.");
        return;
    }

    
    Console.WriteLine("ID\tDescripción\tPeso\tEstado\t\tDestinatario\tDirección");
    

    foreach (Person person in persons)
    {
        Console.WriteLine($"{person.ids}\t{person.descriptions}\t{person.weights} kg\t{person.statuses}\t{person.names} {person.lastnames}\t{person.addresses}");
    }
}

static void SearchPackage(List<Person> persons)
{
    Console.WriteLine("Buscar por:");
    Console.WriteLine("1. ID");
    Console.WriteLine("2. Estado");
    Console.Write("Seleccione una opción: ");

    int searchOp;

    if (!int.TryParse(Console.ReadLine(), out searchOp))
    {
        Console.WriteLine("Opción inválida.");
        return;
    }

    if (searchOp == 1)
    {
        Console.Write("Ingrese el ID: ");

        int searchId;

        if (!int.TryParse(Console.ReadLine(), out searchId))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        Person person = persons.Find(p => p.ids == searchId);

        if (person != null)
        {
            Console.WriteLine("ENCOMIENDA");
            Console.WriteLine($"ID: {person.ids}");
            Console.WriteLine($"Descripcion: {person.descriptions}");
            Console.WriteLine($"Peso: {person.weights} kg");
            Console.WriteLine($"Estado: {person.statuses}");
            Console.WriteLine($"Destinatario: {person.names} {person.lastnames}");
            Console.WriteLine($"Dirección: {person.addresses}");
            Console.WriteLine($"Email: {person.emails}");
            Console.WriteLine($"Edad: {person.ages}");
        }
        else
        {
            Console.WriteLine("Encomienda no encontrada.");
        }
    }
    else if (searchOp == 2)
    {
        Console.Write("Ingrese el estado (Pendiente, En Ruta o Entregado): ");
        string searchStatus = Console.ReadLine();

        bool found = false;

        foreach (Person person in persons)
        {
            if (person.statuses.Equals(searchStatus, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"{person.ids} | {person.descriptions} | {person.names} {person.lastnames} | {person.statuses}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No se encontraron encomiendas con ese estado.");
        }
    }
    else
    {
        Console.WriteLine("Opción inválida.");
    }
}

static void DeletePackage(List<Person> persons)
{
    if (persons.Count == 0)
    {
        Console.WriteLine("No hay encomiendas registradas.");
        return;
    }

    Console.Write("Ingrese el ID de la encomienda que desea eliminar: ");

    int idToDelete;

    if (!int.TryParse(Console.ReadLine(), out idToDelete))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    Person person = persons.Find(p => p.ids == idToDelete);

    if (person != null)
    {
        persons.Remove(person);
        Console.WriteLine("\n¡Encomienda eliminada correctamente!");
    }
    else
    {
        Console.WriteLine("El ID ingresado no existe.");
    }
}