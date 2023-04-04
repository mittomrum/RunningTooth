using UnityEngine.AI;
using UnityEngine;

public class Move : MonoBehaviour
{
    private NavMeshAgent agent;
    private LineRenderer lineRenderer;
    [SerializeField] private GameObject endPoint;
    [SerializeField] private float lineWidth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        lineRenderer = GetComponent<LineRenderer>();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
                endPoint.transform.position = hit.point;
                lineRenderer.enabled = true;
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);
                endPoint.SetActive(true);
            }
        }

        lineRenderer.SetPosition(0, transform.position);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            lineRenderer.enabled = false;
            endPoint.SetActive(false);
        }
    }
}
