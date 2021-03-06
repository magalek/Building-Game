using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Building : MonoBehaviour
{
    public event Action EnteredCollision;
    public event Action ExitedCollision;

    public Sprite PreviewImage => previewImage;
    public BlueprintMaterialChanger BlueprintMaterialChanger => blueprintMaterialChanger;

    public bool IsColliding => collidersCount > 0;

    [SerializeField] private Sprite previewImage;
    [SerializeField] private BuildingData data;

    private BlueprintMaterialChanger blueprintMaterialChanger;

    private CurrencyManager currencyManager;
    private FloatingLabelsManager floatingLabelsManagers;

    private int collidersCount;

    private void Awake() {
        blueprintMaterialChanger = GetComponentInChildren<BlueprintMaterialChanger>();
    }

    private void Start() {
        currencyManager = Managers.GetManager<CurrencyManager>();
        floatingLabelsManagers = Managers.GetManager<FloatingLabelsManager>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == 7) return;
        if (collidersCount == 0) {
            EnteredCollision?.Invoke();
        }
        collidersCount++;
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.layer == 7) return;
        collidersCount--;
        if (collidersCount == 0) {
            ExitedCollision?.Invoke();
        }
    }

    public void Build() {
        currencyManager.AddIncomeSource(data);
        currencyManager.IncomeChanged += ShowLabel;
    }

    private void ShowLabel() {
        floatingLabelsManagers.Show(data, transform);
    }

#if UNITY_EDITOR

    public void UpdatePreviewImage() {
        var assetPath = AssetDatabase.GetAssetPath(this);
        var asset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(UnityEngine.Object));
        var texture = AssetPreview.GetAssetPreview(asset);

        previewImage = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0f, 0f));
        EditorUtility.SetDirty(asset);
        AssetDatabase.SaveAssets();
    }
#endif
}
