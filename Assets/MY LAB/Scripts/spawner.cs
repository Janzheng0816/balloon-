using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] GameObject balloon;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    { 
   
        int xMin = -7;
        int xMax = 7;
        int yMin = -5;
        int yMax = 5;  
		Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
		Instantiate(balloon, position, Quaternion.identity);
    }
}
