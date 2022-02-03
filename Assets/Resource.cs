using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    private Vector3 targetPoint;
    private Rigidbody2D rb;

    //Dropping
    private float dropSpeed = 2f;
    //Following the finalPoint
    private float minModifier = 3.5f;
    Vector2 velocity = Vector2.zero;
    bool isFollowing = false;
    FinalPointResources finalPoint;

    public int amount;
    ResourcesManager manager;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float randx = Random.Range(-1f, 1f)/3;
        float randy = Random.Range(-1f, 1f)/3;
        targetPoint = transform.position + new Vector3(randx, randy, transform.position.z);
        FindObjectOfType<ResourcesManager>().clickedResource.AddListener(ReceiveCommand);
    }

    private void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector2.Lerp(transform.position, finalPoint.transform.position, Time.deltaTime * minModifier);
            transform.localScale = Vector2.Lerp(transform.localScale, finalPoint.transform.localScale, Time.deltaTime * minModifier);
        }
        else if(transform.position != targetPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, Time.deltaTime * dropSpeed);
            dropSpeed -= Time.deltaTime;
        }
    }

    private void ReceiveCommand(FinalPointResources finalPoint)
    {
        if (isFollowing) return;
        this.finalPoint = finalPoint;
        StartCoroutine(SendResources());
    }

    private IEnumerator SendResources()
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        GetComponentInChildren<Animator>().enabled = true;
    }

    public void StartFollowing()
    {
        isFollowing = true;
    }

    public void ActivateFollow(FinalPointResources finalPoint)
    {
        this.finalPoint = finalPoint;
        GetComponentInChildren<Animator>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<FinalPointResources>())
        {
            CasteloStats.GetInstance().AddSeeds(amount);
            Destroy(gameObject);
        }
    }
}
