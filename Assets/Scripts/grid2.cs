using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class grid2 : MonoBehaviour
{

    public GameObject Cell;
    int[] array = new int[5];
    
    bool mouseDown = false;
    bool rightDown = false;
    bool leftDown = false;
    bool downDown = false;
    bool upDown = false;

    bool preMouseDown = false;
    bool prevRightDown = false;
    bool prevLeftDown = false;
    bool prevDownDown = false;
    bool prevUpDown = false;

    List<float[]> grid = new List<float[]>();
    int total = 10;
    float size = 18;    

    private GameObject cursorObject;
    Vector3 cursor = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        
        float[] row = Enumerable.Range(0,this.total).Select(i => (float)i/this.total).ToArray();
        

        this.grid = 
            (from x in row
            from y in row
            select new float[]{x,y}).ToList();

        foreach (float[] vec in this.grid)
        {
            Vector3 pos = new Vector3(vec[0] * this.size, 0, vec[1] * this.size);
            // Instantiate(Cell, pos, new Quaternion(), this.transform);
        }

        int r = (int)Random.Range (0, this.grid.Count);
        this.cursor = new Vector3(this.grid[r][0] * this.size,0, this.grid[r][1] * this.size);


        this.cursorObject = Instantiate(Cell, this.cursor, new Quaternion(), this.transform);
        MeshRenderer mr = this.cursorObject.GetComponent<MeshRenderer>();
        mr.material.SetColor("_Color",  Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        mouseDown = Input.GetMouseButton(0);
        rightDown = Input.GetKeyDown(KeyCode.RightArrow);
        leftDown = Input.GetKeyDown(KeyCode.LeftArrow);
        downDown = Input.GetKeyDown(KeyCode.DownArrow);
        upDown = Input.GetKeyDown(KeyCode.UpArrow);

        if (mouseDown && mouseDown != preMouseDown)
        {
            Debug.Log("Pressed left click.");
        }

        if (rightDown && rightDown != prevRightDown){
            this.moveRight();
        }

        if (leftDown && leftDown != prevLeftDown){
            this.moveLeft();
        }

        if (downDown && downDown != prevDownDown){
            this.moveDown();
        }

        if (upDown && upDown != prevUpDown){
            this.moveUp();
        }

        preMouseDown = mouseDown;
        prevRightDown = rightDown;
        prevLeftDown = leftDown;
        prevDownDown = downDown;
        prevUpDown = upDown;
    }

    void moveLeft() {
        IEnumerable<float[]> path = this.grid.Where(gridItem => gridItem[0] * this.size < this.cursor.x && Mathf.Approximately(gridItem[1] *  this.size, this.cursor.z));
        foreach(var item in path){
            GameObject go = Instantiate(Cell, new Vector3(item[0] * size, 0, item[1] * size), new Quaternion(), this.transform);
            MeshRenderer mr = go.GetComponent<MeshRenderer>();
            mr.material.SetColor("_Color",  Color.green);
        }

        float[] first = path.FirstOrDefault();
        setCurrentPos(first);

    }

    void moveRight() {
        IEnumerable<float[]> path = this.grid.Where(gridItem => gridItem[0] * this.size > this.cursor.x && Mathf.Approximately(gridItem[1] *  this.size, this.cursor.z));
        foreach(var item in path){
            GameObject go = Instantiate(Cell, new Vector3(item[0] * size, 0, item[1] * size), new Quaternion(), this.transform);
            MeshRenderer mr = go.GetComponent<MeshRenderer>();
            mr.material.SetColor("_Color",  Color.green);
        }

    }

    void moveUp() {
        Debug.Log("test2");
        IEnumerable<float[]> path = this.grid.Where(gridItem => Mathf.Approximately(gridItem[0] * this.size, this.cursor.x) &&  gridItem[1] * this.size > this.cursor.z);
        foreach(var item in path){
            GameObject go = Instantiate(Cell, new Vector3(item[0] * size, 0, item[1] * size), new Quaternion(), this.transform);
            MeshRenderer mr = go.GetComponent<MeshRenderer>();
            mr.material.SetColor("_Color",  Color.green);
        }

        float[] first = path.FirstOrDefault();
        setCurrentPos(first);
    }

    void moveDown() {
        IEnumerable<float[]> path = this.grid.Where(gridItem => Mathf.Approximately(gridItem[0] * this.size, this.cursor.x) &&  gridItem[1] * this.size < this.cursor.z);
        foreach(var item in path){
            GameObject go = Instantiate(Cell, new Vector3(item[0] * size, 0, item[1] * size), new Quaternion(), this.transform);
            MeshRenderer mr = go.GetComponent<MeshRenderer>();
            mr.material.SetColor("_Color",  Color.green);
        }
    }

    void setCurrentPos(float[] coos) {
        this.cursor.x = coos[0];
        this.cursor.z = coos[1];

        Debug.Log("---");
        Debug.Log(coos[0]);
        Debug.Log(coos[1]);

        // this.cursorObject.transform.position = this.cursor;
    }

    void OnMouseUpAsButton()
    {
        Debug.Log("test");
    }
}
