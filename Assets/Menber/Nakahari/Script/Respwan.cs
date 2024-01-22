using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Respwan : MonoBehaviour
{
    Player _player;
    EnemyAi _enemy;

    Rigidbody2D _rb2d;

    [SerializeField]
    int _respawnTime;

    float _respawnCount;

    AttackForce _attackForce;

    public int random;

    [SerializeField]
    Score _score;

    Catch _catch;

    ULT _ult;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 触れたオブジェクトのComponentを取得しそれぞれの処理を行い、初期位置にスポーンさせる
        if (collision.gameObject.CompareTag("Player"))
        {
            _player = collision.GetComponent<Player>();
            _rb2d = collision.GetComponent<Rigidbody2D>();
            _attackForce = collision.GetComponent<AttackForce>();
            _catch = collision.GetComponent<Catch>();
            _ult = collision.GetComponent<ULT>();
            _ult.AddUltScore(-2);
            _attackForce._power -= 100;
            PlayerLost(collision);
            _rb2d.velocity = Vector3.zero;
            collision.gameObject.SetActive(false);
            collision.transform.position = _player._firstPos;
            collision.transform.rotation = _player._firstRot;
            StartCoroutine(RespawnTime(collision));
        }

        if (collision.gameObject.CompareTag("CPU1"))
        {
            _enemy = collision.GetComponent<EnemyAi>();
            _rb2d = collision.GetComponent<Rigidbody2D>();
            _attackForce = collision.GetComponent<AttackForce>();
            _catch = collision.GetComponent<Catch>();
            _ult = collision.GetComponent<ULT>();
            _ult.AddUltScore(-2);
            _attackForce._power -= 100;
            Cpu1Lost(collision);
            _rb2d.velocity = Vector3.zero;
            collision.gameObject.SetActive(false);
            collision.transform.position = _enemy._firstPos;
            collision.transform.rotation = _enemy._firstRot;
            StartCoroutine(RespawnTime(collision));
        }

        if (collision.gameObject.CompareTag("CPU2"))
        {
            _enemy = collision.GetComponent<EnemyAi>();
            _rb2d = collision.GetComponent<Rigidbody2D>();
            _attackForce = collision.GetComponent<AttackForce>();
            _catch = collision.GetComponent<Catch>();
            _ult = collision.GetComponent<ULT>();
            _ult.AddUltScore(-2);
            _attackForce._power -= 100;
            Cpu2Lost(collision);
            _rb2d.velocity = Vector3.zero;
            collision.gameObject.SetActive(false);
            collision.transform.position = _enemy._firstPos;
            collision.transform.rotation = _enemy._firstRot;
            StartCoroutine(RespawnTime(collision));
        }

        if (collision.gameObject.CompareTag("CPU3"))
        {
            _enemy = collision.GetComponent<EnemyAi>();
            _rb2d = collision.GetComponent<Rigidbody2D>();
            _attackForce = collision.GetComponent<AttackForce>();
            _catch = collision.GetComponent<Catch>();
            _ult = collision.GetComponent<ULT>();
            _ult.AddUltScore(-2);
            _attackForce._power -= 100;
            Cpu3Lost(collision);
            _rb2d.velocity = Vector3.zero;
            collision.gameObject.SetActive(false);
            collision.transform.position = _enemy._firstPos;
            collision.transform.rotation = _enemy._firstRot;
            StartCoroutine(RespawnTime(collision));
        }
    }

    IEnumerator RespawnTime(Collider2D collision)
    {
        _respawnCount = _respawnTime;
        while (_respawnCount > 0)
        {
            yield return new WaitForSeconds(1f);
            _respawnCount--;
        }
        collision.gameObject.SetActive(true);
    }

    #region 場外に出た際に果物を消す処理
    // ランダムに1～3を取得しその数によって特定の果物を減らす
    // 合計値によって減る果物の量が変わる
    void PlayerLost(Collider2D collision)
    {
        
        random = Random.Range(1, 3);
        if (_score._playerScore <= 3) return;
        if (_score._playerScore <= 24)
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
        else if (_score._playerScore <= 48)
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
        else if (_score._playerScore <= 72)
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

    void Cpu1Lost(Collider2D collision)
    {
        random = Random.Range(1, 4);
        if (_score._cpu1Score <= 3) return;
        if (_score._cpu1Score <= 24)
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
        else if (_score._cpu1Score <= 48)
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
        else if (_score._cpu1Score <= 72)
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
    void Cpu2Lost(Collider2D collision)
    {
        if (_score._cpu2Score <= 3) return;
        if (_score._cpu2Score <= 24)
        {
            collision.transform.localScale -= new Vector3(2f, 2f, 2f);
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
            collision.transform.localScale -= new Vector3(4f, 4f, 4f);
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
            collision.transform.localScale -= new Vector3(6f, 6f, 6f);
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
            collision.transform.localScale -= new Vector3(8f, 8f, 8f);
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
    void Cpu3Lost(Collider2D collision)
    {
        if (_score._cpu3Score <= 3) return;
        if (_score._cpu3Score <= 24)
        {
            collision.transform.localScale -= new Vector3(2f, 2f, 2f);
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
            collision.transform.localScale -= new Vector3(4f, 4f, 4f);
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
            collision.transform.localScale -= new Vector3(6f, 6f, 6f);
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
            collision.transform.localScale -= new Vector3(8f, 8f, 8f);
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

    #endregion
}
