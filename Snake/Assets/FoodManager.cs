using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject foodPrefab;
    public Border border;
    public Snake snake;

    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        float minx = border.left.position.x + 1;
        float maxx = border.right.position.x - 1;
        float miny = border.bottom.position.y + 1;
        float maxy = border.top.position.y - 1;
        float x = 0;
        float y = 0;
        bool notOk = false;

        // TODO to nie zadziala jak snake bedzie wypelnial cale pole
        // TODO w takim wypadku jest win i trzeba to obsluzyc
        do
        {
            x = Mathf.Round(Random.Range(minx, maxx));
            y = Mathf.Round(Random.Range(miny, maxy));
            for (int i = 0; i < snake.transform.childCount || notOk; i++)
            {
                Transform child = snake.transform.GetChild(i);
                notOk = child.position.x == x && child.position.y == y;
            }

        } while (notOk);

        Instantiate(foodPrefab, new Vector3(x, y), Quaternion.identity, transform);
    }
}
