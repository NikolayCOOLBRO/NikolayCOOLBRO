using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHandler : MonoBehaviour
{
    public static List<CellObject> AllCells;

    private WorkersArea _workersArea;

    private int countCells;

    private void Awake()
    {
        AllCells = new List<CellObject>();
        _workersArea = GetComponent<WorkersArea>();
        countCells = _workersArea.Width * _workersArea.Heigth;
    }

    private void Update()
    {
        countCells = _workersArea.Width * _workersArea.Heigth;
        if (AllCells.Count == countCells)
        {
            foreach (var item in AllCells)
            {
                if(item.GetCellData().numberNeighbors == 3 && item.GetCellData().isEmpety)
                {
                    item.ActiveCell(ref WorkersArea.cells);
                }
            }
            foreach (var item in AllCells)
            {
                if ((item.GetCellData().numberNeighbors < 2 || item.GetCellData().numberNeighbors > 3) && !item.GetCellData().isEmpety)
                {
                    item.DeactivateCell(ref WorkersArea.cells);
                }
            }

            AllCells.Clear();
        }
    }
}
