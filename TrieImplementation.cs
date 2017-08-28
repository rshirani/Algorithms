public class TrieNode {
    char c;
    public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    public bool isLeaf;
 
    public TrieNode() {}
 
    public TrieNode(char c){
        this.c = c;
    }
}

public class Trie {
    private TrieNode root;
 
    public Trie() {
        root = new TrieNode();
    }
 
    // Inserts a word into the trie.
    public void Add(String word) {
        var children = root.children;
 
        for(int i=0; i<word.Length; i++){
            char c = word[i];
 
            TrieNode t;
            if(children.ContainsKey(c)){
                    t = children[c];
            }else{
                t = new TrieNode(c);
                children.Add(c, t);
            }
 
            children = t.children;
 
            //set leaf node
            if(i==word.Length-1)
                t.isLeaf = true;    
        }
    }
 
    // Returns if the word is in the trie.
    public bool Search(String word) {
        TrieNode t = SearchNode(word);
 
        if(t != null && t.isLeaf) 
            return true;
        else
            return false;
    }
 
    // Returns if there is any word in the trie
    // that starts with the given prefix.
    public bool StartsWith(String prefix) {
        if(SearchNode(prefix) == null) 
            return false;
        else
            return true;
    }
    
    public string GetRoot(String str)
    {
        var children = root.children;
        TrieNode t = null;
        
        for(int i = 0; i <str.Length; i++)
        {
            char c = str[i];
            
            if(children.ContainsKey(c)){
                t = children[c];
                children = t.children;
            }
            else
            {
                break;
            }

            if (t != null && t.isLeaf)
                return str.Substring(0, i+1);
        }
        
        return string.Empty;
    }
 
    private TrieNode SearchNode(String str){
        var children = root.children; 
        TrieNode t = null;
        for(int i=0; i<str.Length; i++){
            char c = str[i];
            if(children.ContainsKey(c)){
                t = children[c];
                children = t.children;
            }else{
                return null;
            }
        }
 
        return t;
    }
}
