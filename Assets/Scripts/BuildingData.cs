using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Building/BuildingData")]
public class BuildingData : ScriptableObject {

    public float incomeDelay;
    public int goldAmount;
    public int peopleAmount;
    public int oreAmount;
}
