using UnityEngine;

public class Base : MonoBehaviour
{
    public float damageOnTouch = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            HealthManager.Instance.TakeDamage(damageOnTouch);
        }
    }
}