using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SetupApp.Model
{
    class RotaryDataModel
    {
        public string RightTextData { get; set; }
        public string LeftTextData { get; set; }

        public RotaryDataModel() 
        {
            RightTextData = "";
            LeftTextData = "";
        }
    }
}
