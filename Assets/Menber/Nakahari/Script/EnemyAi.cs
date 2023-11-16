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
    float Move = 5; // 移動
    [SerializeField]
    float blowAway = 5; // 吹き飛ばし
    [SerializeField]
    float durability = 5; // 耐久度

    State currentState = State.eat;
    bool stateEnter = true;

    AttackForce _affectForce;

    // ゲージが溜まってから技発動までの時間
    [SerializeField]
    float spaceTime;

    private Rigidbody2D rb2D;

    [SerializeField]
    Transform player;

    // 以下は仮置き
    int apple;
    int orange;
    int pair;

    float skilGage = 0;

    

    private float rotationSpeed = 300.0f;

    FruitGeneration _fruitGeneration;


    private void Start()
    {
        if (rb2D == null) rb2D = GetComponent<Rigidbody2D>();

        _fruitGeneration = GetComponent<FruitGeneration>();

        if(_affectForce == null) _affectForce = GetComponent<AttackForce>();
    }

    void ChangeState(State newState)
    {
        currentState = newState;
        stateEnter = true;
    }

    private void Update()
    {
        /*if(currentState == State.attack)
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
        }*/


        /*switch(currentState)
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

        }*/
    }

    IEnumerator Space()
    {
        yield return new WaitForSeconds(spaceTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            apple++;
            _affectForce._power += 150;
            Debug.Log("リンゴ" + apple);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Orange"))
        {
            orange++;
            _affectForce._power -= 150;
            Debug.Log("オレンジ" + orange);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Pair"))
        {
            pair++;
            Debug.Log("ナシ" + pair);
            Destroy(collision.gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector2 tracking = player.position - this.transform.position;
        rb2D.AddForce(tracking * Move);       
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
