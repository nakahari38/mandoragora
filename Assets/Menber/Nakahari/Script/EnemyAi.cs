using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    // Ai�̏��
    enum State{
        attack,
        eat,
        skil,
    };

    // �X�e�[�^�X
    [SerializeField]
    float Move = 5; // �ړ�
    [SerializeField]
    float blowAway = 5; // ������΂�
    [SerializeField]
    float durability = 5; // �ϋv�x

    State currentState = State.eat;
    bool stateEnter = true;

    AttackForce _affectForce;

    // �Q�[�W�����܂��Ă���Z�����܂ł̎���
    [SerializeField]
    float spaceTime;

    private Rigidbody2D rb2D;

    [SerializeField]
    Transform player;

    // �ȉ��͉��u��
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
            // �U����Ԃł�AI�̏���

            if(currentState == State.eat)
            {
                // �H����Ԃł�AI�̏���

                if(skilGage >= 100)
                {
                    StartCoroutine(Space());
                    // �X�L���g�p����AI�̏���

                }
            }
        }*/


        /*switch(currentState)
        {
            case State.attack:
                    if (stateEnter)
                    {
                        stateEnter = false;
                        Debug.Log("�U��");
                    }
                break;

            case State.eat:
                    if (stateEnter)
                    {
                        stateEnter = false;
                        Debug.Log("�H�ׂ�");
                    }
                break;

            case State.skil:
                    if (stateEnter)
                    {
                        stateEnter = false;
                        Debug.Log("�K�E�Z����");
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
            Debug.Log("�����S" + apple);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Orange"))
        {
            orange++;
            _affectForce._power -= 150;
            Debug.Log("�I�����W" + orange);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Pair"))
        {
            pair++;
            Debug.Log("�i�V" + pair);
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
