using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 10f;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}