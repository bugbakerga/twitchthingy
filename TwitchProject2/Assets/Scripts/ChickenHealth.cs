using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenHealth : MonoBehaviour
{
    public Image theFill;

    public float maxHealth;
    public float health;

    public float smoothspeed = 5;
    public Animator chikengfx;

    public GameObject blood;
    public Animator baranim;

    AudioSource speaker;
    public AudioClip clip;

    void Start()
    {
        speaker = gameObject.GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
    {
        if(health - damage > 0)
        {
            health -= damage;
            chikengfx.SetTrigger("hit");
            baranim.SetTrigger("hit");
            speaker.PlayOneShot(clip);
        }
        else
        {
            health = 0;
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Heal(float increase)
    {
        if(health + increase <= maxHealth)
        {
            health += increase;
        }
        else
        {
            health = maxHealth;
        }
    }

    public void Update()
    {
        if(theFill.fillAmount != health)
        {
            theFill.fillAmount = Mathf.Lerp(theFill.fillAmount, health, smoothspeed * Time.deltaTime);
        }
    }
}
