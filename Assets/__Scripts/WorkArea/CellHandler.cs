using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CellHandler : MonoBehaviour
{
    [SerializeField]private List<GameObject> AllUI;
    [SerializeField]private Button OneStep;

    [SerializeField]private TMP_Text PlayOrPauseUI;

    public static List<CellObject> AllCells;//Список куда попадают все клетки находящиеся на сцене

    private WorkersArea _workersArea;

    private int countCells;

    private bool isNoneStop = false;
    private float timer;

    /// <summary>
    /// Метод для нажатия кнопки Play
    /// </summary>
    public void CheckNoneStop()
    {
        if (isNoneStop)
        {
            PlayOrPauseUI.text = "Play";
            isNoneStop = false;
            foreach(var item in AllUI)
            {
                item.SetActive(true);
            }
        }
        else
        {
            PlayOrPauseUI.text = "Pause";
            isNoneStop = true;
            foreach (var item in AllUI)
            {
                item.SetActive(false);
            }
        }
    }

    private void Awake()
    {
        AllCells = new List<CellObject>();
        _workersArea = GetComponent<WorkersArea>();
        countCells = _workersArea.Width * _workersArea.Heigth;
    }

    private void Update()
    {
        if (isNoneStop) timer += Time.deltaTime;

        if(timer >= 1f)
        {
            OneStep.onClick.Invoke();
            timer = 0f;
        }

        countCells = _workersArea.Width * _workersArea.Heigth;

        //При нажатой кнопке OneStep
        if (AllCells.Count == countCells && !isNoneStop)
        {
            SpawnOrDeadCells();
        }
        //При нажатие на кнопку Play
        else if(AllCells.Count == countCells && isNoneStop)
        {
            SpawnOrDeadCells();
        }
    }

    /// <summary>
    /// Реализация правил игры
    /// </summary>
    private void SpawnOrDeadCells()
    {
        foreach (var item in AllCells)
        {
            if (item.GetCellData().numberNeighbors == 3 && item.GetCellData().isEmpety)
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
