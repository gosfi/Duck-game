using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject bread;
    BoxCollider collider;
    public Rigidbody rb;
    public Transform npc;

    private float dropFowardForce;
    private float dropUpwardForce;
    private int dropPoint;

    // Start is called before the first frame update
    void Start()
    {
        collider = bread.GetComponent<BoxCollider>();
        collider.isTrigger = true;
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            bread.transform.parent = null;
            collider.isTrigger = false;
            rb.isKinematic = false;

            rb.AddForce(-npc.right * dropFowardForce, ForceMode.Impulse);
            rb.AddForce(npc.up * dropUpwardForce, ForceMode.Impulse);

            float random = Random.Range(-1f, 1f);
            rb.AddTorque(new Vector3(random, random, random));
        }
    }
}
