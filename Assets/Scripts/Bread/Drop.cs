using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public Patrol patrol;
    BoxCollider boxCollider;
    public Transform npc;

    public float dropFowardForce;
    public float dropUpwardForce;
    public int dropPoint;
    public int breadCount;

    private GameObject breadPrefab;
    private Rigidbody rb;
    private GameObject currentBread;

    private void Awake()
    {
        var bread = Resources.Load("Prefab/Bread");
        breadPrefab = bread as GameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        dropFowardForce = Random.Range(5f, 8f);
        dropUpwardForce = Random.Range(5f, 8f);
        dropPoint = (int)Random.Range(2f, 12f);

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        if (patrol.waypointIndex == dropPoint && currentBread.transform.parent != null)
        {
            currentBread.transform.parent = null;
            currentBread.SetActive(true);
            boxCollider.isTrigger = false;
            rb.isKinematic = false;

            rb.AddForce(-npc.right * dropFowardForce, ForceMode.Impulse);
            rb.AddForce(npc.up * dropUpwardForce, ForceMode.Impulse);

            float random = Random.Range(-1f, 1f);
            rb.AddTorque(new Vector3(random, random, random));

            dropFowardForce = Random.Range(4f, 7f);
            dropUpwardForce = Random.Range(4f, 7f);
            dropPoint = (int)Random.Range(2f, 12f);

            Spawn();
        }
    }

    private void Spawn()
    {
        currentBread = Instantiate(breadPrefab, npc.transform.position, npc.transform.rotation);
        currentBread.transform.parent = npc;
        boxCollider = currentBread.GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        rb = currentBread.GetComponent<Rigidbody>();
        rb.isKinematic = true;

    }
}
