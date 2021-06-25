using UnityEngine;
using UnityEngine.AI;

namespace Ghosts
{
    public class GhostAI : MonoBehaviour
    {
        private GameObject _pacman;
        private NavMeshAgent _ghost;
        private State _currentState;
        private void Start()
        {
            _pacman = GameObject.FindWithTag("Player");
            _ghost = GetComponent<NavMeshAgent>();
            _currentState = new Wander(gameObject, _ghost, _pacman.transform);
        }

        private void Update()
        {
            _currentState = _currentState.Process();
        }
    }
}
