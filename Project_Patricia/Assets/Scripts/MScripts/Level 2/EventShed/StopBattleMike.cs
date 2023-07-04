using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBattleMike : MonoBehaviour
{
    [SerializeField] private GameObject mike;
    [SerializeField] private GameObject otherCol;
    [SerializeField] private MikeBossLevel2 life;
    [SerializeField] private AudioSource sound3;
    [SerializeField] private GameObject eyes;
    [SerializeField] private WakingUpMode waking;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject rifle, aim;
    [SerializeField] private Weapon weapon;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            col.enabled= false;
            sound3.Stop();
            mike.SetActive(true);
            Destroy(otherCol);
            life.life = 0;
            
            StartCoroutine("FalseModeDream");
        }
    }

    public IEnumerator FalseModeDream()
    {
        yield return new WaitForSeconds(4.3f);
        eyes.SetActive(true);
        yield return new WaitForSeconds(0.48f);
        rifle.SetActive(false);
        aim.SetActive(false);
        weapon.shoot= false;
        weapon.shootTwo= false;
        waking.WakingOff();
        yield return new WaitForSeconds(1.12f);
        eyes.SetActive(false);
        Destroy(this.gameObject);
    }

}
