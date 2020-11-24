using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public Text timerText;
    public float startTimer = 60;
    public Patrol[] patrol;

    private bool startTimerBool;

    // Start is called before the first frame update
    void Start()
    {
        startTimerBool = true;
        timerText.text = startTimer.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (startTimerBool)
        {
            startTimer -= Time.deltaTime;
            timerText.text = Mathf.Round(startTimer).ToString();
        }
        

        if(startTimer <= 0)
        {
            startTimerBool = false;
            timerText.text = "0";
            startTimer = 60;

            for(int i = 0; i < patrol.Length; i++)
            {
            patrol[i].start = true;
            }
        }
    }
}
