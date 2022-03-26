using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Red());

            Vector3 collPos = collision.transform.position;
            collPos.y = transform.position.y;
            transform.position += (transform.position - collPos).normalized; 
        }
    }
    IEnumerator Red()
    {
        rend.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rend.color = Color.white;
    }
}
