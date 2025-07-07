using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace LinqExample
{
    public class LinqTest : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;

        private void Awake()
        {
            List<Enemy> enemies = new List<Enemy>();

            enemies.Add(new Enemy("Igor", 220));
            enemies.Add(new Enemy("Alex", 50));
            enemies.Add(new Enemy("Dima", 40));
            enemies.Add(new Enemy("Igor", 30));
            enemies.Add(new Enemy("Pasha", 20));
            enemies.Add(new Enemy("Sasha", 10));
            enemies.Add(new Enemy("Sasha", 34));


            IEnumerable<IGrouping<string, Enemy>> groupedEnemies = enemies.GroupBy(enemy => enemy.Name);
            

            foreach(IGrouping<string, Enemy> group in groupedEnemies)
            {
                Debug.Log($"Group: {group.Key}");

                foreach(Enemy enemy in group)
                {
                    Debug.Log($"Enemy: {enemy.Name} Damage: {enemy.Damage}");
                }
            }
            
        }


    }
    
    public class Enemy
    {

        public string Name { get; private set; }
        public int Damage { get; private set; }


        public Enemy(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
            
    }
    

}

