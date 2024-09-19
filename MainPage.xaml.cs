using BreakTime.Custom;

namespace BreakTime;

public partial class MainPage : ContentPage
{
    private TimerLogic _breakTime;
    private bool _isTimerRunning;
    private bool _redBackground;
    private bool _alternateBackground;
    private CancellationTokenSource _cancelTokenSource;
    

    public MainPage()
    {
        InitializeComponent();
        _isTimerRunning = false;
        _redBackground = false;
        _alternateBackground = false;
        _cancelTokenSource = new CancellationTokenSource();

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
        var token = _cancelTokenSource.Token;
        
        
        
         _breakTime = new TimerLogic(minutes);
         //lblTimer.Text = _breakTime.GetTime();
         lblDisplay.Text = _breakTime.GetFormattedString();

         

       
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (token.IsCancellationRequested)
                {
                    return false;
                }
                
                
                if (!_breakTime.SetTickCount())
                {
                    lblDisplay.Text = "Time's up!";
                    
                    ToggleBackground();
                    return false;
                }
                else
                {
                    //lblTimer.Text = _breakTime.GetTime();
                    lblDisplay.Text = _breakTime.GetFormattedString();
                    return true;
                }
            });
       
    }

    private void StopTimer()
    {
        _cancelTokenSource.Cancel();
        _cancelTokenSource.Dispose();
        _cancelTokenSource = new CancellationTokenSource();
        _isTimerRunning = false;
    }
    private void btnFive_OnClicked(object sender, EventArgs e)
    {
        _isTimerRunning = false;
        StopTimer();
        _alternateBackground = false;
        _redBackground = false;
        ftnMain.Background = Colors.White;
        StartTimer(1);
        
    }

    private void btnTen_OnClicked(object sender, EventArgs e)
    {
        _isTimerRunning = false;
        StopTimer();
        _alternateBackground = false;
        _redBackground = false;
        ftnMain.Background = Colors.White;
        StartTimer(10);
        
    }

    private void btnFifteen_OnClicked(object sender, EventArgs e)
    {
        _isTimerRunning = false;
        StopTimer();
        _alternateBackground = false;
        _redBackground = false;
        ftnMain.Background = Colors.White;
        StartTimer(15);
        
    }
}