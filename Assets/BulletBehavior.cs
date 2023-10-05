using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    Boundry _offLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);

        if(transform.position.y > _offLimit.max || transform.position.x < _offLimit.min)
        {
            Destroy(gameObject);
        }
    }
}
