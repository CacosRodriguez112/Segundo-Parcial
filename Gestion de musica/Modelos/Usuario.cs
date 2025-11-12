namespace MusicManager.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public Dictionary<string, List<Cancion>> ListasReproduccion { get; set; }

        public Usuario(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) 
                throw new ArgumentException("Nombre no puede estar vacío.");
           
            Nombre = nombre;
            ListasReproduccion = new Dictionary<string, List<Cancion>>(StringComparer.OrdinalIgnoreCase);
        }

        public bool CrearListaReproduccion(string nombreLista, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(nombreLista))
            {
                mensaje = "El nombre de la lista no puede estar vacío.";
                return false;
            }

            if (ListasReproduccion.ContainsKey(nombreLista))
            {
                mensaje = $"La lista '{nombreLista}' ya existe.";
                return false;
            }

            ListasReproduccion[nombreLista] = new List<Cancion>();
            mensaje = $"Lista '{nombreLista}' creada correctamente.";
            return true;
        }

        public bool AgregarCancionALista(string nombreLista, Cancion cancion, out string mensaje)
        {
            if (cancion == null) throw new ArgumentNullException(nameof(cancion));

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
            if (ListasReproduccion.Count == 0) return "No hay listas de reproducción.";

            var sb = new System.Text.StringBuilder();
            foreach (var kv in ListasReproduccion)
            {
                sb.AppendLine($"Lista: {kv.Key}");
                if (kv.Value.Count == 0) sb.AppendLine("  (vacía)");
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