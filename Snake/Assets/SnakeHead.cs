using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public Snake snake;
    public FoodManager foodManger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            snake.canMove = false;
        }
        if (collision.tag == "Food")
        {
            Debug.Log(collision.gameObject);
            Destroy(collision.gameObject);
            foodManger.Spawn();
        }
    }
}
