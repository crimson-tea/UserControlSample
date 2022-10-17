namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _titleControl = new TitleControl(playButton_Click);
            Controls.Add(_titleControl);
        }

        TitleControl _titleControl;

        private async void playButton_Click(object sender, EventArgs e)
        {
            var numbers = Enumerable.Repeat(0, _titleControl.Difficulty).Select(x => Random.Shared.Next(1, 10)).ToArray();
            Controls.Remove(_titleControl);

            using ShowNumberControl showNumber = new ShowNumberControl();
            Controls.Add(showNumber);
            await showNumber.PlayAsync(numbers);
            Controls.Remove(showNumber);

            using var input = new InputControl();
            Controls.Add(input);
            var inputs = await input.GetInputAsync(numbers.Length);
            Controls.Remove(input);

            ResultControl result = new ResultControl((ResultControl self) =>
            {
                Controls.Remove(self);
                self.Dispose();
                Controls.Add(_titleControl);
            });
            Array.Reverse(numbers);
            result.SetResult(inputs, numbers);
            Controls.Add(result);
        }
    }
}