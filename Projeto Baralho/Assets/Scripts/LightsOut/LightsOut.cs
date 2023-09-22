using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LightsOut : MonoBehaviour
{
    public List<LightsOutCell> cells;
    public int rows;
    public int columns;
    public static LightsOut instance;

    public UnityEvent onSolve;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Multiple instances of LightsOut!");
            Destroy(this);
        }
        if (cells.Count != rows * columns)
        {
            Debug.LogError("LightsOut não foi configurado corretamente!");
        }
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].index = i;
        }
    }

    public int GetIndex(int x, int y)
    {
        return y * columns + x;
    }
    public bool CellExists(int x, int y)
    {
        if (x >= columns || x < 0)
        {
            return false;
        }
        if (y >= rows || y < 0)
        {
            return false;
        }
        return true;
    }
    public void TryFlipCell(int x, int y)
    {
        if (CellExists(x, y))
        {
            cells[GetIndex(x, y)].Flip();
            CheckSolved();
        }
    }

    void CheckSolved()
    {
        foreach (var cell in cells)
        {
            if (!cell.isOn)
            {
                return;
            }
        }

        foreach (var cell in cells)
        {
            cell.gameObject.SetActive(false);
        }
        
        Invoke(nameof(OnSolve), 1f);
    }

    void OnSolve()
    {
        onSolve.Invoke();
    }

    public void OnCellClicked(int index)
    {
        int x = index % columns;
        int y = index / columns;

        TryFlipCell(x, y);
        TryFlipCell(x + 1, y);
        TryFlipCell(x - 1, y);
        TryFlipCell(x, y + 1);
        TryFlipCell(x, y - 1);
    }
}
