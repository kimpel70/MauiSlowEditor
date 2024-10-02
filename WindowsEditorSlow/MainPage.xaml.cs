namespace WindowsEditorSlow
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            if (Application.Current?.MainPage is NavigationPage np)
            {
                np.PushAsync(new EditorPage());
            }
        }
    }

}
