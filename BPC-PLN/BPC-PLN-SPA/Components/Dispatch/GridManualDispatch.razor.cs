using Domain.Entities.Dispatch;
using Domain.IRipository;
using Microsoft.AspNetCore.Components;

namespace BPC_PLN_SPA.Components.Dispatch
{
    public class GridManualDispatchComponent : ComponentBase
    {
        #region prop

        [Inject]
        private IDispatchRipository _dispatchRipository { get; set; }

        [Parameter]
        public string? Value { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        [Parameter]
        public string? FetchedName { get; set; }

        [Parameter]
        public DispatchTypes? Type { get; set; }

        
        protected Domain.Entities.Dispatch.Dispatch dispatchVM = new Domain.Entities.Dispatch.Dispatch { };



        #endregion


        protected string GetBranchColumnHeader() 
            => Type switch
        {
            DispatchTypes.Customer => "کد مشتری",
            DispatchTypes.Brench => "کد شعبه",
            DispatchTypes.All => "کد شعبه"
        };

        protected bool IsBranchInputDisabled() =>
            Type == DispatchTypes.Brench || Type == DispatchTypes.Customer;

        //for edit in All mode
        protected async Task FetchName(ChangeEventArgs e)
        {
            Value = e.Value.ToString();

            if (!string.IsNullOrEmpty(Value) && Type == DispatchTypes.All)
            {
                FetchedName = await _dispatchRipository.GetBranchNameByCodeAsync(Value);
            }
            else
            {
                FetchedName = string.Empty;
            }
            StateHasChanged();
        }



















        protected string? FetchedProductName { get; set; }
        protected List<DispatchRow> DispatchList { get; set; } = new();
        protected override void OnInitialized()
        {
            DispatchList.Add(new DispatchRow());
        }
        protected async Task FetchProductName(ChangeEventArgs e)
        {
            string prodctCode = e.Value.ToString();

            if (!string.IsNullOrEmpty(prodctCode))
            {
                FetchedProductName = await _dispatchRipository.GetBranchNameByCodeAsync(prodctCode);
                AddNewRowIfNeeded();
            }
            else
            {
                FetchedProductName = string.Empty;
            }
            StateHasChanged();
        }
        private void AddNewRowIfNeeded()
        {
            // اگر آخرین ردیف کامل شده، یک ردیف جدید اضافه کن
            if (!string.IsNullOrEmpty(DispatchList[^1].Name))
            {
                DispatchList.Add(new DispatchRow());
            }
        }
        protected async Task HandleSubmit()
        {
            // ارسال ردیف‌ها به ریپوزیتوری
            var validRows = DispatchList
                .Where(row => !string.IsNullOrEmpty(row.Code) && !string.IsNullOrEmpty(row.Name))
                .ToList();

            if (validRows.Any())
            {
                await _dispatchRipository.SubmitDispatchRowsAsync(validRows);
                Console.WriteLine("Rows submitted successfully.");
            }
            else
            {
                Console.WriteLine("No valid rows to submit.");
            }
        }


    }
}
