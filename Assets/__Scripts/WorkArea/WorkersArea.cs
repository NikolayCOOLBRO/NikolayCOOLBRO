using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkersArea : MonoBehaviour
{
    public int Width;
    public int Heigth;

    public Button button;

    [SerializeField]private Vector3Int Area;
    [SerializeField]private CellObject cellPrefab;
    [SerializeField] private GameObject background;

    public static Cell[,] cells;
    public static bool isInit;

    private void Awake()
    {
        isInit = false;
        InitCells();
    }
    private void Update()
    {
        
    }

    public void CheckInit()
    {
        if (isInit) isInit = false;
        else isInit = true;
    }

    private void InitCells()
    {
        cells = new Cell[Width, Heigth];

        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                cells[i, j] = new Cell(i, j, Width, Heigth);
                CellObject cell = Instantiate(cellPrefab, new Vector3(i,j,0), transform.rotation);
                cell.SetCellData(cells[i, j], cellPrefab.gameObject);
                button.onClick.AddListener(cell.Play);
                Instantiate(background, new Vector3(i,j,1), transform.rotation, transform);
            }
        }
    }
}
