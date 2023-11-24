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
    float _move = 5; // �ړ�

    //State currentState = State.eat;
    //bool stateEnter = true;

    private Catch _catch;

    // �Q�[�W�����܂��Ă���Z�����܂ł̎���
    [SerializeField]
    float _spaceTime;

    private Rigidbody2D _rb2D;

    [SerializeField]
    Transform _player;

    // �ȉ��͉��u��

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
        }


        switch(currentState)
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
