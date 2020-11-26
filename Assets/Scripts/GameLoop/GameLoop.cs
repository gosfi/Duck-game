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
    private bool whistleStop;
    private bool start3;
    private bool start2;
    private bool start1;

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

        whistleStop = false;
        start3 = true;
        start2 = true;
        start1 = true;

    }

    // Update is called once per frame
    void Update()
    {


        if (startTimerBool)
        {
            startTimer -= Time.deltaTime;
            timerText.text = Mathf.Round(startTimer).ToString();
        }

        if (timerText.text == "3" && start3)
        {
            // PlaySound("Stop");
            PlaySound("Start");
            start3 = false;
        }
        if (timerText.text == "2" && start2)
        {
            // PlaySound("Stop");
            PlaySound("Start");
            start2 = false;
        }
        if (timerText.text == "1" && start1)
        {
            // PlaySound("Stop");
            PlaySound("Start");
            start1 = false;
        }

        if (startTimer < 0.8f)
        {
            timerText.text = "GO";
        }

        if (timerText.text == "GO" && !whistleStop)
        {
           // PlaySound("Stop");
            PlaySound("Whistle");
            whistleStop = true;
        }

        if (startTimer <= 0)
        {
           // PlaySound("Stop");
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
