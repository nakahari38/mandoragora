using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrownView : MonoBehaviour
{
    [SerializeField]
    private Image _playerCrown;
    [SerializeField]
    private Image _cpu1Crown;
    [SerializeField]
    private Image _cpu2Crown;
    [SerializeField]
    private Image _cpu3Crown;

    [SerializeField]
    Score _score;

    float _max;
    // Start is called before the first frame update
    void Start()
    {
        _playerCrown.enabled = false;
        _cpu1Crown.enabled = false;
        _cpu2Crown.enabled = false;
        _cpu3Crown.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _max = Mathf.Max(_score._playerScore, _score._cpu1Score, _score._cpu2Score, _score._cpu3Score);

        if(_max == _score._playerScore)
        {
            _playerCrown.enabled = true;
            _cpu1Crown.enabled = false;
            _cpu2Crown.enabled = false;
            _cpu3Crown.enabled = false;
        }
        else if(_max == _score._cpu1Score)
        {
            _playerCrown.enabled = false;
            _cpu1Crown.enabled = true;
            _cpu2Crown.enabled = false;
            _cpu3Crown.enabled = false;
        }
        else if(_max == _score._cpu2Score)
        {
            _playerCrown.enabled = false;
            _cpu1Crown.enabled = false;
            _cpu2Crown.enabled = true;
            _cpu3Crown.enabled = false;
        }
        else if(_max == _score._cpu3Score)
        {
            _playerCrown.enabled = false;
            _cpu1Crown.enabled = false;
            _cpu2Crown.enabled = false;
            _cpu3Crown.enabled = true;
        }
    }
}
