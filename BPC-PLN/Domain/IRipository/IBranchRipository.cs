using Domain.Dtos;

namespace Domain.IRipository
{
    public interface IBranchRipository
    {
        string? GetUserName();
        Task<HeaderBranchDto?> GetHeaderAsync(string userName);

    }
}
