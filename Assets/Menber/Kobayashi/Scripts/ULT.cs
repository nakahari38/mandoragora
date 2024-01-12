using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ULT : MonoBehaviour
{
    public  int UltScore = 0;
    private int RESET_SCORE = 0;
    private int ULT_USE_SCORE = 20;

    private bool isUltFlg = false;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddUltScore(Random.Range(0, 3));
        }
    }
    /// <summary>
    /// 必殺技が使用可能確認関数
    /// </summary>
    /// <returns>true:発動可能 false:発動不可能</returns>
    public bool AvailableFlag()
    {
        if(UltScore >= ULT_USE_SCORE)
        {
            isUltFlg = true;
        }
        else
        {
            isUltFlg = false;
        }

        return isUltFlg;
    }
     /// <summary>
     /// ウルトゲージ用スコア加算関数
     /// </summary>
     /// <param name="AddScore"></param>
    public void AddUltScore(int AddScore)
    {
        UltScore += AddScore;
    }
    /// <summary>
    /// ウルトスコアリセット用関数
    /// </summary>
    public void ResetUltScore()
    {
        UltScore = RESET_SCORE;
    }
}
