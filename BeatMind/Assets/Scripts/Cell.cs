using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{    
    public bool hasNote = false;
    public bool composer = false;
    public bool resolver = false;

    private void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }
   
    private void OnMouseDown()
    {
        if (hasNote)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            //acceder al turno para sumarle notas
            GameManager.Instance.currentNotes++;
            if (GameManager.Instance.currentTurn.GetComponent<Turn>().getState() == "Composing")
            {
                composer = false;
            }
            else resolver = false;
        }
        else //añadir condicion de si no te quedan notas no lo pongan
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            //acceder al turno para restarle notas
            GameManager.Instance.currentNotes--;
            if (GameManager.Instance.currentTurn.GetComponent<Turn>().getState() == "Composing")
            {
                composer = true;
            }
            else resolver = true;
        }
        hasNote = !hasNote;
    }

    public void resetCell()
    {
        hasNote = false;
        composer = false;
        resolver = false;
    }
}
