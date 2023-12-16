using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Image uiImage; // UI��Image�R���|�[�l���g���A�^�b�`���Ă�������
    public Color yellowColor = Color.yellow;
    public Color whiteColor = Color.white;
    public float blinkInterval = 5f; // �_�ŊԊu�i�b�j
    public float blinkDuration = 0.5f; // �_�ł̌p�����ԁi�b�j

    private void Start()
    {
        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            // ���ɕύX����0.5�b�_��
            uiImage.color = whiteColor;
            yield return new WaitForSeconds(blinkDuration);

            // ���F�ɕύX����5�b�\��
            uiImage.color = yellowColor;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
