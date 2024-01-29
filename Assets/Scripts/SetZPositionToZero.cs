using UnityEngine;

public class SetZPositionToZero : MonoBehaviour
{
    void Start()
    {
        Invoke("SetZPositionToZeroRecursive", 2f);
    }

    void SetZPositionToZeroRecursive()
    {
        RecursiveSetZPositionToZero(transform);
    }

    void RecursiveSetZPositionToZero(Transform parentTransform)
    {
        foreach (Transform child in parentTransform)
        {
            // Set the Z position to zero for the child
            child.position = new Vector3(child.position.x, child.position.y, 0f);

            // Recursively process child's children
            RecursiveSetZPositionToZero(child);
        }
    }
}
