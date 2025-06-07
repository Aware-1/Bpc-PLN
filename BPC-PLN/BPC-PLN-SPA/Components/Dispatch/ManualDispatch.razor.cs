using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Domain.Entities.Dispatch;
using Domain.IRipository;

namespace BPC_PLN_SPA.Components.Dispatch
{

    public class ManualDispatchComponent : ComponentBase
    {
        protected IDispatchRipository _dispatchRipository;


        protected string inputCode;
        protected string fetchedName;
        protected DispatchTypes selectedType;

        protected bool IsDisabled => selectedType == DispatchTypes.All; 
        protected string labelText => selectedType switch
        {
            DispatchTypes.All => "در جدول وارد کنید",
            DispatchTypes.Brench => "کد شعبه:",
            DispatchTypes.Customer => "کد مشتری:"
        };
        protected void OnDispatchTypeChange(ChangeEventArgs e)
        {
            if (Enum.TryParse(e.Value.ToString(), out DispatchTypes newType))
            {
                selectedType = newType;
                inputCode = selectedType == DispatchTypes.All ? string.Empty : inputCode;
                StateHasChanged(); 
            }
        }




        protected List<DispatchTypes> dispatchTypes = Enum.GetValues(typeof(DispatchTypes)).Cast<DispatchTypes>().ToList();
        protected string GetEnumDisplayName(DispatchTypes type)
        {
            var field = type.GetType().GetField(type.ToString());
            var displayAttribute = field?.GetCustomAttribute<DisplayAttribute>();
            return displayAttribute?.Name ?? type.ToString();
        }

        protected async Task FetchName()
        {
            if (!string.IsNullOrEmpty(inputCode))
            {
                 fetchedName = selectedType switch
                {
                    DispatchTypes.Brench => await _dispatchRipository.GetBranchNameByCodeAsync(inputCode),
                    DispatchTypes.Customer => await _dispatchRipository.GetCustomerNameByCodeAsync(inputCode),
                    DispatchTypes.All => "..."
                };
            }
            else
            {
                fetchedName = string.Empty;
            }
        }


    





    }
}