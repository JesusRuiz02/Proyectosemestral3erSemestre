using UnityEngine;

public class Miniboss_AttackPlayerAnim : StateMachineBehaviour
{
    [SerializeField] private Miniboss _miniboss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _miniboss = GameObject.FindWithTag("MiniBoss").GetComponent<Miniboss>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _miniboss.AttackPlayer();
    }
}
