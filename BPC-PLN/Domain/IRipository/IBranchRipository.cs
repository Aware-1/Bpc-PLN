using Domain.Dtos;

namespace Domain.IRipository
{
    public interface IBranchRipository
    {
        string? GetUserName();
        string? GetUserRole();
        Task<HeaderBranchDto?> GetHeaderAsync(string userName);

    }
}
