using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [Header("Wander")]
    [SerializeField] private Transform[] wanderPoints;
    public int wanderPointsCursor = 0;

    [Header("Player Detection")]
    [SerializeField] public Transform player = null;
    private GameObject playerGameObject;
    [SerializeField] private float sightRange;
    private float sightRangeDefault;
    private Vector2 playerDirection;

    [Header("Enemy Attributes")]
    public float moveSpeed;

    public void Awake()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    public void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        sightRangeDefault = sightRange;
    }

    public void Update()
    {
        if(Vector2.Distance(playerGameObject.transform.position,this.transform.position) < sightRange)
        {
            player = playerGameObject.transform;
            sightRange = sightRangeDefault * 1.5f;
        }
        else
        {
            player = null;
            sightRange = sightRangeDefault;
        }
    }

    #region -wander functions-
    public Transform nextWanderPoint()
    {
        wanderPointsCursor = ((wanderPointsCursor + 1) % wanderPoints.Length);
        return wanderPoints[wanderPointsCursor];
    }

    public Transform currentWanderPoint()
    {
        return wanderPoints[wanderPointsCursor];
    }
    #endregion


    public void OnDrawGizmos()
    {
        if (player != null)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.blue;
        }
        Gizmos.DrawWireSphere(this.transform.position, sightRange);

    }
}
