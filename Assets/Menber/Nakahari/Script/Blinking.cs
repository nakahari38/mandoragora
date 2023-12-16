using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    [SerializeField]
    private float _cycle = 1;
    public Color _color;
    public Image _image;
    private float _time;

    public float _changeTime;

    public float _normalTime;

    public int num;

    int test = 0;

    private void Start()
    {
        StartCoroutine(Change());
    }
    // Update is called once per frame
    void Update()
    {
        /*_time += Time.deltaTime;
        var value = Mathf.Repeat((float)_time, _cycle);
        _color.b = value >= _cycle * 0.5f ? 1 : 0;*/
    }

    IEnumerator Change()
    {
        while (true)
        {
            for (int i = 0; i < num; i++)
            {
                _image.color = Color.white;
                yield return new WaitForSeconds(_changeTime);
                _image.color = Color.yellow;
                yield return new WaitForSeconds(_changeTime);
            }
            _image.color = Color.yellow;
            yield return new WaitForSeconds(_normalTime);
        }
        
    }
}
