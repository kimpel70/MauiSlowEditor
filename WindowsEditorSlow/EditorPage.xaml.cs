namespace WindowsEditorSlow;

public partial class EditorPage : ContentPage
{
    public string LongText { get; set; }
    public EditorPage()
	{
        LongText = App.PreparedLongText;
        BindingContext = this;
		InitializeComponent();
    }
}