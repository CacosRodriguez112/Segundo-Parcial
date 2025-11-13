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
                throw new ArgumentNullException("no");

            CancionesDisponibles.Add(cancion);
        }

        public List<Cancion> BuscarPorNombre(string ya)
        {
            if (string.IsNullOrWhiteSpace(ya))
                return new List<Cancion>();

            return CancionesDisponibles
                .Where(c => c.Nombre.IndexOf(ya, StringComparison.OrdinalIgnoreCase) >= 0) // búsqueda sin distinción de mayúsculas/minúsculas
                .ToList();
        }

        // QuickSort por DuracionSegundos (ascendente)

        public void QuickSort(List<Cancion> lista, int low, int high)
        {
            if (lista == null || lista.Count == 0)
                return;

            if (low >= high)
                return;

            int pivotIndex = (low + high) / 2;
            int pivotValue = lista[pivotIndex].DuracionSegundos;

            int i = low, j = high;
            while (i <= j)
            {
                while (lista[i].DuracionSegundos < pivotValue)
                    i++;
                while (lista[j].DuracionSegundos > pivotValue)
                    j--;

        private int Partition(List<Cancion> lista, int low, int high) // Particiona la lista para QuickSort
        {
            var pivot = lista[high].DuracionSegundos; // pivote generalmente es el último elemento 
            int i = low - 1;
            for (int j = low; j <= high - 1; j++)
            {
                if (lista[j].DuracionSegundos <= pivot)
                {
                    Swap(lista, i, j);
                    i++;
                    j--;
                }
            }

            if (low < j) QuickSort(lista, low, j);
            if (i < high) QuickSort(lista, i, high);
        }

        private void Swap(List<Cancion> lista, int i, int j)
        {
            Cancion temp = lista[i];
            lista[i] = lista[j];
            lista[j] = temp;
        }

        public string MostrarCancionesDisponibles()
        {
            if (CancionesDisponibles.Count == 0)
                return "No hay rolas w.";

            var sb = new System.Text.StringBuilder(); // Usar StringBuilder para eficiencia
            for (int i = 0; i < CancionesDisponibles.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {CancionesDisponibles[i].ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
