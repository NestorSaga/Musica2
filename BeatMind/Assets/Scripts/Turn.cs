using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{    
    int rows;
    GameObject[] cells;
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
        rows = Assignations.Instance.ReturnRows();       

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

    private void Update()
    {
        
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

}
