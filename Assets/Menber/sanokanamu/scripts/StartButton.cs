using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour 
{
    public void start_button()
     {
        SceneChangr.scenechangrInstance._fade.SceneFade("GameScene");
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.battle);
     }

 }

