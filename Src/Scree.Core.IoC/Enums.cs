using System;
using System.Collections.Generic;
using System.Text;

namespace Scree.Core.IoC
{
    /// <summary>
    /// Ӧ�ó�������״̬
    /// </summary>
    public enum InitStatus
    {
        /// <summary>
        /// δ����
        /// </summary>
        None = 0,

        /// <summary>
        /// ������
        /// </summary>
        Initing = 1,

        /// <summary>
        /// �������
        /// </summary>
        Complete = 2,

        /// <summary>
        /// ����ʧ��
        /// </summary>
        Fail = 3
    }

}
