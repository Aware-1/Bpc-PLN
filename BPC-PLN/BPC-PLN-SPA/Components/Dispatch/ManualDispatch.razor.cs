using Domain.Entities.Dispatch;
using Domain.IRipository;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BPC_PLN_SPA.Components.Dispatch
{

    public class ManualDispatchComponent : ComponentBase
    {
        [Inject]
        private IDispatchRipository _dispatchRipository { get; set; }

        protected DispatchTypes selectedType;
        protected string inputCode { get; set; }
        protected string fetchedName;

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
                inputCode = fetchedName = selectedType == DispatchTypes.All ? string.Empty : inputCode = fetchedName;
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

        protected async Task FetchName(ChangeEventArgs e)
        {
            inputCode = e.Value.ToString();

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
            StateHasChanged();
        }
    }
}