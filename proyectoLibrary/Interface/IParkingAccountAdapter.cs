using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoLibrary.Interface
{
    interface IParkingAccountAdapter
    {
        BindingSource GetParkingAccountConnection();

        enum PathType
        {
            CurrentDay,
            Imported
        } 
    }
}
