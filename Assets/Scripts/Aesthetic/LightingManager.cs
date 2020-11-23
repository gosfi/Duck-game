using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    float angleY = 0;
    float angleX = 45;

    void Update()
    {
        angleY += Time.deltaTime * 5;

        directionalLight.transform.localRotation = Quaternion.Euler(angleX, angleY, 0);
    }
}
