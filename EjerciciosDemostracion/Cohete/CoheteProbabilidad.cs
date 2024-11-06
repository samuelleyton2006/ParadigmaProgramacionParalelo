using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    // Representa un punto en el espacio 3D
    public struct Vector3D
    {
        public double X, Y, Z;
        public Vector3D(double x, double y, double z) => (X, Y, Z) = (x, y, z);
    }

    // Simulación de una nave espacial en movimiento
    public class NaveEspacial
    {
        public Vector3D Posicion { get; set; }
        public Vector3D Velocidad { get; set; }

        public NaveEspacial(Vector3D posicion, Vector3D velocidad)
        {
            Posicion = posicion;
            Velocidad = velocidad;
        }

        // Calcula la nueva posición después de un paso de tiempo usando la velocidad
        public void ActualizarPosicion(double tiempo)
        {
            // Crear una nueva variable para modificar la posición
            var nuevaPosicion = Posicion;
            nuevaPosicion.X += Velocidad.X * tiempo;
            nuevaPosicion.Y += Velocidad.Y * tiempo;
            nuevaPosicion.Z += Velocidad.Z * tiempo;

            // Asignar la nueva posición
            Posicion = nuevaPosicion;
        }
    }

    static void Main()
    {
        var naves = new NaveEspacial[]
        {
            new NaveEspacial(new Vector3D(0, 0, 0), new Vector3D(1, 2, 3)),
            new NaveEspacial(new Vector3D(100, 200, 300), new Vector3D(0.5, 1.5, 2.5)),
            new NaveEspacial(new Vector3D(400, 500, 600), new Vector3D(2, 1, 0)),
        };

        // Simula la actualización de las posiciones de todas las naves en paralelo
        Parallel.ForEach(naves, nave =>
        {
            for (int i = 0; i < 10; i++) // Simula 10 pasos de tiempo
            {
                nave.ActualizarPosicion(1.0);
                Console.WriteLine($"Nave en posición {nave.Posicion.X}, {nave.Posicion.Y}, {nave.Posicion.Z}");
            }
        });
    }
}
