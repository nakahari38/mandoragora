using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    BoxCollider2D bc2d;
    [SerializeField]
    private float _cycle = 1;
    [SerializeField]
    private float _speed = 1f;
    public Color _color;
    public SpriteRenderer _spriteRenderer;
    private float _time;

    private void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _color.r = 1;
        _color.g = 0;
        _color.b = 0;
        _color.a = 0f;
        _spriteRenderer.color = _color;
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
                bc2d.isTrigger = true;
            }
        }
    }

    private void Update()
    {
        if(bc2d.isTrigger)
        {
            StartCoroutine(BreakTime(5f));
        }
        
    }

    IEnumerator BreakTime(float time)
    {
        // 壁を一定間隔で点滅させる
        _time += Time.deltaTime;
        var value = Mathf.Repeat(_time * _speed, _cycle);
        if (value < 0.5f)
        {
            _color.a = Mathf.Lerp(0f, 0.5f, value * 2);
        }
        else
        {
            _color.a = Mathf.Lerp(0.5f, 0f, (value - 0.5f) * 2);
        }
        //_color.a = 1;
        _spriteRenderer.color = _color;
        yield return new WaitForSeconds(time);
        _color.a = 0f;
        _spriteRenderer.color = _color;
        bc2d.isTrigger = false;
    }
}
