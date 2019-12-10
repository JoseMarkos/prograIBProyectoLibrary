using proyectoLibrary.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoLibrary.Interface
{
    interface IParkingAdapter
    {
        enum Source
        {
            Curret,
            Imported
        }
        
        List<Parking> GetPakingList();
    }
}
