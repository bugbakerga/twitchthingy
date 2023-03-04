using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeDrop : MonoBehaviour
{
    public Prize[] prizes;

    public List<Prize> selectedPrizes;

    // Start is called before the first frame update
    void Start()
    {
        CheckSelection();
    }

    public void CheckSelection()
    {
        for (int i = 0; i < prizes.Length; i++)
        {
            if(PlayerPrefs.GetInt(prizes[i].prefname) == 1)
            {
                selectedPrizes.Add(prizes[i]);
            }
        }
    }

    public void DropPrize()
    {
        int randomdrop = Random.Range(0, selectedPrizes.Count);
        Instantiate(selectedPrizes[randomdrop].prizeprefab, transform.position, Quaternion.identity);
    }
}
