using proyectoLibrary.Interface;
using proyectoLibrary.Modelos;
using System;
using System.Collections.Generic;

namespace proyectoLibrary
{
    public class CuentaParqueo : ICuentaParqueo
    {
        static Visitante GetVisitante()
        {
            return new Visitante();
        }

        private Visitante visitante;

        public CuentaParqueo()
        {
            visitante = GetVisitante();
        }

        public void GuardarInformacionPersonal(string Nombre, byte DPI)
        {
            visitante.Nombre = Nombre;
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
