using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenHealth : MonoBehaviour
{
    public bool invincible;
    public Image healthgfx;

    public float maxHealth;
    public float health;
    public string username;

    public float smoothspeed = 5;
    public Animator chikengfx;

    public GameObject blood;
    public GameObject healfx;
    public Animator baranim;

    AudioSource speaker;
    public AudioClip clip;

    void Start()
    {
        speaker = gameObject.GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
    {
        if (invincible == false)
        {
            if (health - damage > 0)
            {
                health -= damage;
                chikengfx.SetTrigger("hit");
                baranim.SetTrigger("hit");
                speaker.PlayOneShot(clip);
            }
            else
            {
                NotiManager.instance.addNotification(username);
                health = 0;
                Instantiate(blood, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    public void Heal(float increase)
    {
        if(health + increase <= maxHealth)
        {
            health += increase;
            baranim.SetTrigger("heal");
            Instantiate(healfx, transform.position, Quaternion.identity);
        }
        else
        {
            health = maxHealth;
            baranim.SetTrigger("heal");
            Instantiate(healfx, transform.position, Quaternion.identity);
        }
    }

    public void Update()
    {
        if(healthgfx.fillAmount != health)
        {
            healthgfx.fillAmount = Mathf.Lerp(healthgfx.fillAmount, health, smoothspeed * Time.deltaTime);
        }
    }
}
