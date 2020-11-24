using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public Text timerText;
    public float timer = 60;
    public Patrol[] patrol;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = Mathf.Round(timer).ToString();

        if(timer <= 0)
        {
            for(int i = 0; i < patrol.Length; i++)
            {
            patrol[i].start = true;
            }
        }
    }
}
