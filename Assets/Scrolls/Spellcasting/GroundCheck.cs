using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    internal bool Grounded;
    [SerializeField] string GroundTag;
    List<GameObject> TouchedGround;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Contains(GroundTag) && !TouchedGround.Contains(collision.gameObject))
        {
            TouchedGround.Add(collision.gameObject);
            if (Grounded == false) 
                Grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag.Contains(GroundTag) && TouchedGround.Contains(collision.gameObject))
        {
            TouchedGround.Remove(collision.gameObject);
            if (TouchedGround.Count == 0)
                Grounded = false;
        }

    }
}
