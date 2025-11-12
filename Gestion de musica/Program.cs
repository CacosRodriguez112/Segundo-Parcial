using MusicManager.Models;
using MusicManager.Sevice;
using MusicManager.Gestores;


// 1- Inicialización
GestorCanciones gestor = new GestorCanciones();
ServicioMusica servicioMusica = new ServicioMusica(gestor);

gestor.AgregarCancion(new Cancion("Amor Eterno", "Rocío Dúrcal", 342));
gestor.AgregarCancion(new Cancion("El Rey", "Vicente Fernández", 182));
gestor.AgregarCancion(new Cancion("La Bikina", "Luis Miguel", 175));
gestor.AgregarCancion(new Cancion("Ojalá que te mueras", "Panteón Rococó", 224));
gestor.AgregarCancion(new Cancion("Como la flor", "Selena", 193));
gestor.AgregarCancion(new Cancion("La ingrata", "Café Tacvba", 201));
gestor.AgregarCancion(new Cancion("Eres", "Café Tacvba", 258));
gestor.AgregarCancion(new Cancion("Si nos dejan", "Luis Miguel", 156));


// 2- Registro Usuario
Console.WriteLine("--- REGISTRO DE USUARIO ---");
Console.Write("Por favor, ingrese su nombre de usuario: ");

string nombreUsuario = Console.ReadLine() ?? "";

servicioMusica.RegistrarUsuario(nombreUsuario);
Console.WriteLine($"\n¡Bienvenido, {nombreUsuario}!");


//3- Creación Lista
Console.Write("\nIngrese el nombre de su primera lista de reproducción: ");

string nombreLista = Console.ReadLine() ?? "";

Usuario usuario = servicioMusica.BuscarUsuario(nombreUsuario);
if (usuario.CrearListaReproduccion(nombreLista, out string mensajeLista))
{
    Console.WriteLine(mensajeLista);
}
else
{
    Console.WriteLine(mensajeLista);
    nombreLista = "Lista por defecto";
    usuario.CrearListaReproduccion(nombreLista, out _);
    Console.WriteLine($"Se ha creado una lista por defecto llamada '{nombreLista}'.");
}


// 4- Menu Principal
bool salir = false;

while (!salir)
{
    Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
    Console.WriteLine($"Usuario actual: {usuario.Nombre}");
    Console.WriteLine($"Lista actual: {nombreLista} ({gestor.CancionesDisponibles.Count} canciones)");
    Console.WriteLine("1. Buscar canciones para agregar a mi lista");
    Console.WriteLine("2. Ver mi lista de reproducción (ordenada por duración)");
    Console.WriteLine("3. Ver todas las canciones disponibles");
    Console.WriteLine("4. Crear nueva lista de reproducción");
    Console.WriteLine("5. Cambiar de lista actual");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");

    string opcion = Console.ReadLine() ?? "";

    switch (opcion)
    {
        case "1":
            
            break;
        case "2":
           
            break;
        case "3":
        
            break;
        case "4":
      
            break;
        case "5":
        
            break;
        case "6":
            salir = true;
            break;
        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            break;
    }
}








