using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinnerText : MonoBehaviour
{
    public TextMeshProUGUI huddisplay;

    public GameObject copied;
    public Transform copiedposition;

    public string nameofwinner;


    // Start is called before the first frame update
    void Start()
    {
        nameofwinner = WinnerInfo.instance.winnername;
        huddisplay.text = "Winner!: " + nameofwinner;
        Destroy(WinnerInfo.instance);
    }

    public void CopyWinner()
    {
        Instantiate(copied, copiedposition).GetComponent<AudioSource>().Play();
        TextEditor textEditor = new TextEditor();
        textEditor.text = nameofwinner;
        textEditor.SelectAll();
        textEditor.Copy();
    }
}
