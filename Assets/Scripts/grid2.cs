using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class grid2 : MonoBehaviour
{

    public GameObject Cell;
    int[] array = new int[5];
    
    bool mouseDown = false;
    bool preMouseDown = false;

    // Start is called before the first frame update
    void Start()
    {
        int total = 5;

        float[] row = Enumerable.Range(0,total).Select(i => (float)i/total).ToArray();
        float size = 10;

        var grid = 
            (from x in row
            from y in row
            select new float[]{x,y}).ToList();

        foreach (float[] vec in grid)
        {
            Vector3 pos = new Vector3(vec[0] * size, 0, vec[1] * size);
            Instantiate(Cell, pos, new Quaternion(), this.transform);
        }

        double rand = Random.Range(0.0f, 1.0f);
        double rand2 = Random.Range(0.0f, 1.0f);
        Debug.Log(total * rand);

        double pivot = total * rand;
        double pivot2 = total * rand2;
        
        var xGridRand = grid.Min(n => Mathf.Abs((float)(pivot - n[0])));
        var yGridRand = grid.Min(n => Mathf.Abs((float)(pivot2 - n[1])));

        Debug.Log(xGridRand);
        Debug.Log(yGridRand);

        GameObject go = Instantiate(Cell, new Vector3(xGridRand,0, yGridRand), new Quaternion(), this.transform);
        MeshRenderer mr = go.GetComponent<MeshRenderer>();
        mr.material.SetColor("_Color", Random.ColorHSV());
    
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseDown = Input.GetMouseButton(0);
        if (mouseDown != preMouseDown && mouseDown)
        {
            Debug.Log("Pressed left click.");
        }
        preMouseDown = mouseDown;
    }

    void OnMouseUpAsButton()
    {
        Debug.Log("test");
    }
}
