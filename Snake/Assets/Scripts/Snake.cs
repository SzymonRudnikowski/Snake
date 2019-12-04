using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public enum MoveMode
    {
        // Na 4 strzalki
        MODE_4_WAY,
        // Tylko lewo prawo
        MODE_2_WAY
    }

    [Range(0.5f, 10f)]
    public float speed = 3f;
    public bool canMove = true;
    public MoveMode moveMode = MoveMode.MODE_2_WAY;

    private Vector2Int gridMoveCurrentDirection;
    private Vector2Int gridMoveNextDirection;

    //Znajdujemy snake'a na planszy
    private Vector2Int gridPosition;

    //czas pomiedzy ruchami
    private float gridMoveTimer;
    //Czas w sekundach pomiedzy ruchami, 1/speed
    private float gridMoveTimeInterval;

    private void Awake()
    {
        gridPosition = new Vector2Int(0, 0);
        gridMoveTimeInterval = 1 / speed;
        gridMoveTimer = gridMoveTimeInterval;
        gridMoveCurrentDirection = new Vector2Int(1, 0);
        gridMoveNextDirection = new Vector2Int(1, 0);
    }

    private void Update()
    {
        if (moveMode == MoveMode.MODE_2_WAY)
        {
            HandleInput2Way();
        }
        else if (moveMode == MoveMode.MODE_4_WAY)
        {
            HandleInput4Way();
        }

        HandleGridMovement();
    }

    private void HandleInput4Way()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveCurrentDirection.y != -1)
            {
                gridMoveNextDirection.x = 0;
                gridMoveNextDirection.y = 1;
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveCurrentDirection.y != +1)
            {
                gridMoveNextDirection.x = 0;
                gridMoveNextDirection.y = -1;
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveCurrentDirection.x != +1)
            {
                gridMoveNextDirection.x = -1;
                gridMoveNextDirection.y = 0;
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveCurrentDirection.x != -1)
            {
                gridMoveNextDirection.x = +1;
                gridMoveNextDirection.y = 0;
            }

        }
    }

    private void HandleInput2Way()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveCurrentDirection.y == 1)
            {
                gridMoveNextDirection.x = 1;
                gridMoveNextDirection.y = 0;
            }
            else if (gridMoveCurrentDirection.y == -1)
            {
                gridMoveNextDirection.x = -1;
                gridMoveNextDirection.y = 0;
            }
            else if (gridMoveCurrentDirection.x == 1)
            {
                gridMoveNextDirection.x = 0;
                gridMoveNextDirection.y = -1;
            }
            else if (gridMoveCurrentDirection.x == -1)
            {
                gridMoveNextDirection.x = 0;
                gridMoveNextDirection.y = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveCurrentDirection.y == 1)
            {
                gridMoveNextDirection.x = -1;
                gridMoveNextDirection.y = 0;
            }
            else if (gridMoveCurrentDirection.y == -1)
            {
                gridMoveNextDirection.x = 1;
                gridMoveNextDirection.y = 0;
            }
            else if (gridMoveCurrentDirection.x == 1)
            {
                gridMoveNextDirection.x = 0;
                gridMoveNextDirection.y = 1;
            }
            else if (gridMoveCurrentDirection.x == -1)
            {
                gridMoveNextDirection.x = 0;
                gridMoveNextDirection.y = -1;
            }
        }
    }

    private void HandleGridMovement()
    {
        if (!canMove)
        {
            return;
        }

        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimeInterval)
        {
            // 1. odzyskujemy ostatnie dziecko obiektu Snake
            int lastone = transform.childCount - 1;
            var lastchild = transform.GetChild(lastone);

            // 2. przesuwamy wynik z 1. na miejsce glowy
            var head = transform.GetChild(0);
            lastchild.position = head.position;

            // 3. updatujemy hierarchie - przesuwamy wynik z 1. na 2 !!! miejsce
            //transform.SetSiblingIndex
            lastchild.SetSiblingIndex(1);

            // 4. przesuwamy glowe - czyli to co juz mamy ponizej
            gridMoveTimer -= gridMoveTimeInterval;
            gridPosition += gridMoveNextDirection;
            gridMoveCurrentDirection = gridMoveNextDirection;
            head.position = new Vector3(gridPosition.x, gridPosition.y);
        }

    }
}
