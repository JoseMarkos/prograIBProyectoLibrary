namespace proyectoLibrary.Modelos
{
    public sealed class Vehicle
    {
        #region Enums
        enum Vehicletype
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
        private string LicensePlate { get; set; }

        #endregion

        public Vehicle()
        {
        }
    }
}
