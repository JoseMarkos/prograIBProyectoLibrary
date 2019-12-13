using proyectoLibrary.Modelos;
using System.Collections.Generic;
using System.IO;

namespace proyectoLibrary
{
    public sealed class FileRead
    {
        public string PathVehicle { get; set; }
        public string PathParking { get; set; }
        private List<Vehicle> listVehicles = new List<Vehicle>();
        private List<Parking> listParkings = new List<Parking>();

        public List<Vehicle> ReadVehicleFile()
        {
            string line;
            StreamReader streamReader = new StreamReader(PathVehicle);

            string _owner;
            int OwnderIDInt = -10;
            byte _ownerID = 0;
            Vehicle.Vehicletype _type;
            string _licensePlate, _parking;

            while ((line = streamReader.ReadLine()) != null)
            {
                string[] lineArray = line.ToString().Split(',');

                _owner = lineArray[0] is null ? "" : lineArray[0];

                // ownerID
                byte.TryParse(lineArray[1], out _ownerID);

                if (OwnderIDInt * _ownerID == 0)
                {
                    _ownerID = 0;
                }
                // end ownerID

                _type = (Vehicle.Vehicletype)int.Parse(lineArray[2]);

                // Plate number
                _licensePlate = lineArray[3] is null ? "" : lineArray[3];

                string[] _licensePlateArray = _licensePlate.Split();

                if (_licensePlateArray.Length == 2)
                {
                    _licensePlate = _licensePlateArray[1];
                }
                // End Plate number

                _parking = lineArray[4] is null ? "" : lineArray[4].Substring(1);


                string[] servicesArray = lineArray[5].Split('|');

                servicesArray = servicesArray[1].Split();

                List<string> _services = new List<string>();


                for (int i = 0; i < servicesArray.Length; i++)
                {
                    _services.Add(servicesArray[i]);
                }

                Vehicle vehicle = new Vehicle(
                    _owner,
                    _ownerID,
                    _type,
                    _licensePlate,
                    _parking,
                    _services);

                listVehicles.Add(vehicle);
            }

            streamReader.Close();

            return listVehicles;
        }

        public List<Parking> ReadParkingFile()
        {
            if (listParkings.Count > 0)
            {
                return listParkings;
            }

            string line;
            StreamReader streamReader = new StreamReader(PathParking);

            string _name;
            Parking.ParkingQuadrant _parkingQuadrant;
            byte _normal = 0;
            byte _big = 0;

            while ((line = streamReader.ReadLine()) != null)
            {
                string[] lineArray = line.ToString().Split(',');

                List<string> _services = new List<string>();

                _name = lineArray[0] is null ? "" : lineArray[0];
                _parkingQuadrant = (Parking.ParkingQuadrant)int.Parse(lineArray[1]);

                string[] servicesArray = lineArray[2].Split('|');

                servicesArray = servicesArray[1].Split();

                for (int i = 0; i < servicesArray.Length; i++)
                {
                    _services.Add(servicesArray[i]);
                }

                byte.TryParse(lineArray[3], out _normal);
                byte.TryParse(lineArray[4], out _big);

                Parking parking = new Parking(_name, _parkingQuadrant, _services, _normal, _big);

                if (lineArray.Length == 6)
                {
                    byte _freeSpace = byte.Parse(lineArray[5]);

                    for (int i = 0; i < (parking.Capacity - (int)_freeSpace); i++)
                    {
                        parking.DiscountFreeSpaces();
                    }
                }

                listParkings.Add(parking);
            }

            streamReader.Close();

            return listParkings;
        }
    }
}
