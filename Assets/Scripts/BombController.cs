using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 1f;
    public LayerMask enemyLayer;

    public ParticleSystem explosionParticlesPrefab;


private void Start() 
{
    Invoke(nameof(Explode), 3f);
}    
        
    

void Explode()
{
    // Find all enemies within the explosion radius
    Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRadius, enemyLayer);

    // Apply damage or eliminate enemies
    foreach (Collider enemy in enemies)
    {
        // Implement enemy elimination logic here
        enemy.GetComponent<EnemyAI>().HitByBomb();
    }
    // Instantiate and play explosion particle effect
    Instantiate(explosionParticlesPrefab, transform.position, Quaternion.identity).Play();

    // Destroy the bomb after exploding
    Destroy(gameObject);
}
}
