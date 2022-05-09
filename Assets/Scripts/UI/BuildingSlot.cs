using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class BuildingSlot : MonoBehaviour, IPointerDownHandler {

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameLabel;
    [SerializeField] private Image outline;

    public Building Building { get; private set; }

    private BuildingManager buildingManager;

    private void Start() {
        buildingManager = Managers.GetManager<BuildingManager>();
    }

    public void Initialize(Building _building) {
        Building = _building;
        image.sprite = _building.PreviewImage;
        nameLabel.text = _building.name;
    }

    public void OnPointerDown(PointerEventData eventData) {
        Select();
    }

    public void Select() {
        outline.color = Color.yellow;
        buildingManager.SetSlot(this);
    }

    public void Deselect() {
        outline.color = Color.black;
    }
}
