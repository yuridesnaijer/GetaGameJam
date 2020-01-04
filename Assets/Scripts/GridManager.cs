using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public GameObject Grid;
    private GameObject CurrentGrid;
    private float animationTimer = 0f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        CurrentGrid = Instantiate(Grid, new Vector3(), new Quaternion());
    }

    public void NextLevelAnimation()
    {
        GameObject newGrid = Instantiate(Grid, new Vector3(), new Quaternion());
        newGrid.transform.localScale = new Vector3(5f, 5f, 5f);

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
}
