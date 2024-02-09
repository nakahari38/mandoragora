using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour
{
    public void End_Button()
    {
        SceneChangr.scenechangrInstance._fade.SceneFade("RankScene");
    }
}
