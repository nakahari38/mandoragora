using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    Image _image;
    [SerializeField]
    Result _result;

    public Sprite _playerSprite;
    public Sprite _cpu1Sprite;
    public Sprite _cpu2Sprite;
    public Sprite _cpu3Sprite;


    private void Awake()
    {
        _image = GetComponent<Image>();
        if(_result == null) _result = GetComponent<Result>();
    }

    // ���ꂼ��̃X�R�A�ɉ����Ĉ�ԃX�R�A�������L�����N�^�[�����U���g�ɕ\������
    private void Start()
    {
        switch (_result.GetScore())
        {
            case 1:
                _image.sprite = _playerSprite;
                break;
            case 2:
                _image.sprite = _cpu1Sprite;
                break;
            case 3:
                _image.sprite = _cpu2Sprite;
                break;
            case 4:
                _image.sprite = _cpu3Sprite;
                break;
        }
    }

}
