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
        public event CStoreLoad cSL;
        public static int _sid; //店家的ID
        public void outsideLoad()
        {            
            cSL();
        }
    }
}
