using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    int scoreP1, scorep2;

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
}
