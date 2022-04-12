using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour, IManager
{
    private const int GROUND_LAYER_MASK = 1 << 7;

    [SerializeField] private Building blueprint;

    private BuildingSlot buildingSlot;

    private CameraManager cameraManager;

    private void Awake() {
        Managers.RegisterManager(this);
    }

    private void Start() {
        cameraManager = Managers.GetManager<CameraManager>();
    }

    private void Update() {

        if (blueprint) {
            Ray ray = cameraManager.Camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, GROUND_LAYER_MASK);
            blueprint.transform.position = hit.point;
        }
        if (Input.GetMouseButtonDown(0)) {
            blueprint = null;
        }
    }

    public void SetSlot(BuildingSlot slot) {
        buildingSlot?.Deselect();
        buildingSlot = slot;
        if (blueprint) Destroy(blueprint.gameObject);
        blueprint = Instantiate(buildingSlot.Building);
    }
}
