using UnityEngine;
using UnityEngine.AI;

namespace Ghosts
{
    public class Wander : State
    {
        private float _wanderRadius = 5;
        private float _wanderTimer = 1;
        private float _timer;
        
        public Wander(GameObject _npc, NavMeshAgent _agent, Transform _player)
            : base(_npc, _agent, _player)
        {
            name = STATE.WANDER;
            agent.isStopped = false;
        }
        
        public override void Enter()
        {
            base.Enter();
            Debug.Log("ENTERED WANDER");
            //anim.SetTrigger("isWandering");
        }

        public override void Update()
        {
            if (CanSeePlayer())
            {
                nextState = new Pursue(npc, agent, player);
                stage = EVENT.EXIT;
            }
            else
            {
                _timer += Time.deltaTime;

                if (_timer >= _wanderTimer)
                {
                    Vector3 newPos = RandomNavSphere(player.transform.position, _wanderRadius, -1);
                    agent.SetDestination(newPos);
                    _timer = 0;
                }
            }
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("EXITED WANDER");
            //anim.ResetTrigger("isWandering");
        }

        private static Vector3 RandomNavSphere (Vector3 origin, float distance, int layermask) {
            Vector3 randomDirection = Random.insideUnitSphere * distance;
           
            randomDirection += origin;
           
            NavMeshHit navHit;
           
            NavMesh.SamplePosition (randomDirection, out navHit, distance, layermask);
           
            return navHit.position;
        }
    }
}