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

    public GameObject camera1;
    public GameObject camera2;

    private AudioListener camera1Audio;
    private AudioListener camera2Audio;

    private bool startTimerBool;
    private bool whistleStop = false;
    private bool start3 = true;
    private bool start2 = true;
    private bool start1 = true;
    private bool gameMusic = true;
    private bool endGame = true;

    const float START_TIMER = 3;
    const float GAME_TIMER = 45;

    private AudioClip duckSound, whistleSound, parkSound;
    public AudioSource audioSrcGame;
    public AudioSource audioSrcPark;

    // Start is called before the first frame update
    void Start()
    {
        duckSound = Resources.Load<AudioClip>("Sound/DuckSound");
        whistleSound = Resources.Load<AudioClip>("Sound/WhistleSound");
        parkSound = Resources.Load<AudioClip>("Sound/Park");

        audioSrcGame = GetComponent<AudioSource>();

        startTimer = START_TIMER;
        startTimerBool = true;
        timerText.text = startTimer.ToString();

        gameTimer = GAME_TIMER;

        camera1Audio = camera1.GetComponent<AudioListener>();
        camera2Audio = camera2.GetComponent<AudioListener>();

        camera1.SetActive(true);
        camera1Audio.enabled = true;
        camera2.SetActive(false);
        camera2Audio.enabled = false;


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

            PlaySound("Start");
            start3 = false;
        }
        if (timerText.text == "2" && start2)
        {
            PlaySound("Start");
            start2 = false;
        }
        if (timerText.text == "1" && start1)
        {
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
            camera1.SetActive(false);
            camera1Audio.enabled = false;
            camera2.SetActive(true);
            camera2Audio.enabled = true;
            // PlaySound("Stop");
            startTimerBool = false;
            timerText.text = " ";
            startTimer = 0;
            if (gameMusic)
            {
                PlaySound("Park");
                gameMusic = false;
            }
            gameTimer -= Time.deltaTime;
            gameTimerText.text = Mathf.Round(gameTimer).ToString();

            for (int i = 0; i < patrol.Length; i++)
            {
                patrol[i].start = true;
            }
        }

        if (gameTimer <= 0)
        {
            camera1.SetActive(true);
            camera1Audio.enabled = true;
            camera2.SetActive(false);
            camera2Audio.enabled = false;
            PlaySound("StopPark");
            if (endGame)
            {
                PlaySound("Whistle");
                endGame = false;
            }
            gameTimerText.text = " ";
            gameTimer = 0;
            for (int i = 0; i < patrol.Length; i++)
            {
                patrol[i].start = false;
            }
            score.startScore = true;
        }
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Start":
                audioSrcGame.PlayOneShot(duckSound);
                break;
            case "Whistle":
                audioSrcGame.PlayOneShot(whistleSound);
                break;
            case "Park":
                audioSrcPark.PlayOneShot(parkSound);
                break;
            case "StopGame":
                audioSrcGame.Stop();
                break;
            case "StopPark":
                audioSrcPark.Stop();
                break;
        }
    }
    
}
