using System.Data;

namespace Game
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
            var result = inputs.Zip(answer).Select(x => x.First == x.Second ? "o" : "x").Aggregate("", (acc, x) => acc + x);
            var score = inputs.Zip(answer).Count(x => x.First == x.Second);

            resultLabel.Text = result;
            scoreLabel.Text = $"{score} / {inputs.Length}";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            _exit(this);
        }
    }
}
