using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameLoop : MonoBehaviour
{
    public Text gameTimerText;
    public float gameTimer;

    public Text timerText;
    public float startTimer;

    public Score score;

    public Patrol[] patrol;

    private bool startTimerBool;

    const float START_TIMER = 3;
    const float GAME_TIMER = 5;

    private AudioClip duckSound, whistleSound;
    private AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        duckSound = Resources.Load<AudioClip>("Sound/DuckSound");
        whistleSound = Resources.Load<AudioClip>("Sound/WhistleSound");

        audioSrc = GetComponent<AudioSource>();

        startTimer = START_TIMER;
        startTimerBool = true;
        timerText.text = startTimer.ToString();

        gameTimer = GAME_TIMER;

    }

    // Update is called once per frame
    void Update()
    {


        if (startTimerBool)
        {
            startTimer -= Time.deltaTime;
            timerText.text = Mathf.Round(startTimer).ToString();
        }
       


        if (startTimer < 0.8f)
        {
            timerText.text = "GO";
        }

        if (timerText.text == "GO")
        {
           // PlaySound("Stop");
            PlaySound("Whistle");
        }

        if (startTimer <= 0)
        {
            PlaySound("Stop");
            startTimerBool = false;
            timerText.text = " ";
            startTimer = 0;

            gameTimer -= Time.deltaTime;
            gameTimerText.text = Mathf.Round(gameTimer).ToString();

            for (int i = 0; i < patrol.Length; i++)
            {
                patrol[i].start = true;
            }
        }

        if (gameTimer <= 0)
        {

            gameTimerText.text = " ";
            gameTimer = 0;
            for (int i = 0; i < patrol.Length; i++)
            {
                patrol[i].start = false;
            }
            score.startScore = true;
        }
    }

    void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Start":
                audioSrc.PlayOneShot(duckSound);
                break;
            case "Whistle":
                audioSrc.PlayOneShot(whistleSound);
                break;
            case "Stop":
                audioSrc.Stop();
                break;
        }
    }
}
