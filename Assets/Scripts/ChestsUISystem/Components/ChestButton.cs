using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ChestButton : MonoBehaviour
{
    [SerializeField] private Button _itemButton;
    private IChestBus _chestBus;

    [Inject]
    public void Construct(IChestBus chestBus)
    {
        _chestBus = chestBus;
        _itemButton.onClick.AddListener(Click);
    }
   
    private void Click()
    {
        _chestBus.ChestCreateClick();
    }
}
