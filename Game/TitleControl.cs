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
