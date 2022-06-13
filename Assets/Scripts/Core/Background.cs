using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform cameraPos;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    public Vector3 startPos;

    private void FixedUpdate()
    {
        CoolMove();
    }

    private void SmoothTransBtw()
    {
        Vector3 distanceBtw = cameraPos.position + offset;

        Vector3 smoothPosTrans = Vector3.Lerp(transform.position, distanceBtw, smoothSpeed);

        transform.position = smoothPosTrans;
    }

    private void CoolMove()
    {
        transform.position += new Vector3(2f * Time.deltaTime, 2f * Time.deltaTime, 0f);
        if (transform.position.y == 5.879996f)
        {
            transform.position = startPos;
        }
    }

}
