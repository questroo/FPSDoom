﻿using Assets.Scripts.Enemy_Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ExecutionState
{
    NONE,
    ACTIVE,
    COMPLETED,
    TERMINATED,
};

public enum FSMStateType
{
    IDLE,
    PATROL,
    CHASE,
    EXPLODE,
    ALERT,
};

public abstract class AbstractFSMState : ScriptableObject
{
    protected NavMeshAgent _navMeshAgent;
    protected Enemy _enemy;
    protected FiniteStateMachine _fsm;
    protected GameObject player;

    public ExecutionState executionState { get; protected set; }
    public FSMStateType StateType { get; protected set; }
    public bool EnteredState { get; protected set; }

    public virtual void OnEnable()
    {
        executionState = ExecutionState.NONE;
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    //A: Enter states successfully
    public virtual bool EnterState()
    {
        bool successNavMesh = true;
        bool successEnemy = true;

        executionState = ExecutionState.ACTIVE;

        successNavMesh = (_navMeshAgent != null);
        successEnemy = (_enemy != null);

        return successEnemy & successNavMesh;
    }

    //A: Updates current state in the state machine
    public abstract void UpdateState();


    //A: Exits State successfully
    public virtual bool ExitState()
    {
        executionState = ExecutionState.COMPLETED;
        return true;
    }

    public virtual void SetNavMeshAgent(NavMeshAgent navMeshAgent)
    {
        if (navMeshAgent != null)
        {
            _navMeshAgent = navMeshAgent;
        }
    }

    public virtual void SetExecutingFSM(FiniteStateMachine fsm)
    {
        if (fsm != null)
        {
            _fsm = fsm;
        }
    }

    public virtual void SetExecutingEnemy(Enemy enemy)
    {
        if(enemy != null)
        {
            _enemy = enemy;
        }
    }
}
