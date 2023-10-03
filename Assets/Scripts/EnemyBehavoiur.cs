using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavoiur : MonoBehaviour
{
    [Header("Speed")]
    public float speed = 2f;

    
    [Header("Disparo")] 
    public GameObject prefabDisparo;
    public float disparoSpeed =2f;
    public float shootingInterval = 6f;
    public float timeDisparoDestroy = 2f;
    
    private float _shootingTimer;
    
    public Transform weapon1;
    public Transform weapon2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _shootingTimer = Random.Range (0f, shootingInterval);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        StartFire();
    }
    
    public void StartFire()
    {
        _shootingTimer -= Time.deltaTime;
        if (_shootingTimer <= 0f)
        {
            _shootingTimer = shootingInterval;
           GameObject disparoInstance = Instantiate(prefabDisparo);
           disparoInstance.transform.SetParent(transform.parent);
           disparoInstance.transform.position = weapon1.position;
           
           disparoInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, disparoSpeed);
           Destroy(disparoInstance,timeDisparoDestroy);
                    
           GameObject disparoInstance2 = Instantiate(prefabDisparo);
           disparoInstance2.transform.SetParent(transform.parent);
           disparoInstance2.transform.position = weapon2.position;
           
           disparoInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, disparoSpeed);
           Destroy(disparoInstance2,timeDisparoDestroy);
            
        }
    }
    
    void OnTriggerEnter2D (Collider2D otherCollider) {
        //otherCollider.gameObject.GetComponent<DisparoBehaviour>()
        if (otherCollider.tag == "disparoPlayer" || otherCollider.tag == "Player") {
            gameObject.SetActive (false);
            Destroy (otherCollider.gameObject);
        }
    }
    
}
