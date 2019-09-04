using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIElementDragger2 : MonoBehaviour {

    public const string DRAGGABLE_TAG = "UIDraggable";

    private bool dragging = false;

    private Vector2 originalPosition;
    private Transform objectToDrag;
    private Image objectToDragImage;
    public bool CorrectPositionImage1Top=false;
    public bool CorrectPositionImage1Mid = false;
    public bool CorrectPositionImage1Bottom = false;
    public bool CorrectPositionImage2Top = false;
    public bool CorrectPositionImage2Mid = false;
    public bool CorrectPositionImage2Bottom = false;
    public bool CorrectPositionImage3Top = false;
    public bool CorrectPositionImage3Mid = false;
    public bool CorrectPositionImage3Bottom = false;
    public bool CorrectPositionImage4Top = false;
    public bool CorrectPositionImage4Mid = false;
    public bool CorrectPositionImage4Bottom = false;
    public bool MatchedImage_1 = false;
    public bool MatchedImage_2 = false;
    public bool MatchedImage_3 = false;
    public bool MatchedImage_4 = false;
    public Transform Image1Top;
    public Transform Image1Mid;
    public Transform Image1Bottom;
    public Transform Image2Top;
    public Transform Image2Mid;
    public Transform Image2Bottom;
    public Transform Image3Top;
    public Transform Image3Mid;
    public Transform Image3Bottom;
    public Transform Image4Top;
    public Transform Image4Mid;
    public Transform Image4Bottom;
    public Transform Image1Part1;
    public Transform Image1Part2;
    public Transform Image1Part3;
    public Transform Image2Part1;
    public Transform Image2Part2;
    public Transform Image2Part3;
    public Transform Image3Part1;
    public Transform Image3Part2;
    public Transform Image3Part3;
    public Transform Image4Part1;
    public Transform Image4Part2;
    public Transform Image4Part3;
    public GameObject MatchedImage1;
    public GameObject MatchedImage2;
    public GameObject MatchedImage3;
    public GameObject MatchedImage4;
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
        if (Image1Part1.position == Image1Top.position)
        {
            CorrectPositionImage1Top = true;
        }
        else
        {
            CorrectPositionImage1Top = false;
        }
        if (Image1Part2.position == Image1Mid.position)
        {
            CorrectPositionImage1Mid = true;
        }
        else
        {
            CorrectPositionImage1Mid = false;
        }
        if(Image1Part3.position==Image1Bottom.position)
        {
            CorrectPositionImage1Bottom = true;
        }
        else
        {
            CorrectPositionImage1Bottom = false;
        }
        if ((CorrectPositionImage1Top == true) && (CorrectPositionImage1Bottom == true)&&(CorrectPositionImage1Mid==true))
        {
            MatchedImage_1 = true;
            Image1Part1.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            Image1Part2.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            Image1Part3.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            MatchedImage1.GetComponent<Image>().enabled = true;
            GameObject Action1 = GameObject.Find("Action1");
            Action1.GetComponent<AudioSource>().enabled = true;
        }
        if (Image2Part1.position == Image2Top.position)
        {
            CorrectPositionImage2Top = true;
        }
        else
        {
            CorrectPositionImage2Top = false;
        }
        if (Image2Part2.position == Image2Mid.position)
        {
            CorrectPositionImage2Mid = true;
        }
        else
        {
            CorrectPositionImage2Mid = false;
        }
        if(Image2Part3.position==Image2Bottom.position)
        {
            CorrectPositionImage2Bottom = true;
        }
        else
        {
            CorrectPositionImage2Bottom = false;
        }
        if ((CorrectPositionImage2Top == true) && (CorrectPositionImage2Bottom == true)&&(CorrectPositionImage2Mid==true))
        {
            MatchedImage_2 = true;
            Image2Part1.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            Image2Part2.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            Image2Part3.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            MatchedImage2.GetComponent<Image>().enabled = true;
            GameObject Comedy1 = GameObject.Find("Comedy1");
            Comedy1.GetComponent<AudioSource>().enabled = true;
        }
        if (Image4Part1.position == Image4Top.position)
        {
            CorrectPositionImage4Top = true;
        }
        else
        {
            CorrectPositionImage4Top = false;
        }
        if (Image4Part2.position == Image4Mid.position)
        {
            CorrectPositionImage4Mid = true;
        }
        else
        {
            CorrectPositionImage4Mid = false;
        }
        if (Image4Part3.position == Image4Bottom.position)
        {
            CorrectPositionImage4Bottom = true;
        }
        else
        {
            CorrectPositionImage4Bottom = false;
        }
        if ((CorrectPositionImage4Top == true) && (CorrectPositionImage4Bottom == true) && (CorrectPositionImage4Mid == true))
        {
            MatchedImage_4 = true;
            Image4Part1.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            Image4Part2.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            Image4Part3.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            MatchedImage4.GetComponent<Image>().enabled = true;
            GameObject Romance1 = GameObject.Find("Romance1");
            Romance1.GetComponent<AudioSource>().enabled = true;
        }
        if (Image3Part1.position == Image3Top.position)
        {
            CorrectPositionImage3Top = true;
        }
        else
        {
            CorrectPositionImage3Top = false;
        }
        if (Image3Part2.position == Image3Mid.position)
        {
            CorrectPositionImage3Mid = true;
        }
        else
        {
            CorrectPositionImage3Mid = false;
        }
        if (Image3Part3.position == Image3Bottom.position)
        {
            CorrectPositionImage3Bottom = true;
        }
        else
        {
            CorrectPositionImage3Bottom = false;
        }
        if ((CorrectPositionImage3Top == true) && (CorrectPositionImage3Bottom == true) && (CorrectPositionImage3Mid == true))
        {
            MatchedImage_3 = true;
            Image3Part1.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            Image3Part2.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            Image3Part3.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            MatchedImage3.GetComponent<Image>().enabled = true;
            GameObject Animation1 = GameObject.Find("Animation1");
            Animation1.GetComponent<AudioSource>().enabled = true;
        }
        if ((MatchedImage_1 == true) || (MatchedImage_2 == true) || (MatchedImage_3 == true) || (MatchedImage_4 == true))
        {
            OneStar.GetComponent<Image>().enabled = true;
        }
        if ((MatchedImage_1 == true) && (MatchedImage_2 == true) && (MatchedImage_3 == true) && (MatchedImage_4 == true))
        {
            OneStar.GetComponent<Image>().enabled = true;
            TwoStar.GetComponent<Image>().enabled = true;
            ThreeStar.GetComponent<Image>().enabled = true;
            FourStar.GetComponent<Image>().enabled = true;
        }
        if ((MatchedImage_1 == true) && (MatchedImage_2 == true) || (MatchedImage_2 == true) && (MatchedImage_3 == true) || (MatchedImage_3 == true) && (MatchedImage_4 == true)
            || (MatchedImage_1 == true) && (MatchedImage_3 == true) || (MatchedImage_1 == true) && (MatchedImage_4 == true) || (MatchedImage_2 == true) && (MatchedImage_4) || (MatchedImage_3 == true) && (MatchedImage_4 == true))
        {
            OneStar.GetComponent<Image>().enabled = true;
            TwoStar.GetComponent<Image>().enabled = true;
        }
        if ((MatchedImage_1 == true) && (MatchedImage_2 == true) && (MatchedImage_3 == true) || (MatchedImage_2 == true) && (MatchedImage_3 == true) && (MatchedImage_4 == true)
            || (MatchedImage_3 == true) && (MatchedImage_4 == true) && (MatchedImage_1 == true) || (MatchedImage_4 == true) && (MatchedImage_1 == true) && (MatchedImage_2 == true))
        {
            OneStar.GetComponent<Image>().enabled = true;
            TwoStar.GetComponent<Image>().enabled = true;
            ThreeStar.GetComponent<Image>().enabled = true;
        }
      

    }

    #endregion
}
