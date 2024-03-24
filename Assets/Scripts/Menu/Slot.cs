using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    // Datas
    private int index;

    private Item item;
    public Item Item => item;

    private byte count;
    public byte Count => count;

    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private TextMeshProUGUI countText;

    private Vector3 originItemPosition;

    private void Awake()
    {
        originItemPosition = itemImage.rectTransform.position;
    }

    public void Setup(int index)
    {
        this.index = index;
    }

    public void SetItem(Item item, byte count = 1)
    {
        if (item == null)
        {
            Clear();

            return;
        }

        this.item = item;
        this.count = count;

        itemImage.sprite = item.image;
        itemImage.color = Color.white;
        countText.text = $"{count}";
    }

    public void IncreaseCount(byte value = 1)
    {
        count = (byte)((byte)(count + value) < count ? 255 : count + value);
        countText.text = $"{count}";
    }

    public void DecreaseCount(byte value = 1)
    {
        count = (byte)((byte)(count - value) > count ? 0 : count - value);

        if (count == 0)
        {
            Clear();

            return;
        }

        countText.text = $"{count}";
    }

    public void Clear()
    {
        item = null;
        count = 0;

        itemImage.sprite = null;
        itemImage.color = new Color(1f, 1f, 1f, 0f);
        countText.text = string.Empty;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item == null)
        {
            return;
        }

        GameManager.instance.Inventory.DragSlotIndex = index;

        itemImage.transform.SetParent(GameManager.instance.Inventory.transform);

        itemImage.rectTransform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemImage.transform.SetParent(transform);
        itemImage.transform.SetSiblingIndex(0);

        itemImage.rectTransform.position = originItemPosition;

        GameManager.instance.Inventory.DragSlotIndex = -1;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (index != GameManager.instance.Inventory.DragSlotIndex)
        {
            GameManager.instance.Inventory.ChangeSlot(index, GameManager.instance.Inventory.DragSlotIndex);
        }
    }
}
