using System.Windows.Input;

namespace TempoPercentStudio.MAUI.Pages;

public partial class CalculateTempoView : ContentPage
{
    public ICommand OnAppearingCommand
    {
        get { return (ICommand)GetValue(OnAppearingCommandProperty); }
        set { SetValue(OnAppearingCommandProperty, value); }
    }

    public static readonly BindableProperty OnAppearingCommandProperty = BindableProperty.Create(nameof(OnAppearingCommand), typeof(ICommand), typeof(CalculateTempoView), null);

    public CalculateTempoView(CalculateTempoViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        OnAppearingCommand?.Execute(null);
        base.OnAppearing();
    }
}