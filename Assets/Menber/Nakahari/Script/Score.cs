using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    public static Score instance;

    public int _playerScore;
    public int _cpu1Score;
    public int _cpu2Score;
    public int _cpu3Score;

    int test = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            _playerScore = 0;
            _cpu1Score = 0;
            _cpu2Score = 0;
            _cpu3Score = 0;
        }
        Debug.Log(test);
    }
}
