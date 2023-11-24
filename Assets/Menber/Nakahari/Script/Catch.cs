using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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

    Score _score;

    private void Start()
    {
        if (_attackForce == null) _attackForce = GetComponent<AttackForce>();
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
            _score._score++;
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
            _score._score++;
            this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            //Debug.Log(_score);
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Pair"))
        {
            _score._score++;
            _pair++;
            _speed++;
            _aiSpeed += 100;
            this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            //Debug.Log(_score);
            //Destroy(collision.gameObject);
        }
    }
}
