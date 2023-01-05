using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SetupApp.Model
{
    class ButtonDataModel
    {
        public string TextData { get; set; }
        public string SecData { get; set; }

        public ButtonDataModel()
        {
            TextData = "";
            SecData = "";
        }
    }
}
