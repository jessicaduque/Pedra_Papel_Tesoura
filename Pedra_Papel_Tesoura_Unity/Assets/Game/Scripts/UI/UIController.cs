using DG.Tweening;
using UnityEngine;
using Utils.Singleton;

public class UIController : Singleton<UIController>
{
    [SerializeField] private GameObject _GamePlayPanel;

    // Variáveis de rect transforms
    [SerializeField] private RectTransform _planeta1;
    [SerializeField] private RectTransform _planeta2;
    [SerializeField] private RectTransform _ufo;

    // Variáveis de posição
    [SerializeField] private Vector3 _planeta1EndPos;
    [SerializeField] private Vector3 _planeta2EndPos;
    [SerializeField] private Vector3 _ufoEndPos;

    // Variáveis de tempo
    public const float _initialWaitTime = 2f;
    public float _animationTime = 2f;

    private new void Awake() { }

    #region InitialPart

    public void MoveInitialUI()
    {
        _planeta1.DOLocalMoveY(150, _animationTime);
        _ufo.DOLocalMoveY(-150, _animationTime).OnComplete(ContinueInitialUI_1);
    }

    private void ContinueInitialUI_1()
    {
        _planeta1.DOAnchorPos(_planeta1EndPos, _animationTime / 3).SetDelay(_initialWaitTime);

        _animationTime /= 2;

        _planeta2.DOAnchorPos(new Vector2(-30, -120), _animationTime).SetDelay(_initialWaitTime);
        _planeta2.DOScale(1.4f, _animationTime).SetDelay(_initialWaitTime);
        _ufo.DOAnchorPos(new Vector2(30, 120), _animationTime).SetDelay(_initialWaitTime);
        _ufo.DOScale(1.5f, _animationTime).SetDelay(_initialWaitTime).OnComplete(ContinueInitialUI_2);

        _animationTime *= 2;
    }
    private void ContinueInitialUI_2()
    {
        _planeta2.DOAnchorPos(_planeta2EndPos, _animationTime / 2).SetDelay(_initialWaitTime / 4);
        _ufo.DOAnchorPos(_ufoEndPos, _animationTime / 2).SetDelay(_initialWaitTime / 4).OnStart(GamePlayPanelUI);
    }

    #endregion

    #region GamePlay

    private void GamePlayPanelUI()
    {
        _GamePlayPanel.SetActive(true);
    }

    #endregion
}
