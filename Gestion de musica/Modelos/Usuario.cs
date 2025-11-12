namespace MusicManager.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public Dictionary<string, List<Cancion>> ListasReproduccion { get; set; }

        public Usuario(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) 
                throw new ArgumentException("Como?");
           
            Nombre = nombre;
            ListasReproduccion = new Dictionary<string, List<Cancion>>(StringComparer.OrdinalIgnoreCase);
        }

        public bool CrearListaReproduccion(string nombreLista, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(nombreLista))
            {
                mensaje = "Necesito un nombre de la lista.";
                return false;
            }

            if (ListasReproduccion.ContainsKey(nombreLista))
            {
                mensaje = $"La lista '{nombreLista}' ya existe.";
                return false;
            }

            ListasReproduccion[nombreLista] = new List<Cancion>(); 
            mensaje = $"Lista '{nombreLista}' creada mai.";
            return true;
        }

        public bool AgregarCancionALista(string nombreLista, Cancion cancion, out string mensaje)
        {
            if (cancion == null) 
                throw new ArgumentNullException("Nada");

            if (!ListasReproduccion.TryGetValue(nombreLista, out var lista))
            {
                mensaje = $"La lista '{nombreLista}' no existe.";
                return false;
            }

            lista.Add(cancion);
            mensaje = $"Canción '{cancion.Nombre}' agregada a la lista '{nombreLista}'.";
            return true;
        }

        public string MostrarListasReproduccion()
        {
            if (ListasReproduccion.Count == 0) 
                return "No hay listas de reproducción.";

            var sb = new System.Text.StringBuilder(); // Usar StringBuilder para eficiencia
            foreach (var kv in ListasReproduccion) // Iterar sobre cada par clave-valor en el diccionario
            {
                sb.AppendLine($"Lista: {kv.Key}"); // Nombre de la lista
                if (kv.Value.Count == 0) 
                    sb.AppendLine("NO");
                else
                {
                    foreach (var c in kv.Value)
                    {
                        sb.AppendLine("  " + c.ToString());
                    }
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}

//Prueba