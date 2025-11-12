using MusicManager.Gestores;
using MusicManager.Models;

namespace MusicManager.Tests.Gestores
{
    public class GestorCancionesTests
    {
        [Fact]
        public void AgregarCancion()
        {
            var gestor = new GestorCanciones();
            var cancion = new Cancion("Like a Rolling Stone", "Bob Dylan", 369);

            gestor.AgregarCancion(cancion);

            // Como en la práctica: verificar que está en la lista
            Assert.Contains(cancion, gestor.CancionesDisponibles);
        }

        [Fact]
        public void BuscarPorNombre_Parcial()
        {
            var gestor = new GestorCanciones();
            gestor.AgregarCancion(new Cancion("Like a Rolling Stone", "Bob Dylan", 369));
            gestor.AgregarCancion(new Cancion("Stone Cold", "Demi Lovato", 211));
            gestor.AgregarCancion(new Cancion("Bohemian Rhapsody", "Queen", 354));

            var resultados = gestor.BuscarPorNombre("rolling"); // parcial + minúsculas

            // Ejemplo de la lámina: el primer match esperado
            Assert.Equal("Like a Rolling Stone", resultados[0].Nombre);
        }

        [Fact]
        public void QuickSortAscendente()
        {
            var gestor = new GestorCanciones();

            var lista = new List<Cancion>
            {
                new Cancion("Larga",  "X", 300),
                new Cancion("Corta",  "X", 100),
                new Cancion("Media",  "X", 200),
            };

            gestor.QuickSort(lista, 0, lista.Count - 1);

            // Como en la práctica: verificar posiciones según duración
            Assert.Equal("Corta", lista[0].Nombre); // 100s
            Assert.Equal("Media", lista[1].Nombre); // 200s
            Assert.Equal("Larga", lista[2].Nombre); // 300s
        }
    }
}