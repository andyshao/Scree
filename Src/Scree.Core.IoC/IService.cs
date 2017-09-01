using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Scree.Log;
 
namespace Scree.Core.IoC
{
    /// <summary>
    /// ���з�������
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Ԥ���������ڲ����񣬹������л��������ڲ����ã�
        /// </summary>
        bool Init();

        bool IsInitialized { get; }

        bool Run();
        bool IsRunned { get; }

    }
}
