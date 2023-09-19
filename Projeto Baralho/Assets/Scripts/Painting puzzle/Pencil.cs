using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Pencil :   MonoBehaviour 
{
    [HideInInspector]
    public Color color;
 
    // Start is called before the first frame update
    void Start()
    {
        this.color = this.GetComponent<Image>().color;
         
    }
 


}
