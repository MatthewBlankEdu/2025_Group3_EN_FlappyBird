using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed;
    public float spawnPointX;
    public float despawnPointX;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, 
            transform.position.y, transform.position.z);

        if (transform.position.x <= despawnPointX)
        {
            transform.position = new Vector3(spawnPointX, 
                transform.position.y, transform.position.z);
        }
    }
}
