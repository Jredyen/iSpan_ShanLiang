using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Frm_ShanLiang
{
    public class CStorePage
    {
        ShanLiangEntities SLE = new ShanLiangEntities(); //資料模型  
        List<Store> _list = new List<Store>(); //建立Store類別的集合
        public event CStoreShow cSS;//委派方法
        public static int _sid = 1; //店家的ID
        
        
        //public CStorePage()
        //{
        //    LoadStoreData();            
        //}  
        //public void LoadStoreData()
        //{
        //    Store store = new Store();//新Store物件
        //    var qName = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => n.RestaurantName);
        //    foreach (var item in qName)
        //        store.RestaurantName = item;
        //    _list.Add(store);
        //}
        //public Store getCurrent()
        //{
        //    return _list[_sid];
        //}
        public void OutsideShow()
        {            
            cSS();
        }
        
    }
}
