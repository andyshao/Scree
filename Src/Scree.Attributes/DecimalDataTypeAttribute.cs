using System;
using Scree.Log;

namespace Scree.Attributes
{
    /// <summary>
    /// �����������ͣ�decimal�����ԣ�ָʾ�������ڴ�����Ӧ�����ֶ�ʱ������
    /// </summary>    
    public class DecimalDataTypeAttribute : DataTypeAttribute
    {
        private const string PRECISIONERROR = "Precision must be between 1 and 38";
        private const string DECIMALDIGITSERROR = "Decimal Digits must be less than or equal to precision between 0 and 38";

        private int precision = 18;
        private int decimaldigits = 4;

        /// <summary>
        /// ����
        /// </summary>
        public int Precision
        {
            get
            {
                return precision;
            }
        }

        /// <summary>
        /// С��λ��
        /// </summary>
        public int DecimalDigits
        {
            get
            {
                return decimaldigits;
            }
        }

        /// <summary>
        /// �����������ͣ�decimal�����ԣ�ָʾ�������ڴ�����Ӧ�����ֶ�ʱ������
        /// </summary>
        /// <param name="precision">���ȣ�1-38֮�䣩</param>
        /// <param name="decimalDigits">С��λ����0-38֮�䣩�ұ���С�ڻ���ھ���</param>
        public DecimalDataTypeAttribute(int precision, int decimalDigits)
        {
            if (precision < 1 || precision > 38)
            {
                LogProxy.Fatal(PRECISIONERROR, true);
            }
            if (decimalDigits < 0 || decimalDigits > precision)
            {
                LogProxy.Fatal(DECIMALDIGITSERROR, true);
            }

            this.precision = precision;
            this.decimaldigits = decimalDigits;
        }

        /// <summary>
        /// �����������ͣ�decimal�����ԣ�ָʾ�������ڴ�����Ӧ�����ֶ�ʱ������
        /// </summary>
        public DecimalDataTypeAttribute()
        {

        }
    }
}
