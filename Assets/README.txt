1) What did you do for avoiding a group of agents? What are the weights of path following and evade behavior?
For cone check, agents actively steer 90 degrees away from the closest other agent in the cone. If there is no agent in this cone to avoid, it follows the path as normal. (binary weighting)
For Collision Prediction the agents steer away from the closest predicted collision spot. If all of those predictions are too far than it also follows the path as normal. (binary weighting)

2) What are the differences in cone check and collision prediction’s performances?

Cone check agents can get stuck turning away from each other occasionally when they hit walls. Collision prediction works much better because if a character is within the cone, but moving away it doesn't actively avoid it.
This allows collision prediction agents to move with their own groups much more easily, unlike cone check agents that actively avoid agents that are in front of them going in the same direction.