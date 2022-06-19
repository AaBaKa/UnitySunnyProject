
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    public GameObject EnterAidlog;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            EnterAidlog.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            EnterAidlog.SetActive(false);
        }
    }
}
