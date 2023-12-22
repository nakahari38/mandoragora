using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField]
    Score _score;
    Image _image;

    public Sprite _playerSprite;
    public Sprite _cpu1Sprite;


    private void Awake()
    {
        _score = Score.instance.GetComponent<Score>();
        _image = GetComponent<Image>();
    }
    private void Start()
    {
        if(_score._playerScore >= _score._cpu1Score)
        {
            _image.sprite = _playerSprite;
        }
        else if(_score._cpu1Score >= _score._playerScore)
        {
            _image.sprite = _cpu1Sprite;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
