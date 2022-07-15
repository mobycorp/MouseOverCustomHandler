// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

using Microsoft.Maui.Platform;
using System.Diagnostics;

namespace MouseOverCustomHandler.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication {

	/// <summary>
	/// Initializes the singleton application object.  This is the first line of authored code
	/// executed, and as such is the logical equivalent of main() or WinMain().
	/// </summary>
	public App () {

		InitializeComponent ();

		Microsoft.Maui.Handlers.ButtonHandler.Mapper.AppendToMapping (nameof(Button), (handler, view) => {
			handler.PlatformView.PointerEntered += PlatformView_PointerEntered;
			handler.PlatformView.PointerExited += PlatformView_PointerExited;
		});
	}

	protected override MauiApp CreateMauiApp () => MauiProgram.CreateMauiApp ();

	private void PlatformView_PointerExited (object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e) {

		// This breakpoint gets hit because the PointerExited delegate
		// does get executed which is goodness, but the comment below
		// indicates why it won't work...
		try {
			if (sender is Button button) {
				_ = VisualStateManager.GoToState (button, "PointerExited");
			}
		} catch (Exception) {
			Debug.WriteLine ("Failed on sender cast as Button... button is null");
		}

		try {
			var button = sender as MauiButton;

			// If you uncomment the next line, the red squiggly of death appears because
			// MauiButton is not a VisualElement.
			//_ = VisualStateManager.GoToState (button, "PointerExited");
		} catch (Exception) {
			Debug.WriteLine ("Button, when cast as MauiButton... button is not a VisualElement");
		}
	}

	private void PlatformView_PointerEntered (object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e) {

		// This breakpoint gets hit because the PointerExited delegate
		// does get executed which is goodness, but the comment below
		// indicates why it won't work...
		try {
			if (sender is Button button) {
				_ = VisualStateManager.GoToState (button, "PointerEntered");
			}
		} catch (Exception) {
			Debug.WriteLine ("Failed on sender cast as Button... button is null");
		}

		try {
			var button = sender as MauiButton;

			// If you uncomment the next line, the red squiggly of death appears because
			// MauiButton is not a VisualElement.
			//_ = VisualStateManager.GoToState (button, "PointerExited");
		} catch (Exception) {
			Debug.WriteLine ("Button, when cast as MauiButton... button is not a VisualElement");
		}
	}
}