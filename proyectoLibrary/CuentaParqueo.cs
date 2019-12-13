using proyectoLibrary.Interface;
using proyectoLibrary.Modelos;
using System;
using System.Collections.Generic;

namespace proyectoLibrary
{
    public sealed class CuentaParqueo : ICuentaParqueo
    {
        #region properties

        private static int id;

        public byte ID { get; set; }

        public long DPI { get; private set; }

        public string NombreCompleto { get; private set; }

        public List<Vehicle> ListaVehiculos = new List<Vehicle>();

        public byte Vehiculos { get; private set; }

        #endregion

        public CuentaParqueo()
        {
            id++;
            ID = (byte)id;
        }

        ~CuentaParqueo() => id--;

        public void GuardarInformacionPersonal(long dpi, string nombre)
        {
            DPI = dpi;
            NombreCompleto = nombre;
        }

        public void GuardarListaDeCarros(List<Vehicle> list)
        {
            ListaVehiculos = list;
            Vehiculos = (byte)ListaVehiculos.Count;
        }
    }
}
