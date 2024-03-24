using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject group;

    [SerializeField]
    private Item[] items;
    public Item[] Items => items;

    [SerializeField]
    private Slot[] slots;
    [SerializeField]
    private TextMeshProUGUI itemCountText;

    // Item counts
    private ushort currentItemCount;
    private ushort maxItemCount;

    private int dragSlotIndex = -1;
    public int DragSlotIndex
    {
        get => dragSlotIndex;
        set => dragSlotIndex = value;
    }

    private void Awake()
    {
        maxItemCount = (ushort)slots.Length;

        itemCountText.text = $"0/{maxItemCount}";

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Setup(i);
        }
    }

    public void Show()
    {
        group.SetActive(true);
    }

    public void Hide()
    {
        group.SetActive(false);
    }

    public void AddItem(Item item)
    {
        // Exist item is increase count
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Item?.name.Equals(item.name) != null)
            {
                slots[i].IncreaseCount();

                return;
            }
        }

        // Has not item is add new item
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Item == null)
            {
                itemCountText.text = $"{++currentItemCount}/{maxItemCount}";

                slots[i].SetItem(item);

                return;
            }
        }
    }

    public void AddItem(Item item, byte count)
    {
        for (int i = 0; i < count; i++)
        {
            AddItem(item);
        }
    }

    public void UseItem(Item item, byte count = 1)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Item.name.Equals(item.name))
            {
                slots[i].DecreaseCount(count);

                return;
            }
        }
    }

    public void Clear()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Clear();
        }

        currentItemCount = 0;
        itemCountText.text = $"0/{maxItemCount}";
    }

    public void ChangeSlot(int index1, int index2)
    {
        if (index1 == -1 || index2 == -1)
        {
            return;
        }

        Item item = slots[index1].Item;
        byte count = slots[index1].Count;

        slots[index1].SetItem(slots[index2].Item, slots[index2].Count);
        slots[index2].SetItem(item, count);
    }
}
