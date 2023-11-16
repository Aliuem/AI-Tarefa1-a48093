using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

    public GameObject goal;
    NavMeshAgent agent;
    Animator anim;
    GameObject[] goallocations;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        goallocations = GameObject.FindGameObjectsWithTag("goal");

        if (goallocations == null || goallocations.Length == 0)
        {
            Debug.LogError("Nenhum objeto com a tag 'goal' encontrado ou array vazio.");
            return; // Evitar que o código abaixo seja executado se não houver objetos 'goal'
        }

        int i = Random.Range(0, goallocations.Length);
        agent.SetDestination(goallocations[i].transform.position);

        anim = this.GetComponent<Animator>();
        anim.SetTrigger("isWalking");
        anim.SetFloat("woffset", Random.Range(0, 1.0f));
    }

    void Update()
    {
        if (agent.remainingDistance < 1)
        {
            int i = Random.Range(0, goallocations.Length);
            agent.SetDestination(goallocations[i].transform.position);
        }
    }
}
