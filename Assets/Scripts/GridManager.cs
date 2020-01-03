using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public GameObject Cell;
    public Camera mainCamera;
    private List<Vector3> gridPositions = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid(5);
    }

    private void GenerateGrid(int length)
    {
        gridPositions.Clear();
        for (int x = 0; x < length; x++)
        {
            for (int z = 0; z < length; z++)
            {
                gridPositions.Add(new Vector3(x, 0, z));
            }
        }

        foreach (Vector3 position in gridPositions)
        {
            Instantiate(Cell, position, new Quaternion(), this.transform);
        }
    }

    public void NextLevelAnimation()
    {
        this.transform.localScale = new Vector3(.1f, .1f, .1f);
    }
}
