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
        public Parqueo Parqueo { get => parqueo; set => parqueo = value; }

        public List<Vehiculo> Vehiculos = new List<Vehiculo>();

        #endregion

        public CuentaParqueo()
        {
        }

        public void GuardarInformacionPersonal(string nombre, byte dpi)
        {
            Nombre = nombre;
            DPI = dpi;
        }

        public void GuardarListaDeCarros(List<Vehiculo> lista)
        {
            Vehiculos = lista;
        }

        public void GuardarParqueo(Parqueo parqueo) => Parqueo = parqueo;
    }
}
