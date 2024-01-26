using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    public int _apple;
    public int _orange;
    public int _pair;

    private AttackForce _attackForce;
    [Header("Powerの増減値")]
    [SerializeField]
    private float _variable;
    [Header("Playerのスピード")]
    public float _speed;
    [Header("AIのスピード")]
    [SerializeField]
    public float _aiSpeed;

    [SerializeField]
    private Score _score;

    private ULT _ult;

    private void Start()
    {
        _score = Score.instance.GetComponent<Score>();
        if (_attackForce == null) _attackForce = GetComponent<AttackForce>();
        if (_ult == null) _ult = GetComponent<ULT>();
    }

    private void Update()
    {
        if (this.gameObject.tag == "Player")
        {
            _score._playerScore = _apple + _orange + _pair;
        }
        else if (this.gameObject.tag == "CPU1")
        {
            _score._cpu1Score = _apple + _orange + _pair;
        }
        else if (this.gameObject.tag == "CPU2")
        {
            _score._cpu2Score = _apple + _orange + _pair;
        }
        else if (this.gameObject.tag == "CPU3")
        {
            _score._cpu3Score = _apple + _orange + _pair;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // それぞれの果物を取った際に特定のステータスに増加させる処理
        // 果物を取った際自身のScaleに0.5fずつ追加する
        if (collision.gameObject.CompareTag("Apple"))
        {
            if (_ult.UltScore < 20)
            {
                _ult.AddUltScore(1);
            }
            _attackForce._power += _variable;
            _apple++;
            this.transform.localScale +=  new Vector3(0.5f, 0.5f, 0.5f);
            //Debug.Log(_score);
            //Destroy(collision.gameObject);

            SoundManager.Instance.PlaySE(SESoundData.SE.pear);
        }

        if (collision.gameObject.CompareTag("Orange"))
        {
            if (_ult.UltScore < 20)
            {
                _ult.AddUltScore(1);
            }
            if (_speed > 1)
            {
                _speed--;
            }
            if(_aiSpeed > 100)
            {
                _aiSpeed -= 100;
            }
            _attackForce._endurance++;
            _orange++;
            this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            //Debug.Log(_score);
            //Destroy(collision.gameObject);

            SoundManager.Instance.PlaySE(SESoundData.SE.pear);
        }

        if (collision.gameObject.CompareTag("Pair"))
        {
            if (_ult.UltScore < 20)
            {
                _ult.AddUltScore(1);
            }
            if (_attackForce._endurance > 1)
            {
                _attackForce._endurance--;
            }
            _pair++;
            _speed++;
            _aiSpeed += 100;
            this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            //Debug.Log(_score);
            //Destroy(collision.gameObject);

            SoundManager.Instance.PlaySE(SESoundData.SE.pear);
        }
    }
}
