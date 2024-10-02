namespace WindowsEditorSlow
{
    public partial class App : Application
    {
        public static string PreparedLongText;


        public App()
        {
            InitializeComponent();
            // To keep creating out of the measurement
            PreparedLongText = new string('x', 64000);
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
