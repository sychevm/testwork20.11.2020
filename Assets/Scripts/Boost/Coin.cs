using UnityEngine;

class Coin : InterectBoost
{
    public static System.Action interect;

    void Update()
    {
        transform.Rotate(Vector3.forward *90f* Time.deltaTime);
    }

    protected override void Interect(Character character)
    {
        interect();
        Destroy(gameObject);
    }
}
