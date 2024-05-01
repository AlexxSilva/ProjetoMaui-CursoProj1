namespace AppMAUIGallery.Views.Components.Mains;

public partial class ButtonPage : ContentPage
{
	public ButtonPage()
	{
		InitializeComponent();
	}

    private void Button_Pressed(object sender, EventArgs e)
    {
        lblLog.Text += $"\n;Pressionado:{DateTime.Now}";
    }

    private void Button_Released(object sender, EventArgs e)
    {
        lblLog.Text += $"\n;Liberado:{DateTime.Now}";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        lblLog.Text += $"\n;Clicado:{DateTime.Now}";
    }
}