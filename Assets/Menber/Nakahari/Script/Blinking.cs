using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    [SerializeField]
    private float _cycle = 1;
    [SerializeField]
    private float speed = 1f;
    public Color _color;
    public Image _image;
    private float _time;

    private bool _isPlaying;


    private void Start()
    {
        InvokeRepeating("Blinkings", 1, 5);
    }
    // Update is called once per frame
    void Update()
    {

    }

    void Blinkings()
    {
        _time += Time.deltaTime;
        var value = Mathf.Repeat((float)_time, _cycle);
        _color.b = value >= _cycle * 0.5f ? 1 : 0;
        /*        if (value < 0.5f)
                {
                    _color.a = Mathf.Lerp(0f, 1f, value * 2);
                }
                else
                {
                    _color.a = Mathf.Lerp(1f, 0f, (value - 0.5f) * 2);
                }*/
        //_color.a = 1;
        _image.color = _color;
    }
}
