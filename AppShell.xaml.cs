namespace MauiBug_SearchHandler_iOSCrash;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("secondpage", typeof(SecondPage));
    }
}
