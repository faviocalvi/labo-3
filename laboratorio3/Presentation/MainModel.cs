namespace laboratorio3.Presentation;

public partial record MainModel
{
    private INavigator _navigator;
    public delegate void StudentDataSubmittedHandler(StudenData data);
    public event StudentDataSubmittedHandler? StudentDataSubmitted;

    public MainModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);
    public IState<string> Age => State<string>.Value(this, () => string.Empty);
    public IState<string> Address => State<string>.Value(this, () => string.Empty);
    public IState<string> Destination => State<string>.Value(this, () => string.Empty);

    public async Task GoToSecond()
    {
        var data = new StudenData
        {
            Name = await Name,
            Age = await Age,
            Address = await Address,
            Destination = await Destination
        };
        StudentDataSubmitted?.Invoke(data);
        await _navigator.NavigateViewModelAsync<SecondModel>(this, data:data!);
    }

}
