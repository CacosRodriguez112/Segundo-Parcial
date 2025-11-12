using MusicManager.Models;


namespace MusicManager.Tests.Models
{
    public class CancionTests
    {
        [Fact]
        public void Constructor_AsignaPropiedades()
        {
            // Arrange
            var nombre = "Bohemian Rhapsody";
            var artista = "Queen";
            var dur = 354; // 5:54

            // Act
            var cancion = new Cancion(nombre, artista, dur);

            // Assert (tal cual sugiere la práctica)
            Assert.Equal(nombre, cancion.Nombre);
            Assert.Equal(artista, cancion.Artista);
            Assert.Equal(dur, cancion.DuracionSegundos);
        }

        [Fact]
        public void ToString_Formato_NombreArtista_MMSS()
        {
            // Arrange
            var cancion = new Cancion("Bohemian Rhapsody", "Queen", 354);

            // Assert (ejemplo de la lámina)
            Assert.Equal("Bohemian Rhapsody - Queen (5:54)", cancion.ToString());
        }
    }
}