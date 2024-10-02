namespace WindowsEditorSlow
{
    public partial class App : Application
    {
        public static string PreparedLongText = String.Empty;


        public App()
        {
            InitializeComponent();
            // To keep creation of string out of "measurement"
            PreparedLongText = new string('x', 64000);
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
