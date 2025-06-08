using Domain.IRipository;

namespace Data.Reposirory
{
    public class DispatchRipository : IDispatchRipository
    {
        public async Task<string> GetBranchNameByCodeAsync(string code)
        {
            return "تهران غرب";
        }

        public async Task<string> GetCustomerNameByCodeAsync(string code)
        {
            return "Tehronas";
        }
    }
}
