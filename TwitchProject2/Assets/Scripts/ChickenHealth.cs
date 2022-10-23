using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenHealth : MonoBehaviour
{
    public bool invincible;
    public Image theFill;
    bool isburning;

    public float maxHealth;
    public float health;
    public string username;

    public float smoothspeed = 5;
    public Animator chikengfx;

    public GameObject blood;
    public GameObject healfx;
    public Animator baranim;
    public GameObject burnfx;

    AudioSource speaker;
    Chickeninput inputmanager;
    public AudioClip clip;

    void Start()
    {
        speaker = gameObject.GetComponent<AudioSource>();
        inputmanager = gameObject.GetComponent<Chickeninput>();
        username = inputmanager.namestring;
    }

    public void TakeDamage(float damage)
    {
        username = inputmanager.namestring;
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

    public void StartBurn(float damage)
    {
        if(isburning == false)
        {
            isburning = true;
            StartCoroutine(Burn(damage));
        }
    }

    IEnumerator Burn(float burnamount)
    {
        burnfx.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        TakeDamage(burnamount);
        yield return new WaitForSeconds(0.6f);
        TakeDamage(burnamount);
        yield return new WaitForSeconds(0.6f);
        TakeDamage(burnamount);
        yield return new WaitForSeconds(0.6f);
        TakeDamage(burnamount);
        yield return new WaitForSeconds(0.6f);
        TakeDamage(burnamount);
        burnfx.SetActive(false);
        isburning = false;
    }

    public void Update()
    {
        if(theFill.fillAmount != health)
        {
            theFill.fillAmount = Mathf.Lerp(theFill.fillAmount, health, smoothspeed * Time.deltaTime);
        }
    }
}
