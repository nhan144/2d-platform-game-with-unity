using UnityEngine;

public class Collectable : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject clone = PoolManager.Instance.SpamEffect();

            clone.transform.position = transform.position;
            FindObjectOfType<SoundManager>().PlaySound("Pickup");

            gameObject.SetActive(false);
            //Debug.Log("You got: " + gameObject.name);

            switch (gameObject.tag)
            {
                case "Fruit1P":
                    FindObjectOfType<UIManager>().AddScore(1);
                    break;
                case "Fruit2P":
                    FindObjectOfType<UIManager>().AddScore(2);
                    break;
                case "Fruit3P":
                    FindObjectOfType<UIManager>().AddScore(3);
                    break;
                default:

                    break;
            }

        }
        
    }

}
