using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FruitScore: MonoBehaviour
{
    [SerializeField]
    Catch _catch;

    [SerializeField]
    TextMeshProUGUI _appleScore;

    [SerializeField]
    TextMeshProUGUI _orangeScore;

    [SerializeField]
    TextMeshProUGUI _pairScore;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // それぞれのスコアを表示する
        _appleScore.text = _catch._apple.ToString();
        _orangeScore.text = _catch._orange.ToString();
        _pairScore.text = _catch._pair.ToString();
    }
}
