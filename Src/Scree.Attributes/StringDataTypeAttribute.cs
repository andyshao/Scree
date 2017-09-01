using System;

namespace Scree.Attributes
{
    /// <summary>
    /// �����������ͣ�string�����ԣ�ָʾ�������ڴ�����Ӧ�����ֶ�ʱ������
    /// </summary>    
    public class StringDataTypeAttribute : DataTypeAttribute
    {
        private int length = 32;
        private bool ismaxlength = false;
        private StringType type = StringType.NVarchar;

        /// <summary>
        /// ��ö��ѡ��NVarcharʱ�����ݿ��ֶεĳ���
        /// </summary>
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }

        /// <summary>
        /// ��ö��ѡ��NVarcharʱ�����ݿ��ֶεĳ���ΪMax����IsMaxLength=true��ͬʱ����Length������IsMaxLengthΪ׼
        /// </summary>
        public bool IsMaxLength
        {
            get
            {
                return ismaxlength;
            }
            set
            {
                ismaxlength = value;
            }
        }

        /// <summary>
        /// string���͵�����ӳ��Ϊ���ݿ��ֶε�����
        /// </summary>
        public StringType Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// �����������ͣ�string�����ԣ�ָʾ�������ڴ�����Ӧ�����ֶ�ʱ������
        /// </summary>
        /// <param name="type">string���͵�����ӳ��Ϊ���ݿ��ֶε�����</param>
        public StringDataTypeAttribute(StringType type)
        {
            this.type = type;
        }

        /// <summary>
        /// �����������ͣ�string�����ԣ�ָʾ�������ڴ�����Ӧ�����ֶ�ʱ������
        /// </summary>
        public StringDataTypeAttribute()
        {

        }
    }
}
