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

        #endregion

        #region public prpiedades

        public string Owner { get; set; }
        public byte OwnerID { get; set; }
        public Vehicletype Type { get; private set; }
        public string LicensePlate { get; private set; }
        private VehicleSize Size { get; set; }
        public string Parking { get; set; }

        #endregion

        public Vehicle(string _owner
            , byte _ownerID
            , Vehicletype _vehicletype
            , string _licensePlate
            , string _parking)
        {
            Owner = _owner;
            OwnerID = _ownerID;
            Type = _vehicletype;
            LicensePlate = _licensePlate;
            SetVehicleSize(Type);
            Parking = _parking;
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
