using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fantasy_card_game_lib
{
    public class ManaPool
    {
        public List<Mana> pool;
        public ManaPool()
        {
            pool = new List<Mana>();

        }
        public ManaPool(List<Mana> pool)
        {
            this.pool = pool;
        }
        public ManaPool(ManaPool manaPool)
        {
            pool = new List<Mana>(manaPool.pool);
        }
        public void Add(Mana mana)
        {
            pool.Add(mana);
        }
        public ManaPool Clone()
        {
            return new ManaPool(new List<Mana>(pool));
        }
        public bool Contains(Mana mana)
        {
            return pool.Contains(mana);
        }
        public bool Contains(ManaPool manaPool)
        {
            ManaPool manaPoolCopy = manaPool.Clone();
            foreach (Mana mana in pool)
            {
                if (!manaPoolCopy.pool.Remove(mana))
                    return false;
            }
            return true;
        }
        public bool Remove(Mana mana)
        {
            return pool.Remove(mana);
        }
        public ManaPool Remove(ManaPool manaPool)
        {
            ManaPool manaPoolCopy = manaPool.Clone();
            foreach (Mana mana in pool)
            {
                if (!manaPoolCopy.pool.Remove(mana))
                    return null!;
            }
            return manaPoolCopy;
        }
        public string ToString(string prefix = "", string separator = " ", string suffix = "")
        {
            return ListUtilities<Mana>.ToString(pool, prefix, separator, suffix);
        }
        public void Describe()
        {
            Console.WriteLine(ToString());
        }
    }
}
