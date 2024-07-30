namespace laboratorio3.Presentation;

public sealed partial class SecondPage : Page
{
    public SecondPage()
    {
        this.InitializeComponent();
    }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (e.Parameter is SecondModel viewModel)
        {
            this.DataContext = viewModel;
        }
    }
}

