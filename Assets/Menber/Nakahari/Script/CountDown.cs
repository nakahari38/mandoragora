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

    private void Awake()
    {
        Time.timeScale = 1f;
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
    }

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
        Time.timeScale = 1;
        _tmpG.text = "\nいただきます！";
        _timer.time_obj.SetActive(true);
        _count = _time;
        while (_count > 0)
        {
            yield return new WaitForSeconds(1f);
            _count--;
        }
        _tmpG.enabled = false;
    }

    IEnumerator EndCountDown()
    {
        _count = _time;
        Time.timeScale = 0.5f;
        _tmpG.text = "ごちそうさまでした！";
        _tmpG.enabled = true;
        while (_count > 1.5f)
        {
            yield return new WaitForSeconds(1f);
            _count--;
        }
        SceneChangr.scenechangrInstance._fade.SceneFade("ResultScene");
    }
}
