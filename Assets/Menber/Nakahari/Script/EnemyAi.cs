using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    // Aiの状態
    enum State{
        attack,
        eat,
        skil,
    };

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

    // 以下は仮置き

    // float skilGage = 0;



    //private float rotationSpeed = 300.0f;

    FruitGeneration _fruitGeneration;


    private void Start()
    {
        if (_rb2D == null) _rb2D = GetComponent<Rigidbody2D>();

        if (_catch == null) _catch = GetComponent<Catch>();

        _fruitGeneration = GetComponent<FruitGeneration>();

        _firstPos = this.transform.position;
        _firstRot = this.transform.rotation;
    }

    //void ChangeState(State newState)
    //{
    //    currentState = newState;
    //    stateEnter = true;
    //}

/*    private void Update()
    {
        if(currentState == State.attack)
        {
            // 攻撃状態でのAIの処理

            if(currentState == State.eat)
            {
                // 食事状態でのAIの処理

                if(skilGage >= 100)
                {
                    StartCoroutine(Space());
                    // スキル使用時のAIの処理

                }
            }
        }


        switch(currentState)
        {
            case State.attack:
                    if (stateEnter)
                    {
                        stateEnter = false;
                        Debug.Log("攻撃");
                    }
                break;

            case State.eat:
                    if (stateEnter)
                    {
                        stateEnter = false;
                        Debug.Log("食べる");
                    }
                break;

            case State.skil:
                    if (stateEnter)
                    {
                        stateEnter = false;
                        Debug.Log("必殺技発動");
                    }
                break;

        }
    }*/

    IEnumerator Space()
    {
        yield return new WaitForSeconds(_spaceTime);
    }

    private void Update()
    {
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
            if (this.gameObject.CompareTag("CPU1"))
            {
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
                else if (_score._cpu1Score <= 48)
                {
                    /*do
                    {
                        random = Random.Range(1, 3);
                    } while (IsConditions2(random));*/
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
                else if (_score._cpu1Score <= 72)
                {
                    /*do
                    {
                        random = Random.Range(1, 3);
                    } while (IsConditions3(random));*/
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
                    /*do
                    {
                        random = Random.Range(1, 3);
                    } while (IsConditions4(random));*/
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
            else if (this.gameObject.CompareTag("CPU2"))
            {
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

    /*private void FruitGet()
    {
        Fruit _obj = null;
        float _closePosition = Mathf.Infinity;
        Vector2 _movePosition = Vector2.zero;

        foreach (Fruit obj in _fruitGeneration._fruitView)
        {
            Vector2 test = obj._thisPosition - this.transform.position;
            Vector2 karioki = test;

            if(karioki < test)
            {

            }


            float _fruitPosition = Vector2.Distance(this.transform.position, obj._thisPosition);
            
            if(_fruitPosition < _closePosition)
            {
                _closePosition = _fruitPosition;
                _movePosition = _fruitPosition;
                _obj = obj;
            }
        }

        rb2D.AddForce(_closePosition * Move);
    }*/

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
