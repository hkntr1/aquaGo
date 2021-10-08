using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public static playerController Current;
    public float _speedModifier = 10f;
    private Touch _touch;
    public List<ridingSurfboard> boards = new List<ridingSurfboard>();
    private void Start()
    {
        Current = this;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                transform.localPosition += new Vector3(transform.localPosition.x, _touch.deltaPosition.x * (_speedModifier / 10f) * Time.deltaTime, transform.localPosition.z);
                transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -0.2f, 0.2f), transform.localPosition.y, transform.localPosition.z);
            }
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="surfboard")
        {
            Destroy(other.gameObject);
            IncrementSurfboardVolume(1f);
            follower.Current.speed++;

        }
        if (other.tag == "cone")
        {
           
            Destroy(other.gameObject);
            follower.Current.speed--;
        }

    }

    public void IncrementSurfboardVolume(float value)
    {
        if (boards.Count == 0)
        {
            if(value > 0)
            {
                ridingSurfboard.Current.CreateSurfboard(value);
               
            }
            else
            {
                //Gameover
            }
        }
        else
        {
            ridingSurfboard.Current.CreateSurfboard(value);
           
        }
       
    }
  
}
