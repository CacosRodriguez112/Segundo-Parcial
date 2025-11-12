namespace MusicManager.Models
{
    public class Cancion
    {
        public string Nombre { get; set;  }
        public string Artista { get; set;  }
        public int DuracionSegundos { get; set; }

        public Cancion(string nombre, string artista, int duracionSegundos)
        {
            if (string.IsNullOrWhiteSpace(nombre)) 
                throw new ArgumentException("Nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(artista)) 
                throw new ArgumentException("Artista no puede estar vacío.");
            if (duracionSegundos < 0) 
                throw new ArgumentOutOfRangeException("Duración no puede ser negativa.");

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
