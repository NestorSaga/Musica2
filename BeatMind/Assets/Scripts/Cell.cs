using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{    
    [SerializeField]private bool note = false;

    private void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }
   
    private void OnMouseDown()
    {
        if (note)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        note = !note;
    }
}
