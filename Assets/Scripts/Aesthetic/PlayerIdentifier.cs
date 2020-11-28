using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerIdentifier : MonoBehaviour
{
    [SerializeField] string playerText;
    [SerializeField] TextMeshPro bigText;
    [SerializeField] Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        bigText.text = playerText;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_camera.transform.position);
    }
}
