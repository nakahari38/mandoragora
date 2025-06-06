using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Timer : MonoBehaviour
{
    public int oldsecond;//分
    [SerializeField]
    public float second;//秒
    public GameObject time_obj = null;//タイマーのテキスト

    public bool end = false;

    [SerializeField]
    CountDown _countDown;


    void Start()
    { 
       
    }

    // Update is called once per frame
    void Update()
    {
        if (_countDown._stop) return;
        CountTime();     
    }
    void CountTime()
    {
        Text time_text = time_obj.GetComponent<Text>();
        time_text.text =  oldsecond +  ":" + ((int)second).ToString("00");
       

        if (second < 0)
        {
            oldsecond -= 1;
            second = 59;
        }

        second -= Time.deltaTime;

        if(0 >= second  && 0 >= oldsecond)
        {
            end = true;
            time_obj.SetActive(false);
        }
    }

}
