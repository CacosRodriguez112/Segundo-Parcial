using MusicManager.Models;
using MusicManager.Sevice;
using MusicManager.Gestores;

// 1- Inicialización
GestorCanciones gestor = new GestorCanciones();
ServicioMusica servicioMusica = new ServicioMusica(gestor);

gestor.AgregarCancion(new Cancion("Amor Eterno", "Rocío Dúrcal", 342));
gestor.AgregarCancion(new Cancion("El Rey", "Vicente Fernández", 182));
gestor.AgregarCancion(new Cancion("La Bikina", "Luis Miguel", 175));
gestor.AgregarCancion(new Cancion("Ojala que te mueras", "Panteón Rococó", 224));
gestor.AgregarCancion(new Cancion("Como la flor", "Selena", 193));
gestor.AgregarCancion(new Cancion("La ingrata", "Cafe Tacvba", 201));
gestor.AgregarCancion(new Cancion("Eres", "Cafe Tacvba", 258));
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
int contadorCancionesLista = 0; // Contador para las canciones en la lista actual

while (!salir)
{
    Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
    Console.WriteLine($"Usuario actual: {usuario.Nombre}");
    Console.WriteLine($"Lista actual: {nombreLista} ({contadorCancionesLista} canciones)");
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
            //Buscar canciones en el GESTOR (catálogo general)
            Console.Write("Ingrese el nombre de la canción a buscar: ");
            string Busqueda = Console.ReadLine() ?? "";

            var resultados = gestor.BuscarPorNombre(Busqueda);
            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron canciones con ese nombre.");
            }
            else
            {
                Console.WriteLine("\nResultados de búsqueda:");
                for (int i = 0; i < resultados.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {resultados[i].Nombre} - {resultados[i].Artista} ({resultados[i].DuracionSegundos}s)");
                }
                // Formato para SI y NO
                Console.Write("\nSeleccione el número de canción para agregar (0 para cancelar): ");
                if (int.TryParse(Console.ReadLine(), out int seleccion) && seleccion > 0 && seleccion <= resultados.Count)
                {

                    if (usuario.AgregarCancionALista(nombreLista, resultados[seleccion - 1], out string mensaje))
                    {
                        contadorCancionesLista++;
                        Console.WriteLine(mensaje);
                        Console.WriteLine($"Total en lista: {contadorCancionesLista}");
                    }
                    else
                    {
                        Console.WriteLine(mensaje);
                    }
                }
            }
            break;

        case "2":
            // Ver mi lista de reproducción ordenada por duración
            if (contadorCancionesLista == 0)
            {
                Console.WriteLine("La lista está vacía.");
            }
            else
            {
                // Obtener las canciones de la lista actual del usuario
                if (usuario.ListasReproduccion.TryGetValue(nombreLista, out var listaCanciones))
                {
                    // Crear copia de la lista para ordenamiento
                    List<Cancion> nuevaLista = new List<Cancion>(listaCanciones);

                    //Quicksort
                    Console.WriteLine("\nLista de reproducción ordenada por duración (QuickSort):");
                    gestor.QuickSort(nuevaLista, 0, nuevaLista.Count - 1);

                    //Mostra la lista ordenada
                    for (int i = 0; i < nuevaLista.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {nuevaLista[i].Nombre} - {nuevaLista[i].Artista} ({nuevaLista[i].DuracionSegundos}s)");
                    }

                    //Duración total
                    int duracionTotal = FunAux.CalcularDuracionTotal(nuevaLista);
                    Console.WriteLine($"\nDuración total: {duracionTotal} segundos ({duracionTotal / 60}:{duracionTotal % 60:D2} minutos)");
                }
                else
                {
                    Console.WriteLine("No se encontró la lista de reproducción.");
                }

            }
            break;

        case "3":

            Console.WriteLine("\n--- TODAS LAS CANCIONES DISPONIBLES ---");
            string cancionesDisponibles = gestor.MostrarCancionesDisponibles();
            Console.WriteLine(cancionesDisponibles);
            break;

        case "4":
            // Crear nueva lista de reproducción
            Console.Write("Ingrese el nombre para la nueva lista de reproducción: ");
            string nuevaListaNombre = Console.ReadLine() ?? "";

            if (usuario.CrearListaReproduccion(nuevaListaNombre, out string mensajeL))
            {
                Console.WriteLine(mensajeL);

                // Actualizar la lista actual a la nueva lista creada
                nombreLista = nuevaListaNombre;
                contadorCancionesLista = 0; // Reiniciar contador para la nueva lista
                Console.WriteLine($"Lista actual cambiada a: '{nombreLista}'");
            }
            else
            {
                Console.WriteLine(mensajeL);
            }
            break;

        case "5":
            // Cambiar de lista actual
            if (usuario.ListasReproduccion.Count == 0)
            {
                Console.WriteLine("No tienes listas de reproducción.");
            }
            else if (usuario.ListasReproduccion.Count == 1)
            {
                Console.WriteLine("Solo tienes una lista de reproducción.");
            }
            else
            {
                Console.WriteLine("Tus listas de reproducción:");
                int c = 1;
                foreach (var lista in usuario.ListasReproduccion)
                {
                    Console.WriteLine($"{c}. {lista.Key} ({lista.Value.Count} canciones)");
                    c++;
                }

                Console.Write("Seleccione el número de lista: ");
                if (int.TryParse(Console.ReadLine(), out int seleccionLista) &&
                    seleccionLista > 0 && seleccionLista <= usuario.ListasReproduccion.Count)
                {
                    // Nombre de la lista seleccionada
                    nombreLista = usuario.ListasReproduccion.Keys.ElementAt(seleccionLista - 1);

                    // Actualziar contador de canciones
                    contadorCancionesLista = usuario.ListasReproduccion[nombreLista].Count;

                    Console.WriteLine($"Lista actual cambiada a: '{nombreLista}' ({contadorCancionesLista} canciones)");
                }
                else
                {
                    Console.WriteLine("Selección no válida.");
                }
            }
            break;

        case "6":
            salir = true;
            break;
        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            break;
    }
}
public class FunAux
{
    public static int CalcularDuracionTotal(List<Cancion> canciones)
    {
        int duracionTotal = 0;
        foreach (var cancion in canciones)
        {
            duracionTotal += cancion.DuracionSegundos;
        }
        return duracionTotal;
    }
}