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
        currencyManager.CurrencyChanged += OnCurrencyChanged;
    }

    private void OnCurrencyChanged() {
        goldLabel.text = currencyManager.Gold.ToString();
        peopleLabel.text = currencyManager.People.ToString();
        oreLabel.text = currencyManager.Ore.ToString();
    }
}
