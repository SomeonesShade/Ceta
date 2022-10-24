using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Depreciated
//Related: SoulSystem
//Notifies When the Player Dies and Positions the Ghost To Be in Position with the Player
public class SoulSetter : MonoBehaviour
{
    public GameObject Ghost;
    
    private Transform Player;
    private Transform gTM;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Transform>();
        Ghost = GameObject.FindGameObjectWithTag("Ghost");
        gTM = Ghost.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        gTM.position = Player.position; //move ghost to player
    }
    void OnDestroy()
    {
        if(Ghost != null) //send the mesage that this is dead
        {
//            Ghost.GetComponent<SoulSystem>().isDestroyed = true;
        }
    }
}
