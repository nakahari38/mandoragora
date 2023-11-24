using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

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

    [SerializeField]
    Transform _player;

    // 以下は仮置き

    // float skilGage = 0;

    

    //private float rotationSpeed = 300.0f;

    FruitGeneration _fruitGeneration;


    private void Start()
    {
        if (_rb2D == null) _rb2D = GetComponent<Rigidbody2D>();

        if (_catch == null) _catch = GetComponent<Catch>();

        _fruitGeneration = GetComponent<FruitGeneration>();
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
}
