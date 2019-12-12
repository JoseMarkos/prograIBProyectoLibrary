using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectoLibrary.Interface;
using proyectoLibrary.Modelos;

namespace proyectoLibrary
{
    sealed class CurrentParkingAccountAdapter : IParkingAccountAdapter
    {
        private static string Year = DateTime.Now.Year.ToString();
        private static string Month = DateTime.Now.Month.ToString();
        private static string Day = DateTime.Now.Day.ToString();
        private static string CurrentDirectory = Directory.GetCurrentDirectory() + "\\parkingAccounts\\" + Year + "\\" + Month;
        private static string CurrentDirectoryFile = CurrentDirectory + "\\" + Day + ".txt";
        private bool Exists = File.Exists(CurrentDirectoryFile);

        private List<CuentaParqueo> cuentaParqueoList = new List<CuentaParqueo>();

        public CurrentParkingAccountAdapter ()
        {
            nose();
        }

        public BindingSource GetParkingAccountConnection()
        {
            return new BindingSource
            {
                DataSource = cuentaParqueoList
            };
        }

        private void nose()
        {
            if (Exists)
            {
                ReadFile();
            }
        }

        private void ReadFile()
        {
            string line;
            StreamReader streamReader = new StreamReader(CurrentDirectoryFile);
            
            byte _id = 0;
            long _dpi = 0;
            string _fullName;
            byte _vehicles;
            List<Vehicle> _vehicleList = new List<Vehicle>();

            while ((line = streamReader.ReadLine()) != null)
            {
                string[] lineArray = line.ToString().Split(',');

                _id = byte.Parse(lineArray[0]);
                _dpi = long.Parse(lineArray[1]);
                _fullName = lineArray[2] is null ? "" : lineArray[2];
                _vehicles = byte.Parse(lineArray[3]);

                // Vehicle List
                //string[] vehicleListArray = lineArray[4].Split('|');

                //vehicleListArray = vehicleListArray[1].Split();

                //for (int i = 0; i < vehicleListArray.Length; i++)
                //{
                //    _vehicleList.Add(vehicleListArray[i]);
                //}

                // End Vehicle List

                CuentaParqueo cuentaParqueo = new CuentaParqueo();
                cuentaParqueo.GuardarInformacionPersonal(_dpi, _fullName);
                cuentaParqueo.GuardarListaDeCarros(_vehicleList);

                cuentaParqueoList.Add(cuentaParqueo);
            }

            streamReader.Close();
        }
    }
}
