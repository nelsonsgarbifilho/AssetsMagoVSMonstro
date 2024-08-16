using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{

    public int damage;
    public float time;
    public float distance;
    public LayerMask layerMonster;

    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.Play();
        Invoke("DestroyPower", time);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distance, layerMonster);

        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Monster"))
            {
                hitInfo.collider.GetComponent<Monster>().TakeDamage(damage);
            }

            DestroyPower();
        }
    }

    void DestroyPower()
    {
        Destroy(gameObject);
    }
}
