using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static UnityEditor.PlayerSettings;

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

    [SerializeField]
    GameObject _effect1;
    [SerializeField]
    GameObject _effect2;
    [SerializeField]
    GameObject _effect3;
    [SerializeField]
    GameObject _effect4;

    [SerializeField]
    GameObject _pos1;
    [SerializeField]
    GameObject _pos2;
    [SerializeField]
    GameObject _pos3;
    [SerializeField]
    GameObject _pos4;

    private float _countTime;

    private float _space;


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
            SoundManager.Instance.PlaySE(SESoundData.SE.attack);

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
        if (_judge && this.CompareTag("Player") && _ult.AvailableFlag())
        {
            EffectView(_effect1, _pos1);
        }

        if (this.gameObject.CompareTag("CPU1") && _ult.AvailableFlag())
        {
            EffectView(_effect2, _pos2);
        }
        if (this.gameObject.CompareTag("CPU2") && _ult.AvailableFlag())
        {
            EffectView(_effect3, _pos3);
        }
        if (this.gameObject.CompareTag("CPU3") && _ult.AvailableFlag())
        {
            EffectView(_effect4, _pos4);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _touchCount++;
            Invoke("Judge", 0.3f);
        }

        Debug.Log(this.gameObject.tag + ":" + _ultUse);
    }
    
    IEnumerator Timer()
    {
        _countTime = 3;
        while (_countTime > 0)
        {
            yield return new WaitForSeconds(1f);
            _countTime--;
        }
        _ultUse = false;
    }

    void EffectView(GameObject obj, GameObject pos)
    {
        _animator.SetTrigger("Ult");
        StartCoroutine(EffectTimes(obj, pos));
        _ultUse = true;
        _ult.ResetUltScore();
        _animator.SetTrigger("Normal");
        _count++;
        StartCoroutine(Timer());
    }

    IEnumerator EffectTimes(GameObject obj, GameObject pos)
    {
        _space = 1;
        while (_space > 0)
        {
            yield return new WaitForSeconds(0.5f);
            _countTime = 3;
            while (_countTime > 0)
            {
                Instantiate(obj, new Vector2(pos.transform.position.x, pos.transform.position.y), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                _countTime--;
            }
            _space--;

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
