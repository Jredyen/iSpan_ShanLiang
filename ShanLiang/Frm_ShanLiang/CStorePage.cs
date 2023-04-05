using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Frm_ShanLiang
{
    public class CStorePage
    {
        ShanLiangEntities SLE = new ShanLiangEntities(); //資料模型  
        List<Store> _list = new List<Store>(); //建立Store類別的集合

        public event CStoreShow cSS;//委派方法
        public static int _sid = 1; //店家的ID


        public CStorePage()
        {
            LoadStoreData();
        }//建構子，從資料庫載入店家資訊
        public void LoadStoreData()
        {
            Store store = new Store();//新Store物件
            store.StoreID = _sid;//載入StoreID
            //店名
            var qName = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => n.RestaurantName);
            foreach (var item in qName)
                store.RestaurantName = item;
            //地址
            var qAd = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => n.RestaurantAddress);
            foreach (var item in qAd)
                store.RestaurantAddress = item;
            //電話
            var qPhone = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => n.RestaurantPhone);
            foreach (var item in qPhone)
                store.RestaurantPhone = item;
            //空位
            var qSeat = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => n.Seats);
            foreach (var item in qSeat)
                store.Seats = item;
            //營業時間
            var qTime = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => new { n.OpeningTime, n.ClosingTime });
            foreach (var item in qTime)
            {
                store.OpeningTime = item.OpeningTime;
                store.ClosingTime = item.ClosingTime;
            }
            //店家圖片
            var qImg = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => n.StoreImage);
            foreach (var item in qImg)
                store.StoreImage = item;
            //評分
            var qRating = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => n.Rating);
            foreach (var item in qRating)            
                store.Rating = item;     

            _list.Add(store);//加入一筆新Store進_list
        }
        public Store getCurrent()
        {
            foreach (var item in _list)
                if(item.StoreID == _sid)
                {
                    return item;
                }                
            return null;
        }//取得當下_sid的_list

        public void OutsideShow()
        {
            LoadStoreData();
            cSS();
        }
        
    }
}
