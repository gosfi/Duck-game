using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraControl : MonoBehaviour
{
    private PlayerControls[] players;
    private Vector3 velocity;

    private Camera _camera;

    [Header("Move Camera Variables")]
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime = 0.5f;

    [Header("Zoom Camera Variables")]
    [SerializeField] private float minZoom = 40f;
    [SerializeField] private float maxZoom = 10f;
    [SerializeField] private float zoomLimiter = 50f;

    //start at frame 1
    private void Start()
    {
        _camera = GetComponent<Camera>();
    }
    void Update()
    {
        GetAllPlayers();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (players.Length == 0)
        {
            return;
        }
        MoveCamera();
        ZoomCamera();
    }

    private void ZoomCamera()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, newZoom, Time.deltaTime);
    }

    private float GetGreatestDistance()
    {
        var bounds = new Bounds(players[0].transform.position, Vector3.zero);
        foreach (var player in players)
        {
            bounds.Encapsulate(player.transform.position);
        }

        return bounds.size.x;
    }

    void MoveCamera()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPos = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothTime);
        transform.LookAt(centerPoint);
    }

    private Vector3 GetCenterPoint()
    {
        if (players.Length == 1)
        {
            return players[0].transform.position;
        }
        var bounds = new Bounds(players[0].transform.position, Vector3.zero);
        foreach (var player in players)
        {
            bounds.Encapsulate(player.transform.position);
        }

        return bounds.center;
    }

    public void GetAllPlayers()
    {
        players = FindObjectsOfType<PlayerControls>();
    }
}
