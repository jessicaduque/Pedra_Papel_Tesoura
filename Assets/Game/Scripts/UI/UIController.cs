using DG.Tweening;
using UnityEngine;
using Utils.Singleton;

public class UIController : Singleton<UIController>
{
    [SerializeField] private RectTransform _planeta1;
    [SerializeField] private RectTransform _planeta2;
    [SerializeField] private RectTransform _ufo;
    [SerializeField] private Vector3 _planeta1EndPos;
    [SerializeField] private Vector3 _planeta2EndPos;
    [SerializeField] private Vector3 _ufoEndPos;

    public const float _initialWaitTime = 2f;
    public const float _animationTime = 2f;

    #region InitialPart

    public void MoveInitialUI()
    {
        _planeta1.DOLocalMoveY(70, _animationTime);
        _ufo.DOLocalMoveY(-70, _animationTime).OnComplete(ContinueInitialUI_1);
    }

    private void ContinueInitialUI_1()
    {
        _planeta1.DOAnchorPos(_planeta1EndPos, _animationTime / 3).SetDelay(_initialWaitTime).OnComplete(ContinueInitialUI_2);
        _planeta2.DOAnchorPos(new Vector2(-50, -30), _animationTime).SetDelay(_initialWaitTime);
        _planeta2.DOScale(1.3f, _animationTime).SetDelay(_initialWaitTime);
        _ufo.DOLocalMove(new Vector2(30, 30), _animationTime).SetDelay(_initialWaitTime);
        _ufo.DOScale(1.3f, _animationTime).SetDelay(_initialWaitTime);
    }
    private void ContinueInitialUI_2()
    {
        _planeta2.DOLocalMove(_planeta2EndPos, _animationTime).SetDelay(_initialWaitTime / 2);
        _ufo.DOLocalMove(_ufoEndPos, _animationTime).SetDelay(_initialWaitTime / 2);
    }

    #endregion
}
