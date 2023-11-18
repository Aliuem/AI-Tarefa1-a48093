using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree: Node
{
    public string name;

    // Default constructor
    public BehaviourTree()
    {
        name = "Tree";
    }

    // Constructor with a parameter
    public BehaviourTree(string n)
    {
        name = n;
    }
    
    public void PrintTree()
    {
        
    }
}

