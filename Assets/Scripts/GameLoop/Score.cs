using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private bool showScore = false;
    private float timer = 0.01f;
    private float timerPanel = 0;
    private float pointP1 = 0;
    private float pointP2 = 0;
    private float pointP1cpt = 0;
    private float pointP2cpt = 0;
    private Vector3 panelCpt;

    public bool startScore = false;
    public Text scoreP1;
    public Text scoreP2;
    public Transform Panel;
    public GameObject menu;

    const float YPOS = 300;
    const float TIMERPANEL = 0;

    // Start is called before the first frame update
    void Start()
    {
        pointP1 = 30;
        pointP2 = 90;
        panelCpt = Panel.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (startScore)
        {
            timerPanel -= Time.deltaTime;
            if (timerPanel <= 0)
            {
                if (Panel.transform.position.y != YPOS)
                {
                    panelCpt.y++;
                    Panel.transform.position = panelCpt;
                }
                if (Panel.transform.position.y >= YPOS)
                {
                    panelCpt.y = YPOS;
                    Panel.transform.position = panelCpt;

                    showScore = true;
                }
                timerPanel = TIMERPANEL;
            }
        }

        if (showScore)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (pointP1cpt != pointP1)
                {
                    pointP1cpt++;
                    scoreP1.text = pointP1cpt.ToString();
                    if (scoreP1.fontSize != 160)
                    {
                        scoreP1.fontSize++;
                    }
                }
                if (pointP2cpt != pointP2)
                {
                    pointP2cpt++;
                    scoreP2.text = pointP2cpt.ToString();
                    if (scoreP2.fontSize != 160)
                    {
                        scoreP2.fontSize++;
                    }
                }
                timer = 0.1f;
            }
            if(pointP1 == pointP1cpt && pointP2 == pointP2cpt)
            {
                menu.SetActive(true);
            }
        }
        
    }
}
