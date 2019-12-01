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
            //acceder al turno para sumarle notas
            GameManager.Instance.CurrentNotes++;
        }
        else //añadir condicion de si no te quedan notas no lo pongan
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            //acceder al turno para restarle notas
            GameManager.Instance.CurrentNotes--;
        }
        note = !note;
    }
}
