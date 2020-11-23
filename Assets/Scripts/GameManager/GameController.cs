using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    int scoreP1, scorep2;
    public TextMeshProUGUI p1Text, p2Text;

    private void Start()
    {
        scoreP1 = 0;
        scorep2 = 0;
    }
    public void AddScorePlayer1()
    {
        scoreP1++;
    }

    public void AddScorePlayer2()
    {
        scorep2++;
    }

    public void EndGame()
    {

    }
}
