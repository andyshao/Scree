using System;
using System.Collections.Generic;
using System.Text;

namespace Winal.Core
{
    /// <summary>
    /// ���з���Ļ������
    /// </summary>
    public interface IServiceBase
    {
        /// <summary>
        /// ���ӷ���
        /// </summary>
        /// <param name="serviceType">��������</param>
        /// <param name="serviceInstance">����ʵ��</param>
        void AddService(Type serviceType, object serviceInstance);

        /// <summary>
        /// �Ƴ�����
        /// </summary>
        /// <param name="serviceType">��������</param>
        void RemoveService(Type serviceType);

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="serviceType">��������</param>
        /// <param name="throwException">�Ƿ��׳��쳣</param>
        /// <returns></returns>
        object GetService(Type serviceType, bool throwException);

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="serviceType">�������ͣ����׳��쳣</param>
        object GetService(Type serviceType);

        /// <summary>
        /// �����Ƿ����
        /// </summary>
        /// <param name="serviceType">��������</param>
        /// <returns></returns>
        bool ExistService(Type serviceType);

        /// <summary>
        /// �滻����
        /// </summary>
        /// <param name="serviceType">��������</param>
        /// <param name="newInstance">�·���ʵ��</param>
        /// <param name="isThrowOut">�Ƿ��׳��쳣</param>
        void ReplaceService(Type serviceType, object newInstance, bool isThrowOut);

        /// <summary>
        /// �滻����
        /// </summary>
        /// <param name="serviceType">��������</param>
        /// <param name="newInstance">�·���ʵ�������׳��쳣</param>
        void ReplaceService(Type serviceType, object newInstance);

    }
}
