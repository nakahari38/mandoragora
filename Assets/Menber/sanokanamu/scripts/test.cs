using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.battle);
        SoundManager.Instance.PlaySE(SESoundData.SE.attack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
