using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    /// <summary>
    /// Implemeting a TRIE with Insert, Search. This can also be modified to include StartWith and Prefix or Search the exact Word.
    /// </summary>
    public class Trie
    {
        public TrieNode Root { get; private set; }

        public void Insert(string str)
        {
            Dictionary<char, TrieNode> children = Root.Children;

            for(int i = 0; i<str.Length; i++)
            {
                var ch = str[i];
                TrieNode t;

                if(!children.TryGetValue(ch, out t))
                {
                    t = new TrieNode(ch);
                    children.Add(ch, t);
                }

                children = t.Children;

                if(i == str.Length-1)
                {
                    t.IsLeaf = true;
                }
            }
        }

        public bool Search(string str)
        {
            Dictionary<char, TrieNode> children = Root.Children;

            for(int i = 0; i<str.Length; i++)
            {
                char ch = str[i];
                TrieNode t;

                if(!children.TryGetValue(ch, out t))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
