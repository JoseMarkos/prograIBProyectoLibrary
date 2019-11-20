using proyectoLibrary.Interface;
using proyectoLibrary.Modelos;
using System;
using System.Collections.Generic;

namespace proyectoLibrary
{
    public class Antigua : IVisitante
    {
        static Visitante GetVisitante()
        {
            return new Visitante();
        }

        private Visitante visitante;

        public Antigua()
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

        public Visitante GetAntiguaVisitante()
        {
            return visitante;
        }
    }
}
