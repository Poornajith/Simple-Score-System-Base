using UnityEngine;

public class LookForObject : MonoBehaviour
{
  
    private Transform lookObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy && (lookObject != null))
        {
            transform.LookAt(lookObject.position);
        }
    }

    public void SetLookTransform(Transform lookObjectToLookat) {
        lookObject = lookObjectToLookat;
    }
}
