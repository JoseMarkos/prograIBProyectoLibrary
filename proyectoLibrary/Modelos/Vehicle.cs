using System.Collections.Generic;

namespace proyectoLibrary.Modelos
{
    public sealed class Vehicle
    {
        #region Enums

        public enum Vehicletype
        {
            Sedan,
            Coupe,
            HatchBack,
            SUV,
            PickUp,
            Camioneta
        }

        /// <summary>
        /// Normal: 3 to 6m
        /// Grande: 6 to 8m
        /// </summary>
        public enum VehicleSize
        {
            Normal,
            Grande
        }

        public enum licensePlatePrefix
        {
            A,
            C,
            CC,
            CD,
            DIS,
            E,
            EXT,
            M,
            MI,
            O,
            P,
            TC,
            TRC,
            U
        }

        public enum licensePlatePrefixLevel
        {
            one = 1,
            two = 2,
            tree = 3
        }

        #endregion

        #region props

        public string Owner { get; set; }
        public byte OwnerID { get; set; }
        public Vehicletype Type { get; private set; }
        public string LicensePlate { get; private set; }
        private VehicleSize Size { get; set; }
        public string Parking { get; set; }

        public List<string> ServiceList;

        #endregion

        public Vehicle(string _owner
            , byte _ownerID
            , Vehicletype _vehicletype
            , string _licensePlate
            , string _parking
            , List<string> _serviceList
            )
        {
            Owner = _owner;
            OwnerID = _ownerID;
            Type = _vehicletype;
            LicensePlate = _licensePlate;
            SetVehicleSize(Type);
            Parking = _parking;
            ServiceList = _serviceList;
        }

        public Vehicle(string owner, byte ownerID, Vehicletype type, string licensePlate, string parking)
        {
            Owner = owner;
            OwnerID = ownerID;
            Type = type;
            SetVehicleSize(Type);
            LicensePlate = licensePlate;
            Parking = parking;
        }

        private void SetVehicleSize(Vehicletype _vehicletype)
        {
            switch (_vehicletype)
            {
                case Vehicletype.Sedan:
                    Size = VehicleSize.Normal;
                    break;

                case Vehicletype.Coupe:
                    Size = VehicleSize.Normal;
                    break;

                case Vehicletype.HatchBack:
                    Size = VehicleSize.Normal;
                    break;

                case Vehicletype.SUV:
                    Size = VehicleSize.Normal;
                    break;

                case Vehicletype.PickUp:
                    Size = VehicleSize.Grande;
                    break;

                case Vehicletype.Camioneta:
                    Size = VehicleSize.Grande;
                    break;
            }
        }
    }
}
