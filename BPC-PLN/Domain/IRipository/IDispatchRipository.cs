using Domain.Dtos;
using Domain.Entities.Dispatch;

namespace Domain.IRipository
{
    public interface IDispatchRipository
    {
        Task<string> GetCustomerNameByCodeAsync(string code);
        Task<string> GetBranchNameByCodeAsync(string code);
        Task<string> CalcTnForDispatch(string code);
        Task<bool> SubmitDispatchRowsAsync(List<GridManualDispatchVM> dispatches);
    }
}
