using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    public int amount = 1;
    public int slotIndex;

    private Transform OriginalParent; // Original parent of item object when dragged
    private Vector2 offsetDrag = new Vector2(0, 0); // offset from mouse position to center of the item icon when drag

    private void OnEnable() => amount = 1;    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            // comment offset for icon always center at mouse position
            //offsetDrag = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
            OriginalParent = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position - offsetDrag;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position - offsetDrag;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            // this.transform.SetParent(OriginalParent);
            // this.transform.position = OriginalParent.transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}
