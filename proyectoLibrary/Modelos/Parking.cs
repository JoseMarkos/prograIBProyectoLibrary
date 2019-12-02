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
            if (!IsFullHouse())
            {
                freeSpaces -= 1;
                FreeSpaces = freeSpaces;
            }
        }

        public byte GetFreeSpaces()
        {
            return freeSpaces;
        }

        public bool IsFullHouse()
        {
            if (FreeSpaces > 0)
            {
                return false;
            }

            return true;
        }

        public List<ParkingQuadrant> GetQuadrantBros(ParkingQuadrant quadrant)
        {
            List<ParkingQuadrant> list = new List<ParkingQuadrant>();

            switch (quadrant)
            {
                case ParkingQuadrant.NorthEast:
                    list.Add(ParkingQuadrant.NorthWest);
                    list.Add(ParkingQuadrant.SouthEast);
                    break;
                case ParkingQuadrant.NorthWest:
                    list.Add(ParkingQuadrant.NorthEast);
                    list.Add(ParkingQuadrant.SouthWest);
                    break;
                case ParkingQuadrant.SouthEast:
                    list.Add(ParkingQuadrant.SouthWest);
                    list.Add(ParkingQuadrant.NorthEast);
                    break;
                case ParkingQuadrant.SouthWest:
                    list.Add(ParkingQuadrant.SouthEast);
                    list.Add(ParkingQuadrant.NorthWest);
                    break;
            }

            return list;
        }
    }
}
