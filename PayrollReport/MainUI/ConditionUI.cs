using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainUI
{
    public partial class ConditionUI : Form
    {
        public ConditionUI()
        {
            InitializeComponent();
        }
        public ConditionUI(Dictionary<int,List<string>> condition)
            :this()
        {

        }
        private void ConditionUI_Load(object sender, EventArgs e)
        {

        }
    }
}
