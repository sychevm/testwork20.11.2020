using UnityEngine;

class BoostSpeed : InterectBoost
{

    bool _use;

    protected override void Interect(Character character)
    {
        if (_use) return;

        _use = true;

        character.SetSpeed(character.Speed + 5);
        Destroy(gameObject);
    }
}
