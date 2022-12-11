namespace CanchaFacilMovil;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Views.ReservaPage), typeof(Views.ReservaPage));

    }
}
