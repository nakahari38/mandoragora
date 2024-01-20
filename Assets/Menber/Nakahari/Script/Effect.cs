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
        _stateLength = _infAnim.length;
        _animator.SetBool("Effect", true);
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if(_time> _stateLength)
        {
            Destroy(this.gameObject);
        }
    }
            
}
