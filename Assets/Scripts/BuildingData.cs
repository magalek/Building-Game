using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Building/BuildingData")]
public class BuildingData : ScriptableObject {

    public float incomeDelay;
    public int goldAmount;
    public int peopleAmount;
    public int oreAmount;

    public override string ToString() {
        string text = default;
        if (goldAmount > 0) text = goldAmount.ToString();
        if (peopleAmount > 0) text = peopleAmount.ToString();
        if (oreAmount > 0) text = oreAmount.ToString();
        return text;
    }

    public static implicit operator string(BuildingData data) => data.ToString();
}
