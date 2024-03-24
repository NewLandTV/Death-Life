using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;

    private void Start()
    {
        Instantiate(inventory.Items[0].prefab, Vector3.up * 2.5f, Quaternion.identity);
    }
}
