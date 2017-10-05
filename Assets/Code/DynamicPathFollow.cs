using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AgentMovement))]
public class DynamicPathFollow : MonoBehaviour {

	public Path my_path;
    int path_index = 0;
    float arrival_radius = 1f;


	protected AgentMovement agent;
    CollisionPrediction coll_pred;
    public AgentMovement coll_test;

	Vector2 targetPosition = Vector2.zero;
	protected virtual void Awake(){
		agent = GetComponent<AgentMovement> ();
        coll_pred = GetComponent<CollisionPrediction>();
	}

	protected virtual void Update () {
		if (my_path == null) {
			return;
		}

        targetPosition = my_path.points[path_index].position;
		agent.targetDirection = (Vector3)(targetPosition) -  transform.position;


        if (Vector3.Distance(transform.position, targetPosition) < arrival_radius) {
            path_index = (path_index + 1)%my_path.points.Count;
        }
	}

	void LateUpdate(){
		PlayerDebug.DrawLine (transform.position,  my_path.points[path_index].position, Color.red);
	}

    void OnDrawGizmos () {
        if (coll_pred) {

            if (Vector3.Dot(coll_pred.get_position_at_time_of_approach_to(coll_test)-transform.position, agent.rb.velocity) > 0) {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, coll_pred.get_position_at_time_of_approach_to(coll_test));
                Gizmos.DrawWireSphere(coll_pred.get_position_at_time_of_approach_to(coll_test), coll_pred.get_distance_at_time_of_approach_to(coll_test));
            }
        }
    }
}
