using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class TitleControl : UserControl
    {
        public TitleControl(Action<object, EventArgs> callback)
        {
            InitializeComponent();
            _callback = callback;   
        }

        Action<object, EventArgs> _callback;

        public int Difficulty { get => (int)countNumericUpDown.Value; }

        private void playButton_Click(object sender, EventArgs e)
        {
            _callback(sender, e);
        }
    }
}
