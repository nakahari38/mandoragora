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
        // �Ԃ��Ă���1�`4�ɂ���ĕ\������X�R�A��ς���
        switch (GetScore())
        {
            case 1:
                _tmpG.text = "No.1\n�悭����΂�܂���!\n���ׂ������F" + _score._playerScore;
            break;
            case 2:
                _tmpG.text = "No.1\n�悭����΂�܂���!\n���ׂ������F" + _score._cpu1Score;
            break;
            case 3:
                _tmpG.text = "No.1\n�悭����΂�܂���!\n���ׂ������F" + _score._cpu2Score;
            break;
            case 4:
                _tmpG.text = "No.1\n�悭����΂�܂���!\n���ׂ������F" + _score._cpu3Score;
            break;
        }

        
    }

    public int GetScore()
    {
        // ��ԑ����X�R�A���擾��if���ł��ꂼ����r��1�`4�ŕԂ�
        _highScore = Mathf.Max(_score._playerScore, _score._cpu1Score, _score._cpu2Score, _score._cpu3Score);
        if (_highScore == _score._playerScore)
            return 1;
        else if (_highScore == _score._cpu1Score)
            return 2;
        else if (_highScore == _score._cpu2Score)
            return 3;
        else�@
            return 4;
    }
}
