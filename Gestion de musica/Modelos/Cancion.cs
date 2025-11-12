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
            if (string.IsNullOrWhiteSpace(nombre)) 
                throw new ArgumentException("No puede estar vacio");
            if (string.IsNullOrWhiteSpace(artista)) 
                throw new ArgumentException("Tampoco puede estar vacio");
            if (duracionSegundos < 0) 
                throw new ArgumentOutOfRangeException("nmms");

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
