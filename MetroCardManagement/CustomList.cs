using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class CustomList<Type>:IEnumerable,IEnumerator
    {
        //Filed
        private int _count;
        private int _capacity;
        private Type []_array;

        //Property
        public int Count { get{return _count;} }
        public int  Capacity { get{return _capacity;} }

        public Type this[int index]
        {
            get {return _array[index];}
            set {_array[index]=value;}
        }

        
        //Constructor
        public CustomList()
        {
            _count=0;
            _capacity=4;
            _array=new Type[_capacity];
        }
        public CustomList(int size)
        {
            _count=0;
            _capacity=size;
            _array=new Type[_capacity];
        }

        // Add Method
        public void Add(Type element)
        {
            if(_count==_capacity)
            {
                GrowSize();
            }
            _array[_count]=element;
            _count++;
        }

        // GrowSize Method
        void GrowSize()
        {
            _capacity=_capacity*2;
            Type []temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;

        }

        int position;
        // GetEnumerator Method
        public IEnumerator GetEnumerator()
        {
             position=-1;
             return (IEnumerator)this;
        }

        // MoveNext Method
        public bool MoveNext()
        {
            if(position<_count-1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }

        // Reset Method
        public void Reset()
        {
            position=-1;
        }

       //Property
        public object Current {get {return _array[position];}}
        
        
        
    }
}