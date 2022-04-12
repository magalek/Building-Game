using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPanel : MonoBehaviour
{
    [SerializeField] private List<Building> buildings;
    [SerializeField] private BuildingSlot slotPrefab;
   
    public List<BuildingSlot> Slots { get; private set; } = new List<BuildingSlot>();

    private void Awake() {
        foreach (var building in buildings) {
            var slot = Instantiate(slotPrefab, transform);
            slot.Initialize(building);
            Slots.Add(slot);
        }
    }
}
