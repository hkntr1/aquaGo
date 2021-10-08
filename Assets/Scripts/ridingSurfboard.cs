using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ridingSurfboard : MonoBehaviour
{
    private bool _filled;
    private float _value;
    public GameObject ridingSurfBoardPrefab;
    public static ridingSurfboard Current;
    

    public void CreateSurfboard(float value)
    {
        ridingSurfboard createdSurfBoard = Instantiate(ridingSurfBoardPrefab, transform).GetComponent<ridingSurfboard>();
        playerController.Current.boards.Add(createdSurfBoard);
        createdSurfBoard.IncrementSurfboardVolume(value);
       
    }
    public void DestroySurfboard(ridingSurfboard surfboard)
    {
        playerController.Current.boards.Remove(surfboard);
        Destroy(surfboard.gameObject);
    }
    public void IncrementSurfboardVolume(float value)
    {
        _value += _value;       
        int surfboardCount = playerController.Current.boards.Count;
        transform.localPosition = new Vector3(-0.1f * (surfboardCount - 1) + 1f, transform.localPosition.y, transform.localPosition.z);
        transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
      
    }

    // Start is called before the first frame update
    private void Start()
    {
        Current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
