namespace MouseOverCustomHandler;

public static class MauiProgram {

	public static MauiApp CreateMauiApp () {

		var builder = MauiApp.CreateBuilder ();

		_ = builder
			.UseMauiApp<App> ()
			.ConfigureFonts (fonts => {
				_ = fonts.AddFont ("OpenSans-Regular.ttf", "OpenSansRegular");
				_ = fonts.AddFont ("OpenSans-Semibold.ttf", "OpenSansSemibold");
				_ = fonts.AddFont ("Font Awesome 6 Pro-Light-300.otf", "FaLight");
			});

		return builder.Build ();
	}
}