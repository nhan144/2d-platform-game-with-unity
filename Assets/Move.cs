using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float HorizontalInput;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

        speed = 8f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(HorizontalInput * Time.deltaTime * speed, 0f, 0f);
    }
}
