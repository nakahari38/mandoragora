using System.Collections;
using System.Collections.Generic;
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

    // ゲージが溜まってから技発動までの時間
    [SerializeField]
    float spaceTime;

    private Rigidbody2D rb2D;

    // 以下は仮置き
    int apple;
    int orange;
    int pair;

    [SerializeField]
    int str = 10;
    [SerializeField]
    int vit = 10;

    float skilGage = 0;

    [SerializeField]
    Transform player;

    private float rotationSpeed = 300.0f;


    private void Start()
    {
        if (rb2D == null) rb2D = GetComponent<Rigidbody2D>();
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
            str++;
            vit--;
            Debug.Log("リンゴ" + apple);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Orange"))
        {
            orange++;
            str--;
            vit++;
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
}
