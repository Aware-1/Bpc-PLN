using System.ComponentModel.DataAnnotations;
using Domain.Entities.Dispatch;

namespace Domain.Dtos
{
    public class GridManualDispatchVM
    {
        [Display(Name = "شماره سفارش")]// بپرسم چه شکلیه؟
        public string DispatchID { get; set; }

        public DispatchTypes DispatchType { get; set; } = 0;

        [Display(Name = "کد کالا")]
        public string ProductCode { get; set; }

        [Display(Name = "شرح کالا")]
        public string? ProductDescription { get; set; }
        
        [Display(Name = "تن")]
        public string tnDispatch { get; set; }





        [Display(Name = "کد شعبه")]
        public string BranchCode { get; set; }
        
        [Display(Name = "نام شعبه")]
        public string? BranchName { get; set; }


        [Display(Name = "کد مشتری")]
        public string CustomerCode { get; set; }

    }
}
