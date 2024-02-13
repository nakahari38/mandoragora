using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _tmpG;

    Animator _animator;

    private float _count = 3f;
    // Start is called before the first frame update
    void Start()
    {
        if( _animator == null ) _animator = GetComponent<Animator>();
        _tmpG.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("Ground"))
        {
            _tmpG.enabled = true;
            StartCoroutine(View());
            _animator.SetTrigger("Move");
        }*/
    }

    IEnumerator View()
    {
        while (_count > 0)
        {
            yield return new WaitForSeconds(1f);
            _count--;
        }
        _tmpG.enabled = false;
    }
}
