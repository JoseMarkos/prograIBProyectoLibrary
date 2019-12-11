using proyectoLibrary.Interface;
using proyectoLibrary.Modelos;
using System;
using System.Collections.Generic;

namespace proyectoLibrary
{
    public sealed class CuentaParqueo : ICuentaParqueo
    {
        #region public properties
        private static int id;
        public byte ID { get; private set; }

        public string Card { get; private set; }

        public string NombreCompleto { get; private set; }

        public List<Vehicle> ListaVehiculos;

        public byte Vehiculos { get; private set; }

        public string ParqueoElegido;

        public List<string> ListaServicios;

        #endregion

        public CuentaParqueo()
        {
            id++;
            ID = (byte)id;
        }

        ~CuentaParqueo() => id--;

        public void GuardarInformacionPersonal(string nombre, string card)
        {
            NombreCompleto = nombre;
            Card = card;
        }

        public void GuardarListaDeCarros(List<Vehicle> list)
        {
            ListaVehiculos = list;
            Vehiculos = (byte)ListaVehiculos.Count;
        }

        public void GuardarParqueo(string parqueo) => ParqueoElegido = parqueo;

        public void GuardarServicios(List<string> listaServicios)
        {
            ListaServicios = listaServicios;
        }
    }
}
