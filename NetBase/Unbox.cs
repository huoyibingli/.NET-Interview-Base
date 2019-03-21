using System;
using System.Collections.Generic;
using System.Text;

namespace NetBase
{
    class Unbox
    {
        /*
         * 拆箱与装箱就是值类型与引用类型的转换，她是值类型和引用类型之间的桥梁，
         * 他们可以相互转换的一个基本前提就是上面所说的：Object是.NET中的万物之源
         */
        public void Sample()
        {
            int x = 1023;
            object o = x; //装箱
            int y = (int)o; //拆箱
        }
        /*
         * 装箱：值类型转换为引用对象，一般是转换为System.Object类型或值类型实现的接口引用类型；
         * 拆箱：引用类型转换为值类型，注意，这里的引用类型只能是被装箱的引用类型对象；
         */

        /*
         * 由于值类型和引用类型在内存分配的不同，从内存执行角度看，
         * 拆箱与装箱就势必存在内存的分配与数据的拷贝等操作，这也是装箱与拆箱性能影响的根源。
         */
    }
}
