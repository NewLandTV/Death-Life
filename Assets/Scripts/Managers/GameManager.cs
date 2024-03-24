using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private Character character;
    public Character Character => character;

    // Menu
    [SerializeField]
    private Settings settings;
    public Settings Settings => settings;
    [SerializeField]
    private Inventory inventory;
    public Inventory Inventory => inventory;

    private void Awake()
    {
        instance = this;
    }
}
