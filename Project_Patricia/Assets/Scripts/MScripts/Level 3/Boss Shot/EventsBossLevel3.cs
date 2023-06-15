using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsBossLevel3 : MonoBehaviour
{
    [SerializeField] private Animator animMike;

    [Header("Shoot")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject rifle;
    [SerializeField] private Transform point;

    [Header("Life")]
    public float life = 100;
    [SerializeField] private GameObject container;
    public int shootCount;

    [Header("Note")]
    [SerializeField] private GameObject note;
    [SerializeField] private Vector3 pos;

    public void Shoot()
    {
        GameObject bulletInstatiate = Instantiate(bullet, point.position, point.rotation);
        bulletInstatiate.name = "BulletBoss";
    }

    public void ShootFalse()
    {
        animMike.SetBool("Shoot", false);
        rifle.SetActive(false);
    }

    public void LessLife()
    {
        shootCount++;
        life -= 8;
        if (life <= 0)
        {
            Destroy(container);
            note.transform.position = pos;
            note.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletPlayer"))
        {
            pos = new Vector3(transform.position.x, transform.position.y + 8, transform.position.z);
            Destroy(other.gameObject);
            LessLife();
        }
    }
}
