using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour
{
    public void End_Button()
    {
        FadeManager.Instance.LoadScene("RankScene", 1.0f);
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Title);
    }
}
