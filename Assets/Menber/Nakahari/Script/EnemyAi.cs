using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    // Ai�̏��
    enum State{
        battle,
        eat,
        skil,
    };

    // �X�e�[�^�X
    float Move = 5; // �ړ�
    float blowAway = 5; // ������΂�
    float durability = 5; // �ϋv�x

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
