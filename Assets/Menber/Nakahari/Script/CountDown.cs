using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _tmpG;

    private float _count;
    [Header("カウントダウン")]
    [SerializeField]
    private int _time;

    bool fade;

    [SerializeField]
    Timer _timer;

    bool end;

    public bool _stop = true;

    private void Awake()
    {
        if(_tmpG == null) _tmpG = GetComponent<TextMeshProUGUI>();
        _timer.time_obj.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(StartCountDown());
    }
    private void Update()
    {
        if (_timer.end == false) return;
        StartCoroutine(EndCountDown());
        Debug.Log(_stop);
    }

    // 最初のカウントダウン
    IEnumerator StartCountDown()
    {
        _tmpG.enabled = true;
        _count = _time;
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
        _count = _time;
        _tmpG.text = "ごちそうさまでした！";
        _tmpG.enabled = true;
        _stop = true;
        while (_count > 0)
        {
            yield return new WaitForSeconds(1f);
            _count--;
        }
        SceneChangr.scenechangrInstance._fade.SceneFade("ResultScene");
    }
}
