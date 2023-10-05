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
    
    public GameObject GetBullet()
    {
        if( _bulletPool.Count < 1 )
            CreateBullet();
        return _bulletPool.Dequeue();
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);

        _bulletPool.Enqueue(bullet);
    }
}
