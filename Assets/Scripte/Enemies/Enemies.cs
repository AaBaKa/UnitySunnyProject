
using UnityEngine;

public class Enemies : MonoBehaviour
{
    protected Animator Anim;
    protected AudioSource deathAudioSource;
    protected  virtual void Start()   //virtual，虚拟的，可重写
    {
        Anim = GetComponent<Animator>();
        deathAudioSource = GetComponent<AudioSource>();
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void Jumpon()
    {
        Anim.SetTrigger("death");
        deathAudioSource.Play();
    }
}
