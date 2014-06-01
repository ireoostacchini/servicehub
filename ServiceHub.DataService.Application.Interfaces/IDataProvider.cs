using ServiceHub.DataContracts.Interfaces;
using ServiceHub.DataAccess;


namespace ServiceHub.DataService.Application.Interfaces
{
    public interface IDataProvider
    {
        void LoadData(IData data, IUnitOfWork unitOfWork);
    }
}