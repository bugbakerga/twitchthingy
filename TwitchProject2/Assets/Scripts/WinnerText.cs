using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinnerText : MonoBehaviour
{
    public TextMeshProUGUI overhead;
    public TextMeshProUGUI huddisplay;

    public GameObject copied;

    // Start is called before the first frame update
    void Start()
    {
        overhead.text = WinnerInfo.instance.winnername;
        huddisplay.text = "Winner!: " + WinnerInfo.instance.winnername;
    }

    public void CopyWinner()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.text = WinnerInfo.instance.winnername;
        textEditor.SelectAll();
        textEditor.Copy();
        copied.SetActive(false);
        StartCoroutine(resetcopied());
    }

    IEnumerator resetcopied()
    {
        yield return new WaitForSeconds(0.3f);
        copied.SetActive(true);
    }
}
