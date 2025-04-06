using System.Collections.Generic;
using System.Linq;
using Project.EntenEller.Base.Scripts.Advanced.GameObjects;
using Project.EntenEller.Base.Scripts.Cache.Components.Master;
using UnityEngine;

namespace Project.Scripts.Spawn
{
    public class SpawnRandom : EEBehaviour
    {
        [SerializeField] private int amountItem;
        [SerializeField] private EEGameObject elements;

        private List<SpawnElement> spawnElements;
        private int currentItem;
        protected override void EEAwake()
        {
            base.EEAwake();
            spawnElements = elements.GetComponentsInChildren<SpawnElement>().ToList();
            spawnElements.ForEach(n => n.Disable());

        }

        public void Spawn()
        {
            if (amountItem > spawnElements.Count)
            {
                Debug.LogWarning("Amount bigger elements");
                amountItem = spawnElements.Count;
            }
            currentItem = amountItem;

            while (currentItem > 0)
            {
                var randomElement = spawnElements[Random.Range(0, spawnElements.Count)];
                randomElement.Active();
                spawnElements.Remove(randomElement);
                currentItem--;
            }
        }
    }
}
