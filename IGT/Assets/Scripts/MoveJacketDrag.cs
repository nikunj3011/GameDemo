using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MoveJacketDrag : MonoBehaviour
{
    private Vector3 mousePosition;
    private Rigidbody2D rb;
    public Transform robotPos,jacketDefaultPos;
    private Vector2 direction;
    private float moveSpeed = 80f;
    public GameObject winUI;
    public float thresholdBetweenVector;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }
        else if(Input.GetMouseButtonUp(0)){
            float dist = Vector3.Distance(robotPos.position, transform.position);
            if (Mathf.Abs(dist) <= thresholdBetweenVector)
            {
                Debug.Log("move to robot pos"+dist);
                transform.position = robotPos.position;
                AudioManager.Instance.StopSounds();
                AudioManager.Instance.source.clip = AudioManager.Instance.win;
                AudioManager.Instance.PlaySounds();
                winUI.SetActive(true);

            }
            else
            {
                Debug.Log("move to default pos"+dist);
                transform.DOMove(jacketDefaultPos.position, 2.0f);
                AudioManager.Instance.StopSounds(); 
                AudioManager.Instance.source.clip = AudioManager.Instance.loss;
                AudioManager.Instance.PlaySounds();
                
            }
        }
        else {
            rb.velocity = Vector2.zero;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
