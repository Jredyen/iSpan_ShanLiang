using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.AxHost;

namespace Frm_ShanLiang
{
    public class CCustomers
    {
        ShanLiangEntities SLE = new ShanLiangEntities();
        public void memberDataLoad(string accountName)
        {
            Member member = SLE.Members.Where(n => n.AccountName == accountName).FirstOrDefault();
            if (member != null)
            {
                CMemberData._memberId = member.MemberID;
                CMemberData._memberName = member.MemberName;
                CMemberData._address = member.Address;
                CMemberData._brithDate = (DateTime)member.BrithDate;
                CMemberData._memberphone = member.Memberphone;
                CMemberData._email = member.Email;
                CMemberData._customerLevel = (int)member.CustomerLevel;
            }
        }
        public void storeDataLoad(string accountName)
        {
            Store store = SLE.Stores.Where(n => n.AccountName == accountName).FirstOrDefault();
            if (store != null)
            {
                CStoreData._storeID = store.StoreID;
                CStoreData._storyName = store.AccountName;
                CStoreData._taxID = store.TaxID;
                CStoreData._restaurantName = store.RestaurantName;
                CStoreData._restaurantPhone = store.RestaurantPhone;
                CStoreData._restaurantAddress = store.RestaurantAddress;
                CStoreData._storeMail = store.StoreMail;
                CStoreData._seats = (int)store.Seats;
                CStoreData._website = store.Website;
                CStoreData._openTime = store.OpeningTime;
                CStoreData._closeTime = store.ClosingTime;
            }
        }
        internal void logout()
        {
            clearMemberData();
            clearStoreData();
        }
        internal void clearMemberData()
        {
            CMemberData._memberId = null;
            CMemberData._memberName = null;
            CMemberData._address = null;
            CMemberData._brithDate = null;
            CMemberData._memberphone = null;
            CMemberData._email = null;
            CMemberData._customerLevel = null;
        }
        internal void clearStoreData()
        {
            CStoreData._storeID = null;
            CStoreData._storyName = null;
            CStoreData._taxID = null;
            CStoreData._restaurantName = null;
            CStoreData._restaurantPhone = null;
            CStoreData._restaurantAddress = null;
            CStoreData._storeMail = null;
            CStoreData._seats = null;
            CStoreData._website = null;
            CStoreData._openTime = null;
            CStoreData._closeTime = null;
        }
    }
}
