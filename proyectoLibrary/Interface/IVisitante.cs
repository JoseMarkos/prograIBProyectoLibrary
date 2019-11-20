using System;
using System.Collections.Generic;
using proyectoLibrary.Modelos;

namespace proyectoLibrary.Interface
{
    public interface IVisitante
    {
        /// <summary>
        /// Guardar informacion de Form1 a un Visitante
        /// usar el Visitante Global de Program.cs
        /// </summary>
        /// <param name="Nombre">Puede venir de un inputtext.Text por  ejemplo</param>
        /// <param name="DPI">Puede venir de un inputtext.Text (convertir antes byte) </param>
        void GuardarInformacionPersonal(string Nombre, byte DPI);

        /// <summary>
        /// Guarda lista de vehiculos de Form2 a un Visitante
        /// usar el Visitante Global de Program.cs
        /// </summary>
        /// <param name="Lista">Lista tipo Vehiculo global </param>
        void GuardarListaDeCarros(List<Vehiculo> Lista);

        /// <summary>
        /// Guarda parqueo de Form3 a un Visitiante
        /// usar el visitante Global de Program.cs
        /// </summary>
        /// <param name="parqueo"></param>
        void GuardarParqueo(Parqueo parqueo);
    }
}
