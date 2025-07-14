using Domain.Dtos;
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
        public string? FetchedBranchName { get; set; }

        [Parameter]
        public DispatchTypes? Type { get; set; }

        protected List<GridManualDispatchVM> DispatchList { get; set; } = new();

        protected GridManualDispatchVM dispatchVM = new();

        //جهت چک کردن نمونه جدید
        private DispatchTypes? PreviousType { get; set; }


        #endregion


        protected override void OnParametersSet()
        {
            if (!string.IsNullOrEmpty(Value))
                AddNewRow();


            if (Type != PreviousType)
            {
                if (Type == DispatchTypes.All)
                {
                    DispatchList.Clear();
                    AddNewRow();
                }
                else
                    DispatchList.Clear();
                PreviousType = Type;
            }
        }
        private void AddNewRow()
        {
            DispatchList.Insert(0, new GridManualDispatchVM
            {
                DispatchType = Type ?? DispatchTypes.Customer,
                BranchCode = Value ?? "",
                BranchName = FetchedBranchName ?? ""
            });

        }
        protected string GetBranchColumnHeader()
            => Type switch
            {
                DispatchTypes.Customer => "کد مشتری",
                DispatchTypes.Brench => "کد شعبه",
                DispatchTypes.All => "کد شعبه"
            };

        protected bool IsBranchInputDisabled(DispatchTypes dispatchType)
           => dispatchType == DispatchTypes.Brench || dispatchType == DispatchTypes.Customer;



        //for edit in All mode
        protected async Task FetchBranchName(GridManualDispatchVM dispatch)
        {
            if (!string.IsNullOrEmpty(dispatch.BranchCode) && Type == DispatchTypes.All)
            {
                dispatch.BranchName = await _dispatchRipository.GetBranchNameByCodeAsync(dispatch.BranchCode);
            }
            else
            {
                dispatch.BranchName = string.Empty;
            }
            StateHasChanged();
        }

        protected async Task FetchProductName(GridManualDispatchVM dispatch)
        {
            if (!string.IsNullOrEmpty(dispatch.ProductCode))
            {
                dispatch.ProductDescription = await _dispatchRipository.GetBranchNameByCodeAsync(dispatch.ProductCode); //Todo
            }
            else
            {
                dispatch.ProductDescription = string.Empty;
            }
            StateHasChanged();
        }  
        protected async Task CalcTn(GridManualDispatchVM dispatch)
        {
            if (!string.IsNullOrEmpty(dispatch.Count))
            {
                dispatch.tnDispatch = await _dispatchRipository.CalcTnForDispatch(dispatch.Count); //Todo
                AddNewRow();
            }
            else
            {
                dispatch.tnDispatch = string.Empty;
            }
            StateHasChanged();
        }



        protected async Task HandleSubmit()
        {
            var validRows = DispatchList
                .Where(row => !string.IsNullOrEmpty(row.BranchName) && !string.IsNullOrEmpty(row.ProductDescription))
                .ToList();

            if (validRows.Any())
            {
                await _dispatchRipository.SubmitDispatchRowsAsync(validRows);
                Console.WriteLine("succes");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }

    }
}
