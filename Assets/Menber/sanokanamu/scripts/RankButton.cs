using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RankButton : MonoBehaviour
{
    public void Rank_button()
    {
        FadeManager.Instance.LoadScene("ResultScene", 1.0f);
    }

}