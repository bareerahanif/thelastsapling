using UnityEngine;

public class SkyVehicle : MonoBehaviour
{
    public float speed = 5f;  
    public Vector3 moveDirection = Vector3.right;  
    public float resetPositionX = -10f;  
    public float startPositionX = 10f; 

    void Start()
    {
        transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        if (transform.position.x < resetPositionX)
        {
            transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
        }
    }
}
