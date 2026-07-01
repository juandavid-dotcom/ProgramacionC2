List<int> ids = new List<int>();

Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, string> descriptions = new Dictionary<int, string>();
Dictionary<int, double> weights = new Dictionary<int, double>();
Dictionary<int, string> statuses = new Dictionary<int, string>();

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
            Console.WriteLine("Debe ingresar un numero del 1 al 6.");
            Console.ReadKey();
            continue;
        }

        switch (typeOption)
        {
            case 1:
                {
                    int id;

                    Console.Write("Ingrese el ID de la encomienda: ");

                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.Write("ID invalido. Intente nuevamente: ");
                    }

                    if (names.ContainsKey(id))
                    {
                        Console.WriteLine("Ese ID ya existe.");
                        break;
                    }

                    ids.Add(id);

                    Console.Write("Nombre del destinatario: ");
                    names.Add(id, Console.ReadLine());

                    Console.Write("Apellido del destinatario: ");
                    lastnames.Add(id, Console.ReadLine());

                    Console.Write("Correo electronico: ");
                    emails.Add(id, Console.ReadLine());

                    Console.Write("Dirección: ");
                    addresses.Add(id, Console.ReadLine());

                    int age;

                    Console.Write("Edad: ");

                    while (!int.TryParse(Console.ReadLine(), out age))
                    {
                        Console.Write("Edad invalida. Intente nuevamente: ");
                    }

                    ages.Add(id, age);

                    Console.Write("Descripción del paquete: ");
                    descriptions.Add(id, Console.ReadLine());

                    double weight;

                    Console.Write("Peso (kg): ");

                    while (!double.TryParse(Console.ReadLine(), out weight))
                    {
                        Console.Write("Peso invalido. Intente nuevamente: ");
                    }

                    weights.Add(id, weight);

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
                            statuses.Add(id, "Pendiente");
                            break;

                        case 2:
                            statuses.Add(id, "En Ruta");
                            break;

                        case 3:
                            statuses.Add(id, "Entregado");
                            break;
                    }

                    Console.WriteLine("¡Encomienda registrada correctamente!");
                }
                break;
            case 2:
                {
                    Console.Write("Ingrese el ID de la encomienda que desea modificar: ");

                    int id;

                    if (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }

                    if (!names.ContainsKey(id))
                    {
                        Console.WriteLine("¡Encomienda no encontrada!");
                        break;
                    }

                    Console.Write($"Nuevo nombre (Actual: {names[id]}): ");
                    names[id] = Console.ReadLine();

                    Console.Write("Nuevo apellido: ");
                    lastnames[id] = Console.ReadLine();

                    Console.Write("Nueva dirección: ");
                    addresses[id] = Console.ReadLine();

                    Console.Write("Nuevo email: ");
                    emails[id] = Console.ReadLine();

                    Console.Write("Nueva edad: ");

                    int age;

                    while (!int.TryParse(Console.ReadLine(), out age))
                    {
                        Console.Write("Edad inválida. Intente nuevamente: ");
                    }

                    ages[id] = age;

                    Console.Write("Nueva descripción del paquete: ");
                    descriptions[id] = Console.ReadLine();

                    Console.Write("Nuevo peso (kg): ");

                    double weight;

                    while (!double.TryParse(Console.ReadLine(), out weight))
                    {
                        Console.Write("Peso inválido. Intente nuevamente: ");
                    }

                    weights[id] = weight;

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
                            statuses[id] = "Pendiente";
                            break;

                        case 2:
                            statuses[id] = "En Ruta";
                            break;

                        case 3:
                            statuses[id] = "Entregado";
                            break;
                    }

                    Console.WriteLine("¡Encomienda actualizada correctamente!");
                }
                break;

            case 3:
                {
                    if (ids.Count == 0)
                    {
                        Console.WriteLine("No hay encomiendas registradas.");
                        break;
                    }

                    Console.WriteLine("\n---ID---Descripción--------Peso------Estado---------Destinatario-------Dirección----");

                    foreach (var id in ids)
                    {
                        Console.WriteLine($" {id}{descriptions[id]}\t{weights[id]} kg\t{statuses[id]}\t{names[id]} {lastnames[id]}\t{addresses[id]}");
                    }
                }
                break;

            case 4:
                {
                    Console.WriteLine("Buscar por:");
                    Console.WriteLine("1. ID");
                    Console.WriteLine("2. Estado");

                    int searchOp;

                    if (!int.TryParse(Console.ReadLine(), out searchOp))
                    {
                        Console.WriteLine("Opción inválida.");
                        break;
                    }

                    if (searchOp == 1)
                    {
                        Console.Write("Ingrese el ID: ");

                        int searchId;

                        if (!int.TryParse(Console.ReadLine(), out searchId))
                        {
                            Console.WriteLine("ID inválido.");
                            break;
                        }

                        if (names.ContainsKey(searchId))
                        {
                            Console.WriteLine($"ID: {searchId}");
                            Console.WriteLine($"Descripción: {descriptions[searchId]}");
                            Console.WriteLine($"Peso: {weights[searchId]} kg");
                            Console.WriteLine($"Estado: {statuses[searchId]}");
                            Console.WriteLine($"Destinatario: {names[searchId]} {lastnames[searchId]}");
                            Console.WriteLine($"Dirección: {addresses[searchId]}");
                            Console.WriteLine($"Email: {emails[searchId]}");
                            Console.WriteLine($"Edad: {ages[searchId]}");
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

                        foreach (var id in ids)
                        {
                            if (statuses[id].Equals(searchStatus, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"ID: {id} | {descriptions[id]} | {names[id]} {lastnames[id]} | {statuses[id]}");
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
                break;
            case 5:
                {
                    if (ids.Count == 0)
                    {
                        Console.WriteLine("No hay encomiendas registradas.");
                        break;
                    }

                    Console.Write("Ingrese el ID de la encomienda que desea eliminar: ");

                    int idToDelete;

                    if (!int.TryParse(Console.ReadLine(), out idToDelete))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }

                    if (names.ContainsKey(idToDelete))
                    {
                        ids.Remove(idToDelete);
                        names.Remove(idToDelete);
                        lastnames.Remove(idToDelete);
                        emails.Remove(idToDelete);
                        addresses.Remove(idToDelete);
                        ages.Remove(idToDelete);
                        descriptions.Remove(idToDelete);
                        weights.Remove(idToDelete);
                        statuses.Remove(idToDelete);

                        Console.WriteLine("\n¡Encomienda eliminada correctamente!");
                    }
                    else
                    {
                        Console.WriteLine("El ID ingresado no existe.");
                    }
                }
                break;

            case 6:
                {
                    running = false;
                    Console.WriteLine("\nCerrando el programa...");
                }
                break;

            default:
                {
                    Console.WriteLine("\nOpción inválida. Intente nuevamente.");
                }
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($" Ocurrio un error : {ex.Message}");
    }

    if (running)
    {
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}

Console.WriteLine("Aplicación finalizada. Presione una tecla para salir.");
Console.ReadKey();
