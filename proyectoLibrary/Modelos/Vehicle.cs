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

        enum VehicleSize
        {
            Big,
            Normal,
            Small
        }

        #endregion

        #region public prpiedades

        private Vehicletype Type;
        private VehicleSize Size;
        private string LicensePlate;

        #endregion

        public Vehicle(Vehicletype _vehicletype, string _licensePlate)
        {
            Type = _vehicletype;
            LicensePlate = _licensePlate;
            SetVehicleSize(Type);
        }

        private void SetVehicleSize(Vehicletype _vehicletype)
        {
            switch (_vehicletype)
            {
                case Vehicletype.Sedan:
                    Size = VehicleSize.Big;
                    break;

                case Vehicletype.Coupe:
                    Size = VehicleSize.Big;
                    break;

                case Vehicletype.HatchBack:
                    Size = VehicleSize.Big;
                    break;

                case Vehicletype.SUV:
                    Size = VehicleSize.Big;
                    break;

                case Vehicletype.PickUp:
                    Size = VehicleSize.Big;
                    break;

                case Vehicletype.Camioneta:
                    Size = VehicleSize.Big;
                    break;

                default:
                    Size = VehicleSize.Big;
                    break;
            }
        }
    }
}
