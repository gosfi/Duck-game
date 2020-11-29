using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private bool showScore = false;
    private float timer = 0.01f;
    private float timer2 = 5f;
    private float timer3 = 5f;
    private float timerPanel = 0;
    private float pointP1cpt = 0;
    private float pointP2cpt = 0;
    private Vector3 panelCpt;

    public float pointP1;
    public float pointP2;
    public bool startScore = false;
    public Text scoreP1;
    public Text scoreP2;
    public Transform Panel;
    public GameObject menu;
    public GameLoop loop;
    public GameObject win1;
    public GameObject win2;
    public GameObject tie;
    public GameObject scoreView;

    const float YPOS = 500;
    const float TIMERPANEL = 0;

    // Start is called before the first frame update
    void Start()
    {
        pointP1 = 0;
        pointP2 = 0;
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
                    panelCpt.y += 5;
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
                    loop.PlaySound("Start");
                }
                if (pointP2cpt != pointP2)
                {

                    pointP2cpt++;
                    scoreP2.text = pointP2cpt.ToString();
                    if (scoreP2.fontSize != 160)
                    {
                        scoreP2.fontSize++;
                    }
                    loop.PlaySound("Start");
                }

                timer = 0.1f;
            }

            if (pointP1 == pointP1cpt && pointP2 == pointP2cpt)
            {
                timer3 -= Time.deltaTime;

                if (timer3 <= 0)
                {
                    scoreView.SetActive(false);
                    if (pointP1 > pointP2)
                    {
                        win1.SetActive(true);
                        timer2 -= Time.deltaTime;
                    }
                    else if (pointP2 > pointP1)
                    {
                        win2.SetActive(true);
                        timer2 -= Time.deltaTime;
                    }
                    else if (pointP1 == pointP2)
                    {
                        tie.SetActive(true);
                        timer2 -= Time.deltaTime;
                    }
                }

                if (timer2 <= 0)
                {
                    menu.SetActive(true);
                }
            }
        }

    }
}
