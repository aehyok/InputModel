using System;
using System.Data;

namespace SinoSZBaseClass.Authorize
{
        /// <summary>
        /// RightItem ��ժҪ˵����
        /// �û������ɫ�����߱��ĵ���Ȩ�������Χ��������������
        /// </summary>
        [Serializable()]
        public class UserRightItem
        {
                public SinoRightItem Right = null;//Ȩ����
                public decimal Level = 0;//����Χ

                public UserRightItem()
                {
                        //
                        // TODO: �ڴ˴���ӹ��캯���߼�
                        //
                }



        }

}
