using System;
using System.Collections.Generic;
using System.Text;

namespace NetBase.Equal
{
    class EqualDifference
    {
        //https://blog.csdn.net/wuchen_net/article/details/5409327

        /*
         *1. ReferenceEquals, == , Equals 
        Equals , == , ReferenceEquals都可以用于判断两个对象的个体是不是相等。 
        
        a) ReferenceEquals 
        ReferenceEquals是Object的静态方法，用于比较两个引用类型的对象是否是对于同一个对象的引用。对于值类型它总是返回false。（因为Box以后的对象总是不同的，hehe） 
        
        b) ==是一个可以重载的二元操作符,可以用于比较两个对象是否相等。 
        对于内置值类型，==判断的是两个对象的代数值是否相等。它会根据需要自动进行必要的类型转换，并根据两个对象的值是否相等返回true或者false。
        
        而对于用户定义的值类型，如果没有重载==操作符，==将是不能够使用的。
             
             */

        private bool _judge = false;
        public void demo1()
        {
            int a = 100;
            double b = 100;
            _judge = a == b; // true

        }
        /*对于引用类型，== 默认的行为与ReferenceEquals的行为相同，仅有两个对象指向同一个Reference的时候才返回true。但是.NET Framework中的类很多对==进行了重载，
         * 例如String类的==与Equals的行为相同，判断两个字符串的内容是否相等。所以在应用中，对于 系统定义的引用类型建议不要使用==操作符，以免程序出现与预期不同的运行结果。
         * 
         c) Equals 作为Object内置方法，Equals支持对于任意两个CTSCommon Type System对象的比较。 Equals它有静态方法和可重载的一个版本，下面的程序片断解释了这两个方法的用法， 
         这两个版本的结果完全相同，如果用户重载了Equals，调用的都是用户重载后的Equals。Equals的静态方法的好处是可以不必考虑用于比较的对象是否为null。

        Equals方法对于值类型和引用类型的定义不同，对于值类型，类型相同，并且数值相同(对于struct的每个成员都必须相同)，则Equals返回 true,否则返回false。
        而对于引用类型，默认的行为与ReferenceEquals的行为相同，仅有两个对象指向同一个Reference的时 候才返回true。可以根据需要对Equals进行重载，例如String类的Equals用于判断两个字符串的内容是否相等。 
         */

        public void demo2()
        {
            //StringBuilder 类
            //表示可变字符字符串。无法继承此类。


            StringBuilder a = new StringBuilder();
            a.Append("the test a");
            string s1 = a.ToString();
            string s2 = "the test a";

            _judge = s1 == s2; // true;
            _judge = Object.Equals(s1, s2); // true
            _judge = Object.ReferenceEquals(s1, s2); // false
        }

        /*
         * 注：对于String类，直接声明s1 = “the test a”的话，输出结果将包含 "ReferenceEquals returns true"， 
            因为默认的，String对于声明的相同的字符串在堆上只保留一个Copy，所以s1与s2将会指向相同的Reference
         */


        /*5.3.1 引用类型的相等比较*/
        /*
         1. ReferenceEquals()方法
        ReferenceEquals()是一个静态方法，测试两个引用是否指向类的同一个实例，即两个引用是否包含内存中的相同地址。
        作为静态方法，它不能重写，所以只能使用System.Object的实现代码。如果提供的两个引用指向同一个对象实例，
        ReferenceEquals()总是返回true，否则就返回false。但是它认为null等于null：
         */
        public void demo3()
        {
            var x = new User();
            var y = new User();

            _judge = Object.ReferenceEquals(null, null); // true
            _judge = Object.ReferenceEquals(x, null); // false
            _judge = Object.ReferenceEquals(x, y); // false, because x and y point to different objects
        }


        /*
         2. 虚拟的Equals()方法

        Equals()虚拟版本的System.Object实现代码也比较引用。但因为这个方法是虚拟的，所以可以在自己的类中重写它，按值来比较对象。
        特别是如果希望类的实例用作字典中的键，就需要重写这个方法，以比较值。否则，根据重写Object.GetHashCode()的方式，包含对象的字典类要么不工作，要么工作的效率非常低。
        在重写Equals()方法时要注意，重写的代码不会抛出异常。这是因为如果抛出异常，字典类就会出问题，一些在内部调用这个方法的.NET基类也可能出问题。
        
        3. 静态的Equals()方法
        Equals()的静态版本与其虚拟实例版本的作用相同，其区别是静态版本带有两个参数，并对它们进行相等比较。这个方法可以处理两个对象中有一个是null的情况，因此，
        如果一个对象可能是null，这个方法就可以抛出异常，提供了额外的保护。静态重载版本首先要检查它传送的引用是否为null。如果它们都是null，就返回true(因为null与null相等)。
        如果只有一个引用是null，就返回false。如果两个引用都指向某个对象，它就调用Equals()的虚拟实例版本。这表示在重写Equals()的实例版本时，其效果相当于也重写了静态版本。[Page]
        
        4. 比较运算符＝＝
        最好将比较运算符看作是严格值比较和严格引用比较之间的中间选项。在大多数情况下，下面的代码：
        表示比较引用。但是，如果把一些类看作值，其含义就会比较直观。在这些情况下，最好重写比较运算符，以执行值的比较。后面将讨论运算符的重载，
        但显然它的一个例子是System.String类，Microsoft重写了这个运算符，比较字符串的内容，而不是它们的引用。
         */


        /*5.3.2 值类型的相等比较*/








    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
