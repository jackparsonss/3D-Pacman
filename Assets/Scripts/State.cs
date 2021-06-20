using UnityEngine;
using UnityEngine.AI;

public class State
{
    public enum STATE
    {
        IDLE,
        PATROL,
        PURSUE,
        RUNAWAY,
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    }

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected NavMeshAgent agent;
    protected Transform player;
    protected State nextState;

    private float visDist = 5.0f;

    public State(GameObject _npc, NavMeshAgent _agent, Transform _player)
    {
        npc = _npc;
        agent = _agent;
        player = _player;
        stage = EVENT.ENTER;
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public State Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }

    public bool CanSeePlayer()
    {
        Vector3 direction = player.position - npc.transform.position;

        if (direction.magnitude < visDist)
            return true;
        return false;
    }
}

public class Idle : State
{
    public Idle(GameObject _npc, NavMeshAgent _agent, Transform _player) 
        : base(_npc, _agent, _player)
    {
        name = STATE.IDLE;
        agent.isStopped = true;
    }

    public override void Enter()
    {
        //anim.SetTrigger("isIdle");
        Debug.Log("ENTERED IDLE");
        base.Enter();
    }

    public override void Update()
    {
        if (CanSeePlayer())
        {
            nextState = new Pursue(npc, agent, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        //anim.ResetTrigger("isIdle");
        Debug.Log("EXITED IDLE");
        base.Exit();
    }
}

public class Pursue : State
{
    public Pursue(GameObject _npc, NavMeshAgent _agent, Transform _player)
        : base(_npc, _agent, _player)
    {
        name = STATE.PURSUE;
        agent.isStopped = false;
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("ENTERED PURSUE");
        //anim.SetTrigger("isRunning");
        
    }
    
    public override void Update()
    {
        agent.SetDestination(player.position);

        if (agent.hasPath && !CanSeePlayer())
        {
            nextState = new Idle(npc, agent, player);
            stage = EVENT.EXIT;
        }
    }
    
    public override void Exit()
    {
        base.Exit();
        Debug.Log("EXITED IDLE");
        //anim.ResetTrigger("isRunning");
    }
}
