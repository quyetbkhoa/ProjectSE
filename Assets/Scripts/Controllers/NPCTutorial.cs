using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTutorial: MonoBehaviour
{
    public  GameObject[] Pickups;
    public  Direction[] List_Direction;
    [SerializeField] private Speech speech;
    private  int index = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interact();
        }
    }
    
    public void Interact()
    {
        if (index <Pickups.Length)
        {
            if (Pickups[index].CompareTag("Key") || Pickups[index].CompareTag("Star") || Pickups[index].CompareTag("Chest"))
            {
                speech.ShowTutorial(Pickups[index], List_Direction[index]);
            }
        }
    }

    void Update()
    {
        while (Pickups[index] == null)
        {
            if (index + 1 < Pickups.Length)
                index++;
            else break;

        }
    }
}
public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

