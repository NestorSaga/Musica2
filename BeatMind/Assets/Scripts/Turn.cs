﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{    
    int rows;
    public GameObject[] cells;
    public GameObject cellPrefab;
    public float _distBetweenRows = 2; //La distancia a la que quieres que se instancie la siguiente fila. Habría que calcular cuánto mide el sprite siguiente y eso.
    PopulateGrid grid;

    public enum TTurnState
    {
        COMPOSING, 
        RESOLVING
    }

    public TTurnState turnState;

    private void Start()
    {
        turnState = TTurnState.COMPOSING;

        rows = GameManager.Instance.ReturnRows();       

        //cells = new GameObject[rows];
 
        grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<PopulateGrid>();

        grid.Populate(rows);     
    }

    public string getState()
    {
        if (turnState == TTurnState.COMPOSING)
        {
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
        Debug.Log("Estoy entrando aqui");
        if(turnState == TTurnState.COMPOSING)
        {
            //Lanzar evento de cambio de player
            //Volver todas las celdas a color negro
            for(int i = 0; i< this.transform.childCount; i++)
            {
                for(int j = 0; j < this.transform.GetChild(i).transform.childCount; j++)
                {
                    this.transform.GetChild(i).transform.GetChild(j).gameObject.GetComponent<Cell>().GoBlack();
                    this.transform.GetChild(i).transform.GetChild(j).gameObject.GetComponent<Cell>().hasNote = false;
                }
            }
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
