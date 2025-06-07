namespace Domain.IRipository
{
    public interface IDispatchRipository
    {
        Task<string> GetCustomerNameByCodeAsync(string code);
        Task<string> GetBranchNameByCodeAsync(string code);
    }
}
