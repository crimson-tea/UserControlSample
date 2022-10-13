using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class InputControl : UserControl
    {
        public InputControl()
        {
            InitializeComponent();

            Size = new Size(290, 290);
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < 9; i++)
            {
                var num = i + 1;
                Button b = new Button();
                b.Text = num.ToString();
                b.Location = new Point(i % 3 * 70 + 50, i / 3 * 70 + 50);
                b.Size = new Size(50, 50);
                b.Click += numberButton_Click;
                b.Tag = num;

                Controls.Add(b);
            }
        }


        List<int> _inputNumbers = new List<int>();

        private void numberButton_Click(object? sender, EventArgs e)
        {
            Button button = sender as Button;
            var number = (int)button.Tag;
            _inputNumbers.Add(number);
        }

        internal async Task<int[]> GetInputAsync(int count)
        {
            while (_inputNumbers.Count < count)
            {
                progressLabel.Text = $"{_inputNumbers.Count} / {count}";
                await Task.Delay(16);
            }

            return _inputNumbers.Take(count).ToArray();
        }
    }
}
