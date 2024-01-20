using Cysharp.Threading.Tasks;
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
    [SerializeField]
    Transform _cpu1;
    [SerializeField]
    Transform _cpu2;
    [SerializeField]
    Transform _cpu3;

    public bool _judge = false;

    public int random;

    AttackForce _attackForce;

    [SerializeField]
    CountDown _countDown;

    [SerializeField]
    GameObject _effect;

    Vector2 _hitPos;

    [SerializeField]
    float _respawmTime;

    float _respawn;

    [SerializeField]
    int times;

    [SerializeField]
    int _count;

    Vector2 tracking;

    Vector3 _pos;

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
        StartCoroutine(State());
        tracking = _pos - this.transform.position;
        if(_rb2D.velocity.magnitude <= _catch._aiSpeed)
        {
            _rb2D.AddForce(tracking * _move, ForceMode2D.Force);
        }

        #region 場外に出た時の処理
        if (this.transform.position.x >= 2300 || this.transform.position.x <= -2300)
        {
            StartCoroutine(Respawn());
            _rb2D.velocity = Vector3.zero;
            if (_respawn > 0) return;
            this.transform.position = _firstPos;
            this.transform.rotation = _firstRot;
            random = Random.Range(1, 4);
            if (this.gameObject.CompareTag("CPU1"))
            {
                _attackForce._power -= 100;
                if (_score._cpu1Score <= 3) return;
                if (_score._cpu1Score <= 24)
                {
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

    IEnumerator State()
    {
        _count = times;
        int _random = Random.Range(1, 4);
        while (_count > 0)
        {
            yield return new WaitForSeconds(1f);
            _count--;
        }
        switch (_random)
        {
            case 1:
                _pos = _player.position;
            break;
            case 2:
                _pos = _cpu1.position;
            break;
            case 3:
                _pos = _cpu2.position;
            break;
            case 4:
                _pos = _cpu3.position;
            break;

        }
    }

    IEnumerator Respawn()
    {
        _respawn = _respawmTime;
        while(_respawn > 0)
        {
            yield return new WaitForSeconds(1f);
            _respawn--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("CPU1") || collision.gameObject.CompareTag("CPU2") || collision.gameObject.CompareTag("CPU3"))
        {
            foreach (ContactPoint2D hitPoint in collision.contacts)
            {
                _hitPos = hitPoint.point;
            }
            Instantiate(_effect, new Vector2(_hitPos.x, _hitPos.y), Quaternion.identity);
        }
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
