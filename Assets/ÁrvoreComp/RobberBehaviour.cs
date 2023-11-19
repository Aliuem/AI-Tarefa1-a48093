using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobberBehaviour : MonoBehaviour
{
    BehaviourTree tree;
    public GameObject diamond;
    public GameObject van;
    NavMeshAgent agent;

    public enum ActionState{ IDLE,WORKING };
    ActionState state = ActionState.IDLE;


    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        tree = new BehaviourTree();
        
        Node steal = new Node("Steal Something");
        LeafNode goToDiamond = new LeafNode("Go To Diamond", GoToDiamond);
        LeafNode goToVan = new LeafNode("Go To Van", GoToVan);
        
        steal.AddChild(goToDiamond);
        steal.AddChild(goToVan);
        
        tree.AddChild(steal);
        tree.PrintTree();
        
        tree.Process();
    
    }

    public Node.Status GoToDiamond()
    {
        return GoToLocation(diamond.transform.position);
    }

    public Node.Status GoToVan()
    {
      return GoToLocation(Van.transform.position);
    }

    Node. status GoToLocation(vector3 destination)
    {
        Float distanceToTarger = vector3 Destance(destination, this.transform.position);
        if(state == ActionState.IDLE)
        {
            agent.SetDestination(destination);
            state = ActionState. WORKING;
        }
        else if (vector3.Distance(agent.pathEndpositons, destination) >= 2 )
        {
            state = ActionState.IDLE;
            return Node.StateFAILURE;

        }
        else if (disntaceToTarger< 2 )
        {
            state = ActionState.IDLE; 
            return Node.Status.SUCCESS; 
        
        }
        return Node.Status. RUNNING; 
    }

    // Update is called once per frame
    void Update()
    {
        // Add your behavior tree execution logic here
    }
}
