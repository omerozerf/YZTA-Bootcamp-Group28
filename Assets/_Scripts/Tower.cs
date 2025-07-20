using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Tower Settings")]
    [SerializeField] private GameObject towerModel; //kulenin görseli (3d model)
    [SerializeField] private GameObject projectilePrefab; //fırlatılacak mermi türü (ok/top vs)
    [SerializeField] private Transform firePoint; //mermi nereden ateşlenecek
    [SerializeField] private float range = 10f;
    [SerializeField] private float fireRate = 1f; //saniye başı ateş sayısı
    private Transform currentTarget;
    private float fireCooldown = 0f;
    void Start()
    {
        Debug.Log("selam gençler kulemiz var");
        // 0.15 saniyede bir hedef taraması başlat. çok da fazla olursa performans düşebilir
        InvokeRepeating(nameof(FindTarget), 0f, 0.15f);
    }

    void Update()
    {
        if (currentTarget == null)
            return;

        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }
    }

    void FindTarget()
    {
        // Menzil içinde hangi collider'lar var onu bul
        Collider[] hits = Physics.OverlapSphere(transform.position, range);

        //shortestDistance'la karşılaştırma yapıp en yakın düşmanı bulmak için
        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy")) // Sadece tag'i "Enemy" olan objelere ateş edilecek (prefablara tag eklendi)
            {
            
            float distance = Vector3.Distance(transform.position, hit.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = hit.transform;
            }
            }
        }

        if (nearestEnemy != null)
        {
            currentTarget = nearestEnemy;
        }
        else
        {
        currentTarget = null;
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null || firePoint == null || currentTarget == null)
            return;

        //Mermiyi oluştur
        GameObject projectileGO = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Mermi scriptine eriş
        Projectile projectileScript = projectileGO.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            //Hedefi ata
            projectileScript.SetTarget(currentTarget);
        }
    }
}