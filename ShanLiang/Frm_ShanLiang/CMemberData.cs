using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frm_ShanLiang
{
    internal class CMemberData : CNowLoginAccount
    {
        internal static string _memberphone { get; set; }
        internal static string _memberName { get; set; }
        internal static string _email { get; set; }
        internal static DateTime? _brithDate { get; set; }
        internal static string _address { get; set; }
        internal static int? _customerLevel { get; set; }
    }
}
