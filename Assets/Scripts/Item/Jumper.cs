using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float forceY;

    public Animator ani;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, forceY), ForceMode2D.Impulse);
        ani.SetTrigger("OnJumper");
    }
}
