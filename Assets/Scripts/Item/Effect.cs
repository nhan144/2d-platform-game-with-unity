using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private void OnEnable()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        Invoke("Hide", 0.5f);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
