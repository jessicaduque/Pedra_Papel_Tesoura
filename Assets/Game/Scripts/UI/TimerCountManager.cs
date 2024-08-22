using Utils.Singleton;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountManager : Singleton<TimeCountManager>
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI t_time;
    [SerializeField] private Image im_outerCircle;

    [Header("Timer Settings")]
    [SerializeField] private float _startTime;
    private float _currentTime;

    private bool _timeOver = false;
    private bool _timerEnding = false;
    private bool _startTimer;

    //private LevelController _levelController => LevelController.I;
    //private AudioManager _audioManager => AudioManager.I;

    protected new void Awake()
    {
        _currentTime = _startTime + 1;
        SetTimeText();
    }
    private void Update()
    {
        if (!_timeOver)
        {
            _currentTime -= Time.deltaTime;

            if (!_timerEnding && _currentTime <= 4)
            {
                //_audioManager.PlaySfx2("clocktick");
                _timerEnding = true;
            }
            else if (_currentTime <= 0)
            {
                //_audioManager.StopSfx2();
                _timeOver = true;
            }
            else if (_currentTime > 6)
            {
                //_audioManager.StopSfx2();
                _timerEnding = false;
            }

            SetTimeText();
        }
        else
        {
            //_levelController.TimeUp();
        }
    
        /*
        if (_levelController.GetLevelState() == LevelState.CHOOSEMOVE)
        {
            if (!_timeOver)
            {
                _currentTime -= Time.deltaTime;

                if (!_timerEnding && _currentTime <= 6)
                {
                    _audioManager.PlaySfx2("clocktick");
                    _timerEnding = true;
                }
                else if (_currentTime <= 0)
                {
                    _audioManager.StopSfx2();
                    _timeOver = true;
                }
                else if (_currentTime > 6)
                {
                    _audioManager.StopSfx2();
                    _timerEnding = false;
                }

                SetTimeText();
            }
            else
            {
                _levelController.TimeUp();
            }
        }
        else
        {
            _audioManager.StopSfx2();
            _timerEnding = false;
        }
        */
    }

    #region Set

    public void SetTimeUp()
    {
        _timeOver = true;
    }

    private void SetTimeText()
    {
        int minutes = (int)_currentTime / 60;
        int seconds = (int)_currentTime - minutes * 60;
        t_time.text = string.Format("{0}", seconds);
        im_outerCircle.fillAmount = (_startTime - seconds) / _startTime;
    }

    #endregion
}
