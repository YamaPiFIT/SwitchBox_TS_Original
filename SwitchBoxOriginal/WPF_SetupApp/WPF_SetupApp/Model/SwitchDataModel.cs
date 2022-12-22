using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SetupApp.Model
{
    class SwitchDataModel
    {
        public string OnTextData { get; set; }
        public string OffTextData { get; set; }

        public SwitchDataModel(string _onTextData, string _offTextData)
        {
            OnTextData = _onTextData;
            OffTextData = _offTextData;
        }
    }
}
