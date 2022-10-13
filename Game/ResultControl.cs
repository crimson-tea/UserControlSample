using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGame
{
    public partial class ResultControl : UserControl
    {
        private Action<ResultControl> _exit;

        public ResultControl(Action<ResultControl> exit)
        {
            InitializeComponent();
            _exit = exit;
        }

        internal void SetResult(int[] inputs, int[] answer)
        {
            var ox = inputs.Zip(answer).Select(x => x.First == x.Second ? "o" : "x").Aggregate("", (acc, x) => acc + x);
            var score = inputs.Zip(answer).Count(x => x.First == x.Second);

            resultLabel.Text = ox;
            scoreLabel.Text = $"{score} / {inputs.Length}";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            _exit(this);
        }
    }
}
