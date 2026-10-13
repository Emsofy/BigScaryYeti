using UnityEngine;

public class SmoothLookAtPlayer : MonoBehaviour
{
    private Transform playerTarget; 
    public float rotationSpeed = 5.0f;
    public string playerTag = "Player"; 
    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag(playerTag);

        if (playerObj != null)
        {
            playerTarget = playerObj.transform;
        }
        else
        {
            Debug.LogWarning($"NPC '{gameObject.name}' could not find a GameObject with the tag '{playerTag}'.");
        }
    }

    void Update()
    {
        if (playerTarget != null)
        {
            Vector3 direction = playerTarget.position - transform.position;
            direction.y = 0; 

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
