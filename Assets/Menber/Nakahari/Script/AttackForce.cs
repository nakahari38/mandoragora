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

    private bool _ultUse = false;

    private Animator _animator;

    public int _count = 0;

    private void Start()
    {
        if(_ult == null) _ult = GetComponent<ULT>();
        if(_animator == null) _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 特定のTagとComponentを持ってるオブジェクト以外に当たったら、相手のRigidbody2Dを取得し自身の位置と相手の位置を取って自分と反対方向に飛ばす
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.GetComponent<Fruit>() && !collision.gameObject.CompareTag("Wall"))
        {
            Rigidbody2D _otherRb2d = collision.gameObject.GetComponent<Rigidbody2D>();
            if (_otherRb2d == null) return;

            Vector2 _directions = (collision.transform.position - this.transform.position).normalized;

            _otherRb2d.AddForce(_directions * _power / _endurance, ForceMode2D.Impulse);

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.GetComponent<Fruit>() && !collision.gameObject.CompareTag("Wall"))
        {
            Rigidbody2D _otherRb2d = collision.gameObject.GetComponent<Rigidbody2D>();
            if (_otherRb2d == null) return;

            Vector2 _directions = (collision.transform.position - this.transform.position).normalized;

            // ゲージが溜まっている場合プレイヤーはダブルタップかつ相手に触れていると相手を吹き飛ばす。
            // CPUの場合自身がPlayerのTagをもってないかつゲージが溜まっていて相手に触れていると相手を吹き飛ばす

            if (_ultUse)
            {
                _otherRb2d.AddForce(_directions * _blowAway, ForceMode2D.Impulse);
            }
        }
    }

    private void Update()
    {
        if(_judge && this.CompareTag("Player") && _ult.AvailableFlag())
        {
            _animator.SetTrigger("Ult");
            _ultUse = true;
            _ult.ResetUltScore();
            _animator.SetTrigger("Normal");
            _count++;
        }

        if (!this.CompareTag("Player") && _ult.AvailableFlag())
        {
            _animator.SetTrigger("Ult");
            _ult.ResetUltScore();
            _animator.SetTrigger("Normal");
            _count++;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _touchCount++;
            Invoke("Judge", 0.3f);
            
        }
    }

    // ダブルタップしたかどうかの判定
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
