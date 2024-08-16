using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    private Animator animator;
    public int monsterLife;

    public BackgroundActions BackgroundActions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (monsterLife <= 0)
        {
            Invoke("DestroyBody", .5f);
            Victory();
        }
    }

    public void TakeDamage (int damage) 
    {
        monsterLife -= damage;
    }

    private void DestroyBody()
    {
        Destroy(gameObject);
    }

    public void Victory()
    {
        BackgroundActions.Setup();
    }
}
