using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Sprite previewImage;

    public Sprite PreviewImage => previewImage;

#if UNITY_EDITOR

    public void UpdatePreviewImage() {
        var assetPath = AssetDatabase.GetAssetPath(this);
        var asset = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Object));
        var texture = AssetPreview.GetAssetPreview(asset);

        previewImage = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0f, 0f));
        EditorUtility.SetDirty(asset);
        AssetDatabase.SaveAssets();
    }
#endif
}
