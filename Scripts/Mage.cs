using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{


    public float Speed;//velocidade do personagem
    public GameObject powerPrefab;//prefab do projetil
    public Transform shootPoint; //ponto de onde sai o projetil

    public Rigidbody2D rb;
    public int jumpForce;
    public bool onFloor;
    public Transform floorDetect;
    public LayerMask floor;
    public int extraJump = 1;

    private float lastShootTime;

    private bool facingRight;

    public float projectileVelocity;

    


    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onFloor = Physics2D.OverlapCircle(floorDetect.position, 0.2f, floor);
        if(Input.GetButtonDown("Jump") && onFloor == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if(Input.GetButtonDown("Jump") && onFloor == false && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        if(onFloor)
        {
            extraJump = 1;
        }

        Move();
        Shoot();

    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        float inputAxis = Input.GetAxis("Horizontal");

        if(inputAxis > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
            facingRight = true;
        }

        if(inputAxis < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
            facingRight = false;
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(powerPrefab, shootPoint.position, transform.rotation);

            lastShootTime = .7f;

            if (facingRight)
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileVelocity, 0);
            else
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileVelocity, 0);

        }

        lastShootTime -= Time.deltaTime;

    }

    
}
