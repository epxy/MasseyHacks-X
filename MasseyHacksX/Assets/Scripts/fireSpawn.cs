using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script that spawns a referenced gameobject on the surface of the cube
public class fireSpawn : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;

    [SerializeField] bool onFire = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnFire();
    }

    private void SpawnFire()
    {
        if(onFire)
        {
            Debug.Log("Fire");
        }
    }
    
    public void Extinguish()
    {
        onFire = false;
    }
}
