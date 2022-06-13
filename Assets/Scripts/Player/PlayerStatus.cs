using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerStatus : MonoBehaviour
{

    [Header("Status")]
    [SerializeField]
    private int life;
    [SerializeField]
    private int currentLife;

    private bool finishState;

    [SerializeField]
    private int levelScore;
    public Transform groundCheckPos;

    public Animator animator;
    public Transform spawnPos;

    private Sprite heartOn;
    private Sprite heartOff;

    private GameObject heartBar;

    private bool isColliding;

    private void Awake()
    {
        life = 3;
        currentLife = life;
        finishState = false;

        heartOn = Resources.Load<Sprite>("heart-star_2");
        heartOff = Resources.Load<Sprite>("heart-star_3");
        heartBar = GameObject.Find("CanvasGamePlay/PanelTop/PanelHeart");

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isColliding = false;
        CheckRayDown();
    }

    public void CheckRayDown()
    {
        Vector2 groundCheckVec2 = new Vector2(groundCheckPos.position.x, groundCheckPos.position.y);
        RaycastHit2D hit = Physics2D.Raycast(groundCheckVec2, Vector2.down);

        //if (hit.collider != null)
        //{
        //    Debug.Log("Hit " + hit.transform.name);
        //}
        //Debug.DrawRay(groundCheckPos.position, Vector2.down, Color.red);

        switch (hit.transform.name)
        {
            case "FloatingPlatform":
                hit.transform.gameObject.GetComponent<FloatPlatform>().isTrigg = true;
                break;
            default:
                Debug.Log("Hit Nothing");
                break;
        }
    }

    //Check for traps
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            if (isColliding) return;
            isColliding = true;
            Die();
        }

    }

    IEnumerator ResetCollider()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
    }

    private void Die()
    {
        currentLife--;

        Debug.Log("Player is dead, life left: " + currentLife);
        StartCoroutine("PlayerDead");

        lifeLeft();

        if (currentLife == 0)
        {
            FindObjectOfType<FinishLevel>().GameLose();
        }

        StartCoroutine("PlayerSpawn");
    }

    private void lifeLeft ()
    {

        if (currentLife == 2)
        {
            heartBar.transform.GetChild(2).gameObject.SetActive(false);        }
        else if (currentLife == 1)
        {
            heartBar.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            heartBar.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    IEnumerator PlayerDead()
    {
        //GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;

        GameObject.Find("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        FindObjectOfType<SoundManager>().PlaySound("Die");
        animator.SetTrigger("PlayerDead");
        gameObject.GetComponent<PlayerMovement>().isDead = true;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<Renderer>().enabled = false;
        animator.SetBool("PlayerJump", false);
        animator.SetBool("PlayerFall", false);
        animator.SetBool("PlayerRun", false);
        animator.SetBool("PlayerJumpBonus", false);
        animator.SetBool("PlayerWallSlide", false);
    }

    IEnumerator PlayerSpawn()
    {
        yield return new WaitForSeconds(2f);
        transform.position = spawnPos.position;
        gameObject.GetComponent<Renderer>().enabled = true;
        animator.SetTrigger("PlayerSpawn");
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<PlayerMovement>().isDead = false;

        GameObject.Find("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
    }


}
