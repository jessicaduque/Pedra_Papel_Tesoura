using DG.Tweening;
using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    // Variáveis de animação
    [SerializeField] private RectTransform _topLeftSide;
    [SerializeField] private RectTransform _topRightSide;
    [SerializeField] private RectTransform _handLeft;
    [SerializeField] private RectTransform _handRight;
    [SerializeField] private RectTransform _bottomButtons;

    // Variáveis de fade
    [SerializeField] private CanvasGroup _timerCG;
    [SerializeField] private CanvasGroup _moveChoiceText;

    private float _animationTime;

    private void Awake()
    {
        _moveChoiceText.alpha = 0;
        _timerCG.alpha = 0;
    }

    private void Start()
    {
        _animationTime = UIController.I._animationTime;
        StartGamePlayUI();
    }

    private void StartGamePlayUI()
    {
        _timerCG.DOFade(1, _animationTime);
        _moveChoiceText.DOFade(1, _animationTime);
        _bottomButtons.DOAnchorPosY(-250, _animationTime);
        _topRightSide.DOAnchorPosX(-20, _animationTime);
        _topLeftSide.DOAnchorPosX(20, _animationTime);
        _handLeft.DOAnchorPos(new Vector2(-171, 87), _animationTime);
        _handRight.DOAnchorPos(new Vector2(172, -140), _animationTime);
    }

}
