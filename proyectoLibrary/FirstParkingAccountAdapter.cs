using proyectoLibrary.Interface;
using System;
using System.IO;

namespace proyectoLibrary
{
    sealed class FirstParkingAccountAdapter : IParkingAccountAdapter
    {
        private static string Year = DateTime.Now.Year.ToString();
        private static string Month = DateTime.Now.Month.ToString();
        private static string Day = DateTime.Now.Day.ToString();
        private static string CurrentDirectory = Directory.GetCurrentDirectory() + "\\parkingAccounts\\" + Year + "\\" + Month;
        private static string CurrentDirectoryFile = CurrentDirectory + "\\" + Day + ".txt";

        public FileStream GetParkingAccountConnection()
        {
            _ = Directory.CreateDirectory(CurrentDirectory);

            return File.Create(CurrentDirectoryFile);
        }
    }
}
