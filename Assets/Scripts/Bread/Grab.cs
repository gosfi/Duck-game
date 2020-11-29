using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private Score score;

  

    private void OnEnable()
    {
        score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Player 1")
        {

            score.pointP1 += 1;
            Debug.Log("Point player 1 : " + score.pointP1);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player 2")
        {

            score.pointP2 += 1;
            Debug.Log("Point player 2 : " + score.pointP2);
            Destroy(gameObject);
        }
    }
}
