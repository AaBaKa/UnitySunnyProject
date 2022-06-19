
using UnityEngine;

public class GemFeedback : MonoBehaviour
{
    public GameObject feedback;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            feedback.SetActive(true);
            Destroy(gameObject,0.15f);
        }
    }
}
