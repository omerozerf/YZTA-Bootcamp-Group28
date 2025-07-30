using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;  //Hedefe doğru gidiş hızı
    [SerializeField] private float damage = 5f;  //Çarpınca vereceği hasar

    private Transform target; //Hedef düşman


    //Mermi üretilirken hedef buraya argument vererek
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Start()
    {

    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); //hedef yoksa mermi intihar eder,(yolu yarılamışsa bile)
            return;
        }

        //Hedefin pozisyonuna doğru yönlen
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // Eğer bu frame’de hedefe ulaşabiliyorsak:
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        //Hedefe doğru ilerle
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target); // yönünü hedefe çevir
    }

    void HitTarget()
    {
        // Çarptığı nesnede Enemy scripti varsa ona hasar ver
        enemy enemy = target.GetComponent<enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        // Patlama efekti vb. olabilir
        Destroy(gameObject); // mermi kendini yok eder

        //dekorasyonlara falan çarpar da öyle yok olursa nasıl olcak bilmiyorum
        //haritaya bakıp ona gerek olur mu bi düşünelim tekrar
    }
}