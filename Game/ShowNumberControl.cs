namespace Game
{
    public partial class ShowNumberControl : UserControl
    {
        public ShowNumberControl()
        {
            InitializeComponent();
        }

        public async Task PlayAsync(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                progressLabel.Text = $"{i + 1}/ {numbers.Length}";
                numberLabel.Text = numbers[i].ToString();
                await Task.Delay(500);

                numberLabel.Text = string.Empty;
                await Task.Delay(500);
            }
        }
    }
}
