using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TechXR.Core.Sense;

public class GazePointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    // public GameObject bow;
    // public Material red;

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        // bow.GetComponent<Renderer>().material = red;
        GazeTimer.Instance.GazeOff();
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        GazeTimer.Instance.GazeOn();
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        GazeTimer.Instance.GazeOff();
    }

}
