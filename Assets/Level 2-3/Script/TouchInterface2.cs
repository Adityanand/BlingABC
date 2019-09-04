using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TouchInterface2 : MonoBehaviour {
    public const string DRAGGABLE_TAG = "UIDraggable";

    private bool dragging = false;

    private Vector2 originalPosition;
    private Transform objectToDrag;
    private Image objectToDragImage;
    List<RaycastResult> hitObjects = new List<RaycastResult>();
    void Update()
    {
        if (Input.touchCount > 0)
        {
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                { Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                    touchPosition.y = transform.position.y;
                    transform.position = Vector3.Lerp(transform.position, touchPosition, 20 * Time.deltaTime);
                }
            }
            objectToDrag = GetDraggableTransformUnderMouse();

            if (objectToDrag != null)
            {
                dragging = true;

                objectToDrag.SetAsLastSibling();

                originalPosition = objectToDrag.position;
                objectToDragImage = objectToDrag.GetComponent<Image>();
                objectToDragImage.raycastTarget = false;
            }

        }
        if (dragging)
        {
            objectToDrag.position = Input.mousePosition;
        }
        if ((Input.touchCount > 0))
        {
            if (objectToDrag != null)
            {
                var objectToReplace = GetDraggableTransformUnderMouse();

                if (objectToReplace != null)
                {
                    objectToDrag.position = objectToReplace.position;
                    objectToReplace.position = originalPosition;
                }
                else
                {
                    objectToDrag.position = originalPosition;
                }

                objectToDragImage.raycastTarget = true;
                objectToDrag = null;
            }

            dragging = false;
        }
    }
Vector2 CurrentTouchPosition
{
    get
    {
        Vector2 inputPos;
        inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return inputPos;
    }
}
private GameObject GetObjectUnderMouse()
{
    var pointer = new PointerEventData(EventSystem.current);

    
    pointer.position = CurrentTouchPosition;
    EventSystem.current.RaycastAll(pointer, hitObjects);

    if (hitObjects.Count <= 0) return null;

    return hitObjects.First().gameObject;
}
    private Transform GetDraggableTransformUnderMouse()
    {
        var clickedObject = GetObjectUnderMouse();

        // get top level object hit
        if (clickedObject != null && clickedObject.tag == DRAGGABLE_TAG)
        {
            return clickedObject.transform;
        }

        return null;
    }
}