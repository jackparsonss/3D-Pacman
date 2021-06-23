using UnityEngine;
using UnityEngine.AI;

namespace Ghosts
{
    public class State
    {
        public enum STATE
        {
            IDLE,
            WANDER,
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
}



