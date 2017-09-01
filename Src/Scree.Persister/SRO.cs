using System;
using System.Collections.Generic;
using System.Text;
using Scree.Attributes;
using Scree.Cache;
using System.Linq;
using Scree.Common;
using Scree.Log;
using Scree.Syn;

namespace Scree.Persister
{
    /// <summary>
    /// ����������Ļ��࣬һ������»���������Ӧ��ֱ�ӻ��Ӽ̳д���
    /// </summary>
    [DataTable]
    public abstract class SRO : ICacheable, ISynable
    {
        private bool IsIdSetted = false;

        /// <summary>
        /// ȫ��Ψһ��ʾ����ֻ��������һ�Σ�
        /// </summary>
        [StringDataType(StringType.NVarchar, IsNullable = false, Length = 32)]
        public string Id
        {
            get
            {
                return _id;
            }
            internal set
            {
                if (_isNew && IsIdSetted == false)
                {
                    _id = value;
                    IsIdSetted = true;
                }
            }
        }
        private string _id = Guid.NewGuid().ToString().Replace("-", "");

        public void SetId(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// ���󴴽�ʱ��
        /// </summary>
        [DataType(IsNullable = false)]
        public DateTime CreatedDate
        {
            get
            {
                return _createdDate;
            }
            internal set
            {
                _createdDate = value;
            }
        }
        private DateTime _createdDate = DateTime.Now;

        /// <summary>
        /// ��������޸�ʱ��
        /// </summary>
        [DataType(IsNullable = false)]
        public DateTime LastAlterDate
        {
            get
            {
                return _lastAlterDate;
            }
            internal set
            {
                _lastAlterDate = value;
            }
        }
        private DateTime _lastAlterDate = DateTime.Now;

        /// <summary>
        /// �汾��
        /// </summary>
        [DataType(IsNullable = false)]
        public long Version { get; internal set; }

        [DataType(IsNullable = false)]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// �����Ƿ�Ϊ�´�������
        /// </summary>
        [DataType(IsLoad = false, IsSave = false)]
        public bool IsNew
        {
            get
            {
                return _isNew;
            }
            internal set
            {
                if (!value)
                {
                    _isNew = value;
                }
            }
        }
        private bool _isNew = true;

        [DataType(IsLoad = false, IsSave = false)]
        public string CurrentAlias { get; internal set; }
        [DataType(IsLoad = false, IsSave = false)]
        public string CurrentTableName { get; internal set; }

        [DataType(IsLoad = false, IsSave = false)]
        public SROSaveMode SaveMode { get; internal set; }

        private Dictionary<string, string> StorageBehavior = new Dictionary<string, string>();
        private Dictionary<string, object> OriginalValue = new Dictionary<string, object>(29);

        internal string[] Aliases
        {
            get
            {
                return StorageBehavior.Keys.ToArray();
            }
        }
        internal string GetTableName(string alias)
        {
            string tableName = string.Empty;

            if (StorageBehavior.ContainsKey(alias == null ? string.Empty : alias.Trim()))
            {
                tableName = StorageBehavior[alias];
            }

            if (string.IsNullOrEmpty(tableName))
            {
                tableName = this.GetType().Name;
            }

            return tableName;
        }
        internal void SetOriginalValue(string name, object val)
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            OriginalValue[name] = val;
        }
        internal void Reset()
        {
            if (OriginalValue == null || OriginalValue.Count == 0)
            {
                return;
            }

            try
            {
                IMyPropertyInfo[] myPropertys = PropertyInfoProxy.GetProperties(this.GetType());
                foreach (IMyPropertyInfo property in myPropertys)
                {
                    if (property.IsLoad == false)
                    {//�ж��Ƿ����
                        continue;
                    }

                    object value = OriginalValue.ContainsKey(property.Name) ? OriginalValue[property.Name] : null;

                    property.SetValue(this, value);
                }
            }
            catch (Exception ex)
            {
                LogProxy.Error(ex, false);
            }
        }

        internal void Bestrow()
        {
            if (OriginalValue != null && OriginalValue.Count > 0)
            {
                return;
            }

            try
            {
                IMyPropertyInfo[] myPropertys = PropertyInfoProxy.GetProperties(this.GetType());
                foreach (IMyPropertyInfo property in myPropertys)
                {
                    if (property.IsLoad == false && property.IsSave == false)
                    {//�ж��Ƿ����
                        continue;
                    }
                    object value = property.GetValue(this);
                    OriginalValue[property.Name] = value;
                }
            }
            catch (Exception ex)
            {
                LogProxy.Error(ex, false);
            }
        }

        public object GetOriginalValue(string name)
        {
            if (OriginalValue.ContainsKey(name))
            {
                return OriginalValue[name];
            }

            return null;
        }
        public void RegisterStorageBehavior(string alias, string tableName)
        {
            if (alias == null)
            {
                alias = string.Empty;
            }
            else
            {
                alias = alias.Trim();
            }

            StorageBehavior[alias] = tableName == null ? null : tableName.Trim();
        }
        public void RegisterStorageBehavior(string alias)
        {
            this.RegisterStorageBehavior(alias, null);
        }

        protected internal virtual void BeforeSave() { }
        protected internal virtual void AfterSave() { }
    }

    public enum SROSaveMode
    {
        //�´���������Load
        Init = 0,
        //�´����Ķ����Ѿ���һ�γ־û�
        Insert = 1,
        //���ж�����ٴγ־û�
        Update = 2,
        //���ж���ͨ��SaveObject��ͼ�־û������Ƕ�����ҵ��������в�û�б��޸Ĺ�
        NoChange = 3,
    }
}
