using JetBrains.Annotations;
using UnityEngine; 

    [UnityEngine.CreateAssetMenu(fileName = "Pickups", menuName = "Custom / Scriptable Objects / Pickups", order = 0)]
    public class Pickups : ScriptableObject
    {
        public string PickupName;
        public bool IsBooster;
        public int HpModifier;
        public float EffectDuration; 
        [CanBeNull] public Sprite PickupSprite;
        public string TextEffect; 

    }
