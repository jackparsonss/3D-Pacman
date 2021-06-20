using UnityEngine;
using UnityEngine.AI;

namespace Ghosts
{
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
}