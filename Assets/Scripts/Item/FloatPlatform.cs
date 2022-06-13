using System.Collections;
using UnityEngine;

public class FloatPlatform : MonoBehaviour
{
    public bool isTrigg;

    private void Update()
    {
        if (isTrigg == true)
        {
            StartCoroutine("WaitFor1Second");
        }
    }

    IEnumerator WaitFor1Second()
    {
        yield return new WaitForSeconds(1f);

        gameObject.AddComponent<Rigidbody2D>();

        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);
    }



}
