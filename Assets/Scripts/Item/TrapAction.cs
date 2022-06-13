using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAction : MonoBehaviour
{   
    public GameObject posTriggerSpikeBall;
    public GameObject child;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            child.SetActive(true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(posTriggerSpikeBall.transform.position, child.transform.position);
    }

}
