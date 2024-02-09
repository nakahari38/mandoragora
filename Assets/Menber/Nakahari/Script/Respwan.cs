using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Respwan : MonoBehaviour
{
    Player _player;
    EnemyAi _enemy;

    Rigidbody2D _playerRb2d;
    Rigidbody2D _cpu1Rb2d;
    Rigidbody2D _cpu2Rb2d;
    Rigidbody2D _cpu3Rb2d;

    [SerializeField]
    int _respawnTime;

    float _respawnCount;

    AttackForce _attackForce;

    public int random;

    [SerializeField]
    Score _score;

    Catch _catch;

    ULT _ult;

    [SerializeField]
    GameObject _effect1;
    [SerializeField]
    GameObject _effect2;
    [SerializeField]
    GameObject _effect3;
    [SerializeField]
    GameObject _effect4;

    [SerializeField]
    GameObject _playerObj;
    [SerializeField]
    GameObject _cpu1Obj;
    [SerializeField]
    GameObject _cpu2Obj;
    [SerializeField]
    GameObject _cpu3Obj;

    [SerializeField]
    GameObject _pos1;
    [SerializeField]
    GameObject _pos2;
    [SerializeField]
    GameObject _pos3;
    [SerializeField]
    GameObject _pos4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 触れたオブジェクトのComponentを取得しそれぞれの処理を行い、初期位置にスポーンさせる
        if (collision.gameObject.CompareTag("Player"))
        {
            _player = collision.GetComponent<Player>();
            _playerRb2d = collision.GetComponent<Rigidbody2D>();
            _attackForce = collision.GetComponent<AttackForce>();
            _catch = collision.GetComponent<Catch>();
            _ult = collision.GetComponent<ULT>();
            Judge(collision, _player._firstPos, _player._firstRot,_playerRb2d);
            Lost(collision,_score._playerScore);
        }

        if (collision.gameObject.CompareTag("CPU1"))
        {
            _enemy = collision.GetComponent<EnemyAi>();
            _cpu1Rb2d = collision.GetComponent<Rigidbody2D>();
            _attackForce = collision.GetComponent<AttackForce>();
            _catch = collision.GetComponent<Catch>();
            _ult = collision.GetComponent<ULT>();
            Judge(collision,_enemy._firstPos, _enemy._firstRot,_cpu1Rb2d);
            Lost(collision, _score._cpu1Score);
        }

        if (collision.gameObject.CompareTag("CPU2"))
        {
            _enemy = collision.GetComponent<EnemyAi>();
            _cpu2Rb2d = collision.GetComponent<Rigidbody2D>();
            _attackForce = collision.GetComponent<AttackForce>();
            _catch = collision.GetComponent<Catch>();
            _ult = collision.GetComponent<ULT>();
            Judge(collision, _enemy._firstPos, _enemy._firstRot, _cpu2Rb2d);
            Lost(collision, _score._cpu2Score);
        }

        if (collision.gameObject.CompareTag("CPU3"))
        {
            _enemy = collision.GetComponent<EnemyAi>();
            _cpu3Rb2d = collision.GetComponent<Rigidbody2D>();
            _attackForce = collision.GetComponent<AttackForce>();
            _catch = collision.GetComponent<Catch>();
            _ult = collision.GetComponent<ULT>();
            Judge(collision, _enemy._firstPos, _enemy._firstRot, _cpu3Rb2d);
            Lost(collision, _score._cpu3Score);
        }
    }

    void Judge(Collider2D collision, Vector3 pos, Quaternion rot, Rigidbody2D rb2d)
    {
        _attackForce._power -= 100;
        if (_ult.UltScore > 2)
        {
            _ult.AddUltScore(-2);
        }
        rb2d.velocity = Vector3.zero;
        rb2d.bodyType = RigidbodyType2D.Kinematic;
        collision.gameObject.SetActive(false);
        collision.transform.position = pos;
        collision.transform.rotation = rot;
        StartCoroutine(RespawnTime(collision,rb2d));
    }

    IEnumerator RespawnTime(Collider2D collision, Rigidbody2D rb2d)
    {
        // リスポーンにかかる時間
        if (collision.gameObject.CompareTag("Player"))
        {
            var Ins =  Instantiate(_effect1, new Vector2(_pos1.transform.position.x, _pos1.transform.position.y), Quaternion.identity);
            Ins.transform.localScale = _playerObj.transform.localScale;
        }
        else if (collision.gameObject.CompareTag("CPU1"))
        {
            var Ins = Instantiate(_effect2, new Vector2(_pos2.transform.position.x, _pos2.transform.position.y), Quaternion.identity);
            Ins.transform.localScale = _cpu1Obj.transform.localScale;
        }
        else if (collision.gameObject.CompareTag("CPU2"))
        {
            var Ins = Instantiate(_effect3, new Vector2(_pos3.transform.position.x, _pos3.transform.position.y), Quaternion.identity);
            Ins.transform.localScale = _cpu2Obj.transform.localScale;
        }
        else if(collision.gameObject.CompareTag("CPU3"))
        {
            var Ins = Instantiate(_effect4, new Vector2(_pos4.transform.position.x, _pos4.transform.position.y), Quaternion.identity);
            Ins.transform.localScale = _cpu3Obj.transform.localScale;
        }

        collision.gameObject.SetActive(true);
        _respawnCount = _respawnTime;
        while (_respawnCount > 0)
        {
            yield return new WaitForSeconds(1f);
            _respawnCount--;
        }
        rb2d.bodyType = RigidbodyType2D.Dynamic;
    }

    #region 場外に出た際に果物を消す処理
    // ランダムに1～3を取得しその数によって特定の果物を減らす
    // 合計値によって減る果物の量が変わる
    void Lost(Collider2D collision,int score)
    {
        
        random = Random.Range(1, 3);
        if (score <= 3) return;
        if (score <= 24)
        {
            collision.transform.localScale -= new Vector3(2f, 2f, 2f);
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
        else if (score <= 48)
        {
            collision.transform.localScale -= new Vector3(4f, 4f, 4f);
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
        else if (score <= 72)
        {
            collision.transform.localScale -= new Vector3(6f, 6f, 6f);
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
            collision.transform.localScale -= new Vector3(8f, 8f, 8f);
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
}
