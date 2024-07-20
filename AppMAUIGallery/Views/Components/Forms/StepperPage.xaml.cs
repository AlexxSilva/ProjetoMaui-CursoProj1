namespace AppMAUIGallery.Views.Components.Forms;

public partial class StepperPage : ContentPage
{
	public StepperPage()
	{
		InitializeComponent();
	}

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        LblValue.Text = $"Antigo:{e.OldValue.ToString()} Novo: {e.NewValue.ToString()}";
    }
}