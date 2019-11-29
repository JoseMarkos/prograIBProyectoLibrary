using proyectoLibrary.Modelos;
using System.Collections.Generic;
using System.IO;

namespace ParqueoAdministrator
{
    public sealed class FileManager
    {
        public static int counter = 0;
        private static readonly string currentDirectory = Directory.GetCurrentDirectory();
        private readonly string ParkingPath = currentDirectory + "\\parkings";

        public FileManager()
        {
            counter++;
        }

        public void CreateParkingFile(string path)
        {
            // create just once
            if (counter < 2)
            {
                _ = Directory.CreateDirectory(ParkingPath);
            }

            string filePath = path;

            Stream stream = File.Create(filePath);
            stream.Close();
        }

        public void WriteParkingFile(string path, List<Vehicle> source)
        {
            FileManager fileManager = new FileManager();
            List<Vehicle> list = source;

            fileManager.CreateParkingFile(path);

            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                StreamWriter sw = new StreamWriter(fileStream);
                foreach (var item in list)
                {
                    sw.Write(item.Owner is null ? "" : "" + item.Owner);
                    sw.Write(item.OwnerID is 0 ? ", " : ", " + item.OwnerID);
                    sw.Write(", " + (int)item.Type);
                    sw.Write(item.LicensePlate is null ? ", " : "," + item.LicensePlate);
                    sw.Write(item.Parking is null ? ", " : "," + item.Parking);

                    sw.Write("\n");
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
    }
}
