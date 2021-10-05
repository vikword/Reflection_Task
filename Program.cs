using System;
using System.Reflection;

namespace Reflection_Task
{
    static class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(TestClass);
            var instance = Activator.CreateInstance(type) as TestClass;


            #region Получаем данные о типе

            ListVariosStats(instance);
            ListMethods(instance);
            ListFields(instance);
            ListProps(instance);
            ListConstructors(instance);

            #endregion

            #region Обращение к закрытым членам

            Console.WriteLine(new string('-', 60));

            MethodInfo method3 = type.GetMethod("Method3", BindingFlags.Instance | BindingFlags.NonPublic);
            method3.Invoke(instance, new object[] { "Hello", " World!" });

            Console.WriteLine(new string('-', 30));

            FieldInfo mystring = type.GetField("_mystring", BindingFlags.Instance | BindingFlags.NonPublic);
            mystring.SetValue(instance, "Привет Мир!");

            Console.WriteLine(instance.MyString);

            Console.WriteLine(new string('-', 30));

            FieldInfo myint = type.GetField("_myint", BindingFlags.Instance | BindingFlags.NonPublic);
            myint.SetValue(instance, 10);

            Console.WriteLine(instance.MyInt);

            #endregion
        }
        private static void ListVariosStats(TestClass instance)
        {
            Console.WriteLine(new string('-', 30) + " Информация о MyClass" + "\n");
            Type t = instance.GetType();

            Console.WriteLine($"Полное имя:             {t.FullName}");
            Console.WriteLine($"Базовый класс:          {t.BaseType}");
            Console.WriteLine($"Абстрактный:            {t.IsAbstract}");
            Console.WriteLine($"Это COM Объект:         {t.IsCOMObject}");
            Console.WriteLine($"Запрещено Наслелование: {t.IsSealed}");
            Console.WriteLine($"Это Class:              {t.IsClass}");
        }
        private static void ListMethods(TestClass instance)
        {
            Console.WriteLine(new string('-', 30) + " Методы класса MyClass" + "\n");

            Type t = instance.GetType();
            MethodInfo[] mi = t.GetMethods(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.DeclaredOnly);

            foreach (MethodInfo m in mi)
            {
                Console.WriteLine($"Method: {m.Name}");
            }
        }
        private static void ListFields(TestClass instance)
        {
            Console.WriteLine(new string('-', 30) + " Поля класса MyClass" + "\n");

            Type t = instance.GetType();
            FieldInfo[] fi = t.GetFields(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.NonPublic);

            foreach (FieldInfo f in fi)
            {
                Console.WriteLine($"Field: {f.Name}");
            }
        }
        private static void ListProps(TestClass instance)
        {
            Console.WriteLine(new string('-', 30) + " Свойства класса MyClass" + "\n");

            Type t = instance.GetType();
            PropertyInfo[] pi = t.GetProperties();

            foreach (PropertyInfo p in pi)
            {
                Console.WriteLine($"Property: {p.Name}");
            }
        }
        private static void ListConstructors(TestClass instance)
        {
            Console.WriteLine(new string('-', 30) + " Конструкторы класса MyClass" + "\n");

            Type t = instance.GetType();
            ConstructorInfo[] ci = t.GetConstructors();

            foreach (ConstructorInfo c in ci)
            {
                Console.WriteLine($"Constructor: {c.Name}");
            }
        }
    }
}
