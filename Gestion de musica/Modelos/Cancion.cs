namespace MusicManager.Models
{
    public class Cancion
    {
        // Atributos
        public string Nombre { get; set;  }
        public string Artista { get; set;  }
        public int DuracionSegundos { get; set; }

        // Constructor
        public Cancion(string nombre, string artista, int duracionSegundos)
        {
            Nombre = nombre;
            Artista = artista;
            DuracionSegundos = duracionSegundos;
        }

        public override string ToString()
        {
            int minutos = DuracionSegundos / 60;
            int segundos = DuracionSegundos % 60; // Formatear segundos con dos dígitos
            return $"{Nombre} - {Artista} ({minutos}:{segundos:D2})";
        }
    }
}
