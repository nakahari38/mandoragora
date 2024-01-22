using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    AttackForce _attackForce;
    Vector2 _startPos;
    Vector2 _endPos;

    float _flickValue_x;
    float _flickValue_y;

    private Rigidbody2D _rb2D;

    private Catch _catch;

    [SerializeField]
    private float _move;

    public Vector3 _firstPos;
    public Quaternion _firstRot;

    private Vector2 force;

    public int random;
    [SerializeField]
    private GameObject _flowerPot1;
    [SerializeField]
    private GameObject _flowerPot2;
    [SerializeField]
    CountDown _countDown;

    // Start is called before the first frame update
    void Start()
    {
        if (_rb2D == null) _rb2D = GetComponent<Rigidbody2D>();
        if(_catch == null) _catch = GetComponent<Catch>();
        if(_attackForce == null) _attackForce = GetComponent<AttackForce>();
        _firstPos = this.transform.position;
        _firstRot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(_countDown._stop) return;
        // �{�^���������ė������ꏊ���擾����
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _endPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            GetDirection();
        }

        // �Z���g�����񐔂��擾������ɉ����Ĕ���\���A��\���ɂ���
        switch (_attackForce._count)
        {
            case 1:
                _flowerPot1.SetActive(false);
                _flowerPot2.SetActive(true);
            break;
            case 2:
                _flowerPot2.SetActive(false);
            break;
        }
        //Debug.Log(rb2D.velocity.magnitude);
    }

    void FlickDirection()
    {
        // �擾�����ϐ����v�Z���ǂ̒��x�t���b�N�����̂����擾����
        _flickValue_x = _endPos.x - _startPos.x;
        _flickValue_y = _endPos.y - _startPos.y;
        //Debug.Log("x �t���b�N�ʂ�" + flickValue_x);
        //Debug.Log("y �t���b�N�ʂ�" + flickValue_y);
    }

    void GetDirection()
    {
        // �t���b�N���������ɗ͂�������
        FlickDirection();
        force = new Vector2(_flickValue_x, _flickValue_y);
        _rb2D.AddForce(force * (_move + _catch._speed));
    }
}
