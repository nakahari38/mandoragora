using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    TextMeshProUGUI _tmpG;

    Score _score;

    int _highScore;
    // Start is called before the first frame update
    private void Awake()
    {
        if(_tmpG == null) _tmpG = GetComponent<TextMeshProUGUI>();
        _score = Score.instance.GetComponent<Score>();
    }

    void Start()
    {
        // 返ってきた1～4によって表示するスコアを変える
        switch (GetScore())
        {
            case 1:
                _tmpG.text = "No.1\nよくがんばりました!\nたべたかず：" + _score._playerScore;
            break;
            case 2:
                _tmpG.text = "No.1\nよくがんばりました!\nたべたかず：" + _score._cpu1Score;
            break;
            case 3:
                _tmpG.text = "No.1\nよくがんばりました!\nたべたかず：" + _score._cpu2Score;
            break;
            case 4:
                _tmpG.text = "No.1\nよくがんばりました!\nたべたかず：" + _score._cpu3Score;
            break;
        }

        
    }

    public int GetScore()
    {
        // 一番多いスコアを取得しif文でそれぞれを比較し1～4で返す
        _highScore = Mathf.Max(_score._playerScore, _score._cpu1Score, _score._cpu2Score, _score._cpu3Score);
        if (_highScore == _score._playerScore)
            return 1;
        else if (_highScore == _score._cpu1Score)
            return 2;
        else if (_highScore == _score._cpu2Score)
            return 3;
        else　
            return 4;
    }
}
