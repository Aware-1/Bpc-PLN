using Domain.Dtos;
using Domain.IRipository;

namespace Data.Reposirory
{
    public class DispatchRipository : IDispatchRipository
    {
        public async Task<string> CalcTnForDispatch(string code)
        {

            //if (true)
            //{
                 
                return "4231232";
            //}
        }

        public async Task<string> GetBranchNameByCodeAsync(string code)
        {
            return "تهران غرب";
        }

        public async Task<string> GetCustomerNameByCodeAsync(string code)
        {
            return "Tehronas";
        }

        public Task<bool> SubmitDispatchRowsAsync(List<GridManualDispatchVM> dispatches)
        {
            return Task.FromResult(true);
        }
    }
}
