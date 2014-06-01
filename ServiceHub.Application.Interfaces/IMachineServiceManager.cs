using ServiceHub.DataContracts;

namespace ServiceHub.Application.Interfaces
{
    public interface IMachineServiceManager
    {
        MachineServiceDto MachineService { get; set; }
        void Stop();
        void Start();
        IMachineServiceStatus GetStatus();
        bool ServiceExists();
    }
}