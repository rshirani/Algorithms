using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TrieNode
    {
        public char Val { get; set; }
        public Dictionary<char, TrieNode> Children{ get; private set; }
        public bool IsLeaf { get; set; }

        public TrieNode(char ch, Dictionary<char,TrieNode> children)
        {
            Val = ch;
            Children = children;
            IsLeaf = false;
        }

        public TrieNode(char ch, bool isLeaf = false)
        {
            Val = ch;
            Children = new Dictionary<char, TrieNode>();
            IsLeaf = isLeaf;
        }

        public TrieNode()
        {

        }
    }
}
