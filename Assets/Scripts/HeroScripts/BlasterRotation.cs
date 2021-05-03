using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterRotation : MonoBehaviour
{
    public Animator blasterAnimatior;
    private Rigidbody2D blasterRb;
    private Rigidbody2D playerRb;

    public float angle;
    public float shootAngle;
    public Camera cam;
    Vector2 mousePos;
    Vector2 normLookDir;

    private void Start()
    {
        blasterRb = gameObject.GetComponent<Rigidbody2D>();
        playerRb = GameObject.FindGameObjectWithTag("Hero").GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        //Read the mouse position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //Send information to blaster animator
        normLookDir = (mousePos - playerRb.position).normalized;
        blasterAnimatior.SetFloat("Horizontal", normLookDir.x);
        blasterAnimatior.SetFloat("Vertical", normLookDir.y);
        
        //Calculate angle where mouse is possitioned. 0deg is at (-1,0)
        angle = (Mathf.Atan2(normLookDir.y, normLookDir.x) * Mathf.Rad2Deg -180f) * -1;
        shootAngle = (angle * -1) + 90f;

        //This if statement is responsible for weapon rotation within different sprites, so the gun would always look at the mouse
        int spriteSortRenderOffset = (-6);
        Vector2 blasterPosition = new Vector2(0f, -0.86f);
        if (angle >= 0 && angle < 30) { spriteSortRenderOffset = (-6); blasterPosition = new Vector2(-0.3f, -0.86f); }
        else if (angle >= 30 && angle < 60) { angle -= 30f; spriteSortRenderOffset = (-5); blasterPosition = new Vector2(-0.53f, -0.86f); }
        else if (angle >= 60 && angle < 120) { angle -= 90f; spriteSortRenderOffset = (-3); blasterPosition = new Vector2(-0.455f, -0.97f); }
        else if (angle >= 120 && angle < 150) { angle -= 150f; spriteSortRenderOffset = (-5); blasterPosition = new Vector2(-0.53f, -0.86f); }
        else if (angle >= 150 && angle < 210) { angle -= 180f; spriteSortRenderOffset = (-5); blasterPosition = new Vector2(-0.23f, -0.87f); }
        else if (angle >= 210 && angle < 240) { angle -= 210f; spriteSortRenderOffset = (-6); blasterPosition = new Vector2(0f, -0.87f); }
        else if (angle >= 240 && angle < 300) { angle -= 270f; spriteSortRenderOffset = (-6); blasterPosition = new Vector2(-0.1f, -0.94f); }
        else if (angle >= 300 && angle < 330) { angle -= 330f; spriteSortRenderOffset = (-6); blasterPosition = new Vector2(-0.04f, -0.86f); }
        else if (angle >= 330 && angle < 360) { angle -= 360f; spriteSortRenderOffset = (-6); blasterPosition = new Vector2(-0.3f, -0.86f); }
        //Change the offset according to the gun position (if behind player, offset it bigger so the gun shows behind the player)
        gameObject.GetComponent<SpriteSortingScript>().offset = spriteSortRenderOffset;

        //Change the position of the gun accordin to the rotation, so the gun would appear always in hero's hand
        gameObject.transform.localPosition = blasterPosition;

        //Create a new Quaternion, needed for the rotation of the blaster transform
        Quaternion angleQ = new Quaternion();
        angleQ.eulerAngles = new Vector3(0f, 0f, (angle * -1));

        //Blaster transform rotation = angle
        gameObject.transform.rotation = angleQ;

    }
}
