using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _tmpG;
    [SerializeField]
    TextMeshProUGUI _tmpGPlayerView;

    private float _count;
    [Header("カウントダウン")]
    [SerializeField]
    private int _time;

    [SerializeField]
    GameObject _button;
    
    private int _stopTime;
    [SerializeField]
    private int StopTime;
    bool fade;

    [SerializeField]
    Timer _timer;

    bool end = true;

    public bool _stop = true;

    private void Awake()
    {
        if(_tmpG == null) _tmpG = GetComponent<TextMeshProUGUI>();
        _timer.time_obj.SetActive(false);
        _tmpGPlayerView.enabled = false;
        _button.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(StartCountDown());
    }
    private void Update()
    {
        if (_timer.end == false) return;
        if(end == true)
        {
            StartCoroutine(EndCountDown());
        }
        Debug.Log(_stop);
    }

    // 最初のカウントダウン
    IEnumerator StartCountDown()
    {
        
        while (_stopTime > 0)
        {
            yield return new WaitForSeconds(1f);
            _stopTime--;
        }
        _stopTime = StopTime;
        _tmpGPlayerView.enabled = true;
        while (_stopTime > 0)
        {
            yield return new WaitForSeconds(1f);
            _stopTime--;
        }
        _tmpG.enabled = true;
        _count = _time;
        _tmpGPlayerView.enabled = false;
        while (_count > 0)
        {
            _tmpG.text = "さ～て\n" + ((int)_count).ToString("0");
            yield return new WaitForSeconds(1f);
            _count--;
        }
        _tmpG.text = "\nいただきます！";
        _stop = false;
        _timer.time_obj.SetActive(true);
        _count = _time;
        while (_count > 0)
        {
            yield return new WaitForSeconds(1f);
            _count--;
        }
        _tmpG.enabled = false;
    }
    // 最後のカウントダウン
    IEnumerator EndCountDown()
    {
        end = false;
        _count = _time;
        _tmpG.text = "ごちそうさまでした！";
        _tmpG.enabled = true;
        _stop = true;
        while (_count > 0)
        {
            yield return new WaitForSeconds(1f);
            _count--;
        }
        _button.SetActive(true);
    }
}
