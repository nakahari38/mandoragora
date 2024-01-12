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

    private int _touchCount;

    private bool _judge = false;

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

            if (_judge && this.CompareTag("Player"))
            {
                _otherRb2d.AddForce(_directions * _blowAway, ForceMode2D.Impulse);
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

        //Debug.Log(_judge);
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
