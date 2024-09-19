using BreakTime.Custom;

namespace BreakTime;

public partial class MainPage : ContentPage
{
    private TimerLogic _breakTime;
    private bool _isTimerRunning;
    private bool _redBackground;
    private bool _alternateBackground;
    
    

    public MainPage()
    {
        InitializeComponent();
        _isTimerRunning = false;
        _redBackground = false;
        _alternateBackground = false;
        
    }

    private void ToggleBackground()
    {
        _alternateBackground = true;
        Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
        {
            if (_alternateBackground)
            {
                if (_redBackground)
                {
                    ftnMain.Background = Colors.White;
                }
                else
                {
                    ftnMain.Background = Colors.Red;
                }

                _redBackground = !_redBackground;
                return true;
            }

            return false;
        });

    }

    private void StartTimer(int minutes)
    {
        if (_isTimerRunning)
        {
            _isTimerRunning = false;
        }
        _breakTime = new TimerLogic(minutes);
        lblTimer.Text = _breakTime.GetTime();
        lblDisplay.Text = _breakTime.GetFormattedString();

        _isTimerRunning = true;

       
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (!_isTimerRunning)
                {
                    return false;
                }
                
                if (!_breakTime.SetTickCount())
                {
                    lblDisplay.Text = "Time's up!";
                    _isTimerRunning = false;
                    ToggleBackground();
                    return false;
                }
                else
                {
                    lblTimer.Text = _breakTime.GetTime();
                    lblDisplay.Text = _breakTime.GetFormattedString();
                    return true;
                }
            });
        
    }

    private void btnFive_OnClicked(object sender, EventArgs e)
    {
        _isTimerRunning = false;
        StartTimer(1);
        _alternateBackground = false;
        _redBackground = false;
        ftnMain.Background = Colors.White;
        
    }

    private void btnTen_OnClicked(object sender, EventArgs e)
    {
        _isTimerRunning = false;
        StartTimer(10);
        _alternateBackground = false;
        _redBackground = false;
        ftnMain.Background = Colors.White;
        
    }

    private void btnFifteen_OnClicked(object sender, EventArgs e)
    {
        _isTimerRunning = false;
        StartTimer(15);
        _alternateBackground = false;
        _redBackground = false;
        ftnMain.Background = Colors.White;
        
    }
}