using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
   private void Awake()
   {
    GameObject.FindGameObjectWithTag("Player").transform.position = transform.position; // this is called to spawn the player in the spawn point
   }
}
