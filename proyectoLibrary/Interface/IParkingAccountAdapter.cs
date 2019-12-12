using System.IO;

namespace proyectoLibrary.Interface
{
    public interface IParkingAccountAdapter
    {
        FileStream GetParkingAccountConnection();

        enum PathType
        {
            CurrentDay,
            First,
            Imported
        }
    }
}
