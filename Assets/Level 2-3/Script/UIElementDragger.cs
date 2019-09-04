using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIElementDragger : MonoBehaviour {

    public const string DRAGGABLE_TAG = "UIDraggable";

    private bool dragging = false;

    private Vector2 originalPosition;
    private Transform objectToDrag;
    private Image objectToDragImage;
    public bool CorrectPositionDadTop=false;
    public bool CorrectPositionDadTopMid = false;
    public bool CorrectPositionDadBotMid = false;
    public bool CorrectPositionDadBottom = false;
    public bool CorrectPositionMomTop = false;
    public bool CorrectPositionMomTopMid = false;
    public bool CorrectPositionMomBotMid = false;
    public bool CorrectPositionMomBottom = false;
    public bool MatchedImage_1 = false;
    public bool MatchedImage_2 = false;
    public bool MatchedImage_3 = false;
    public bool MatchedImage_4 = false;
    public Transform DadTop;
    public Transform DadTopMid;
    public Transform DadBotMid;
    public Transform DadBottom;
    public Transform MomTop;
    public Transform MomTopMid;
    public Transform MomBotMid;
    public Transform MomBottom;
    public Transform DadPart1;
    public Transform DadPart2;
    public Transform DadPart3;
    public Transform DadPart4;
    public Transform MomPart1;
    public Transform MomPart2;
    public Transform MomPart3;
    public Transform MomPart4;
    public GameObject MatchedImage1;
    public GameObject MatchedImage2;
    public GameObject OneStar;
    public GameObject TwoStar;
    public GameObject ThreeStar;
    public GameObject FourStar;
    List<RaycastResult> hitObjects = new List<RaycastResult>();

    #region Monobehaviour API

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
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

        if (Input.GetMouseButtonUp(0))
        {
            if (objectToDrag != null)
            {
                var objectToReplace = GetDraggableTransformUnderMouse();

                if (objectToReplace != null)
                {
                    objectToDrag.position = objectToReplace.position;
                    objectToReplace.position = originalPosition;
					CheckMatched ();
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
      private GameObject GetObjectUnderMouse()
    {
        var pointer = new PointerEventData(EventSystem.current);

        pointer.position = Input.mousePosition;
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
    public void CheckMatched()
    {
        if (MomPart1.position == MomTop.position)
        {
            CorrectPositionMomTop = true;
        }
        else
        {
            CorrectPositionMomTop = false;
        }
        if (MomPart2.position == MomTopMid.position)
        {
            CorrectPositionMomTopMid = true;
        }
        else
        {
            CorrectPositionMomTopMid = false;
        }
        if(MomPart3.position==MomBotMid.position)
        {
            CorrectPositionMomBotMid = true;
        }
        else
        {
            CorrectPositionMomBotMid = false;
        }
        if(MomPart4.position==MomBottom.position)
        {
            CorrectPositionMomBottom = true;
        }
        else
        {
            CorrectPositionMomBottom = false;
        }
        if ((CorrectPositionMomTop == true) && (CorrectPositionMomBottom == true)&&(CorrectPositionMomTopMid==true)&&(CorrectPositionMomBotMid==true))
        {
            MatchedImage_1 = true;
            MomPart1.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            MomPart2.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            MomPart3.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            MomPart4.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            MatchedImage1.GetComponent<Image>().enabled = true;
            GameObject Mom = GameObject.Find("Mom");
            Mom.GetComponent<AudioSource>().enabled = true;
        }
        if (DadPart1.position == DadTop.position)
        {
            CorrectPositionDadTop = true;
        }
        else
        {
            CorrectPositionDadTop = false;
        }
        if (DadPart2.position == DadTopMid.position)
        {
            CorrectPositionDadTopMid = true;
        }
        else
        {
            CorrectPositionDadTopMid = false;
        }
        if(DadPart3.position==DadBotMid.position)
        {
            CorrectPositionDadBotMid = true;
        }
        else
        {
            CorrectPositionDadBotMid = false;
        }
        if(DadPart4.position==DadBottom.position)
        {
            CorrectPositionDadBottom = true;
        }
        else
        {
            CorrectPositionDadBottom = false;
        }
        if ((CorrectPositionDadTop == true) && (CorrectPositionDadBottom == true)&&(CorrectPositionDadTopMid==true)&&(CorrectPositionDadBotMid==true))
        {
            MatchedImage_2 = true;
            DadPart1.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            DadPart2.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            DadPart3.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            DadPart4.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            MatchedImage2.GetComponent<Image>().enabled = true;
            GameObject Dad = GameObject.Find("Dad");
            Dad.GetComponent<AudioSource>().enabled = true;
        }
        if ((MatchedImage_1 == true) || (MatchedImage_2 == true) || (MatchedImage_3 == true) || (MatchedImage_4 == true))
        {
            OneStar.GetComponent<Image>().enabled = true;
        }
        /*if ((MatchedImage_1 == true) && (MatchedImage_2 == true) && (MatchedImage_3 == true) && (MatchedImage_4 == true))
        {
            OneStar.GetComponent<Image>().enabled = true;
            TwoStar.GetComponent<Image>().enabled = true;
            ThreeStar.GetComponent<Image>().enabled = true;
            FourStar.GetComponent<Image>().enabled = true;
        }*/
        if ((MatchedImage_1 == true) && (MatchedImage_2 == true))/* || (MatchedImage_2 == true) && (MatchedImage_3 == true) || (MatchedImage_3 == true) && (MatchedImage_4 == true)
            || (MatchedImage_1 == true) && (MatchedImage_3 == true) || (MatchedImage_1 == true) && (MatchedImage_4 == true) || (MatchedImage_2 == true) && (MatchedImage_4) || (MatchedImage_3 == true) && (MatchedImage_4 == true))*/
        {
            OneStar.GetComponent<Image>().enabled = true;
            TwoStar.GetComponent<Image>().enabled = true;
        }
        /*if ((MatchedImage_1 == true) && (MatchedImage_2 == true) && (MatchedImage_3 == true) || (MatchedImage_2 == true) && (MatchedImage_3 == true) && (MatchedImage_4 == true)
            || (MatchedImage_3 == true) && (MatchedImage_4 == true) && (MatchedImage_1 == true) || (MatchedImage_4 == true) && (MatchedImage_1 == true) && (MatchedImage_2 == true))
        {
            OneStar.GetComponent<Image>().enabled = true;
            TwoStar.GetComponent<Image>().enabled = true;
            ThreeStar.GetComponent<Image>().enabled = true;
        }
      */ 
    }

    #endregion
}
