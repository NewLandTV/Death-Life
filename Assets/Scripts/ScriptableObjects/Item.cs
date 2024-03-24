using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New/Item")]
public class Item : ScriptableObject
{
    public GameObject prefab;
    public Sprite image;

    public string name;
    public string description;

    public Type type;

    public enum Type
    {
        Use,
        Ingredient,
        Weapon,
        ETC
    }
}
