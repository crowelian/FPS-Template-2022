using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField] float destroyAfterSecs = 2f;
    void Update()
    {
        destroyAfterSecs -= 1f * Time.deltaTime;
        if (destroyAfterSecs <= 0)
        {
            Destroy(gameObject);
        }
    }
}
