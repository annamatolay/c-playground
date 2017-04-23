using System;

namespace PlayGround
{
    public class Logger
    {
        public static void Log(string msg)
        {
            Console.WriteLine(">>> StackMsg: " + msg + " <<<");
        }
    }

    public class MyStack<T>
    {
        private int _topIndex;
        private readonly int _stackLimit;
        private  T[] _stack;

        public MyStack(int limit)
        {
            if (limit <= 0)
                throw new ArgumentOutOfRangeException();
            _topIndex = 0;
            _stackLimit = limit;
            _stack = new T[_stackLimit];
        }

        // return type because of liquid code
        public MyStack<T> Push(T item)
        {
            if (_topIndex >= _stackLimit)
            {
                throw new Exception("StackOverFlow!");
            }
            _stack[_topIndex] = item;
            ++_topIndex;
            Logger.Log("Succesfully pushed: "+item+"!");
            return this;
        }

        public T Pop()
        {
            CheckEmpty();
            --_topIndex;
            var item = _stack[_topIndex];
            Logger.Log("Succesfully popped: "+item+"!");
            return item;
        }

        public MyStack<T> Peek()
        {
            string item;
            try
            {
                CheckEmpty();
                item = _stack[_topIndex - 1].ToString();
            }
            catch (Exception e)
            {
                item = "not exist";
            }
            Logger.Log("Top item: "+item+"!");
            return this;
        }

        public MyStack<T> Clear()
        {
            _stack = new T[_stackLimit];
            _topIndex = 0;
            return this;
        }

        private void CheckEmpty()
        {
            if (_topIndex == 0)
                throw new Exception("StackIsEmpty!");
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            // Examples
            MyStack<int> myStack;
            try
            {
                myStack = new MyStack<int>(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            myStack = new MyStack<int>(2);
            myStack.Push(10)
                .Push(20)
                .Peek();
            try
            {
                myStack.Push(30);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            myStack.Clear();
            try
            {
                myStack.Peek()
                    .Pop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}