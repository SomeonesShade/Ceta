using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Related: SoulSetter, UpgradeSystem, and UI<ProgressBar, and UiUpgradeData>
//Main Function is To Handle Death, Respawn and Restarting
//As an Intermediate To Transfer Object Data (No Null), and To reset ALL values
public class SoulSystem : MonoBehaviour
{
    public bool isDestroyed;
    public GameObject playerPrefab;
//    public GameObject Ghost;
    public GameObject child;
    public GameObject ProgressBar;
    public GameObject UpgradeSet;
    
    private Transform tr;
    
    private ProgressBar PB;
    
    void Awake()
    {
        tr = this.gameObject.transform;
        SetChild(tr.GetChild(0).gameObject);
        child.transform.SetParent(null);
    }
    // Start is called before the first frame update
    void Start()
    {
        ProgressBar = GameObject.FindGameObjectWithTag("ProgressBar");
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
        else
        {
            isDestroyed = child == null;
        }
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnRespawn()
    {
        isDestroyed = false;
        GameObject Player = Instantiate( //create the player
            playerPrefab,
            tr.position,
            tr.rotation);
        UpgradeSet.GetComponent<UiUpgradeData>().Reset(Player); //reset the upgrade data
        SetChild(Player);
//        Player.GetComponent<SoulSetter>().Ghost = Ghost; //set the player to this
        PB = ProgressBar.GetComponent<ProgressBar>();
        PB.Reset(); //set the progress bar
        Player.GetComponent<UpgradeSystem>().ProgressBar = ProgressBar; //aslo set the player to that
    }
    void SetChild(GameObject child)
    {
        this.child = child;
    }
}
