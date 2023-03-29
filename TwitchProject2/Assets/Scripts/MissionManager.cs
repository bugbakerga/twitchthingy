using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public RawImage display;
    public RawImage proggressdisplay;

    public Emote[] emote;
    public Slider bar;

    public float maxHype;
    public float hype;

    public Animator message;
    public Animator baranim;

    public Animator reminderanimator;
    public Text remindertext;
    public string settingname;

    public int chatthreshhold;
    public float smoothspeed;
    public TextMeshProUGUI textDisplay;
    public int randomnumber;

    bool inMission;
    bool canadd;
    public GameObject endprize;
    public Transform prizespawn;

    AudioSource audioSource;
    public AudioClip clip;

    public void startfirst()
    {
        StartCoroutine(missiondelay());
        audioSource = gameObject.GetComponent<AudioSource>();
        maxHype = PlayerPrefs.GetFloat(settingname, 5) - 1f;
        bar.maxValue = maxHype;
    }

    public void BeginMission()
    {
        missionContents();
    }

    public void AddHype()
    {
        if(canadd == true)
        {
            if (hype + chatthreshhold <= maxHype)
            {
                hype += chatthreshhold;
            }
            else
            {
                canadd = false;
                hype = maxHype;
                resetHype();
            }
        }
    }

    void Update()
    {
        if (bar.value != hype)
        {
            bar.value = Mathf.Lerp(bar.value, hype, smoothspeed * Time.deltaTime);
        }
    }

    public void missionContents()
    {
        randomnumber = Random.Range(0, emote.Length);
        canadd = true;
        display.texture = emote[randomnumber].emoteImage;
        proggressdisplay.texture = emote[randomnumber].emoteImage;
        textDisplay.text = "Emote Mission: " + emote[randomnumber].emoteName;
        message.SetTrigger("mission");
        baranim.SetBool("isopen", true);
        reminderanimator.SetTrigger("move");
        remindertext.text = emote[randomnumber].emoteName + " in chat!";
        audioSource.PlayOneShot(clip);
    }

    public void resetHype()
    {
        Instantiate(endprize, prizespawn.position, Quaternion.identity);
        hype = 0f;
        baranim.SetBool("isopen", false);
        reminderanimator.SetTrigger("ending");
        StartCoroutine(missiondelay());
    }

    IEnumerator missiondelay ()
    {
        yield return new WaitForSeconds(10f);
        BeginMission();
    }
}
