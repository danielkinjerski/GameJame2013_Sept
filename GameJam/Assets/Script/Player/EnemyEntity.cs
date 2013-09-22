using UnityEngine;
using System.Collections;

public class EnemyEntity : BaseEntity 
{
    public StateMachine<EnemyEntity> FSM = new StateMachine<EnemyEntity>();

    public delegate void OnDie();
    public event OnDie OnDied;

    public Transform target;
    public float seekThreshold = 0;
    public float attackThreshold = 0;
	
	public Material infected;
	public int maxHealth = 100;
	public int health;
	public float regenHealthTime = 1f;
	public int regenAmount = 10;
	
	public float destroyTime = 5f;

    public bool invincible = false;

    public void Start()
    {
        base.Start();
        FSM.Configure(this, Idle.Instance);
		
		health = maxHealth;
		StartCoroutine(Regenerate());

        GameManager gm = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
        OnDied += gm.CellDie;

    }


    public override Vector2 InputMovement()
    {
        if (FSM.CurrentState == Seek.Instance)
        {
            Vector3 targetDir = (target.position - trans.position).normalized;
            return new Vector2(targetDir.x, targetDir.z);
        }
        else
        {
            //print("stop");
            return Vector2.zero;
        }
    }

    public void Update()
    {
        FSM.Update();
    }
    


    public float CheckDistanceToTarget()
    {
        if (target != null)
        {
            return (target.position - trans.position).magnitude;
        }
        return seekThreshold;
    }
	
	public void ApplyDamage(int damage)
	{
        if (health <= 0 || invincible)
            return;

		health -= damage;

        if (health <= 0)
        {
            if (OnDied != null)
            {
                OnDied();
            }
            this.gameObject.renderer.material = infected;
            Timed t = GetComponent<Timed>();
            t.m_Mat = this.gameObject.renderer.material;
            t.enabled = true;
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(destroyCell());
        }

	}
	
	IEnumerator Regenerate()
	{
		while(true)
		{
			yield return new WaitForSeconds(regenHealthTime);
			health += regenAmount;
			
			if(health > maxHealth)
			{
				health = maxHealth;
			}
		}
	}
	
	IEnumerator destroyCell()
	{
		yield return new WaitForSeconds(destroyTime);
		Destroy(this.gameObject);
	}
}
