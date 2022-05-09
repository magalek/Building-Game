using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour, IManager
{
    private const int GROUND_LAYER_MASK = 1 << 7;

    private Building blueprint;

    private BuildingSlot buildingSlot;

    private CameraManager cameraManager;

    private bool buildingSetThisFrame;

    private List<Building> builtBuildings = new List<Building>();

    private void Awake() {
        Managers.RegisterManager(this);
    }

    private void Start() {
        cameraManager = Managers.GetManager<CameraManager>();
    }

    private void Update() {
        PlaceBlueprint();
    }

    private void LateUpdate() {
        MoveBlueprint();
    }

    public void SetSlot(BuildingSlot slot) {
        buildingSlot?.Deselect();
        buildingSlot = slot;
        if (blueprint) Destroy(blueprint.gameObject);
        blueprint = Instantiate(buildingSlot.Building);
        blueprint.EnteredCollision += OnEnteredCollision;
        blueprint.ExitedCollision += OnExitedCollision;

        buildingSetThisFrame = true;
    }

    private void OnEnteredCollision() {
        blueprint.BlueprintMaterialChanger.SetBad();
    }

    private void OnExitedCollision() {
        blueprint.BlueprintMaterialChanger.SetGood();
    }

    private void PlaceBlueprint() {
        if (Input.GetMouseButtonDown(0) && blueprint && !blueprint.IsColliding && !buildingSetThisFrame) {
            blueprint.BlueprintMaterialChanger.SetInitial();
            blueprint.EnteredCollision -= OnEnteredCollision;
            blueprint.ExitedCollision -= OnExitedCollision;
            builtBuildings.Add(blueprint);
            blueprint.Build();
            blueprint = null;
        }
        else {
            buildingSetThisFrame = false;
        }
    }

    private void MoveBlueprint() {
        if (!blueprint) return;
        Ray ray = cameraManager.Camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, GROUND_LAYER_MASK);
        Vector3 newPos = new Vector3(Mathf.Ceil(hit.point.x) - 0.5f, hit.point.y, Mathf.Ceil(hit.point.z) - 0.5f);
        blueprint.transform.position = newPos;
    }
}
