using Unity.Cinemachine;
using UnityEngine;

public class clubEnterLoc : MonoBehaviour
{
    [SerializeField] public Camera camera;
    [SerializeField] public CinemachineCamera script;
    void Start()
    {
        camera.enabled = false;
        script.enabled = false;
        GameController.instance.SpawnCharacter(this.transform.position, this.transform.rotation);
    }


}
