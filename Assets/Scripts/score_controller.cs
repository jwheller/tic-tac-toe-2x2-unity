using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_controller : MonoBehaviour
{
    public int swordScore = 0;
    public int shieldScore = 0;

    public void UpdateSwordScore()
    {
        GetComponent<Text>().text = "Swords: " + swordScore;
    }

    public void UpdateShieldScore()
    {
        GetComponent<Text>().text = "Shields: " + shieldScore;
    }
}
