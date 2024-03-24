using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private Item item;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        GameManager.instance.Inventory.AddItem(item);

        gameObject.SetActive(false);
    }
}
