using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    GameObject _bulletPrefab;
    Queue<GameObject> _bulletPool = new Queue<GameObject>();

    [SerializeField]
    int _bulletTotal = 50;


    // Start is called before the first frame update
    void Start()
    {
        _bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");

        BuildBulletPool();
    }

    //Instantiate a bullet pool

    void BuildBulletPool()
    {
        //create bullets
        //add them to a list

        for(int i = 0; i < _bulletTotal; i++)
        {
            CreateBullet();
        }
    }

    void CreateBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab);
        
        bullet.SetActive(false);
        bullet.transform.SetParent(transform);
        _bulletPool.Enqueue(bullet);

    }
    
    public GameObject GetBullet(Vector3 spawnPos, Vector3 dir, Color color)
    {
        if( _bulletPool.Count < 1 )
            CreateBullet();

        GameObject bullet = _bulletPool.Dequeue();

        bullet.SetActive(true);
        bullet.transform.position = spawnPos;
        bullet.GetComponent<BulletBehavior>().SetDirection(dir);
        bullet.GetComponent<SpriteRenderer>().color = color;


        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);



        _bulletPool.Enqueue(bullet);
    }
}
