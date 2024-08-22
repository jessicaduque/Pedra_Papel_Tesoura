using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class InitialPartUI : MonoBehaviour
{
    [SerializeField] private GameObject _logo;
    [SerializeField] private GameObject _foguete;
    [SerializeField] private GameObject _startButton;
    private Button b_start;

    private void Awake()
    {
        b_start = _startButton.GetComponent<Button>();
        b_start.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        b_start.enabled = false;
    }
}
