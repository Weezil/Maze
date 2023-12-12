using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPopUp : MonoBehaviour
{
    public GameObject EndPanel;
    public Text GemRemain;
    public Text TimeRemain;



    private void Start()
    {
        EndPanel.SetActive(false);
    }
    public void ShowEndPanel(int totalGems, float totalTime, int collectedGems, float timeRemain)
    {
        EndPanel.SetActive(true);
        GemRemain.text = " Gems: " + collectedGems + " / 113" ;
        TimeRemain.text = " Time: " + Mathf.CeilToInt(timeRemain) + " / " + Mathf.CeilToInt(totalTime);
    }

    public void HideEndPanel()
    {
        EndPanel.SetActive(false);
    }
}
