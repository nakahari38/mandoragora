using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    TextMeshProUGUI _tmpG;
    Score _score;


    // Start is called before the first frame update
    private void Awake()
    {
        if(_tmpG == null) _tmpG = GetComponent<TextMeshProUGUI>();
        _score = Score.instance.GetComponent<Score>();
    }

    void Start()
    {
        _tmpG.text = "\nよくがんばりました!\nあなたがたべたかず:" + _score._playerScore;
    }
}
