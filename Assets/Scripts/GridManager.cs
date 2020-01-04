using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    #region Singleton
    public static GridManager instance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject Grid;
    private GameObject CurrentGrid;
    private List<GameObject> ActivatedCells = new List<GameObject>();
    private Color CurrentCollor = Random.ColorHSV();

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        CurrentGrid = Instantiate(Grid, new Vector3(), new Quaternion());
    }

    public void NextLevel()
    {
        GameObject newGrid = Instantiate(Grid, new Vector3(), new Quaternion());

        foreach (MeshRenderer mr in newGrid.GetComponentsInChildren<MeshRenderer>())
        {
            mr.material.SetColor("_Color", CurrentCollor);
        }
        CurrentCollor = Random.ColorHSV();

        float size = Mathf.Sqrt(CurrentGrid.transform.childCount);
        newGrid.transform.localScale = new Vector3(size, size, size);

        ActivatedCells.Clear();
        Destroy(CurrentGrid);
        StartCoroutine(ScaleDownAnimation(3f, newGrid));
    }

    IEnumerator ScaleDownAnimation(float time, GameObject grid)
    {

        CurrentGrid = grid;

        float i = 0;
        float rate = 1 / time;
        Vector3 fromScale = grid.transform.localScale;
        Vector3 toScale = Vector3.one;
        while (i < 1)
        {
            i += Time.deltaTime * rate;
            grid.transform.localScale = Vector3.Lerp(fromScale, toScale, i);
            yield return 0;
        }
    }

    public void ActivateCell(GameObject cell)
    {
        if (ActivatedCells.Find((x) => x.transform == cell.transform) == null)
        {
            ActivatedCells.Add(cell);
            MeshRenderer mr = cell.GetComponent<MeshRenderer>();
            mr.material.SetColor("_Color", CurrentCollor);
        }
        else
        {
            Debug.Log("Cell already activated");
        }

        if (ActivatedCells.Count == CurrentGrid.transform.childCount)
        {
            NextLevel();
        }
    }
}
