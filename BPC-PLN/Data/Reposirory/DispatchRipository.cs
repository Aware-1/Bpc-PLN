﻿using Domain.IRipository;

namespace Data.Reposirory
{
    public class DispatchRipository : IDispatchRipository
    {
        public async Task<string> GetBranchNameByCodeAsync(string code)
        {
            return "سیرلذشسذرلسذرش";
        }

        public async Task<string> GetCustomerNameByCodeAsync(string code)
        {
            return "sdvosvm";
        }
    }
}
