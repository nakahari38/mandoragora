using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Catch : MonoBehaviour
{
    private int score;

    private AttackForce _attackForce;

    [SerializeField]
    private float variable;

    public float speed;

    [SerializeField]
    public float aiSpeed;

    private void Start()
    {
        if (_attackForce == null) _attackForce = GetComponent<AttackForce>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            _attackForce.power += variable;
            if (_attackForce.endurance > 1)
            {
                _attackForce.endurance--;
            }
            score++;
            this.transform.localScale +=  new Vector3(0.5f, 0.5f, 0.5f);
            Debug.Log(score);
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Orange"))
        {
            if (_attackForce.power > 150)
            {
                _attackForce.power -= variable;
            }
            _attackForce.endurance++;
            score++;
            this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            Debug.Log(score);
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Pair"))
        {
            score++;
            speed++;
            aiSpeed += 100;
            this.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            Debug.Log(score);
            //Destroy(collision.gameObject);
        }
    }
}
