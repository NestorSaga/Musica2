using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{    
    int rows;
    public GameObject[] cells;
    public GameObject cellPrefab;
    public float _distBetweenRows = 2; //La distancia a la que quieres que se instancie la siguiente fila. Habría que calcular cuánto mide el sprite siguiente y eso.
    public Transform InitPos;
    public enum TTurnState
    {
        COMPOSING, 
        RESOLVING
    }

    public TTurnState turnState;

    private float _distance = 50f;
    private void Start()
    {
        turnState = TTurnState.COMPOSING;
        rows = GameManager.Instance.ReturnRows();       

        cells = new GameObject[rows];

        float l_Dist = 0;

        //TO DO: Sistema para arrastrar la grid  
        InitPos = GameObject.Find("InitPos").transform;


        for(int i = 0; i<cells.GetLength(0); i++)
        {
            cells[i] = Instantiate(cellPrefab, InitPos.position + new Vector3(0, l_Dist, -3), Quaternion.identity, transform);            
            l_Dist += _distBetweenRows;
        }
    }

    public string getState()
    {
        if (turnState == TTurnState.COMPOSING)
        {
            //Lanzar evento de cambio de player
            return "Composing";
        }
        else return "Resolving";
    }

    private void Update()
    {
        if (turnState == TTurnState.COMPOSING)
        {
            //Lanzar evento de cambio de player
          
        }
    }
    public void ButtonChangesTurnState()
    {
        if(turnState == TTurnState.COMPOSING)
        {
            //Lanzar evento de cambio de player





            turnState = TTurnState.RESOLVING;
        }
        else
        {
            //Lanzar evento de resolver
            //Reinicializar los materiales o el color al inicial

            GameManager.Instance.EndTurn();
        }
    }


    public void Resolve()
    {
        for (int i = 0; i < GameManager.Instance.currentTurn.transform.childCount; i++)
        {

            if (GameManager.Instance.currentTurn.transform.GetChild(i).GetComponent<Cell>().resolver && GameManager.Instance.currentTurn.transform.GetChild(i).GetComponent<Cell>().composer)
            {
               //guay, ha acertado input positivo
            }
            else if (!GameManager.Instance.currentTurn.transform.GetChild(i).GetComponent<Cell>().resolver && GameManager.Instance.currentTurn.transform.GetChild(i).GetComponent<Cell>().composer)
            {
                //Estaba pero no la ha acertado input negativo, se resta vida
                if (GameManager.Instance.getPlayerinTurn() == 1)
                {
                    GameManager.Instance.p2Life--;
                }
                else GameManager.Instance.p1Life--;
            }
            else
            {
                //No hay un cagao, 
            }
            GameManager.Instance.currentTurn.transform.GetChild(i).GetComponent<Cell>().resetCell();
        }
    }

}
