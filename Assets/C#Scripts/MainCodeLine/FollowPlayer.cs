using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerTr;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        tr = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(NullCheck())
        {
            return;
        }
        tr.position = playerTr.position; //move ghost to player
    }

    bool NullCheck()
    {
        if(playerTr == null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");
            if(temp != null)
            {
                playerTr = temp.transform;
            }
            return true;
        }
        return false;
    }
}
