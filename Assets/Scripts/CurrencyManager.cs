using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CurrencyManager : MonoBehaviour, IManager {

    public event Action IncomeChanged;
    public event Action TickChanged;

    [SerializeField, Range(0.1f, 10f)] private float incomeTickDelay;

    public int Gold { get; private set; }
    public int People { get; private set; }
    public int Ore { get; private set; }

    public int GoldTick { get; private set; }
    public int PeopleTick { get; private set; }
    public int OreTick { get; private set; }

    private void Awake() {
        Managers.RegisterManager(this);
        StartCoroutine(IncomeTick());
    }

    public void AddIncomeSource(BuildingData data) {
        GoldTick += data.goldAmount;
        PeopleTick += data.peopleAmount;
        OreTick += data.oreAmount;
        TickChanged?.Invoke();
    }

    public void RemoveIncomeSource(BuildingData data) {
        GoldTick -= data.goldAmount;
        PeopleTick -= data.peopleAmount;
        OreTick -= data.oreAmount;
        TickChanged?.Invoke();
    }

    private void TickIncome() {
        Gold += GoldTick;
        People += PeopleTick;
        Ore += OreTick;
        IncomeChanged?.Invoke();
    }

    private IEnumerator IncomeTick() {
        while (gameObject.activeSelf) {
            yield return new WaitForSeconds(incomeTickDelay);
            TickIncome();
        }
    }
}
