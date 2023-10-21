using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    // Aiの状態
    enum State{
        battle,
        eat,
        skil,
    };

    // ステータス
    float Move = 5; // 移動
    float blowAway = 5; // 吹き飛ばし
    float durability = 5; // 耐久度

    State currentState = State.eat;
    bool stateEnter = true;

    void ChangeState(State newState)
    {
        currentState = newState;
        stateEnter = true;
    }

    private void Update()
    {
        if(currentState == State.battle)

        switch(currentState)
        {

        }
    }
}
