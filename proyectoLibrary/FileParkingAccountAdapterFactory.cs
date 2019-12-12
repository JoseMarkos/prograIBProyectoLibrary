using proyectoLibrary.Interface;

namespace proyectoLibrary
{
    public sealed class FileParkingAccountAdapterFactory
    {
        public IParkingAccountAdapter GetParkingAccountAdapter(IParkingAccountAdapter.PathType type)
        {
            return type switch
            {
                IParkingAccountAdapter.PathType.CurrentDay => (new CurrentParkingAccountAdapter()),
                IParkingAccountAdapter.PathType.First => (new FirstParkingAccountAdapter()),
                // IParkingAccountAdapter.PathType.Imported => (IParkingAccountAdapter)new CurrentParkingAccountAdapter(),
                _ => (new CurrentParkingAccountAdapter())
            };
        }
    }
}
