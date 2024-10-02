#if WINDOWS
using Microsoft.Maui.Handlers;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WindowsEditorSlow.Handler
{

    public partial class RichEditorHandler() : ViewHandler<RichEditor, RichEditBox>(Mapper)
    {
        public static IPropertyMapper<RichEditor, RichEditorHandler> Mapper = new PropertyMapper<RichEditor, RichEditorHandler>(ViewHandler.ViewMapper)
        {
            [nameof(RichEditor.Text)] = MapText
        };

        protected override RichEditBox CreatePlatformView()
        {
            var richEditBox = new RichEditBox
            {
                IsReadOnly = false,
                AcceptsReturn = true,
                TextWrapping = TextWrapping.Wrap
            };
            return richEditBox;
        }

        public static void MapText(RichEditorHandler handler, RichEditor view)
        {
            handler.PlatformView.Document.SetText(TextSetOptions.None, view.Text ?? string.Empty);
        }

        protected override void ConnectHandler(RichEditBox platformView)
        {
            base.ConnectHandler(platformView);
            platformView.TextChanged += OnTextChanged;
        }

        protected override void DisconnectHandler(RichEditBox platformView)
        {
            platformView.TextChanged -= OnTextChanged;
            base.DisconnectHandler(platformView);
        }

        private void OnTextChanged(object sender, RoutedEventArgs e)
        {
            if (VirtualView != null && PlatformView != null)
            {
                PlatformView.Document.GetText(TextGetOptions.None, out var text);
                VirtualView.Text = text;
            }
        }
    }
}
#endif