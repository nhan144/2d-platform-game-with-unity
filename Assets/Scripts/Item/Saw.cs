using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float moveX;

    [SerializeField]
    private float moveY;

    public Transform objectToRotate;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(moveX * moveSpeed *  Time.deltaTime, moveY * moveSpeed * Time.deltaTime, 0f);
    }

    private void MoveAroundObject()
    {
        transform.RotateAround(objectToRotate.position, Vector3.right, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            moveSpeed *= -1;

        }
    }
}
