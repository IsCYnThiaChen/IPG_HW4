using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GameAI { 
    public class EnemyAI : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Animator animator;
        private Transform player;

        private enum EnemyState { Idle, Chasing }
        private EnemyState currentState = EnemyState.Idle;
        
        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player").transform;

            Invoke("StartChasing", 2f); // Start chasing after 2 seconds
        }
        void StartChasing()
        {
            currentState = EnemyState.Chasing;
            animator.SetTrigger("Chase"); // Trigger animation change
        }

        // Update is called once per frame
        void Update()
        {
            if (currentState == EnemyState.Chasing)
            {
                agent.SetDestination(player.position);
            }
        }
    }
}
