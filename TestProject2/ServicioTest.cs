using MusicManager.Gestores;
using MusicManager.Models;
using MusicManager.Sevice;


namespace MusicManager.Tests.Service
{
    public class ServicioMusicaTests
    {
        [Fact]
        public void RegistrarUsuario_AgregaAListaUsuarios()
        {
            // Arrange
            var gestor = new GestorCanciones();
            var servicio = new ServicioMusica(gestor);

            // Act
            servicio.RegistrarUsuario("TestUser");

            // Assert (como en la práctica)
            Assert.Equal("TestUser", servicio.Usuarios[0].Nombre);
        }

        [Fact]
        public void BuscarUsuario_IgnoraMayusculasYRetornaNullSiNoExiste()
        {
            // Arrange
            var gestor = new GestorCanciones();
            var servicio = new ServicioMusica(gestor);
            servicio.RegistrarUsuario("TestUser");

            // Act + Assert (ejemplos de la lámina)
            Assert.NotNull(servicio.BuscarUsuario("testuser"));     // case-insensitive
            Assert.Null(servicio.BuscarUsuario("NoExistente"));     // usuario que no está
        }
    }
}