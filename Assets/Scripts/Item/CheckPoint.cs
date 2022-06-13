using UnityEngine;
public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private Animator ani;

    private void Start()
    {
        if (ani == null)
            ani = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerStatus>().spawnPos = transform;
            ani.SetTrigger("CheckPointTrigger");
            ani.SetBool("CheckPointOn", true);
        }
    }
}
