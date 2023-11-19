using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobberBehaviour : MonoBehaviour
{
    BehaviourTree tree;
    public GameObject diamond;
    public GameObject van;
    public GameObject backdoor;
    NavMeshAgent agent;

    public enum ActionState { IDLE, WORKING };
    ActionState state = ActionState.IDLE;
    Node.Status treeStatus = Node.Status.RUNNING;


    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        tree = new BehaviourTree();

        Sequence steal = new Sequence("Steal Something");
        LeafNode goToDiamond = new LeafNode("Go To Diamond", GoToDiamond);
        LeafNode goToBackdoor = new LeafNode("Go To Backdoor", GoToBackdoor);
        LeafNode goToVan = new LeafNode("Go To Van", GoToVan);

        steal.AddChild(goToBackdoor);
        steal.AddChild(goToDiamond);
        steal.AddChild(goToBackdoor);
        steal.AddChild(goToVan);

        tree.AddChild(steal);
        tree.PrintTree();

        tree.Process();

    }

    public Node.Status GoToDiamond()
    {
        return GoToLocation(diamond.transform.position);
    }
     public Node.Status GoToBackdoor()
    {
        return GoToLocation (backdoor.transform.position);
    }


    public Node.Status GoToVan()
    {
        return GoToLocation(van.transform.position);
    }

    Node.Status GoToLocation(Vector3 destination)
    {
        float distanceToTarget = Vector3.Distance(destination, this.transform.position);
        if (state == ActionState.IDLE)
        {
            agent.SetDestination(destination);
            state = ActionState.WORKING;
        }
        else if (Vector3.Distance(agent.pathEndPosition, destination) >= 2)
        {
            state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }
        else if (distanceToTarget < 2)
        {
            state = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }

    // Update is called once per frame
    void Update()
    {
        if (treeStatus == Node.Status.RUNNING)
         treeStatus = tree.Process();
        
    }
}
