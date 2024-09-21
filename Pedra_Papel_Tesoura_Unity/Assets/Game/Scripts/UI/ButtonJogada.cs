using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonJogada : MonoBehaviour
{
    private Button b_this;
    private RectTransform rt;
    private void Awake()
    {
        b_this = GetComponent<Button>();
        rt = GetComponent<RectTransform>();
    }
    private void Start()
    {
        b_this.onClick.AddListener(ChooseMove);
    }
    private void ChooseMove()
    {
        b_this.Select();
        rt.DOScale(1.1f, UIController.I._animationTime / 3);
    }
}
