using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    public int _apple;
    public int _orange;
    public int _pair;

    private AttackForce _attackForce;

    [SerializeField]
    private float _variable;

    public float _speed;

    [SerializeField]
    public float _aiSpeed;

    [SerializeField]
    private Score _score;

    private void Start()
    {
        if (_attackForce == null) _attackForce = GetComponent<AttackForce>();
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
        Debug.Log(_score._playerScore);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            _attackForce._power += _variable;
            if (_attackForce._endurance > 1)
            {
                _attackForce._endurance--;
            }
            _apple++;
            this.transform.localScale +=  new Vector3(0.5f, 0.5f, 0.5f);
            //Debug.Log(_score);
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Orange"))
        {
            if (_attackForce._power > 150)
            {
                _attackForce._power -= _variable;
            }
            _attackForce._endurance++;
            _orange++;
            this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            //Debug.Log(_score);
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Pair"))
        {
            _pair++;
            _speed++;
            _aiSpeed += 100;
            this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            //Debug.Log(_score);
            //Destroy(collision.gameObject);
        }
    }
}
