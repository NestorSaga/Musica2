using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignations : MonoBehaviour
{    
    public static Assignations Instance
    {
        get
        {
            return instance;
        }
    }

    public int instrumentsNumber = 4;
    public int initialRowsNumber = 4;
    //Quantes notes se li dona a cada jugador al començament
    //Tamany de la grid de notes

    private static Assignations instance = null;


    private void Awake()
    {        
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public int ReturnRows()
    {
        return GameManager.Instance.turnNumber + initialRowsNumber - 1;
    }


}
