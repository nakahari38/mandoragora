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

    private Vector3 _firstPos;
    private Quaternion _firstRot;

    private Vector2 force;

    [SerializeField]
    Score _score;

    public bool _judge = false;

    public int random;

    private ULT _ult;

    [SerializeField]
    private GameObject _flowerPot1;
    [SerializeField]
    private GameObject _flowerPot2;
    [SerializeField]
    CountDown _countDown;

    // Start is called before the first frame update
    void Start()
    {
        _score = Score.instance.GetComponent<Score>();
        if (_rb2D == null) _rb2D = GetComponent<Rigidbody2D>();
        if(_catch == null) _catch = GetComponent<Catch>();
        if (_ult == null) _ult = GetComponent<ULT>();
        if(_attackForce == null) _attackForce = GetComponent<AttackForce>();
        _firstPos = this.transform.position;
        _firstRot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(_countDown._stop) return;
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _endPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            GetDirection();
        }

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

        #region 場外に出た時の処理
        if (this.transform.position.x >= 2300 || this.transform.position.x <= -2300)
        {
            _ult.AddUltScore(-2);
            _attackForce._power -= 100;
            _rb2D.velocity = Vector3.zero;
            this.transform.position = _firstPos;
            this.transform.rotation = _firstRot;
            _judge = true;
            random = Random.Range(1, 4);
            if (_score._playerScore <= 3) return;
            if (_score._playerScore <= 24)
            {
                /*do
                {
                    random = Random.Range(1, 3);
                } while (IsConditions(random));*/
                switch (random)
                {
                    case 1:
                        if (_catch._apple <= 3) return;
                        _catch._apple -= 4;
                        break;
                    case 2:
                        if (_catch._orange <= 3) return;
                        _catch._orange -= 4;
                        break;
                    case 3:
                        if (_catch._pair <= 3) return;
                        _catch._pair -= 4;
                        break;
                }
            }
            else if( _score._playerScore <= 48)
            {
                /*do
                {
                    random = Random.Range(1, 3);
                } while (IsConditions2(random));*/
                switch (random)
                {
                    case 1:
                        if (_catch._apple <= 7) return;
                        _catch._apple -= 8;
                        break;
                    case 2:
                        if (_catch._orange <= 7) return;
                        _catch._orange -= 8;
                        break;
                    case 3:
                        if (_catch._pair <= 7) return;
                        _catch._pair -= 8;
                        break;
                }
            }
            else if(_score._playerScore <= 72)
            {
                /*do
                {
                    random = Random.Range(1, 3);
                } while (IsConditions3(random));*/
                switch (random)
                {
                    case 1:
                        if (_catch._apple <= 11) return;
                        _catch._apple -= 12;
                        break;
                    case 2:
                        if (_catch._orange <= 11) return;
                        _catch._orange -= 12;
                        break;
                    case 3:
                        if (_catch._pair <= 11) return;
                        _catch._pair -= 12;
                        break;
                }
            }
            else
            {
                /*do
                {
                    random = Random.Range(1, 3);
                } while (IsConditions4(random));*/
                switch (random)
                {
                    case 1:
                        if (_catch._apple <= 15) return;
                        _catch._apple -= 16;
                        break;
                    case 2:
                        if (_catch._orange <= 15) return;
                        _catch._orange -= 16;
                        break;
                    case 3:
                        if (_catch._pair <= 15) return;
                        _catch._pair -= 16;
                        break;
                }
            }
        }

        #endregion

        //Debug.Log(rb2D.velocity.magnitude);
    }

    void FlickDirection()
    {
        _flickValue_x = _endPos.x - _startPos.x;
        _flickValue_y = _endPos.y - _startPos.y;
        //Debug.Log("x フリック量は" + flickValue_x);
        //Debug.Log("y フリック量は" + flickValue_y);
    }

    void GetDirection()
    {
        FlickDirection();
        force = new Vector2(_flickValue_x, _flickValue_y);
        _rb2D.AddForce(force * (_move + _catch._speed));
    }

    public bool IsConditions(int value)
    {
        switch (value)
        {
            case 1:
                return _catch._apple <= 3;
            case 2:
                return _catch._orange <= 3;
            case 3:
                return _catch._pair <= 3;
            default:
                return true;
        }
    }
    public bool IsConditions2(int value)
    {
        switch (value)
        {
            case 1:
                return _catch._apple <= 7;
            case 2:
                return _catch._orange <= 7;
            case 3:
                return _catch._pair <= 7;
            default:
                return true;
        }
    }
    public bool IsConditions3(int value)
    {
        switch (value)
        {
            case 1:
                return _catch._apple <= 11;
            case 2:
                return _catch._orange <= 11;
            case 3:
                return _catch._pair <= 11;
            default:
                return true;
        }
    }
    public bool IsConditions4(int value)
    {
        switch (value)
        {
            case 1:
                return _catch._apple <= 15;
            case 2:
                return _catch._orange <= 15;
            case 3:
                return _catch._pair <= 15;
            default:
                return true;
        }
    }
}
