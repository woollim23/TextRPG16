using System;

namespace TextRPG16
{
    class Thief : User
    {
        public Thief() // ������
        {
            UserClass = "����";
            HP = 100; // �ʱ� ü��
            DefensPower = 10; // �ʱ� ����
            AttackDamage = 15; // �ʱ� ���ݷ�

        }

    }
}