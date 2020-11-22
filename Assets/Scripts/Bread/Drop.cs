using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public Patrol patrol;
    public GameObject bread;
    BoxCollider collider;
    public Rigidbody rb;
    public Transform npc;

    public float dropFowardForce;
    public float dropUpwardForce;
    public int dropPoint;
    public int breadCount;

    // Start is called before the first frame update
    void Start()
    {
        collider = bread.GetComponent<BoxCollider>();
        collider.isTrigger = true;
        rb.isKinematic = true;

        dropFowardForce = Random.Range(2f, 7f);
        dropUpwardForce = Random.Range(2f, 7f);
        dropPoint = (int)Random.Range(2f, 12f);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        if (patrol.waypointIndex == dropPoint && bread.transform.parent != null)
        {

            bread.transform.parent = null;
            bread.SetActive(true);
            collider.isTrigger = false;
            rb.isKinematic = false;

            rb.AddForce(-npc.right * dropFowardForce, ForceMode.Impulse);
            rb.AddForce(npc.up * dropUpwardForce, ForceMode.Impulse);

            float random = Random.Range(-1f, 1f);
            rb.AddTorque(new Vector3(random, random, random));

            dropFowardForce = Random.Range(2f, 7f);
            dropUpwardForce = Random.Range(2f, 7f);
            dropPoint = (int)Random.Range(1f, 12f);

        }
    }
}
