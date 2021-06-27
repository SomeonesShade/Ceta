using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoulSystem : MonoBehaviour
{
    public bool isDestroyed;
    public GameObject playerPrefab;
    public GameObject Ghost;
    public GameObject ProgressBar;
    public GameObject UpgradeSet;
    
    private Transform tr;
    private ProgressBar PB;
    
    
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Restart(); //self explanitory lel
        }
        if (isDestroyed && Input.GetKeyDown(KeyCode.L))
        {
            OnRespawn(); //same
        }
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnRespawn()
    {
        GameObject Player = Instantiate( //create the player
            playerPrefab,
            tr.position,
            tr.rotation);
        UpgradeSet.GetComponent<UiUpgradeData>().Reset(Player); //reset the upgrade data
        Player.GetComponent<SoulSetter>().Ghost = Ghost; //set the player to this
        PB = ProgressBar.GetComponent<ProgressBar>();
        PB.Reset(); //set the progress bar
        Player.GetComponent<UpgradeSystem>().ProgressBar = ProgressBar; //aslo set the player to that
    }
}
