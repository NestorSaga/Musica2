﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AudioManager audioManager;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public GameObject TurnPrefab;
    public int startingNotes = 3;
    public int turnNumber = 1;
    private List<GameObject> turn = new List<GameObject>();

    public enum TPlayerInTurn
    {
        P1,
        P2
    }

    private TPlayerInTurn playerInTurn = TPlayerInTurn.P1;

    public GameObject currentTurn;

    public int currentNotes;

    private int initialRowsNumber;

    private bool listening;
    private int currentRow;

    private int tempo;

    //Script que assigni quantes notes te cada jugador a cada torn que es pot dir TurnAssignation()
    //Scipt que sigui Turn() que el que faci sigui inicialitzar la matriu de notes i guardar quines han estat col·locades

    private static GameManager instance = null;

    

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        turnNumber = 1;
        InitTurn();
        currentNotes = startingNotes;

        listening = false;

        initialRowsNumber = Assignations.Instance.initialRowsNumber;

        // El tempo tiene que depender de la dificultad:
        // EASY --> tempo = 4
        // MEDIUM --> tempo = 2
        // DIFFICULT --> tempo = 1
        tempo = 1;
    }

  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            EndTurn();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !listening)
        {
            currentRow = 0;
            listening = true;
            Listen();
        }
    }

    public void InitTurn()
    {
        currentTurn = Instantiate(TurnPrefab, transform.position, Quaternion.identity, GameObject.Find("Turns").transform);
        turn.Add(currentTurn);
    }
    public void EndTurn()
    {
        currentTurn.SetActive(false);
        if(playerInTurn == TPlayerInTurn.P2)
        {
            turnNumber++;
            playerInTurn = TPlayerInTurn.P1;
            InitTurn();
        }
        else
        {
            playerInTurn = TPlayerInTurn.P2;
            InitTurn();
        }
    }
   
    public void EraseScreen()
    {
        
        //Limpia la pantalla de las casillas antiguas
    }

    public int ReturnRows()
    {
        return turnNumber + initialRowsNumber - 1;
    }

    void Listen()
    {
        for (int i = 0; i < currentTurn.transform.childCount; i++)
        {

            if (currentTurn.transform.GetChild(currentRow).transform.GetChild(i).GetComponent<Cell>().hasNote)
                PlayInstrument(currentTurn.transform.GetChild(currentRow).transform.GetChild(i).gameObject);

        }
        StartCoroutine(PlayNotes());
        currentRow++;
    }

    void PlayInstrument(GameObject cell)
    {
        switch (cell.tag)
        {
            case "Cymbal":
                audioManager.Play("Cymbal");
                break;
            case "Violin":
                audioManager.Play("Violin");
                break;
            case "Trumpet":
                audioManager.Play("Trumpet");
                break;
            default:
                audioManager.Play("Choir");
                break;
        }
    }

    IEnumerator PlayNotes()
    {
        yield return new WaitForSeconds(tempo);
        audioManager.StopAll();
        if (currentRow != ReturnRows())
            Listen();
        else
            listening = false;
    }

}
