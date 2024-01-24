using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    Animator _animator;

    AnimatorStateInfo _infAnim;

    float _stateLength = 0;
    float _time = 0;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _infAnim = _animator.GetCurrentAnimatorStateInfo(0);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        // アニメーションの時間を取得。
        _stateLength = _infAnim.length;
    }

    // Update is called once per frame
    void Update()
    {
        // アニメーションが終ったら消す処理
        _time += Time.deltaTime;
        if(_time> _stateLength)
        {
            Destroy(this.gameObject);
        }
    }
            
}
