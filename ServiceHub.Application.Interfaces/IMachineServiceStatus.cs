namespace ServiceHub.Application.Interfaces
{
    public interface IMachineServiceStatus
    {
        int Id { get; set; }
        string Name { get; set; }
        string ToString();
    }
}