using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public GameObject m_player1VictoryText;
    public GameObject m_player2VictoryText;



    void Start()
    {
        m_player1VictoryText.SetActive(false);
        m_player2VictoryText.SetActive(false);
    }

    
    void Update()
    {
        
    }
    public void EnablePlayer1TextAsWinner()
    {
        m_player1VictoryText.SetActive(true);
    }
    public void EnablePlayer2TextAsWinner()
    {
        m_player1VictoryText.SetActive(false);
    }
}
