using UnityEngine;
using UnityEngine.AI;

namespace Ghosts
{
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
            //anim.SetTrigger("isRunning");
        }
    
        public override void Update()
        {
            agent.SetDestination(player.position);

            if (agent.hasPath && !CanSeePlayer())
            {
                nextState = new Wander(npc, agent, player);
                stage = EVENT.EXIT;
            }else if (GameManager.IsPowerUpActive)
            {
                nextState = new RunAway(npc, agent, player);
                stage = EVENT.EXIT;
            }
        }
    
        public override void Exit()
        {
            base.Exit();
            //anim.ResetTrigger("isRunning");
        }
    }
}