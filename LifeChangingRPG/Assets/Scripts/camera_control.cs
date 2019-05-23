using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control : MonoBehaviour {


    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;
    public static bool CameraExist;

    public BoxCollider2D boundBox;
    private Vector3 maxVal;
    private Vector3 minVal;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(transform.gameObject);

        if (!CameraExist)
        {
            CameraExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if (boundBox == null)
        {
            boundBox = FindObjectOfType<CameraBounds>().GetComponent<BoxCollider2D>();
        }
        minVal = boundBox.bounds.min;
        maxVal = boundBox.bounds.max;
        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }
	
	// Update is called once per frame
	void Update () {
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if(boundBox == null)
        {
            boundBox = FindObjectOfType<CameraBounds>().GetComponent<BoxCollider2D>();
        }

        float clampedX = Mathf.Clamp(transform.position.x, minVal.x + halfWidth, maxVal.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minVal.y + halfHeight, maxVal.y - halfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
    public void SetBounds(BoxCollider2D newBounds)
    {
        boundBox = newBounds;
        minVal = boundBox.bounds.min;
        maxVal = boundBox.bounds.max;
    }
}
