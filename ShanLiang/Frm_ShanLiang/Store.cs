//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Frm_ShanLiang
{
    using System;
    using System.Collections.Generic;
    
    public partial class Store
    {
        public int StoreID { get; set; }
        public string AccountName { get; set; }
        public string TaxID { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantPhone { get; set; }
        public Nullable<int> DistrictID { get; set; }
        public Nullable<int> Seats { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<System.TimeSpan> OpeningTime { get; set; }
        public Nullable<System.TimeSpan> ClosingTime { get; set; }
        public string Website { get; set; }
        public byte[] StoreImage { get; set; }
        public Nullable<int> Rating { get; set; }
        public string StoreMail { get; set; }
    }
}
