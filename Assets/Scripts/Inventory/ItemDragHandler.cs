using UnityEngine.EventSystems;
using UnityEngine;
using Unity.VisualScripting;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
 
    public InventorySlot assignedSlot;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private CrutchForInventorySprite dragSprite2;

    private void Start()
    {
        canvasGroup = GameObject.Find("Inventory").GetComponent<CanvasGroup>();
        dragSprite2.spriterender.enabled = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(assignedSlot.currentItem!=null)
        {
            dragSprite2.spriterender.enabled = true;
            dragSprite2.sprite = assignedSlot.currentItem.icon;
            dragSprite2.spriterender.sprite = dragSprite2.sprite;
            dragSprite2.transform.parent = transform.root;
            //canvasGroup.blocksRaycasts = true; // Отключаем возможность взаимодействия во время перетаскивания
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (assignedSlot.currentItem != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0;
            dragSprite2.transform.position = worldPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragSprite2.spriterender.enabled=false;
        //canvasGroup.blocksRaycasts = false; // Включаем возможность взаимодействия
        if (assignedSlot.currentItem != null)
        {
            if (eventData.pointerEnter != null && eventData.pointerEnter.GetComponent<InventorySlot>() != null)
            {
                InventorySlot newSlot = eventData.pointerEnter.GetComponent<InventorySlot>();
                if (newSlot.CanAcceptItem(assignedSlot.currentItem)) // Проверка на возможность вставки предмета
                {
                    newSlot.AddItem(assignedSlot.currentItem);
                    assignedSlot.ClearSlot();
                    dragSprite2.transform.parent = transform;
                    dragSprite2.transform.localPosition = Vector3.zero;
                }
            }
            else
            {
                dragSprite2.transform.parent = transform;
                dragSprite2.transform.localPosition = Vector3.zero;
            }
        }
    }
       
}
