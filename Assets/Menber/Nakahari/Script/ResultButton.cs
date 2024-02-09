using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultButton : MonoBehaviour
{
    public void Result_Button()
    {
        SceneChangr.scenechangrInstance._fade.SceneFade("ResultScene");
    }
}
