
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject key;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            key.SetActive(true);
            Destroy(gameObject,0.15f);
        }
    }
}
