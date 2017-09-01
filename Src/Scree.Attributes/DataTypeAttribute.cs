using System;

namespace Scree.Attributes
{
    /// <summary>
    /// ���������������ԣ�ָʾ�������ڴ�����Ӧ�����ֶ�ʱ������
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DataTypeAttribute : Attribute
    {
        /// <summary>
        /// �Ƿ��Ϊ��
        /// </summary>
        public bool IsNullable
        {
            get
            {
                return _isNullable;
            }
            set
            {
                _isNullable = value;
            }
        }
        private bool _isNullable = true;

        /// <summary>
        /// �Ƿ���Ҫ����ֵ
        /// </summary>
        public bool IsLoad
        {
            get
            {
                return _isLoad;
            }
            set
            {
                _isLoad = value;
            }
        }
        private bool _isLoad = true;

        /// <summary>
        /// �Ƿ���Ҫ����
        /// </summary>
        public bool IsSave
        {
            get
            {
                return _isSave;
            }
            set
            {
                _isSave = value;
            }
        }
        private bool _isSave = true;
    }
}
