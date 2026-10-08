using Unity.Cinemachine;
using UnityEngine;

public class clubEnterLoc : MonoBehaviour
{
    [SerializeField] public Camera camera;
    //[SerializeField] public CinemachineCamera cam;
    void Start()
    {
        camera.enabled = false;
        //cam.Priority = -1;
        GameController.instance.SpawnCharacter(this.transform.position, this.transform.rotation);
    }


}
