using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackForce : MonoBehaviour
{
    [Header("吹き飛ばし力")]
    [SerializeField]
    public float _power;
    [Header("耐久力")]
    [SerializeField]
    public float _endurance;
    [Header("必殺技の吹き飛ばし力")]
    [SerializeField]
    public float _blowAway;

    private ULT _ult;

    private int _touchCount;

    private bool _judge = false;

    private Animator _animator;

    public int _count = 0;

    private void Start()
    {
        if(_ult == null) _ult = GetComponent<ULT>();
        if(_animator == null) _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.GetComponent<Fruit>())
        {
            Rigidbody2D _otherRb2d = collision.gameObject.GetComponent<Rigidbody2D>();
            if (_otherRb2d == null) return;

            Vector2 _directions = (collision.transform.position - this.transform.position).normalized;

            _otherRb2d.AddForce(_directions * _power / _endurance, ForceMode2D.Impulse);

            //Debug.Log(_directions);
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.GetComponent<Fruit>())
        {
            Rigidbody2D _otherRb2d = collision.gameObject.GetComponent<Rigidbody2D>();
            if (_otherRb2d == null) return;

            Vector2 _directions = (collision.transform.position - this.transform.position).normalized;

            if (_judge && this.CompareTag("Player") && _ult.AvailableFlag())
            {
                _animator.SetTrigger("Ult");
                _otherRb2d.AddForce(_directions * _blowAway, ForceMode2D.Impulse);
                _ult.ResetUltScore();
                _animator.SetTrigger("Normal");
                _count++;
            }

            if(this.CompareTag("CPU1") && _ult.AvailableFlag())
            {
                _animator.SetTrigger("Ult");
                _otherRb2d.AddForce(_directions * _blowAway, ForceMode2D.Impulse);
                _ult.ResetUltScore();
                _animator.SetTrigger("Normal");
                _count++;
            }

            if (this.CompareTag("CPU2") && _ult.AvailableFlag())
            {
                _animator.SetTrigger("Ult");
                _otherRb2d.AddForce(_directions * _blowAway, ForceMode2D.Impulse);
                _ult.ResetUltScore();
                _animator.SetTrigger("Normal");
                _count++;
            }

            if (this.CompareTag("CPU3") && _ult.AvailableFlag())
            {
                _animator.SetTrigger("Ult");
                _otherRb2d.AddForce(_directions * _blowAway, ForceMode2D.Impulse);
                _ult.ResetUltScore();
                _animator.SetTrigger("Normal");
                _count++;
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _touchCount++;
            Invoke("Judge", 0.3f);
            Debug.Log("ダブルタップ");
        }
    }

    void Judge()
    {
        if (_touchCount != 2)
        {
            _touchCount = 0;
            _judge = false;
            return;
        }
        else
        {
            _touchCount = 0;
            _judge = true;
        }
    }
}
