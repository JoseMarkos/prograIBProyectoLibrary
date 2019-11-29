using System.Collections.Generic;

namespace proyectoLibrary.Modelos
{
    public sealed class Parking
    {
        #region Enum

        public enum ParkingQuadrant
        {
            NorthEast,
            NorthWest,
            SouthEast,
            SouthWest
        }
        #endregion

        #region public propiedades
        public string Name { get; private set; }
        public ParkingQuadrant Quadrant { get; private set; }

        public List<string> Services;

        public byte Capacity { get; private set; }

        public byte NormalSizeCapacity { get; private set; }
        public byte BigSizeCapacity { get; private set; }
        private static byte freeSpaces;
        public byte FreeSpaces { get; private set; }
        #endregion

        public Parking(string _name, ParkingQuadrant _quadrant, List<string> _services, byte _normal, byte _big)
        {
            Name = _name;
            Quadrant = _quadrant;
            Services = _services;
            NormalSizeCapacity = _normal;
            BigSizeCapacity = _big;
            SetCapacity();
            SetFreeSpaces();
        }

        private void SetCapacity()
        {
            Capacity = (byte)(NormalSizeCapacity + BigSizeCapacity);
        }

        private void SetFreeSpaces()
        {
            freeSpaces = Capacity;
            FreeSpaces = freeSpaces;
        }

        public void DiscountFreeSpaces()
        {
            freeSpaces -= 1;
            FreeSpaces = freeSpaces;
        }

        private bool IsFullHouse()
        {
            if (freeSpaces > 0)
            {
                return false;
            }

            return true;
        }
    }
}
