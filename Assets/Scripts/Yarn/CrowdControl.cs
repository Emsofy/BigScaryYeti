using UnityEngine;
using Yarn.Unity;

public class CrowdControl : MonoBehaviour
{
    public VariableStorageBehaviour crowdStageNum;

    [YarnCommand("set_crowd_img")]
    public void SetCrowdImg()
    {
        Debug.Log("SetCrowdImg is running");
        if (crowdStageNum == null)
        {
            Debug.LogError("stage num is not assigned");
            return;
        }
        // Get the stage variable from Yarn Spinner
        if (!crowdStageNum.TryGetValue("$stage", out float stageValue))
        {
            Debug.LogError("Could not get $stage from YS");
            return;
        }
        int stage = Mathf.RoundToInt(stageValue);
        if (stage < 0 || stage >= transform.childCount)
        {
            Debug.LogError("Stage " + stage + " is outside range");
            return;
        }
        
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(stage).gameObject.SetActive(true);
        Debug.Log(stage);
    }

}