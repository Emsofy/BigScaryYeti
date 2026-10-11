using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class MeterController : MonoBehaviour
{
    public Slider mySlider;
    public VariableStorageBehaviour variableStorage; 
    void Update()
    {
        if (variableStorage.TryGetValue("$meterValue", out float score))
        {
            mySlider.value = score;
        }
    }
}
