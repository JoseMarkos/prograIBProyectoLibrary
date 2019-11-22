using proyectoLibrary.Interface;
using proyectoLibrary.Modelos;
using System;
using System.Collections.Generic;

namespace proyectoLibrary
{
    public class CuentaParqueo : ICuentaParqueo
    {
        private static Visitante GetVisitante()
        {
            return new Visitante();
        }

        private Visitante visitante;

        public CuentaParqueo()
        {
            visitante = GetVisitante();
        }

        public void GuardarInformacionPersonal(string nombre, byte dpi)
        {
            visitante.Nombre = nombre;
            visitante.DPI = dpi;
        }

        public void GuardarListaDeCarros(List<Vehiculo> Lista)
        {
            
        }

        public void GuardarParqueo(Parqueo parqueo)
        {
            
        }

        public Visitante GetCuenta()
        {
            return visitante;
        }
    }
}
