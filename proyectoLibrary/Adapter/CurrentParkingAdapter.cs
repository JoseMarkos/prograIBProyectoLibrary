using proyectoLibrary.Interface;
using proyectoLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoLibrary.Adapter
{
    class CurrentParkingAdapter : IParkingAdapter
    {
        private static string Year = DateTime.Now.Year.ToString();
        private static string Month = DateTime.Now.Month.ToString();
        private static string Day = DateTime.Now.Day.ToString();
        private static string CurrentVehiclesDirectory = Directory.GetCurrentDirectory() + "\\vehicles\\" + Year + "\\" + Month;
        private static string CurrentParkingsDirectory = Directory.GetCurrentDirectory() + "\\parkings\\" + Year + "\\" + Month;
        private static string CurrentVehiclesFile = CurrentVehiclesDirectory + "\\" + Day + ".txt";
        private static string CurrentParkingFile = CurrentParkingsDirectory + "\\" + Day + ".txt";

        public List<Parking> GetPakingList()
        {
            throw new NotImplementedException();
        }


    }
}
