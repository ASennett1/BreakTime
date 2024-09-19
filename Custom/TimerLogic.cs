namespace BreakTime.Custom;

public class TimerLogic
{
    private int _intSec;
    private int _intMin;

    
    public void TimerTime(int minutes)
    {
        _intMin = minutes;
        _intSec = 0;
    }

    public bool SetTickCount()
    {
        if (_intSec == 0)
        {
            if (_intMin == 0)
            {
                return false;
            }
            else
            {
                _intMin--;
                _intSec = 59;
            }
        }
        else
        {
            _intSec--;
        }

        return true;
    }

    public string GetFormattedString()
    {
        return  _intMin.ToString().PadLeft(2, '0') + ":" +
               _intSec.ToString().PadLeft(2, '0') + "Minutes left";
    }
}