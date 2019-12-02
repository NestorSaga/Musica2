using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{    
    public bool hasNote = false;
    public bool composer = false;
    public bool resolver = false;

    public Color unselected;

    private void Start()
    {
        GoBlack();
    }
   
    private void OnMouseDown()
    {
        if (hasNote)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = unselected;
            //acceder al turno para sumarle notas
            GameManager.Instance.currentNotes++;
            if (GameManager.Instance.currentTurn.GetComponent<Turn>().getState() == "Composing")
            {
                composer = false;
            }
            else resolver = false;
            hasNote = !hasNote;
        }

        else //añadir condicion de si no te quedan notas no lo pongan
        {
            if (GameManager.Instance.currentNotes > 0)
            {
                switch (this.gameObject.tag)
                {
                    case "Cymbal":
                        this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                        break;
                    case "Violin":
                        this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                        break;
                    case "Trumpet":
                        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                        break;
                    default:
                        this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                        break;
                }

                //acceder al turno para restarle notas
                GameManager.Instance.currentNotes--;
                if (GameManager.Instance.currentTurn.GetComponent<Turn>().getState() == "Composing")
                {
                    composer = true;
                }
                else resolver = true;
                hasNote = !hasNote;
            }
            
        }
        
        
    }

    public void GoBlack()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = unselected;
    }

    public void resetCell()
    {
        hasNote = false;
        composer = false;
        resolver = false;
    }
}
