using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public Item currentItem;
    public Image icon;
    public string slotType;
    public Sprite defaultSprite;

    private void Start()
    {
        if(currentItem!=null)
        {
            icon.sprite = currentItem.icon;
        }
        else
        {
            icon.sprite = defaultSprite;
        }
    }
    public virtual void AddItem(Item newItem)
    {
        if(newItem!=null)
        {
            currentItem = newItem;
            icon.sprite = newItem.icon;
        }
    }

    public void ClearSlot()
    {
        currentItem = null;
        icon.sprite = defaultSprite;
    }

    public bool CanAcceptItem(Item item)//Can put item in slot or not
    {
        //Debug.Log(slotType);
        //Debug.Log(item.itemType);
        if (slotType=="Any" || slotType==item.itemType)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
