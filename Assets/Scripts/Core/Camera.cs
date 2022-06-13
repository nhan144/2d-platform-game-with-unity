using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float smoothSpeed = 0.125f;

    public Vector3 offset;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 distanceBtw = player.position + offset;

        Vector3 smoothPos = Vector3.Lerp(transform.position, distanceBtw, smoothSpeed * Time.deltaTime);

        transform.position = smoothPos;
    }


}
