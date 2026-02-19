using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

public class Program
{
    public static void arraylist()
    {
        ArrayList arlist = new ArrayList();

        // store the item as a object j
        arlist.Add(10);
        arlist.Add("Hello");
        arlist.Add(3.14);
        arlist.Add(true);


        Console.WriteLine("item within the arrlist");
        foreach(var item in arlist)
        {
            Console.WriteLine(item);
        }

        // has to go through boxing and unboxing 

        int num =(int)arlist[0];
        Console.WriteLine("after the casting input : "+num);


        // differenet properties 
        // 1. count 
        Console.WriteLine("COUNT OF ARRLIST :"+arlist.Count);
        // 2. capacity 
        Console.WriteLine("capacity of the arraylist:"+arlist.Capacity);

        // important method 

        //1 add (add value to the end )
        arlist.Add(20);

        ArrayList ar2 = new ArrayList(){1,2,3,4,5};

        // 2. add range used when to add a new arraylist
        arlist.AddRange(ar2);
        Console.WriteLine("after addrange");
        foreach(var item in arlist)
        {
            Console.WriteLine(item);
        }

        // 3 . to insert a number at a particular place 
        arlist.Insert(2,"hello");
        foreach(var item in arlist)
        {
            Console.WriteLine(item);
        }

        ArrayList ar3 = new ArrayList(){'h',11,'j'};
        // 4. insertRange to insert a whole arrylist
        arlist.InsertRange(3,ar3);
        foreach(var item in arlist)
        {
            Console.WriteLine(item);
        }

        //5. remove 
        arlist.Remove(10);

        //6. removeat()
        arlist.RemoveAt(0);

        //7. removerange()
        arlist.RemoveRange(2,5);

        //8.contains
        Console.WriteLine("tells whether the item is there :"+arlist.Contains(10));

        //9.indexof 
        Console.WriteLine("tells the INDEX OF THE  item :"+arlist.IndexOf("Hello"));
        
        //10 .LastIndexOf()
        Console.WriteLine("tell the last occurence of the object :"+arlist.LastIndexOf("Hello"));

        //11 . sort()
        ArrayList nums = new ArrayList(){5,2,9};
        nums.Sort(); // must be same type

        //12. Reverse()
        nums.Reverse();

        //13. Arraylist to array 
        object [] arr =nums.ToArray();
        foreach(var numb in arr)
        {
            Console.WriteLine(numb);
        }
    }

    public static void hashtable()
    {
        Hashtable ht = new Hashtable();

        ht.Add("Id", 101);
        ht.Add("Name", "Shubhankar");
        ht.Add("Age", 25);

        Console.WriteLine(ht["Name"]);   // Output: Shubhankar

        // important methods
        // adding in the list 
        // 1 .using add
        ht.Add("city","Delhi");

        // using indexer 
        ht["Country"]="India"; // could be used as update and adding 

        // 2. Remove()
        ht.Remove("Age");

        // 3. Containskey 
        bool exists = ht.ContainsKey("Name");

        // 4. ContainsValue()
        bool valex = ht.ContainsValue("India");

        // 5. clear 
        ht.Clear();

        // property 
        Console.WriteLine(ht.Count);

        foreach(DictornaryEntry val in ht)
        {
            Console.WriteLine(val.Value+" "+val.Key);
        }

        foreach(var key in ht.keys)
        {
            Console.WriteLine(key +":"+ht[key]);
        }
    }

    public static void stack()
    {
        stack s1 = new Stack();
        stack<int> s2=new Stack<int>();
        s2.Push(10);
        s2.Push(20);
        s2.Push(30);

        Console.WriteLine(s2.Peek());
        Console.WriteLine(s2.Pop());
        Console.WriteLine(s2.Peek());

        // property 

        //clear
        s2.clear();

        //contains
        bool exist = s1.Constains(30);

        int[] ar = s2.ToArray();

        // cant or shouldnt perform pop on a empty stack

        if(s1.Count > 0)
        {
            s1.Pop();
        }
    }

    public static void queue()
    {
        Queue<int> q1 = new Queue<int>();
        q1.Enqueue(10);
        q1.Enqueue(20);
        q1.Enqueue(30);

        Console.WriteLine(q1.Peek());
        Console.WriteLine(q1.Dequeue());
        Console.WriteLine(q1.Dequeue());

        // search contains
        bool ex = q1.Contains(20);

        int[]arr = q1.ToArray();

        // cant dequeue on a empty queue 
        // cant peek on a empty queu 
    }
    public static void list()
    {
        List<int> l1 = new List<int>(){1,2,3,4,5,6};
        Console.WriteLine(l1.Count);
        l1.Add(40);
        l1.AddRange(new List<int>{50,60});
        l1.Insert(1,90);
        l1.Insert(2,30);
        l1.InsertRange(2,new List<int>{6,7});
        l1.Remove(20);
        l1.RemoveAt(0);
        l1.RemoveAll(x => x>50);
        l1.Clear();
        bool ex = l1.Contains(20);
        int index = l1.IndexOf(30);
        l1.Sort();
        l1.Reverse();
        int []arr=l1.ToArray();
        //If reference type:

        List<string> list = new List<string>();
        list.Add(null);   // ✔ allowed


        //If value type:

        List<int> list = new List<int>();
        list.Add(null);  // ❌ error
        // insert at end
        l1.Insert(l1.Count,100);
    }

    public static void hashset()
    {
        // collection of the unique element 
        HashSet<int> set = new HashSet<int>();

        set.Add(10);
        set.Add(20);
        set.Add(10);  // Duplicate

        foreach (var item in set)
        {
            Console.WriteLine(item);
        }
        // add also return bool 
        set.Remove(10);
        bool exists = set.Contains(20);
        set.Clear();
        Console.WriteLine(set.Count);

        // set operation
        //union 
        //set1.UnionWith(set2);
        //intersectwith
        //set1.IntersectWith(set2);
        //exceptwith()
        //set1.ExceptWith(set2);

        // if need sorted the use
        //sortedset<T>
    }
    public static void Main()
    {
        arraylist();
        hashtable();
        queue();
        list();
        hashSet();
    }
}