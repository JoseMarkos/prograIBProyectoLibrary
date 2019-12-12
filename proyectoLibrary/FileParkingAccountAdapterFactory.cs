using proyectoLibrary.Interface;


namespace proyectoLibrary
{
    sealed class FileParkingAccountAdapterFactory
    {
        private IParkingAccountAdapter GetParkingAccountAdapter(IParkingAccountAdapter.PathType type)
        {
            return type switch
            {
                IParkingAccountAdapter.PathType.CurrentDay => (IParkingAccountAdapter)new CurrentParkingAccountAdapter(),
                IParkingAccountAdapter.PathType.Imported => (IParkingAccountAdapter)new CurrentParkingAccountAdapter(),
            };
        }
    }
}
