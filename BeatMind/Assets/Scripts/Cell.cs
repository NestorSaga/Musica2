using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{    
    [SerializeField]private bool note = false;
    
    public void ChangeState()
    { 
        //Cambiar el sprite
        //Gestionar cuantas notas le quedan al player
        note = !note;
    }
}
