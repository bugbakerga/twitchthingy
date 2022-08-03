using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menureturn : MonoBehaviour
{
    public void backtomenu()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void todashboard()
    {
        StartCoroutine(delaytime());
    }

    IEnumerator delaytime()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(3);
    }
}
