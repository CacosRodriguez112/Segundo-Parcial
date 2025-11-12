using MusicManager.Gestores;
using MusicManager.Models;
namespace MusicManager.Sevice
{
    public class ServicioMusica
    {
        //Atributos
        public GestorCanciones Gestor { get; set; }
        public List<Usuario> Usuarios { get; set; }

        //Constructor
        public ServicioMusica(GestorCanciones gestor) 
        {
            Gestor = gestor;
            Usuarios = new List<Usuario>();
        }

        //Metodos
        public void RegistrarUsuario(string nombre)
        {
            Usuario nuevoUsuario = new Usuario(nombre);
            Usuarios.Add(nuevoUsuario);
            Console.WriteLine($"Usuario '{nombre}' registrado exitosamente.");
        }

        public Usuario BuscarUsuario(string nombre)
        {
            return Usuarios.FirstOrDefault(p => p.Nombre.ToLower() == nombre.ToLower());
        }
    }
}