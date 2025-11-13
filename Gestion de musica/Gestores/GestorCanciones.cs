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

        public List<Cancion> BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return new List<Cancion>();

            return CancionesDisponibles
                .Where(c => c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }


        // QuickSort por DuracionSegundos (ascendente)
        public void QuickSort(List<Cancion> lista, int low, int high)
        {
            if (lista == null)
                throw new ArgumentNullException("");

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

                if (i <= j)
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
            throw new NotImplementedException();
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
