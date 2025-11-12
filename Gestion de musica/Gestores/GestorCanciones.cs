using MusicManager.Models;

namespace MusicManager.Gestores
{
    public class GestorCanciones
    {
        public List<Cancion> CancionesDisponibles { get; set; }

        public GestorCanciones()
        {
            CancionesDisponibles = new List<Cancion>();
        }

        public void AgregarCancion(Cancion cancion)
        {
            if (cancion == null) 
                throw new ArgumentNullException("");

            CancionesDisponibles.Add(cancion);
        }

        public List<Cancion> BuscarPorNombre(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino)) 
                return new List<Cancion>();

            return CancionesDisponibles
                .Where(c => c.Nombre.IndexOf(termino, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        // QuickSort por DuracionSegundos (ascendente)
        public void QuickSort(List<Cancion> lista, int low, int high)
        {
            if (lista == null) 
                throw new ArgumentNullException("");

            if (low < 0 || high >= lista.Count) { /* permitir que se use con (0, Count-1) normalmente */ }

            if (low < high)
            {
                int pi = Partition(lista, low, high);
                QuickSort(lista, low, pi - 1);
                QuickSort(lista, pi + 1, high);
            }
        }

        private int Partition(List<Cancion> lista, int low, int high)
        {
            var pivot = lista[high].DuracionSegundos;
            int i = low - 1;
            for (int j = low; j <= high - 1; j++)
            {
                if (lista[j].DuracionSegundos <= pivot)
                {
                    i++;
                    Swap(lista, i, j);
                }
            }
            Swap(lista, i + 1, high);
            return i + 1;
        }

        private void Swap(List<Cancion> lista, int i, int j)
        {
            var temp = lista[i];
            lista[i] = lista[j];
            lista[j] = temp;
        }

        public string MostrarCancionesDisponibles()
        {
            if (CancionesDisponibles.Count == 0) 
                return "No hay canciones disponibles.";

            var sb = new System.Text.StringBuilder(); // Usar StringBuilder para eficiencia
            for (int i = 0; i < CancionesDisponibles.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {CancionesDisponibles[i].ToString()}");
            }
            return sb.ToString().TrimEnd();
        }

        // Helper para ordenar el catálogo completo por duración (uso externo)
        public void OrdenarCatalogoPorDuracion()
        {
            if (CancionesDisponibles.Count <= 1) 
                return;
            QuickSort(CancionesDisponibles, 0, CancionesDisponibles.Count - 1);
        }
    }
}
