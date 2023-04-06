using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frm_ShanLiang
{
    public class CStoreData : CNowLoginAccount
    {
        internal static string _storyName { get; set; }
        internal static string _taxID { get; set; }
        internal static string _restaurantName { get; set; }
        internal static string _restaurantAddress { get; set; }
        internal static string _restaurantPhone { get; set; }
        internal static int? _seats { get; set; }
        internal static string _website { get; set; }
        internal static string _storeMail { get; set; }
    }
}
