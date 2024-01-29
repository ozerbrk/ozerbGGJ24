using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    
    // Reference to the BoxCollider and Particle System
    private BoxCollider boxCollider;
    private new ParticleSystem particleSystem;

    private void Start() {

        // Get references to the BoxCollider and Particle System components
        boxCollider = GetComponent<BoxCollider>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        
        // Deactivate the components initially
        DeactivateFinishPoint();
    }
    
    // Function to activate BoxCollider and Particle System
    public void ActivateFinishPoint()
    {
        boxCollider.enabled = true; // Activate the BoxCollider
        particleSystem.Play(); // Play the Particle System
    }

    // Function to deactivate BoxCollider and Particle System
    void DeactivateFinishPoint()
    {
        boxCollider.enabled = false; // Deactivate the BoxCollider
        particleSystem.Stop(); // Stop the Particle System
    }
}
