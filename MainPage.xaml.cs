using BreakTime.Custom;

namespace BreakTime;

public partial class MainPage : ContentPage
{
    TimerLogic breakTime = new TimerLogic(minutes);
    

    public MainPage()
    {
        InitializeComponent();
    }


    private void btnFive_OnClicked(object sender, EventArgs e)
    {
        
        lblDisplay.Text = breakTime(5).GetFormattedString();
        
    }
}