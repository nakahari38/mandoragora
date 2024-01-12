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
    /// �K�E�Z���g�p�\�m�F�֐�
    /// </summary>
    /// <returns>true:�����\ false:�����s�\</returns>
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
     /// �E���g�Q�[�W�p�X�R�A���Z�֐�
     /// </summary>
     /// <param name="AddScore"></param>
    public void AddUltScore(int AddScore)
    {
        UltScore += AddScore;
    }
    /// <summary>
    /// �E���g�X�R�A���Z�b�g�p�֐�
    /// </summary>
    public void ResetUltScore()
    {
        UltScore = RESET_SCORE;
    }
}
