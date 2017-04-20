using System;

namespace PlayGround
{
    public class Stack
    {
        private int _topIndex;
        private readonly int _stackLimit;
        private readonly int[] _stack;

        public Stack(int num)
        {
            if (num <= 0)
                throw new ArgumentOutOfRangeException();
            _topIndex = 0;
            _stackLimit = num;
            _stack = new int[_stackLimit];
        }

        public void Push(int num)
        {
            if (_topIndex >= _stackLimit)
            {
                throw new Exception("StackOverFlow!");
            }
            _stack[_topIndex] = num;
            ++_topIndex;
            Console.WriteLine(">>>StackMsg: Succesfully pushed: "+num+"!");
        }

        public int Pop()
        {
            if (_topIndex == 0)
                throw new Exception("StackIsEmpty!");
            --_topIndex;
            Console.WriteLine(">>>StackMsg: Succesfully popped!");
            return _stack[_topIndex];
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Stack stack;
            try
            {
                stack = new Stack(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            stack = new Stack(2);
            stack.Push(10);
            stack.Push(20);
            try
            {
                stack.Push(30);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            try
            {
                Console.WriteLine(stack.Pop());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}