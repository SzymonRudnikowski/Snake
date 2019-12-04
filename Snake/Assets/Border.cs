using UnityEngine;

public class Border : MonoBehaviour
{
    public Transform top;
    public Transform bottom;
    public Transform right;
    public Transform left;

    private void Awake()
    {
        SetUpBorder();
    }

    public void SetUpBorder()
    {
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Screen.width / Screen.height;

        top.position = Vector3.up * Mathf.Round(cameraHeight);
        bottom.position = Vector3.down * Mathf.Round(cameraHeight);
        right.position = Vector3.right * Mathf.Round(cameraWidth);
        left.position = Vector3.left * Mathf.Round(cameraWidth);
    }
}
