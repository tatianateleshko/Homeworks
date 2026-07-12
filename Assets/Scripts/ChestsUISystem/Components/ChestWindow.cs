using UnityEngine;
using Zenject;

public class ChestWindow : MonoBehaviour
{
    [SerializeField] private Transform _grid;

    public Transform ChestParent => _grid;

    [Inject]
    public void Construct(IChestWindowPresenter chestWindowPresenter)
    {
        chestWindowPresenter.Register(this);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void UpdateWindow()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
