using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    private float _time;
    Animator _animator;
    int _count = 0;
    BoxCollider2D _bc2;
    bool _isTrigger = false;

    private void Start()
    {
        if(_animator == null) _animator = GetComponent<Animator>();
        if(_bc2 == null)  _bc2 = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // FruitComponent以外を持っている場合
        if (!collision.gameObject.GetComponent<Fruit>())
        {
            // CatchComponentを取得してそれぞれの合計値を計算しその値が15を超えていた場合bool値をtrueにする
            Catch _othercatch = collision.gameObject.GetComponent<Catch>();
            if (_othercatch._apple + _othercatch._pair + _othercatch._orange >= 15)
            {
                _isTrigger = true;
            }
        }
    }

    private void Update()
    {
        if(_isTrigger)
        {
            _isTrigger = false;
            _bc2.isTrigger = true;
            StartCoroutine(BreakTime());
        }
        
    }

    IEnumerator BreakTime()
    {
        _animator.SetTrigger("Break");
        _count = 5;
        while(_count > 0)
        {
            yield return new WaitForSeconds(1f);
            _count--;
        }
        _count = 1;
        _animator.SetTrigger("Return");
        while (_count > 0)
        {
            yield return new WaitForSeconds(1f);
            _count--;
        }
        _bc2.isTrigger = false;
    }
}
