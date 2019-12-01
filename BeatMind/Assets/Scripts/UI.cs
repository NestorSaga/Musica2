using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public GameObject m_player1VictoryText;
    public GameObject m_player2VictoryText;

    public Text m_player1FinalScoreText;
    public Text m_player2FinalScoreText;

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
    public void DisplayFinalScore(int scorePlayer1, int scorePlayer2)
    {
        m_player1VictoryText.GetComponent<Text>().text = "Player 1: "+ scorePlayer1.ToString();
        m_player2VictoryText.GetComponent<Text>().text = "Player 2: " + scorePlayer1.ToString();
    }
}
