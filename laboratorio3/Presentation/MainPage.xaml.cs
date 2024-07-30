
namespace laboratorio3.Presentation;
using Windows.UI.Popups;
public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        this.Loaded += MainPage_Loaded;
    }
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is MainModel viewModel)
        {
            viewModel.StudentDataSubmitted += OnStudentDataSubmitted;
        }
    }

    private async void OnStudentDataSubmitted(StudenData data)
    {
        var dialog = new MessageDialog($"Name: {data.Name}\nAge: {data.Age}\nAddress: {data.Address}\nDestination: {data.Destination}", "Student Data submitted");
        await dialog.ShowAsync();
    }
}
