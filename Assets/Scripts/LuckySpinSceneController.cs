using DefaultNamespace;
using FortuneWheel;
using Money;
using Particles;
using Player;
using PrizeCards;
using Spin;
using UnityEngine;

public class LuckySpinSceneController : MonoBehaviour
{

    [SerializeField] private WheelRotator _wheelRotator;
    [SerializeField] private PrizeCardsController prizeCardsController;

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private SpinAnimationsController _spinAnimationsController;
    [SerializeField] private ChestAnimationsController _chestAnimationsController;

    [SerializeField] private SpinsCountView _spinsCountView;

    [SerializeField] private PrizesView _prizesView;
    [SerializeField] private MoneyView _moneyView;

    [SerializeField] private AuraController _auraController;
    
    private void Awake()
    {
        _wheelRotator.OnWheelStopped += prizeCardsController.SwitchWonCardOn;
        _wheelRotator.OnWheelStopped += _auraController.Stop;
        
        _wheelRotator.OnWheelRotation += _playerController.SpendSpin;
        _wheelRotator.OnWheelRotation += _spinAnimationsController.PlayFlyAnimation;
        _wheelRotator.OnWheelRotation += _auraController.Play;

        _playerController.OnSpinsCountChanged += _chestAnimationsController.SetNewSpinsValue;
        _playerController.OnSpinsCountChanged += _spinsCountView.UpdateSpinsCount;

        _chestAnimationsController.OnChestOpened += _prizesView.UpdatePrizesCount;
        _chestAnimationsController.OnChestClosed += _moneyView.UpdateMoneyView;
        
    }


    private void OnDestroy()
    {
        _wheelRotator.OnWheelStopped -= prizeCardsController.SwitchWonCardOn;
        _wheelRotator.OnWheelRotation -= _playerController.SpendSpin;
        _wheelRotator.OnWheelRotation -= _spinAnimationsController.PlayFlyAnimation;

        _playerController.OnSpinsCountChanged -= _chestAnimationsController.SetNewSpinsValue;
        _playerController.OnSpinsCountChanged -= _spinsCountView.UpdateSpinsCount;

        _chestAnimationsController.OnChestOpened -= _prizesView.UpdatePrizesCount;
        _chestAnimationsController.OnChestClosed -= _moneyView.UpdateMoneyView;
    }


}
