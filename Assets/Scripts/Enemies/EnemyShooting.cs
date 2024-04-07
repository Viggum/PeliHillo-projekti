using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyMovement;

    [SerializeField] private Transform shootPos;
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private Transform firePos;
    public GameObject fireVFX;
    [SerializeField] private VisualEffect smokeEffect;

    public float shootDelay = 5f;
    float shootTimer;

    public float shootForce = 20f;

    public AudioSource audioSource;
    [SerializeField] private AudioClip[] shootingAudioClips;    

    // Update is called once per frame
    void Update()
    {
        // When enemy is looking at player, shoot
        if (enemyMovement.inRange)
            Shoot();
    }

    private void Shoot()
    {
        // TODO: Add some pre shoot indicator effect
        if(Time.time >= shootTimer)
        {
            shootTimer = Time.time + shootDelay;
            StartCoroutine(Shooting());           
        }       
    }

    private IEnumerator Shooting()
    {
        // Start FireVFX
        Instantiate(fireVFX, firePos.position, Quaternion.identity, transform);

        audioSource.clip = shootingAudioClips[0];
        audioSource.Play();
        // Wait
        yield return new WaitForSeconds(2);

        smokeEffect.Play();
        audioSource.clip = shootingAudioClips[1];
        audioSource.Play();

        // TODO: Add shooting sound

        // Shoot
        var instance = Instantiate(projectilePrefab, shootPos.position, Quaternion.identity);
        instance.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce + Vector3.up, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(shootPos.position, transform.forward * shootForce + Vector3.up);
    }
}
