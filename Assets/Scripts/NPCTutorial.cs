using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTutorial: NPC
{   
    //list of pair GameObject and bool
    // pickups and direction
    public  GameObject[] Pickups;
    public  Direction[] List_Direction;
    [SerializeField] private Speech speech;
    private  int index = 0;
    //show List<KeyValuePair<GameObject,int>> in Inspector
    public override void Interact(GameObject _player)
    {
        if (_player.CompareTag("Player"))
        {
            player = _player;
        }

        if (index <Pickups.Length)
        {
            //if pickup is key, star or chest speech.ShowTutorial(pickup, direction)
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

