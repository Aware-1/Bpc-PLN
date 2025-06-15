using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Dispatch
{
    [Table("PLN_Dispatch")]
    public class Dispatch
    {
        [Display(Name = "شماره سفارش")]// بپرسم چه شکلیه؟
        public string DispatchID { get; set; }
        public DispatchTypes DispatchType { get; set; } = 0;
        [Display(Name = "کد کالا")]
        public string ProductCode { get; set; }

        [Display(Name = "تن")]
        public string tnDispatch { get; set; } // بپرسم چه شکلیه؟



        [Display(Name = "کد شعبه")]
        public string BranchCode { get; set; }


        [Display(Name = "کد مشتری")]
        public string CustomerCode { get; set; }

    }

    public enum DispatchTypes
    {
        [Display(Name = "شارژکل")] All = 0,
        [Display(Name = "شعبه")] Brench = 1,
        [Display(Name = "مشتری")] Customer = 2
    }
}
