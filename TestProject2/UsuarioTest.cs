using MusicManager.Models;

namespace MusicManager.Tests.Models
{
    public class UsuarioTests
    {
        [Fact]
        public void CrearListaReproduccion() //Crea una lista de reproducción nueva
        {
            // Arrange
            var usuario = new Usuario("Sebas");

            // Act
            var ok = usuario.CrearListaReproduccion("Favoritas", out _);

            // Assert (como en la práctica)
            Assert.True(ok);
            Assert.True(usuario.ListasReproduccion.ContainsKey("Favoritas"));
            Assert.Empty(usuario.ListasReproduccion["Favoritas"]);
        }

        [Fact]
        public void AgregarCancionALista()
        {
            // Arrange
            var usuario = new Usuario("Sebas");
            usuario.CrearListaReproduccion("Favoritas", out _);
            var cancion = new Cancion("Eres", "Café Tacvba", 258);

            // Act
            var ok = usuario.AgregarCancionALista("Favoritas", cancion, out _);

            // Assert (como en la práctica)
            Assert.True(ok);
            Assert.Single(usuario.ListasReproduccion["Favoritas"]);
            Assert.Equal(cancion, usuario.ListasReproduccion["Favoritas"][0]);
        }
    }
}