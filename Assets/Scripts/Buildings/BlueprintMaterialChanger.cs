using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintMaterialChanger : MonoBehaviour
{
    private const string COLOR_PROPERTY = "_Color";

    [SerializeField] private Material blueprintMaterial;

    private Material[] materials;

    private Material[] initialMaterials;

    private MeshRenderer meshRenderer;

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
        initialMaterials = meshRenderer.materials;
        materials = new Material[initialMaterials.Length];
        for (int i = 0; i < initialMaterials.Length; i++) {
            materials[i] = new Material(blueprintMaterial);
        }
        SetGood();
    }

    public void SetGood() => SetColor(Color.green);
    public void SetBad() => SetColor(Color.red);
    public void SetInitial() => meshRenderer.materials = initialMaterials;

    private void SetColor(Color color) {
        foreach (var material in materials) {
            color.a = 0.2f;
            material.SetColor(COLOR_PROPERTY, color);
        }
        meshRenderer.materials = materials;
    }
}
