using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public GameObject TurnPrefab;
    public int p1StartingNotes = 3;
    public int p2StartingNotes = 3;
    public int turnNumber = 1;
    private List<GameObject> turn = new List<GameObject>();

    public enum TPlayerInTurn
    {
        P1,
        P2
    }

    private TPlayerInTurn playerInTurn = TPlayerInTurn.P1;

    public GameObject currentTurn;

    private int _p1CurrentNotes;
    private int _p2CurrentNotes;
    

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
    }

    void Start()
    {
        turnNumber = 1;
        InitTurn();
    }

  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            EndTurn();
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

}
