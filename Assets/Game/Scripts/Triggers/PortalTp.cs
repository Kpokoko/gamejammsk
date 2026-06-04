using UnityEngine;

public class PortalTp : MonoBehaviour
{
    public Transform targetPortal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player(Clone)")
        {
            other.transform.position = targetPortal.position;
        }
    }
}