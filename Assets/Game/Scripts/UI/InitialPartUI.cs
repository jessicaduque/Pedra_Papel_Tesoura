using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class InitialPartUI : MonoBehaviour
{
    [SerializeField] private RectTransform _logo;
    [SerializeField] private RectTransform _foguete1;
    [SerializeField] private RectTransform _foguete2;
    [SerializeField] private RectTransform _startButton;
    [SerializeField] private Vector3[] _fogueteEndPositions = new Vector3[2];
    private float _animationTime => UIController._animationTime;
    private float _initialWaitTime => UIController._initialWaitTime;
    private Button b_start;

    private UIController _uiController => UIController.I;
    private void Awake()
    {
        b_start = _startButton.GetComponent<Button>();
        b_start.onClick.AddListener(StartGameUI);
    }

    private void StartGameUI()
    {
        b_start.enabled = false;
        _startButton.DOAnchorPosY(-400, _animationTime).OnComplete(StartGameUIContinue);
        _logo.DOLocalMoveY(0, _animationTime);
        _foguete1.DOAnchorPos(_fogueteEndPositions[0], _animationTime / 2);
        _foguete2.DOAnchorPos(_fogueteEndPositions[1], 3 * (_animationTime / 4)).SetDelay(_animationTime / 4);
        _uiController.MoveInitialUI();
    }
    private void StartGameUIContinue()
    {
        _logo.DOAnchorPosY(800, _animationTime).SetDelay(_initialWaitTime);
        _foguete2.DOAnchorPos(_fogueteEndPositions[0], _animationTime / 3).SetDelay(_initialWaitTime);
    }
}
