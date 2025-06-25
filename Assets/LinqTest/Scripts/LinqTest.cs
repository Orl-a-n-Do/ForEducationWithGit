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

            List<string> filteredEnemies = enemies
                .Where(enemy => enemy.Damage > 50)
                .Select(enemy => enemy.Name)
                .ToList();


            List<Enemy> sortedEnemies = enemies
                .OrderBy(enemy => enemy.Damage)
                .ToList();

            sortedEnemies.ForEach(enemy => Debug.Log(enemy.Name + " " + enemy.Damage));

            Debug.Log(enemies.First().Name);
            Debug.Log(enemies.Last().Name);   

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

