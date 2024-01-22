using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackForce : MonoBehaviour
{
    [Header("������΂���")]
    [SerializeField]
    public float _power;
    [Header("�ϋv��")]
    [SerializeField]
    public float _endurance;
    [Header("�K�E�Z�̐�����΂���")]
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
        // �����Tag��Component�������Ă�I�u�W�F�N�g�ȊO�ɓ���������A�����Rigidbody2D���擾�����g�̈ʒu�Ƒ���̈ʒu������Ď����Ɣ��Ε����ɔ�΂�
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

            // �Q�[�W�����܂��Ă���ꍇ�v���C���[�̓_�u���^�b�v������ɐG��Ă���Ƒ���𐁂���΂��B
            // CPU�̏ꍇ���g��Player��Tag�������ĂȂ����Q�[�W�����܂��Ă��đ���ɐG��Ă���Ƒ���𐁂���΂�

            if (_judge && this.CompareTag("Player") && _ult.AvailableFlag())
            {
                _animator.SetTrigger("Ult");
                _otherRb2d.AddForce(_directions * _blowAway, ForceMode2D.Impulse);
                _ult.ResetUltScore();
                _animator.SetTrigger("Normal");
                _count++;
            }

            if(!this.CompareTag("Player") && _ult.AvailableFlag())
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
            Debug.Log("�_�u���^�b�v");
        }
    }

    // �_�u���^�b�v�������ǂ����̔���
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
