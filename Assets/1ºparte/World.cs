using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A singleton to hold an array of all the hiding spots in the game environment
public sealed class MyWorld
{
    private static readonly MyWorld instance = new MyWorld();
    private static GameObject[] hidingSpots;

    //construct the singleton
    static MyWorld()
    {
        //populate hiding spot array with objects in the environment
        //that match the tag
        hidingSpots = GameObject.FindGameObjectsWithTag("hide");
    }

    private MyWorld() { }

    public static MyWorld Instance
    {
        get { return instance; }
    }

    public GameObject[] GetHidingSpots()
    {
        return hidingSpots;
    }
}
