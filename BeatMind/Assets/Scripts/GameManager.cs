﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    AudioManager audioManager;
    PopulateGrid grid;
    public Animator flechaAnim;
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

    public GameObject p1Text;
    public GameObject p2Text;
    public Text notesText;

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

    public int p1Life;
    public int p2Life;

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
        grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<PopulateGrid>();
        // El tempo tiene que depender de la dificultad:
        // EASY --> tempo = 4
        // MEDIUM --> tempo = 2
        // DIFFICULT --> tempo = 1
        tempo = 1;
    }

  
    void Update()
    {
        flechaAnim.SetInteger("Notes", currentNotes);
        notesText.text = currentNotes.ToString();

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
        grid.clean();

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
        return turnNumber;
    }

    public void PlayMusic()
    {
        currentRow = 0;
        listening = true;
        Listen();
    }

    void Listen()
    {
        for (int i = 0; i < grid.transform.GetChild(currentRow).transform.childCount; i++)
        {
            if (grid.transform.GetChild(currentRow).GetChild(i).GetComponent<Cell>().composer)
            {
                PlayInstrument(grid.transform.GetChild(currentRow).GetChild(i).gameObject);
            }
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

    public void UpdateText(string player)
    {
        if(player == "p1")
        {
            p1Text.SetActive(true);
            p2Text.SetActive(false);
        }
        else
        {
            p2Text.SetActive(true);
            p1Text.SetActive(false);
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

    public int getPlayerinTurn()
    {
        if (playerInTurn == TPlayerInTurn.P2)
        {
            return 2;
        }
        else return 1;
    }

    public void SetNotes()
    {
        currentNotes = startingNotes + turnNumber - 1;
    }

}
