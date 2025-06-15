using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPos;
    public Transform cam;
    public float parallaxFactor;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxFactor;
        float reposition = cam.transform.position.x * (1 - parallaxFactor);

        transform.position = new Vector3(startPos + distance,transform.position.y, transform.position.z);

        if(reposition > startPos + length)
        {
            startPos += length;
        }
    }
}
