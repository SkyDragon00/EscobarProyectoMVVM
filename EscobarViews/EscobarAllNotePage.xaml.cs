namespace EscobarProyectoMVVM.EscobarViews;

public partial class EscobarAllNotePage : ContentPage
{
	public EscobarAllNotePage()
	{
		InitializeComponent();
	}

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }
}