using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class BuildingEditorUtility {
#if UNITY_EDITOR
    [MenuItem("Buildings/Update Previews")]
    public static void UpdateAllBuildingPreviews() {
        string[] guids = AssetDatabase.FindAssets(string.Format("t:{0}", typeof(Building)));
        for (int i = 0; i < guids.Length; i++) {
            string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
            Building data = AssetDatabase.LoadAssetAtPath<Building>(assetPath);
            data.UpdatePreviewImage();
        }
        Debug.Log("Updated Previews");
    }
#endif
}