using System.Collections.Generic;
using System.Linq;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class GameController : MonoBehaviour
{
    //this instance variable is the static reference to this class
    //it can only be overwritten within this class (the private set determines that)
    public static GameController instance { get; private set; }

    public Transform startingLoc;
    public Vector3 loadLoc;
    public Quaternion loadRot;
    public bool firstSceneloaded = false;
    public GameObject ThirdPersonRig;
    public bool hTrophy = false;
    public bool fail = false;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;

            //this line uses the `sceneLoaded` UnityAction
            //we subscribe the OnSceneLoaded method to this action, which "fires" whenever a new scene is loaded
            SceneManager.sceneLoaded += OnSceneLoaded;
            //Debug.Log("Loaded Scene: " + SceneManager.GetActiveScene());
        }
        DontDestroyOnLoad(this);

    }

    //this method receives the `sceneLoaded` UnityAction and requires the Scene and LoadSceneMode arguments
    //we use this method to check what current scene has been loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            if (!firstSceneloaded)
            {
                Debug.Log("Spawned Character at starting Location");
                SpawnCharacter(startingLoc.position, startingLoc.rotation);
                firstSceneloaded = true;
            }
            else
            {
                Debug.Log("Spawned Character at new Location");
                SpawnCharacter(loadLoc, loadRot);
            }

            
        }
    }

    public void SpawnCharacter(Vector3 loc, Quaternion rot)
    {
        Debug.Log("SPAWNED THIRD PERSON");
        Instantiate(ThirdPersonRig, loc, rot);
    }

    //the below method is a `setter` method for this singleton
    //it gets called by other GameObjects and classes when we enter/exit "loading zones"
    public void setSpawnPoint(Vector3 loc, Quaternion rot)
    {
        loadLoc = loc;
        loadRot = rot;
    }

  

   
    public void setPlayerMovement(bool b)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        ThirdPersonController tpc = player.GetComponent<ThirdPersonController>();

        if (b)
        {
            tpc.enabled = false;
        }
        else
        {
            tpc.enabled = true;
        }
    }

    //This method is being called by the NPC_Cam_Control script
    //We're calling it from there, because that class has a standardized Transform variable that we want to pass into this method
    public void moveForDialog(Transform movePos)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = movePos.position;
    }
    [YarnCommand("change_scene")]
    public static void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    //[YarnCommand("has_trophy")]
    //public void setTrophyBool(bool hTrophy)
    //{
    //    if (hTrophy)
    //    {
    //        Debug.Log("has trophy");
    //    }
    //    if(!hTrophy)
    //    {
    //        Debug.Log("no trophy");
    //    }
    //}
    [YarnCommand("set_bool")]
    public void SetBool(string answ)
    {
       if (answ == "yes")
       {
            hTrophy = true;
            Debug.Log(hTrophy);
       }
        if (answ == "no")
        {
            hTrophy = false;
            fail = true;    
            Debug.Log(hTrophy);
        }
    }
    
}

