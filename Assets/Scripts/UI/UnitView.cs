using System;
using Code.Gameplay.Signals;
using Code.Infrastructure.Services.Audio;
using Code.Infrastructure.Services.EventBus;
using Code.Infrastructure.Services.Input;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Services.TeamService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
  public sealed class UnitView : MonoBehaviour
  {
    [SerializeField] private Image heroImage;
    [SerializeField] private TMP_Text stats;
    [SerializeField] private Button button;
    
    [Header("Active")] 
    [SerializeField, Space] private Image activeImage;
    [SerializeField] private Sprite activeIcon;
    [SerializeField] private Sprite inactiveIcon;
    [SerializeField] private GameObject activeBlur;
    
    [Header("Attack")] 
    [SerializeField] private RectTransform center;
    [SerializeField] private float forwardDuration = 0.2f;
    [SerializeField] private AnimationCurve attackCurve;
    [SerializeField] private AnimationCurve scaleCurve;
    [SerializeField] private float backDuration = 0.5f;
    [SerializeField] private AudioClip punchSFX;

    private Sequence attackAnimation;
    private AudioPlayer audioPlayer;
    
    private ITeamService _teamService;
    private IEventBus _eventBus;
    private IUnit _unit;
    
    
    [Inject]
    public void Construct(IEventBus eventBus, ITeamService teamService) 
    {
      _eventBus = eventBus;
      _teamService = teamService;
    }
    
    private void Awake()
    {
      button.onClick.AddListener(SelectUnit);
    }

    private void Start()
    {
      audioPlayer = AudioPlayer.Instance;
    }

    private void OnDestroy()
    {
      button.onClick.RemoveListener(SelectUnit);
    }

    private void SelectUnit()
    {
      if (_teamService == null)
      {
        Debug.LogError("_teamService не заинжектился (null)!");
        return;
      }

      if (_unit == null)
      {
        Debug.LogError("_unit не назначен (null)!");
        return;
      }
      
      if (_teamService.GetPlayerTeam() != _unit.Team)
      {
          _eventBus.RaiseEvent(new UnitSelectSignal(_unit));
          SetActive(true);
      }

      else _eventBus.RaiseEvent(new EnemySelectedSignal(_unit));
    }

    public void SetIcon(Sprite icon)
    {
      heroImage.sprite = icon;
    }

    public void SetStats(string stats)
    {
      this.stats.text = stats;
    }

    public void SetUnit(IUnit unit)
    {
      _unit = unit;
    }

    public void SetActive(bool isActive)
    {
      Debug.Log("UnitView Unselect");
      activeImage.sprite = isActive ? activeIcon : inactiveIcon;
      activeBlur.SetActive(isActive);
    }

    public UniTask AnimateAttack(UnitView target)
    {
      if (attackAnimation != null)
      {
        return UniTask.CompletedTask;
      }

      UniTaskCompletionSource tcs = new UniTaskCompletionSource();

      Vector3 sourcePosition = center.position;
      Vector3 targetPosition = target.center.position;

      attackAnimation = DOTween
        .Sequence()
        .Append(center.DOMove(targetPosition, forwardDuration).SetEase(attackCurve))
        .Join(center.DOScale(1.25f, forwardDuration).SetEase(scaleCurve))
        .AppendCallback(() => audioPlayer.PlaySound(punchSFX))
        .Append(center.DOMove(sourcePosition, backDuration))
        .Join(center.DOScale(1, backDuration))
        .OnComplete(() =>
        {
          attackAnimation = null;
          tcs.TrySetResult();
        });

      return tcs.Task;
    }
  }
}