using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    // ステータス
    [SerializeField]
    float _move = 5; // 移動

    //State currentState = State.eat;
    //bool stateEnter = true;

    private Catch _catch;

    // ゲージが溜まってから技発動までの時間
    [SerializeField]
    float _spaceTime;

    private Rigidbody2D _rb2D;

    private Vector3 _firstPos;
    private Quaternion _firstRot;

    [SerializeField]
    Score _score;

    [SerializeField]
    Transform _player;

    public bool _judge = false;

    public int random;

    AttackForce _attackForce;

    [SerializeField]
    CountDown _countDown;

    // 以下は仮置き

    // float skilGage = 0;



    //private float rotationSpeed = 300.0f;

    FruitGeneration _fruitGeneration;


    private void Start()
    {
        _score = Score.instance.GetComponent<Score>();
        if (_rb2D == null) _rb2D = GetComponent<Rigidbody2D>();

        if (_catch == null) _catch = GetComponent<Catch>();
        if(_attackForce == null) _attackForce = GetComponent<AttackForce>();
        _fruitGeneration = GetComponent<FruitGeneration>();

        _firstPos = this.transform.position;
        _firstRot = this.transform.rotation;
    }

    private void Update()
    {
        if (_countDown._stop) return;
        Vector2 tracking = _player.position - this.transform.position;
        if(_rb2D.velocity.magnitude <= _catch._aiSpeed)
        {
            _rb2D.AddForce(tracking * _move, ForceMode2D.Force);
        }

        #region 場外に出た時の処理
        if (this.transform.position.x >= 2300 || this.transform.position.x <= -2300)
        {
            _rb2D.velocity = Vector3.zero;
            this.transform.position = _firstPos;
            this.transform.rotation = _firstRot;
            random = Random.Range(1, 4);
            if (this.gameObject.CompareTag("CPU1"))
            {
                _attackForce._power -= 100;
                if (_score._cpu1Score <= 3) return;
                if (_score._cpu1Score <= 24)
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
                else if (_score._cpu1Score <= 48)
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
                else if (_score._cpu1Score <= 72)
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
            else if (this.gameObject.CompareTag("CPU2"))
            {
                _attackForce._power -= 100;
                if (_score._cpu2Score <= 3) return;
                if (_score._cpu2Score <= 24)
                {
                    do
                    {
                        random = Random.Range(1, 3);
                    } while (IsConditions(random));
                    switch (random)
                    {
                        case 1:
                            _catch._apple -= 4;
                            break;
                        case 2:
                            _catch._orange -= 4;
                            break;
                        case 3:
                            _catch._pair -= 4;
                            break;
                    }
                }
                else if (_score._cpu2Score <= 48)
                {
                    do
                    {
                        random = Random.Range(1, 3);
                    } while (IsConditions2(random));
                    switch (random)
                    {
                        case 1:
                            _catch._apple -= 8;
                            break;
                        case 2:
                            _catch._orange -= 8;
                            break;
                        case 3:
                            _catch._pair -= 8;
                            break;
                    }
                }
                else if (_score._cpu2Score <= 72)
                {
                    do
                    {
                        random = Random.Range(1, 3);
                    } while (IsConditions3(random));
                    switch (random)
                    {
                        case 1:
                            _catch._apple -= 12;
                            break;
                        case 2:
                            _catch._orange -= 12;
                            break;
                        case 3:
                            _catch._pair -= 12;
                            break;
                    }
                }
                else
                {
                    do
                    {
                        random = Random.Range(1, 3);
                    } while (IsConditions4(random));
                    switch (random)
                    {
                        case 1:
                            _catch._apple -= 16;
                            break;
                        case 2:
                            _catch._orange -= 16;
                            break;
                        case 3:
                            _catch._pair -= 16;
                            break;
                    }
                }
            }
            else if (this.gameObject.CompareTag("CPU3"))
            {
                _attackForce._power -= 100;
                if (_score._cpu3Score <= 3) return;
                if (_score._cpu3Score <= 24)
                {
                    do
                    {
                        random = Random.Range(1, 3);
                    } while (IsConditions(random));
                    switch (random)
                    {
                        case 1:
                            _catch._apple -= 4;
                            break;
                        case 2:
                            _catch._orange -= 4;
                            break;
                        case 3:
                            _catch._pair -= 4;
                            break;
                    }
                }
                else if (_score._cpu3Score <= 48)
                {
                    do
                    {
                        random = Random.Range(1, 3);
                    } while (IsConditions2(random));
                    switch (random)
                    {
                        case 1:
                            _catch._apple -= 8;
                            break;
                        case 2:
                            _catch._orange -= 8;
                            break;
                        case 3:
                            _catch._pair -= 8;
                            break;
                    }
                }
                else if (_score._cpu3Score <= 72)
                {
                    do
                    {
                        random = Random.Range(1, 3);
                    } while (IsConditions3(random));
                    switch (random)
                    {
                        case 1:
                            _catch._apple -= 12;
                            break;
                        case 2:
                            _catch._orange -= 12;
                            break;
                        case 3:
                            _catch._pair -= 12;
                            break;
                    }
                }
                else
                {
                    do
                    {
                        random = Random.Range(1, 3);
                    } while (IsConditions4(random));
                    switch (random)
                    {
                        case 1:
                            _catch._apple -= 16;
                            break;
                        case 2:
                            _catch._orange -= 16;
                            break;
                        case 3:
                            _catch._pair -= 16;
                            break;
                    }
                }
            }
            
        }

        #endregion
        //Debug.Log(rb2D.velocity.magnitude);
    }

    #region 条件判定
    bool IsConditions(int value)
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
    bool IsConditions2(int value)
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
    bool IsConditions3(int value)
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
    bool IsConditions4(int value)
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
    #endregion
}
