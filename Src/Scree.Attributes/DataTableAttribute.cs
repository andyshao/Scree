using System;

namespace Scree.Attributes
{
    /// <summary>
    /// ���������ԣ�ָʾ�����̳��˸ýӿڵ����Ƿ���Ҫ�����ݿ��д�����Ӧ�Ĵ洢��
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
    public class DataTableAttribute : Attribute
    {

    }
}
