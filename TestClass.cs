using System;

namespace Reflection_Task
{
    class TestClass
    {
        private int _myint;
        private string _mystring = "Hello World!";

        public TestClass()
        {
        }
        public TestClass(int myint)
        {
            _myint = myint;
        }
        public int MyInt
        {
            get { return _myint; }
            set { _myint = value; }
        }
        public string MyString
        {
            get { return _mystring; }
        }
        public void Method1()
        {
        }
        protected void Method2()
        {
        }
        private void Method3(string str, string str2)
        {
            Console.WriteLine("Private метод");
            Console.WriteLine(str + str2);
        }
    }
}
