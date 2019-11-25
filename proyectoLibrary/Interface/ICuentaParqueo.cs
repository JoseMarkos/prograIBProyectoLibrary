using proyectoLibrary.Modelos;
using System.Collections.Generic;

namespace proyectoLibrary.Interface
{
    public interface ICuentaParqueo
    {
        /// <summary>
        /// Guardar informacion de Form1 a un Visitante
        /// usar el Visitante Global de Program.cs
        /// </summary>
        /// <param name="nombre">Puede venir de un inputtext.Text por  ejemplo</param>
        /// <param name="dpi">Puede venir de un inputtext.Text (convertir antes byte) </param>
        void GuardarInformacionPersonal(string nombre, byte dpi);

        /// <summary>
        /// Guarda lista de vehiculos de Form2 a un Visitante
        /// usar el Visitante Global de Program.cs
        /// </summary>
        /// <param name="lista">Lista tipo Vehicle global </param>
        void GuardarListaDeCarros(List<Vehicle> lista);

        /// <summary>
        /// Guarda parqueo de Form3 a un Visitiante
        /// usar el visitante Global de Program.cs
        /// </summary>
        /// <param name="parqueo"></param>
        void GuardarParqueo(string parqueo);
    }
}
