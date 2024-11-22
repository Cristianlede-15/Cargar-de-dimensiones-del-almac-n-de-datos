using LoadDimsDWH.Data.Results;

namespace LoadDimsDWH.Data.Interfaces
{
    public interface IDataServiceDwOrders
    {
        Task<OperactionResult> LoadDwh();
    }
}
