using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
 using UnityEngine.EventSystems;
using TMPro;


 public class ButtonPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
 {
     private bool mouse_over = false;
     void Update()
     {
         if (mouse_over)
         {
            transform.GetChild(1).gameObject.SetActive(true);
         }
         else
         {
            transform.GetChild(1).gameObject.SetActive(false);
         }
     }
 
     public void OnPointerEnter(PointerEventData eventData)
     {
         mouse_over = true;
         Debug.Log("Mouse enter");
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
         mouse_over = false;
         Debug.Log("Mouse exit");
     }
 }
