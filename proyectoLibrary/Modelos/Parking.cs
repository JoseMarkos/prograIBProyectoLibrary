﻿using System;
using System.Collections.Generic;

namespace proyectoLibrary.Modelos
{
    public sealed class Parking
    {
        public enum ParkingQuadrant
        {
            NorthEast,
            NorthWest,
            SouthEast,
            SouthWest
        }

        #region public propiedades
        public string Name { get; private set; }
        public ParkingQuadrant Quadrant { get; private set; }

        public List<string> Services;

        public byte Capacity { get; private set; }

        public byte NormalSizeCapacity { get; private set; }
        public byte BigSizeCapacity { get; private set; }

        #endregion

        public Parking(string _name, ParkingQuadrant _quadrant, List<string> _services, byte _normal, byte _big)
        {
            Name = _name;
            Quadrant = _quadrant;
            Services = _services;
            NormalSizeCapacity = _normal;
            BigSizeCapacity = _big;
            SetCapacity();
        }

        private void SetCapacity()
        {
            Capacity = (byte) (NormalSizeCapacity + BigSizeCapacity);
        }
    }
}
