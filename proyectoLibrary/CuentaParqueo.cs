using proyectoLibrary.Interface;
using proyectoLibrary.Modelos;
using System;
using System.Collections.Generic;

namespace proyectoLibrary
{
    public sealed class CuentaParqueo : ICuentaParqueo
    {
        #region public properties

        public string Nombre { get; private set; }
        public byte DPI { get; private set; }

        public List<Vehicle> Vehiculos = new List<Vehicle>();

        public Parking Parqueo = new Parking();

        #endregion

        public CuentaParqueo()
        {
        }

        public void GuardarInformacionPersonal(string nombre, byte dpi)
        {
            Nombre = nombre;
            DPI = dpi;
        }

        public void GuardarListaDeCarros(List<Vehicle> Lista)
        {
            Vehiculos = Lista;
        }

        public void GuardarParqueo(Parking parqueo)
        {
            
        }
    }
}
