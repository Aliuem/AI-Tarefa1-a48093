using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

    public GameObject goal;
    NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();

        if (goal != null) {
            agent.SetDestination(goal.transform.position);
        } else {
            Debug.LogError("O campo 'goal' não foi atribuído no Inspector para o objeto " + gameObject.name);
        }
    }

    void Update() {
        // Lógica de atualização aqui
    }
}
