using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICurrencyPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldLabel;
    [SerializeField] private TextMeshProUGUI peopleLabel;
    [SerializeField] private TextMeshProUGUI oreLabel;

    private CurrencyManager currencyManager;

    private void Start() {
        currencyManager = Managers.GetManager<CurrencyManager>();
        currencyManager.IncomeChanged += OnCurrencyChanged;
    }

    private void OnCurrencyChanged() {
        goldLabel.text = $"{currencyManager.Gold} ({currencyManager.GoldTick})";
        peopleLabel.text = $"{currencyManager.People} ({currencyManager.PeopleTick})";
        oreLabel.text = $"{currencyManager.Ore} ({currencyManager.OreTick})";
    }
}
