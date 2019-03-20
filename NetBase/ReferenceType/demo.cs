using System;
using System.Collections.Generic;
using System.Text;

namespace NetBase.ReferenceType
{
    class demo
    {
        /*
        1. 值类型和引用类型的区别？

        2. 结构和类的区别？
        
        3. delegate是引用类型还是值类型？enum、int[]和string呢？
        
        4. 堆和栈的区别？
        
        5. 什么情况下会在堆（栈）上分配数据？它们有性能上的区别吗？
        
        6.“结构”对象可能分配在堆上吗？什么情况下会发生，有什么需要注意的吗？
        
        7. 理解参数按值传递？以及按引用传递？
        
        8. out 和 ref 的区别与相同点？
        
        9. C#支持哪几个预定义的值类型？C#支持哪些预定义的引用类型？
        
        10. 有几种方法可以判定值类型和引用类型？
        
        11. 说说值类型和引用类型的生命周期？
        
        12. 如果结构体中定义引用类型，对象在内存中是如何存储的？例如下面结构体中的class类 User对象是存储在栈上，还是堆上？
         */

        //CLR

        /*
         值类型 数字类型，字符类型，bool，enum，struct
         引用类型 object,string,class,interface,int[],delegate

         Stack 栈：线程栈，由操作系统管理，存放值类型、引用类型变量（就是引用对象在托管堆上的地址）。
         栈是基于线程的，也就是说一个线程会包含一个线程栈，线程栈中的值类型在对象作用域结束后会被清理，效率很高。
         GC Heap托管堆：进程初始化后在进程地址空间上划分的内存空间，存储.NET运行过程中的对象，
         所有的引用类型都分配在托管堆上，托管堆上分配的对象是由GC来管理和释放的。托管堆是基于进程的
        
        值类型一直都存储在栈上面吗？所有的引用类型都存储在托管堆上面吗？

        1.单独的值类型变量，如局部值类型变量都是存储在栈上面的；

        2.当值类型是自定义class的一个字段、属性时，它随引用类型存储在托管堆上，此时她是引用类型的一部分；

        3.所有的引用类型肯定都是存放在托管堆上的。

        4.还有一种情况，同上面题目12，结构体（值类型）中定义引用类型字段，结构体是存储在栈上，其引用变量字段只存储内存地址，指向堆中的引用实例。
        
         */


        /*
         将值类型的变量赋值给另一个变量（或者作为参数传递），会执行一次值复制。
         将引用类型的变量赋值给另一个引用类型的变量，它复制的值是引用对象的内存地址，因此赋值后就会多个变量指向同一个引用对象实例。
         */

        public void test()
        {
            int v1 = 0;
            int v2 = v1;
            v2 = 100;
            Console.WriteLine("v1=" + v1); //输出：v1=0
            Console.WriteLine("v2=" + v2); //输出：v2=100

            User u1 = new User();
            u1.Age = 0;
            User u2 = u1;
            u2.Age = 100;
            Console.WriteLine("u1.Age=" + u1.Age); //输出：u1.Age=100
            Console.WriteLine("u2.Age=" + u2.Age); //输出：u2.Age=100，因为u1/u2指向同一个对象

        }
        private void DoTest(int a)
        {
            a *= 2;
        }

        private void DoUserTest(User user)
        {
            user.Age *= 2;
        }
        
        public void DoParaTest()
        {
            int a = 10;
            DoTest(a);
            Console.WriteLine("a=" + a); //输出：a=10
            User user = new User();
            user.Age = 10;
            DoUserTest(user);
            Console.WriteLine("user.Age=" + user.Age); //输出：user.Age=20
        }
        
        /*
         按引用传递的两个主要关键字：out 和 ref不管值类型还是引用类型，
         按引用传递的效果是一样的，都不传递值副本，而是引用的引用（类似c++的指针的指针）。
         out 和 ref告诉编译器方法传递额是参数地址，而不是参数本身，理解这一点很重要。

         out 和 ref的主要异同：

         out 和 ref都指示编译器传递参数地址，在行为上是相同的；
         他们的使用机制稍有不同，ref要求参数在使用之前要显式初始化，out要在方法内部初始化；
         out 和 ref不可以重载，就是不能定义Method(ref int a)和Method(out int a)这样的重载，从编译角度看，二者的实质是相同的，只是使用时有区别；
             */
        private void DoTest(ref int a)
        {
            a *= 2;
        }

        private void DoUserTest(ref User user)
        {
            user.Age *= 2;
        }
        
        public void DoParaTest2()
        {
            int a = 10;
            DoTest(ref a);
            Console.WriteLine("a=" + a); //输出：a=20 ,a的值改变了
            User user = new User();
            user.Age = 10;
            DoUserTest(ref user);
            Console.WriteLine("user.Age=" + user.Age); //输出：user.Age=20
        }
    }




    internal class User
    {
        public int Age;
    }
}
