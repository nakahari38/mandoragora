using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Character : MonoBehaviour
{
    [SerializeField]
    Image _first;
    [SerializeField]
    Image _second;
    [SerializeField]
    Image _third;
    [SerializeField]
    Image _fourth;

    Score _score;

    public Sprite _playerSprite;
    public Sprite _cpu1Sprite;
    public Sprite _cpu2Sprite;
    public Sprite _cpu3Sprite;


    public void Awake()
    {
        _score = Score.instance.GetComponent<Score>();
    }
    // それぞれのスコアに応じて一番スコアが高いキャラクターをリザルトに表示する
    private void Start()
    {
        RankView();
    }

    public void RankView()
    {
        var data = new int[] { _score._playerScore, _score._cpu1Score, _score._cpu2Score, _score._cpu3Score };
        var rankedData = data.Select((value, index) => new { Value = value, Index = index })
                             .OrderByDescending(item => item.Value)
                             .Select((item, index) => new { Value = item.Value, Rank = index + 1 })
                             .ToList();
        foreach (var item in rankedData)
        {
            Debug.Log($"順位:{item.Rank},データ:{item.Value}");
        }

        var playerRank = rankedData.FindIndex(item => item.Value == _score._playerScore) + 1;
        var cpu1Rank = rankedData.FindIndex(item => item.Value == _score._cpu1Score) + 1;
        var cpu2Rank = rankedData.FindIndex(item => item.Value == _score._cpu2Score) + 1;
        var cpu3Rank = rankedData.FindIndex(item => item.Value == _score._cpu3Score) + 1;

        View(playerRank, _playerSprite);
        View(cpu1Rank, _cpu1Sprite);
        View (cpu2Rank, _cpu2Sprite);
        View(cpu3Rank, _cpu3Sprite);
    }

    public void View(int rank,Sprite sp)
    {
        switch (rank)
        {
            case 1:
                _first.sprite = sp;
                break;
            case 2:
                _second.sprite = sp;
                break;
            case 3:
                _third.sprite = sp;
                break;
            case 4:
                _fourth.sprite = sp;
                break;
        }
    }

}
