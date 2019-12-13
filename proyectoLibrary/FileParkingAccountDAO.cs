using proyectoLibrary.Interface;
using proyectoLibrary.Modelos;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace proyectoLibrary
{
    public sealed class FileParkingAccountDAO
    {
        private IParkingAccountAdapter adapter;
        private List<CuentaParqueo> cuentaParqueoList = new List<CuentaParqueo>();

        public FileParkingAccountDAO (IParkingAccountAdapter.PathType pathType)
        {
            FileParkingAccountAdapterFactory fileFactory = new FileParkingAccountAdapterFactory();

            adapter = fileFactory.GetParkingAccountAdapter(pathType);
        }

        public void SaveCuentaParqueo(CuentaParqueo account)
        {
            cuentaParqueoList.Add(account);

            using (FileStream fileStream = adapter.GetParkingAccountConnection())
            {
                for (int i = 0; i < cuentaParqueoList.Count; i++)
                {
                    AddText(fileStream, cuentaParqueoList[i].ID.ToString());

                    if (cuentaParqueoList[i].DPI.ToString().Length < 13)
                    {
                        AddText(fileStream, ", 0" + cuentaParqueoList[i].DPI);
                    }
                    else
                    {
                        AddText(fileStream, ", " + cuentaParqueoList[i].DPI);
                    }

                    AddText(fileStream, ", " + cuentaParqueoList[i].NombreCompleto);
                    AddText(fileStream, ", " + cuentaParqueoList[i].Vehiculos + "\n");
                }
            }

            void AddText(FileStream fs, string value)
            {
                byte[] info = new UTF8Encoding(true).GetBytes(value);

                fs.Write(info, 0, info.Length);
            }
        }

        
        //private void ReadFile()
        //{
        //    string line;
        //    StreamReader streamReader = new StreamReader(CurrentDirectoryFile);

        //    byte id = 0;
        //    long dpi = 0;
        //    string _fullName;
        //    byte _vehicles;
        //    List<Vehicle> _vehicleList = new List<Vehicle>();

        //    while ((line = streamReader.ReadLine()) != null)
        //    {
        //        string[] lineArray = line.ToString().Split(',');

        //        id = byte.Parse(lineArray[0]);
        //        dpi = long.Parse(lineArray[1]);
        //        _fullName = lineArray[2] is null ? "" : lineArray[2];
        //        _vehicles = byte.Parse(lineArray[3]);


        //        // Vehicle List
        //        //string[] vehicleListArray = lineArray[4].Split('|');

        //        //vehicleListArray = vehicleListArray[1].Split();

        //        //for (int i = 0; i < vehicleListArray.Length; i++)
        //        //{
        //        //    _vehicleList.Add(vehicleListArray[i]);
        //        //}

        //        // End Vehicle List

        //        CuentaParqueo cuentaParqueo = new CuentaParqueo();
        //        cuentaParqueo.GuardarInformacionPersonal(dpi, _fullName);
        //        cuentaParqueo.GuardarListaDeCarros(_vehicleList);

        //        cuentaParqueoList.Add(cuentaParqueo);
        //    }

        //    streamReader.Close();
        //}
    }
}
