using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class grid2 : MonoBehaviour
{

    public GameObject Cell;
    int[] array = new int[5];

    // Start is called before the first frame update
    void Start()
    {
        int total = 5;

        float[] row = Enumerable.Range(0,total).Select(i => (float)i/total).ToArray();

        float size = 10;

        var result = 
            (from x in row
            from y in row
            select new Vector3(x * size, 0, y * size)).ToList();

        foreach (Vector3 vec in result)
        {
            Instantiate(Cell, vec, new Quaternion(), this.transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
