using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

    public GameObject goal;
    NavMeshAgent agent;
    Animator anim;
    GameObject[] goallocations; // Mova a declaração para o nível da classe

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        goallocations = GameObject.FindGameObjectsWithTag("goal"); // Agora goallocations é acessível em toda a classe

        if (goallocations.Length > 0)
        {
            int i = Random.Range(0, goallocations.Length);
            agent.SetDestination(goallocations[i].transform.position);
            anim = this.GetComponent<Animator>();
            anim.SetTrigger("isWalking"); 
            anim.SetFloat("woffset", Random.Range(0, 1.0f));
        }
        else
        {
            
        }
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
