using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CurrencyManager : MonoBehaviour, IManager {

    public event Action CurrencyChanged;

    public int Gold { get; private set; }
    public int People { get; private set; }
    public int Ore { get; private set; }

    private void Awake() {
        Managers.RegisterManager(this);
    }

    public void AddIncome(BuildingData data) {
        Gold += data.goldAmount;
        People += data.peopleAmount;
        Ore += data.oreAmount;
        CurrencyChanged?.Invoke();
    }
}
