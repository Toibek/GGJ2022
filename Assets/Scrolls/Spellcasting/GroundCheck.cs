using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    internal bool Grounded;

    [SerializeField] string GroundTag;
    public bool useTrigger;

    List<GameObject> TouchedGround = new List<GameObject>();

    #region onCollision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!useTrigger)
        {
            if (collision.transform.tag.Contains(GroundTag) && !TouchedGround.Contains(collision.gameObject))
            {
                TouchedGround.Add(collision.gameObject);
                if (Grounded == false)
                    Grounded = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!useTrigger)
        {
            if (collision.transform.tag.Contains(GroundTag) && TouchedGround.Contains(collision.gameObject))
            {
                TouchedGround.Remove(collision.gameObject);
                if (TouchedGround.Count == 0)
                    Grounded = false;
            }
        }
    }
    #endregion
    #region onTrigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (useTrigger)
        {
            if (collision.tag.Contains(GroundTag) && !TouchedGround.Contains(collision.gameObject))
            {
                TouchedGround.Add(collision.gameObject);
                if (Grounded == false)
                    Grounded = true;
            }
        }   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (useTrigger)
        {
            if (collision.tag.Contains(GroundTag) && TouchedGround.Contains(collision.gameObject))
            {
                TouchedGround.Remove(collision.gameObject);
                if (TouchedGround.Count == 0)
                    Grounded = false;
            }
        }
    }
    #endregion
}
