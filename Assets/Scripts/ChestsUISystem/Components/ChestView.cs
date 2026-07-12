using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ChestView : MonoBehaviour
{
    [SerializeField] private Button _openButton;
    [SerializeField] private TextMeshProUGUI _remainTimeText;
    [SerializeField] private TextMeshProUGUI _nameChestText;
    [SerializeField] private Image _chestImage;
    [SerializeField] private CanvasGroup _chestCanvasGroup;
    [SerializeField] private float _canOpenChestCanvasgroupValue = 1;
    [SerializeField] private float _cannotOpenChestCanvasgroupValue = 0.4f;

    private string _id;
    private IChestBus _chestBus;

    [Inject]
    public void Construct(IChestBus chestBus)
    {
        _chestBus = chestBus;
    }

    private void Start()
    {
        _openButton.onClick.AddListener(Open);
    }

   public void SetUp(string uniqueId, string name, Sprite icon)
    {
        _id = uniqueId;

        _nameChestText.text = name;
        _chestImage.sprite = icon;
    }

    private void Open()
    {
        _chestBus.ChestOpenClick(_id);
    }

    public void UpdateTimer(double currentTime)
    {
        double remainSeconds = currentTime;

        if(remainSeconds <= 0)
        {
            _remainTimeText.text = "00:00:00";
            ReadyState();
            return;
        }

        ShowTimer();
        _chestCanvasGroup.alpha = _cannotOpenChestCanvasgroupValue;
        _remainTimeText.text = SecondsToFormat(remainSeconds);
    }

    public void UpdateState(ChestState chestState)
    {
        if (chestState.ReadyToOpen)
            ReadyState();
        else
            UpdateTimer(chestState.Timer.GetRemainTimeInSeconds());
    }

    private void ReadyState()
    {
        _openButton.gameObject.SetActive(true);
        _remainTimeText.gameObject.SetActive(false);
        _chestCanvasGroup.alpha = _cannotOpenChestCanvasgroupValue;
    }

    private void ShowTimer()
    {
        _openButton.gameObject.SetActive(false);
        _remainTimeText.gameObject.SetActive(true);
    }

    private string SecondsToFormat(double seconds)
    {
        var timeSpan = TimeSpan.FromSeconds(seconds);
        return $"{timeSpan.TotalHours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
    }
}
