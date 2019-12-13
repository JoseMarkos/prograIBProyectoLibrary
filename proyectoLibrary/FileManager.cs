using proyectoLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace proyectoLibrary
{
    public sealed class FileManager
    {
        public static int Counter = 0;
        
        private static string Year = DateTime.Now.Year.ToString();
        private static string Month = DateTime.Now.Month.ToString();
        private static string Day = DateTime.Now.Day.ToString();
        private static string CurrentVehiclesDirectory = Directory.GetCurrentDirectory() + "\\vehicles\\" + Year + "\\" + Month;
        private static string CurrentParkingsDirectory = Directory.GetCurrentDirectory() + "\\parkings\\" + Year + "\\" + Month;
        private static string CurrentParkingAccountDirectory = Directory.GetCurrentDirectory() + "\\parkingAccounts\\" + Year + "\\" + Month;
        private static string CurrentVehiclesFile = CurrentVehiclesDirectory + "\\" + Day + ".txt";
        private static string CurrentParkingFile = CurrentParkingsDirectory + "\\" + Day + ".txt";
        private static string CurrentParkingAccountFile = CurrentParkingAccountDirectory + "\\" + Day + ".txt";

        public FileManager()
        {
            Counter++;
        }

        public void CreateVehicleFile()
        {
            CreateOnce(CurrentVehiclesDirectory);

            Stream stream = File.Create(CurrentVehiclesFile);
            stream.Close();
        }

        public void CreateParkingFile()
        {
            CreateOnce(CurrentParkingsDirectory);

            Stream stream = File.Create(CurrentParkingFile);
            stream.Close();
        }

        public void CreateParkingAccountFile()
        {
            CreateOnce(CurrentParkingAccountDirectory);

            Stream stream = File.Create(CurrentParkingAccountFile);
            stream.Close();
        }

        private void CreateOnce(string path)
        {
            if (Counter < 2)
            {
                _ = Directory.CreateDirectory(path);
            }
        }

        public void WriteVehicleFile(List<Vehicle> source)
        {
            List<Vehicle> list = source;

            CreateVehicleFile();

            using (FileStream fileStream = new FileStream(CurrentVehiclesFile, FileMode.Open, FileAccess.ReadWrite))
            {
                StreamWriter sw = new StreamWriter(fileStream);
                foreach (var item in list)
                {
                    sw.Write(item.Owner is null ? "" : "" + item.Owner);
                    sw.Write(item.OwnerID is 0 ? ", " : ", " + item.OwnerID);
                    sw.Write(", " + (int)item.Type);
                    sw.Write(item.LicensePlate is null ? ", " : ", " + item.LicensePlate);
                    sw.Write(item.Parking is null ? ", " : ", " + item.Parking);

                    // Services
                    sw.Write(", |");

                    for (int j = 0; j < item.ServiceList.Count; j++)
                    {
                        if (j == item.ServiceList.Count - 1)
                        {
                            sw.Write(item.ServiceList[j]);
                        }

                        else
                        {
                            sw.Write(item.ServiceList[j] + " ");
                        }
                    }

                    sw.Write("|");
                    // End Services

                    sw.Write("\n");
                }

                sw.Close();
                fileStream.Close();
            }
        }

        public void WriteParkingFile(List<Parking> source)
        {
            List<Parking> list = source;

            CreateParkingFile();

            using (FileStream fileStream = new FileStream(CurrentParkingFile, FileMode.Open, FileAccess.ReadWrite))
            {
                StreamWriter sw = new StreamWriter(fileStream);

                for (int i = 0; i < list.Count; i++)
                {
                    sw.Write(list[i].Name is null ? "" : "" + list[i].Name);
                    sw.Write(", " + (int)list[i].Quadrant);

                    // Services
                    sw.Write(", |");

                    for (int j = 0; j < list[i].Services.Count; j++)
                    {
                        if (j == list[i].Services.Count - 1)
                        {
                            sw.Write(list[i].Services[j]);
                        }

                        else
                        {
                            sw.Write(list[i].Services[j] + " ");
                        }
                    }

                    sw.Write("|");

                    // End Services

                    sw.Write(list[i].NormalSizeCapacity < 0 ? ", " : ", " + list[i].NormalSizeCapacity);
                    sw.Write(list[i].BigSizeCapacity < 0 ? ", " : ", " + list[i].BigSizeCapacity);
                    sw.Write(", " + list[i].FreeSpaces);

                    if (i != list.Count - 1)
                    {
                        sw.Write("\n");
                    }
                }

                sw.Close();
                fileStream.Close();
            }
        }

        public void DeleteParkingFile(string path)
        {
            // Delete if it exits
            if (_ = File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public string GetCurrentVehiclesFile()
        {
            return CurrentVehiclesFile;
        }

        public string GetCurrentParkingFile()
        {
            return CurrentParkingFile;
        }

        public string GetCurrentParkingAccountFile()
        {
            return CurrentParkingAccountFile;
        }

        public void SetCurrentVehiclesFile(string filePath)
        {
            CurrentVehiclesFile = filePath;
        }
     
    }
}
