using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace L10
{
    public class Tree<T>
    {
        public T Data;
        public List<Tree<T>> children = new List<Tree<T>>();

        public static bool calledFirstTime = true;
        public Tree<T> CreateNode(T data)
        {
            Tree<T> newNode = new Tree<T>
            {
                Data = data
            };
            return newNode;
        }
        public void AppendChild(Tree<T> child)
        {
            children.Add(child);
        }
        public void RemoveChild(Tree<T> child)
        {
            children.Remove(child);
        }
        public void PrintTree(String level = "")
        {
            Console.WriteLine(level + Data);
            foreach (Tree<T> child in children)
            {
                child.PrintTree(level + "*");
            }
        }

        public void ForEachNode(Action<string> function)
        {
            if (calledFirstTime)
            {
                Console.Write(this.ToString() + " | ");
            }

            calledFirstTime = false;

            for (int i = 0; i < children.Count; i++)
            {
                function(children[i].ToString());
                children[i].ForEachNode(Program.AppendFunction);
            }
        }

            public void SetFirstTime()
            {
                calledFirstTime = true;
            }

    }
}