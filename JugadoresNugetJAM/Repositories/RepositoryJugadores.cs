using JugadoresNugetJAM.Models;
using System.Xml.Linq;

namespace JugadoresNugetJAM.Repositories
{
    public class RepositoryJugadores
    {

        private XDocument document;

        public RepositoryJugadores()
        {
            //para ller un recurso incrustado necesitamos el namespace del proyecto,
            //si estuviera en una carpeta,tambien el nombre de la carpeta y el file name
            string resourceName = "JugadoresNugetJAM.jugadores.xml";

            //Los datos se recuperan mediante stream

            Stream stream = this.GetType().Assembly.GetManifestResourceStream(resourceName);
            //El FICHERO XML SE ALAMACENA EN DOCUMENT MEDIANTE LOAD

            this.document = XDocument.Load(stream);
        }

        public List<Jugador> GetJugadoresAsync()
        {
            var consulta = from datos in this.document.Descendants("jugador")
                           select datos;

            List<Jugador> jugadores = new List<Jugador>();
            foreach (var dato in consulta)
            {
                Jugador jugador = new Jugador
                {
                    Numero = int.Parse(dato.Element("numero").Value),
                    Nombre = dato.Element("nombre").Value,
                    Posicion = dato.Element("posicion").Value,
                    Edad = int.Parse(dato.Element("edad").Value),
                    Imagen = dato.Element("imagen").Value
                };
                jugadores.Add(jugador);
            }
            return jugadores;
        }
    }
}
