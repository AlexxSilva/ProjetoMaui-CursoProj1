namespace AppMAUIGallery.Views.Components.Forms;

public partial class CheckBoxPage : ContentPage
{
	public CheckBoxPage()
	{
		InitializeComponent();
	}

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value == true)
        {
            CheckBox checkBox = ((CheckBox)sender);
            HorizontalStackLayout stack = (HorizontalStackLayout)checkBox.Parent;
            Label label = (Label)stack.Children[1];
            LblStatus.Text = label.Text;
        }
        else
        {
            LblStatus.Text = string.Empty;
        }
        
    }
}