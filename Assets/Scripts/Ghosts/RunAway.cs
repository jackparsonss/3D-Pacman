using UnityEngine;
using UnityEngine.AI;

namespace Ghosts
{
    public class RunAway : State
    {
        public RunAway(GameObject _npc, NavMeshAgent _agent, Transform _player)
            : base(_npc, _agent, _player)
        {
            name = STATE.RUNAWAY;
            agent.isStopped = false;
        }
        
        public override void Enter()
        {
            base.Enter();
            //anim.SetTrigger("isRunningAway");
        }
        
        public override void Update()
        {
            if (!CanSeePlayer())
            {
                nextState = new Wander(npc, agent, player);
                stage = EVENT.EXIT;
            }
            else
            {
                Flee();
            }
        }
        
        public override void Exit()
        {
            base.Exit();
            //anim.ResetTrigger("isRunningAway");
        }

        private void Flee()
        {
            Vector3 direction = agent.transform.position - player.transform.position;
            Vector3 newPos = (agent.transform.position + direction) * 2;

            agent.SetDestination(newPos);
        }
    }
}