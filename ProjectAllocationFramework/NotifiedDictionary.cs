using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectAllocationFramework
{
    public delegate void CoreDataChangedEventHandler(object sender, CoreDataChangedEventArgs e);
    public class CoreDataChangedEventArgs : EventArgs
    {
        private CoreDataType key;
        private Guid keyGuid = Guid.NewGuid();
        public CoreDataChangedEventArgs(CoreDataType key)
        {
            this.key = key;
        }

        public virtual CoreDataType Key 
        { 
            get{
                return this.key;
            } 
        }

        public virtual Guid GUID
        {
            get
            {
                return keyGuid;
            }
        }
    }

    public class NotifiedDictionary : Dictionary<CoreDataType, object>
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        public new void Add(CoreDataType key, object value)
        {
            if (!base.ContainsKey(key))
            {
                base.Add(key, value);
            }
        }

        public new object this[CoreDataType Key]
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return base[Key];
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                base[Key] = value;
                this.InvokeCoreDataTypeNotification(Key);
            }
        }

        public void InvokeCoreDataTypeNotification(CoreDataType Type)
        {
            if (CoreDataChanged != null)
            {
                this.CoreDataChanged(this, new CoreDataChangedEventArgs(Type));
            }
        }

        public event CoreDataChangedEventHandler CoreDataChanged;

    }

}
