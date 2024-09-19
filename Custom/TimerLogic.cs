namespace BreakTime.Custom;

public class TimerLogic
{
    private int _intSec;
    private int _intMin;

    


    public TimerLogic(int minutes)
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
        return  _intMin.ToString().PadLeft(1, '0') + " " + "Minute(s) left";
    }
    
    public string GetTime()
    {
        return  _intMin.ToString().PadLeft(2, '0') + ":" +
                _intSec.ToString().PadLeft(2, '0');
    }
}