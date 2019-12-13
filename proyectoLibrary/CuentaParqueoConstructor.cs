using proyectoLibrary.Interface;
using proyectoLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoLibrary
{
    public sealed class CuentaParqueoConstructor
    {
        private IParkingAccountAdapter.PathType type;
        private static string Year = DateTime.Now.Year.ToString();
        private static string Month = DateTime.Now.Month.ToString();
        private static string Day = DateTime.Now.Day.ToString();
        private static string CurrentVehiclesDirectory = Directory.GetCurrentDirectory() + "\\vehicles\\" + Year + "\\" + Month;
        private static string CurrentParkingsDirectory = Directory.GetCurrentDirectory() + "\\parkings\\" + Year + "\\" + Month;
        private static string CurrentParkingAccountDirectory = Directory.GetCurrentDirectory() + "\\parkingAccounts\\" + Year + "\\" + Month;
        private static string CurrentVehiclesFile = CurrentVehiclesDirectory + "\\" + Day + ".txt";
        private static string CurrentParkingFile = CurrentParkingsDirectory + "\\" + Day + ".txt";
        private static string CurrentParkingAccountFile = CurrentParkingAccountDirectory + "\\" + Day + ".txt";

        public byte id { get; private set;}
        public long DPI {get; private set;}
        public string fullName {get; private set;}
        public List<Vehicle> vehicleList {get; private set;}
        public byte vehicles {get; private set;}

        public CuentaParqueoConstructor(IParkingAccountAdapter.PathType pathType, long dpi)
        {
            type = pathType;
            DPI = dpi;

            Construct();
        }

        private void Construct()
        {
            if (type != IParkingAccountAdapter.PathType.First)
            {
                using (StreamReader streamReader = new StreamReader(CurrentParkingAccountFile))
                {
                    string line;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] lineArray = line.ToString().Split(',');

                        for (int i = 0; i < lineArray.Length; i++)
                        {
                            if (long.Parse(lineArray[1]) == DPI)
                            {
                                id = byte.Parse(lineArray[0]);
                                fullName = lineArray[2].Trim();
                                vehicles = byte.Parse(lineArray[3]);
                            }

                            break;
                        }
                    }
                }

                using (StreamReader streamReader = new StreamReader(CurrentVehiclesFile))
                {
                    vehicleList = new List<Vehicle>();

                    string line;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] lineArray = line.ToString().Split(',');

                        if (byte.Parse(lineArray[1]) == id)
                        {
                            Vehicle.Vehicletype vehicletype = (Vehicle.Vehicletype)int.Parse(lineArray[2]);
                            string plateNumber = lineArray[3];
                            string parking = lineArray[4];

                            Vehicle vehicle = new Vehicle(fullName, id, vehicletype, plateNumber, parking);

                            vehicleList.Add(vehicle);
                        }
                    }
                }
            }
        }
    }
}
