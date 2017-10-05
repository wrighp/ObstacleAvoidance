using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AgentMovement))]
public class CollisionPrediction : MonoBehaviour {

    AgentMovement my_agent;

    void Start () {
        my_agent = GetComponent<AgentMovement>();
    }

    public float get_closest_time_of_approach_to (AgentMovement other_agent) {

        Vector3 w_0 = my_agent.transform.position - other_agent.transform.position;
        Vector3 u = my_agent.rb.velocity;
        Vector3 v = other_agent.rb.velocity;


        float time_at_cpa;

        if ((u-v).magnitude == 0f) {
            time_at_cpa = 0f;
        }
        else {
            time_at_cpa = (Vector3.Dot(-w_0,(u-v)))/(Mathf.Pow((u-v).magnitude, 2));
        }

        return time_at_cpa;
    }

    public Vector3 get_position_at_time_of_approach_to (AgentMovement other_agent) {
        Vector3 u = my_agent.rb.velocity;
        Vector3 v = other_agent.rb.velocity;
        float time_at_cpa = get_closest_time_of_approach_to(other_agent);
        return (my_agent.transform.position + (u*time_at_cpa));
    }

    public float get_distance_at_time_of_approach_to (AgentMovement other_agent) {
        
        Vector3 u = my_agent.rb.velocity;
        Vector3 v = other_agent.rb.velocity;

        float time_at_cpa = get_closest_time_of_approach_to(other_agent);

        return ((my_agent.transform.position + (u*time_at_cpa)) - (other_agent.transform.position + (v*time_at_cpa))).magnitude;
    }

}
